#pragma once

#include <iostream>
#include <cmath>

using namespace std;

class Fraction
{
public:
	Fraction();

	void setNumber(int n);
	void setDenom(int d);

	int getNumber() const;
	int getDenom() const;

	friend int getDenom(const Fraction& amount1, const Fraction& amount2);

	friend const Fraction operator +(const Fraction& amount1, const Fraction& amount2);
	friend const Fraction operator -(const Fraction& amount1, const Fraction& amount2);
	friend const Fraction operator *(const Fraction& amount1, const Fraction& amount2);
	friend const Fraction operator /(const Fraction& amount1, const Fraction& amount2);
	friend ostream& operator <<(ostream& outputStream, const Fraction& f);

private:
	int number;
	int denom;
};