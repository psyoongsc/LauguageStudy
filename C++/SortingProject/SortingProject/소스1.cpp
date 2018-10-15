#include <iostream>

using namespace std;

int main(void) {
	int cnt;
	int data[1000] = { 0, };

	scanf_s("%d", &cnt);

	for (int i = 0; i < cnt; i++) {
		scanf_s("%d", &data[i]);
	}

	int i = 0, j, temp;
	while (i < cnt) {
		j = i;
		while (j < cnt) {
			if (data[j] < data[i]) {
				temp = data[i];
				data[i] = data[j];
				data[j] = temp;
			}
			j++;
		}
		printf("%d\n", data[i]);
		i++;
	}


}