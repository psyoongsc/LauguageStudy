package InsertionSort;

public class InsertionSort { //시간복잡도 O(N^2)

	public static void main(String[] args) {
		int i, j, temp;
		int[] array = { 1, 10, 4, 5, 2, 7, 9, 6, 3, 8 };
		
		for(i=1; i<10; i++) {
			temp=array[i];
			for(j=i-1; j>=0; j--) {
				if (temp < array[j]) {
					array[j+1]=array[j];
					continue;
				}
				array[j+1] = temp;
				break;
			}
		}
		
		for(i=0; i<10; i++) {
			System.out.printf("%d ", array[i]);
		}
	}

}
