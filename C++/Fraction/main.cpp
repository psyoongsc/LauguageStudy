#include "Fraction.h"

int readNumberDenom(int &n, int &d)
{
	cout << "분자값을 입력하세요 (종료하려면 0): ";
	cin >> n;
	if (n == 0)
		return 0;

	do
	{
		cout << "0이 아닌 분모값을 입력하세요: ";
		cin >> d;
	} while (d == 0);

	return 1;
}

int main()
{
	int n, d;
	Fraction f1, f2;

	while (1)
	{
		cout << "첫번째 분수의 정보를 입력하세요" << endl;
		if (readNumberDenom(n, d) == 0)
			break;
		f1.setNumber(n);
		f1.setDenom(d);

		cout << "두번째 분수의 정보를 입력하세요" << endl;
		readNumberDenom(n, d);
		f2.setNumber(n);
		f2.setDenom(d);

		cout << "입력된 값은 " << f1 << "과 " << f2 << endl << endl;

		cout << f1 << " + " << f2 << " = " << f1 + f2 << endl;
		cout << f1 << " - " << f2 << " = " << f1 - f2 << endl;
		cout << f1 << " * " << f2 << " = " << f1 * f2 << endl;
		cout << f1 << " / " << f2 << " = " << f1 / f2 << endl;
	}
}