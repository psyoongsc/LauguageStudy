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
		
		while (i <= j) { // ������ ������ �ݺ�
			while(array[i] <= array[fibot] && i <= end) // Ű ������ ū ���� ���� ������ �ݺ�
				i++;
			while(array[j] >= array[fibot] && j > start) // Ű ������ ���� ���� ���� ������ �ݺ�
				j--;
			
			if(i > j) { // ������ ���¸� �Ǻ����� ���� ���� ��ü
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
