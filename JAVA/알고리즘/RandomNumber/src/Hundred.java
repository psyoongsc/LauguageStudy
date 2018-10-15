import java.util.Random;

public class Hundred {

	public static void main(String[] args) {
		int RandNum = 0, cnt=0;
		boolean[] used = new boolean[1000];
		StringBuilder sb = new StringBuilder();
		
		Random generateRanNum = new Random();
		for (int i=0; i<1000; i++) {
			
				while(true) {
				RandNum = generateRanNum.nextInt(1000);
				
				if(!used[RandNum]) {
					sb.append(RandNum+1 + ", ");
					used[RandNum] = true;
					System.out.println(++cnt);
					break;
				}
					
			}
		}
		System.out.println(sb.toString());
	}

}
