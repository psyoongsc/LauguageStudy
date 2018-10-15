package QuickSort; // java can't run this code(c++ code)

public class QuickSort2 {
	static int[] array = { 4, 7, 8, 1, 10, 6, 9, 2, 3, 5 };
	
	static void sort(int[] array, int start, int end) {
		if (start >= end)
			return;
		
		int fibot = start;
		int i = start+1;
		int j = end;
		int temp;
		
		while (i <= j) { // 엇갈릴 때까지 반복
			while(array[i] <= array[fibot] && i <= end) // 키 값보다 큰 값을 만날 때까지 반복
				i++;
			while(array[j] >= array[fibot] && j > start) // 키 값보다 작은 값을 만날 때까지 반복
				j--;
			
			if(i > j) { // 엇갈린 상태면 피봇값과 작은 값을 교체
				temp = array[j];
				array[j] = array[fibot];
				array[fibot] = temp;
			} else {
				temp = array[j];
				array[j] = array[i];
				array[i] = temp;
			}
		}
		
		sort(array, start, j-1);
		sort(array, j+1, end);
	}

	public static void main(String[] args) {
		sort(array, 0, 9);
		
		for(int i=0; i<10; i++)
			System.out.printf("%d ", array[i]);
	}

}
