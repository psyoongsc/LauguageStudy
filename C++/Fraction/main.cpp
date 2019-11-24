#include "Fraction.h"

int readNumberDenom(int &n, int &d)
{
	cout << "���ڰ��� �Է��ϼ��� (�����Ϸ��� 0): ";
	cin >> n;
	if (n == 0)
		return 0;

	do
	{
		cout << "0�� �ƴ� �и��� �Է��ϼ���: ";
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
		cout << "ù��° �м��� ������ �Է��ϼ���" << endl;
		if (readNumberDenom(n, d) == 0)
			break;
		f1.setNumber(n);
		f1.setDenom(d);

		cout << "�ι�° �м��� ������ �Է��ϼ���" << endl;
		readNumberDenom(n, d);
		f2.setNumber(n);
		f2.setDenom(d);

		cout << "�Էµ� ���� " << f1 << "�� " << f2 << endl << endl;

		cout << f1 << " + " << f2 << " = " << f1 + f2 << endl;
		cout << f1 << " - " << f2 << " = " << f1 - f2 << endl;
		cout << f1 << " * " << f2 << " = " << f1 * f2 << endl;
		cout << f1 << " / " << f2 << " = " << f1 / f2 << endl;
	}
}