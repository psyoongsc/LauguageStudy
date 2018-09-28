package jNetPcap1;

import java.util.ArrayList;
import java.util.Date;

import org.jnetpcap.Pcap;
import org.jnetpcap.PcapIf;
import org.jnetpcap.packet.PcapPacket;
import org.jnetpcap.packet.PcapPacketHandler;

public class Main {

	public static void main(String[] args) {

		ArrayList<PcapIf> allDevs = new ArrayList<PcapIf>();
		StringBuilder errbuf = new StringBuilder();
		
		int r = Pcap.findAllDevs(allDevs, errbuf);
		if(r == Pcap.NOT_OK || allDevs.isEmpty()) {
			System.out.println("네트워크 장치를 찾을 수 없습니다. " + errbuf.toString());
			return;
		}
		
		System.out.println("[ 네트워크 장비 탐색 성공 ]");
		int i = 0;
		for (PcapIf device : allDevs) {
			String description = (device.getDescription() != null) ?
					device.getDescription() : "장비에 대한 설명이 없습니다.";
			System.out.printf("[%d번]: %s [%s]\n", i++, device.getName(), description);
		}
		
		//\Device\NPF_{9BB39F71-5568-4B5C-B633-00F51625F4DC} [Microsoft]
		PcapIf device = allDevs.get(2);
		System.out.printf("선택한 장치: %s\n", (device.getDescription() != null) ?
				device.getDescription() : device.getName());
		
		int snaplen = 64 * 1024;
		int flags = Pcap.MODE_PROMISCUOUS;
		int timeout = 1;
		
		Pcap pcap = Pcap.openLive(device.getName(), snaplen, flags, timeout, errbuf);
		
		if (pcap == null) {
			System.out.printf("패킷 캡처를 위해 네트워크 장치를 여는 데에 실패하였습니다. 오류: " 
					+ errbuf.toString());
			return;
		}
		
		PcapPacketHandler<String> jPacketHandler = new PcapPacketHandler<String>() {
			@Override
			public void nextPacket(PcapPacket packet, String user) {
				System.out.printf("캡처 시각: %s\n패킷의 길이: %-4d\n",
						new Date(packet.getCaptureHeader().timestampInMillis()),
						packet.getCaptureHeader().caplen());
			}
		};
		
		pcap.loop(10, jPacketHandler, "jNetPcap");
		pcap.close();
		
	}

}
