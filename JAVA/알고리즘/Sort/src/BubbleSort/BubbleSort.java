package BubbleSort;

public class BubbleSort { //시간복잡도 O(N^2)

	public static void main(String[] args) {
		int temp;
		int[] array = { 1, 10, 4, 5, 2, 7, 9, 6, 3, 8 };
		
		for(int i=0; i<10; i++) {
			for (int j=0; j<9-i; j++) {
				if (array[j] > array[j+1]) {
					temp = array[j];
					array[j] = array[j+1];
					array[j+1] = temp;
				}
			}
		}
		
		for (int i=0; i<10; i++) {
			System.out.printf("%d ", array[i]);
		}
	}

}
