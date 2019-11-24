#pragma once

#include <iostream>
#include <string.h>
#include <time.h> // 생성자 호출시에만 사용

using namespace std;

class Day
{
public:
	Day(); // 생성자 / 프로그램을 실행한 날짜로 초기화
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
									 // 1) ~ 2) 함수는 operator << 에서 사용한다.
									 // 3) ~ 5) 함수는 operator >> 에서 사용한다.

	friend ostream& operator <<(ostream& outputStream, const Day& d); // 현재날짜(이동된 날짜)와 D-Day 연산결과를 출력
	friend istream& operator >>(istream& outputStream, Day& d); // 3가지 유형의 input에 유동적으로 반응하는 interface 제공
private:
	int year;
	int month;
	int day;
	int dday;
};