#include <iostream>

int data[10] = { 4, 7, 8, 1, 10, 6, 9, 2, 3, 5 };
int tmp[10] = { 0, };

void view() {
	for (int i = 0; i < 10; i++) {
		printf("%d ", data[i]);
	}
	printf("\n");
}

void MergeSort(int* data, int start, int end) {

	if (start == end) { // 원소가 하나이면 정렬 된 것으로 생각한다
		printf("returned\n");
		return;
	}
	printf("is in!\n");

	//int cutting = start + (((end - start) + 1) / 2); // 원소가 하나가 아니면 재귀함수로 나눈다.
	int cutting = (end + start) / 2;

	MergeSort(data, start, cutting); // 재귀 1
	MergeSort(data, cutting + 1, end); // 재귀 2

	int temp = start;
	int i = start, j = cutting + 1;
	while (temp <= end) { // 정렬 된 원소를 한바퀴 돈다
		if (data[i] <= data[j] && i <= cutting && j <= end) { // 전자값이 후자값 이하이면 전자값을 tmp에 올린다.
			tmp[temp] = data[i++];
		}
		else if (data[j] <= data[i] && i <= cutting && j <= end) { // 후자값이 전자값 이하이면 후자값을 tmp에 올린다.
			tmp[temp] = data[j++];
		}
		else { // i나 j가 끝남
			if (i > cutting) { // i가 끝났다면 j값을 tmp에 올린다
				tmp[temp] = data[j++];
			}
			else { // j가 끝났다면 i값을 tmp에 올린다.
				tmp[temp] = data[i++];
			}
		}
		temp++;
	}

	for (int i = start; i <= end; i++) { // data값을 tmp값으로 교체
		data[i] = tmp[i];
	}
	return;
}

int main(void) {
	//QuickSort(data, 0, 9);
	MergeSort(data, 0, 9);
	view();

	system("pause");
	return 0;
}