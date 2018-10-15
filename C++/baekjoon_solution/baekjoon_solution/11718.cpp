#include <iostream>
#include <string>

using namespace std;

int main(void) {
	int cnt = 0;
	string cpps;
	while (cnt < 100) {
		getline(cin, cpps);

		cout << cpps << endl;

		cnt++;
	}

	return 0;
}