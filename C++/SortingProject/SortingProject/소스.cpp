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

	if (start == end) { // ���Ұ� �ϳ��̸� ���� �� ������ �����Ѵ�
		printf("returned\n");
		return;
	}
	printf("is in!\n");

	//int cutting = start + (((end - start) + 1) / 2); // ���Ұ� �ϳ��� �ƴϸ� ����Լ��� ������.
	int cutting = (end + start) / 2;

	MergeSort(data, start, cutting); // ��� 1
	MergeSort(data, cutting + 1, end); // ��� 2

	int temp = start;
	int i = start, j = cutting + 1;
	while (temp <= end) { // ���� �� ���Ҹ� �ѹ��� ����
		if (data[i] <= data[j] && i <= cutting && j <= end) { // ���ڰ��� ���ڰ� �����̸� ���ڰ��� tmp�� �ø���.
			tmp[temp] = data[i++];
		}
		else if (data[j] <= data[i] && i <= cutting && j <= end) { // ���ڰ��� ���ڰ� �����̸� ���ڰ��� tmp�� �ø���.
			tmp[temp] = data[j++];
		}
		else { // i�� j�� ����
			if (i > cutting) { // i�� �����ٸ� j���� tmp�� �ø���
				tmp[temp] = data[j++];
			}
			else { // j�� �����ٸ� i���� tmp�� �ø���.
				tmp[temp] = data[i++];
			}
		}
		temp++;
	}

	for (int i = start; i <= end; i++) { // data���� tmp������ ��ü
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