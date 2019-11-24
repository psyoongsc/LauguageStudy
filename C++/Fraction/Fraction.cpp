#include "Fraction.h"

Fraction::Fraction() { number = 0; denom = 0; }
void Fraction::setNumber(int n) { number = n; }
void Fraction::setDenom(int d) { denom = d; }
int Fraction::getNumber() const { return number; }
int Fraction::getDenom() const { return denom; }

int getDenom(const Fraction& amount1, const Fraction& amount2)
{ //통분함수
	if (amount1.denom % amount2.denom == 0) //첫번째 인자가 두번째 인자의 배수 or 두 인자값이 같음
		return amount1.denom;
	else if (amount2.denom % amount1.denom == 0) //첫번째 인자가 두번째 인자의 배수
		return amount2.denom;
	else
		return amount1.denom * amount2.denom;
}

const Fraction operator +(const Fraction& amount1, const Fraction& amount2)
{
	Fraction result;
	int resultNum1, resultNum2;

	result.setDenom(getDenom(amount1, amount2));
	resultNum1 = (result.getDenom() / amount1.denom) * amount1.number;
	resultNum2 = (result.getDenom() / amount2.denom) * amount2.number;
	result.setNumber(resultNum1 + resultNum2);

	return result;
}
const Fraction operator -(const Fraction& amount1, const Fraction& amount2)
{
	Fraction result;
	int resultNum1, resultNum2;

	result.setDenom(getDenom(amount1, amount2));
	resultNum1 = (result.getDenom() / amount1.denom) * amount1.number;
	resultNum2 = (result.getDenom() / amount2.denom) * amount2.number;
	result.setNumber(resultNum1 - resultNum2);

	return result;
}
const Fraction operator *(const Fraction& amount1, const Fraction& amount2)
{
	Fraction result;
	result.setDenom(amount1.denom * amount2.denom);
	result.setNumber(amount1.number * amount2.number);

	return result;
}
const Fraction operator /(const Fraction& amount1, const Fraction& amount2)
{
	Fraction result;
	result.setDenom(amount1.denom*amount2.number);
	result.setNumber(amount1.number*amount2.denom);

	return result;
}
ostream& operator <<(ostream& outputStream, const Fraction& f)
{
	int GCF = 1; // Greatest Common Factor(최대공약수)

				 //최대공약수 구하기
	for (int i = 2; i <= abs(f.denom) && i <= abs(f.number); i++)
		if (abs(f.denom) % i == 0 && abs(f.number) % i == 0)
			GCF = i;

	if (abs(f.denom / GCF) == 1)
		outputStream << f.number*f.denom / pow(GCF, 2);
	else
		if (f.denom < 0)
			outputStream << f.number*-1 / GCF << "/" << f.denom*-1 / GCF;
		else
			outputStream << f.number / GCF << "/" << f.denom / GCF;

	return outputStream;
}