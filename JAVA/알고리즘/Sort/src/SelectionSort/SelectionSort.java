package SelectionSort;

public class SelectionSort { //시간복잡도 O(N^2)

	public static void main(String[] args) {
		int index=0, temp;
		int[] array = { 1, 10, 4, 5, 2, 7, 9, 6, 3, 8 };
		
		for(int i=0; i<10; i++) {
			int min=Integer.MAX_VALUE;
			for (int j=i; j<10; j++) {
				if(min > array[j]) {
					min = array[j];
					index = j;
				}
			}
			temp = array[index];
			array[index]=array[i];
			array[i] = temp;
		}
		
		for(int i=0; i<10; i++) {
			System.out.printf("%d ", array[i]);
		}
	}

}
