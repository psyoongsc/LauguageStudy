#include <iostream>
#include <math.h>
using namespace std;

bool notSelfNumber[10001] = {};

int checkSelfNum(int number) {
	int focus = 1;
	int checking;
	int point;
	int origin;

	if (notSelfNumber[number])
		goto end;

	while (number < 10001) {
		if (number == (int)pow(10, focus)) {
			focus++;
		}

		origin = number;
		checking = number;

		for (int i = focus; i > 0; i--) {
			checking += origin / (int)pow(10, i);
			origin = origin % (int)pow(10, i);
		}
		checking += origin % 10;

		if (checking < 10001) {
			notSelfNumber[checking] = true;
			checkSelfNum(checking);
		}
		number++;
	}

	end:
	return 0;
}

int main(void) {
	for (int i = 1; i < 10001; i++) {
		checkSelfNum(i);
	}

	for (int i = 1; i < 10001; i++) {
		checkSelfNum(i);
		if (notSelfNumber[i])
			printf("%d\n", i);
	}

	return 0;
}