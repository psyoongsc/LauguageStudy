#include <iostream>

using namespace std;
static bool checked[5000] = {};
static int DFS[5000] = { 0, };

int deliver(int sugar) {
	if (sugar < 0) return -1;
	else if (sugar == 0) return 0;

	int three, five;

	if (checked[sugar - 3])
		three = DFS[sugar - 3];
	else {
		three = deliver(sugar - 3);
		checked[sugar - 3] = true;
		DFS[sugar - 3] = three;
	}
	if (checked[sugar - 5])
		five = DFS[sugar - 5];
	else {
		five = deliver(sugar - 5);
		checked[sugar - 5] = true;
		DFS[sugar - 5] = five;
	}

	if (five == -1) {
		if (three == -1)
			return -1;
		else
			return ++three;
	}
	else if (three == -1) {
		if (five == -1)
			return -1;
		else
			return ++five;
	}
	else {
		return three <= five ? ++three : ++five;
	}
}

int main(void) {
	int sugar;
	cin >> sugar;
	printf("%d", deliver(sugar));
}