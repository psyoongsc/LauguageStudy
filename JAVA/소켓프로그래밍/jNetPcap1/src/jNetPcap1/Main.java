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
			System.out.println("��Ʈ��ũ ��ġ�� ã�� �� �����ϴ�. " + errbuf.toString());
			return;
		}
		
		System.out.println("[ ��Ʈ��ũ ��� Ž�� ���� ]");
		int i = 0;
		for (PcapIf device : allDevs) {
			String description = (device.getDescription() != null) ?
					device.getDescription() : "��� ���� ������ �����ϴ�.";
			System.out.printf("[%d��]: %s [%s]\n", i++, device.getName(), description);
		}
		
		//\Device\NPF_{9BB39F71-5568-4B5C-B633-00F51625F4DC} [Microsoft]
		PcapIf device = allDevs.get(2);
		System.out.printf("������ ��ġ: %s\n", (device.getDescription() != null) ?
				device.getDescription() : device.getName());
		
		int snaplen = 64 * 1024;
		int flags = Pcap.MODE_PROMISCUOUS;
		int timeout = 1;
		
		Pcap pcap = Pcap.openLive(device.getName(), snaplen, flags, timeout, errbuf);
		
		if (pcap == null) {
			System.out.printf("��Ŷ ĸó�� ���� ��Ʈ��ũ ��ġ�� ���� ���� �����Ͽ����ϴ�. ����: " 
					+ errbuf.toString());
			return;
		}
		
		PcapPacketHandler<String> jPacketHandler = new PcapPacketHandler<String>() {
			@Override
			public void nextPacket(PcapPacket packet, String user) {
				System.out.printf("ĸó �ð�: %s\n��Ŷ�� ����: %-4d\n",
						new Date(packet.getCaptureHeader().timestampInMillis()),
						packet.getCaptureHeader().caplen());
			}
		};
		
		pcap.loop(10, jPacketHandler, "jNetPcap");
		pcap.close();
		
	}

}
