package QuickSort;

public class QuickSort { // 시간복잡도 O(N*log2 N)
	static int[] array = { 3, 7, 8, 1, 5, 9, 6, 10, 2, 4 };
	//static int[] array = { 4, 7, 8, 1, 10, 6, 9, 2, 3, 5 };
	//static int[] array = { 1, 10, 4, 5, 2, 7, 9, 6, 3, 8 };
	
	static void view() {
		for(int i=0; i<10; i++) {
			System.out.printf("%d ", array[i]);
		}
		System.out.println();
	}
	
	static void sort(int fibot_index, int end_index) {
		if(fibot_index==9) {
			return;
		}
		int bigger_index=fibot_index, smaller_index=fibot_index, temp;
		int fibot = array[fibot_index];
		
		while (true){
			for(int i=fibot_index+1; i<=end_index; i++) { // find first bigger index of number
				if(fibot < array[i]) {
					bigger_index = i;
					break;
				}
			}
			for(int i=end_index; i>fibot_index; i--) { //find first smaller index of number
				if(fibot > array[i]) {
					smaller_index = i;
					break;
				}
			}
			
			if (bigger_index==fibot_index) { // only smaller number detected
				temp = array[fibot_index];
				array[fibot_index] = array[smaller_index];
				array[smaller_index] = temp;
				
				sort(fibot_index, end_index); // recursion
				break; // method stop
			}
			else if (smaller_index==fibot_index) { // only bigger number detected
	
				sort(smaller_index+1, end_index); // recursion 2
				break; // method stop
			}
			
			if(bigger_index < smaller_index) { // change number
				temp = array[bigger_index];
				array[bigger_index] = array[smaller_index];
				array[smaller_index] = temp;
			} else {							// cross index detected
				temp = array[smaller_index];
				array[smaller_index] = array[fibot_index];
				array[fibot_index]= temp;
				
				sort(fibot_index, end_index);
				break; // method stop
			}
		}
	}

	public static void main(String[] args) {
		view();
		sort(0, 9);
		view();
		
	}

}
