#include "Day.h"

/*
January 31; February 28; LeapFrebruary 29; March 31;
April 30; May 31; June 30; July 31; August 31;
September 30; October 31; November 30; December 31;
*/

Day::Day()
{
	time_t timer;
	struct tm *t;

	timer = time(NULL);

	t = localtime(&timer);

	year = t->tm_year + 1900;
	month = t->tm_mon + 1;
	day = t->tm_mday;
	dday = 0;
}

int Day::howManyDays()
{
	switch (month)
	{
	case 1:
	case 3:
	case 5:
	case 7:
	case 8:
	case 10:
	case 12:
		return 31;
	case 4:
	case 6:
	case 9:
	case 11:
		return 30;
	case 2: //년도가 4라 나누어 떨어지면 윤년, 하지만 100으로 나누어 떨어지면 평년, 그 중에서도 400으로 나누어 떨어지면 윤년
		if (year % 4 == 0)
		{
			if (year % 100 == 0)
			{
				if (year % 400 == 0)
				{
					return 29;
				}
				else {
					return 28;
				}
			}
			else {
				return 29;
			}
		}
		else {
			return 28;
		}
	}
}

int Day::getYear() const { return year; }
int Day::getMonth() const { return month; }
int Day::getDay() const { return day; }

void Day::setYear(int y) { year = y; }
void Day::setMonth(int m) { month = m; }
void Day::setDay(int d) { day = d; }

const Day operator +(const Day& date, int day)
{
	Day result;

	result.year = date.year;
	result.month = date.month;
	result.day = date.day + day;


	while (result.howManyDays() < result.day)
	{
		result.day -= result.howManyDays();
		result.month++;

		if (result.month > 12)
		{
			result.year++;
			result.month = 1;
		}
	}

	return result;
}
const Day operator -(const Day& date, int day)
{
	Day result;

	result.year = date.year;
	result.month = date.month;
	result.day = date.day - day;

	while (result.day < 0)
	{
		result.month--;
		if (result.month < 1)
		{
			result.year--;
			result.month = 12;
		}
		result.day += result.howManyDays();
	}

	return result;
}
const Day& Day::operator ++()
{
	day++;
	if (this->howManyDays() < day)
	{
		month++;
		day = 1;
	}
	if (month == 13)
	{
		year++;
		month = 1;
	}

	return *this;
}
const Day& Day::operator --()
{
	day--;
	if (day == 0)
	{
		month--;
		if (month == 0)
		{
			year--;
			month = 12;
		}
		day = this->howManyDays();
	}

	return *this;
}
void Day::moveDate(const char* date)
{
	int tmp = atoi(date);

	year = tmp / 10000; tmp %= 10000;
	month = tmp / 100; tmp %= 100;
	day = tmp;

	while (month > 12)
	{
		month -= 12;
		year++;
	}
	while (day > this->howManyDays())
	{
		day -= this->howManyDays();
		if (++month == 13)
		{
			year++;
			month = 1;
		}
	}
}

ostream& operator <<(ostream& outputStream, const Day& d)
{
	Day dd;
	outputStream << "[현재 날짜] " << d.year << "년 " << d.month << "월 " << d.day << "일 ";

	if (d.dday == 0)
		outputStream << "[D-day 없음] ";
	else
	{
		outputStream << "[D";
		if (d.dday > 0)
			outputStream << "+";
		outputStream << d.dday << "] ";

		if (d.dday > 0)
			dd = d + d.dday;
		else
			dd = d - abs(d.dday);

		outputStream << dd.year << "년 " << dd.month << "월 " << dd.day << "일";
	}

	return outputStream;
}
istream& operator >>(istream& inputStream, Day& d)
{
	string integer;
	char input;
	char sign;

	cout << "날짜 이동(년월일, (다음날)+, (전날)-), D-day 계산(+/- 날짜), 종료(Q) : ";

	inputStream >> input;

	if (input == 'Q' || input == 'q')
		exit(0);

	if (input == '+' || input == '-')
	{
		sign = input;
		inputStream.get(input);

		while (isdigit(input)) // 0-9 인 숫자만 받아들인다
		{
			integer += input;
			inputStream.get(input);
		}
		if (integer != "")
		{
			d.dday = atoi(integer.c_str());
			if (sign == '-')
				d.dday *= -1;
		}
		else
		{
			if (sign == '+')
				++d;
			else
				--d;
		}
	}
	else if (!isdigit(input))
		exit(0);
	else
	{
		while (isdigit(input))
		{
			integer += input;
			inputStream.get(input);
		}

		if (integer.length() == 8)
			d.moveDate(integer.c_str());
		// yyyymmdd 의 입력이 아니면 skip
	}

	return inputStream;
}