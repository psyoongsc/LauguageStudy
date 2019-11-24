#pragma once

#include <iostream>
#include <string.h>
#include <time.h> // ������ ȣ��ÿ��� ���

using namespace std;

class Day
{
public:
	Day(); // ������ / ���α׷��� ������ ��¥�� �ʱ�ȭ
	int howManyDays();

	int getYear() const;
	int getMonth() const;
	int getDay() const;

	void setYear(int y);
	void setMonth(int m);
	void setDay(int d);

	friend const Day operator +(const Day& date, int day); // 1)
	friend const Day operator -(const Day& date, int day); // 2)
	const Day& operator ++(); // 3)
	const Day& operator --(); // 4)
	void moveDate(const char* date); // 5)
									 // 1) ~ 2) �Լ��� operator << ���� ����Ѵ�.
									 // 3) ~ 5) �Լ��� operator >> ���� ����Ѵ�.

	friend ostream& operator <<(ostream& outputStream, const Day& d); // ���糯¥(�̵��� ��¥)�� D-Day �������� ���
	friend istream& operator >>(istream& outputStream, Day& d); // 3���� ������ input�� ���������� �����ϴ� interface ����
private:
	int year;
	int month;
	int day;
	int dday;
};