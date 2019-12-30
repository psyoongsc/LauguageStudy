#include "MyString.h"

void MyString::resize(int size)
{
	char *temp = str;
	str = new char[size];
	capacity = size;

	for (int i = 0; i <= pos; i++)
		str[i] = temp[i];

	delete[] temp;
	temp = NULL;
}

MyString::MyString()
{
	capacity = 10;
	pos = 0;
	str = new char[capacity];
	str[pos] = '\0';
}
MyString::MyString(const MyString& ms)
{
	capacity = ms.length() + 1;
	pos = capacity - 1;
	str = new char[capacity];
	*this = ms;

	str[pos] = '\0';
}
MyString::MyString(const char *s)
{
	capacity = strlen(s) + 1;
	pos = capacity - 1;
	str = new char[capacity];
	for (int i = 0; i < pos; i++)
		str[i] = s[i];

	str[pos] = '\0';
}
MyString::~MyString()
{
	delete[] str;
	str = NULL;
}

int MyString::length() const
{
	return pos;
}
char MyString::at(int i) const
{
	if (i >= 0 && i < pos)
	{
		return str[i];
	}
}
const MyString MyString::substr(int firstPos, int lastPos) const
{
	MyString sub;

	if (firstPos > lastPos || 0 > firstPos || pos <= firstPos || pos <= lastPos)
		return sub;

	if (firstPos >= 0 && lastPos < pos)
	{
		for (int i = firstPos; i <= lastPos; i++)
		{
			sub += str[i];
		}
	}

	return sub;
}
void MyString::insert(int iPos, const MyString &ms)
{
	if (iPos < 0 || iPos >= pos)
		return;

	capacity = pos + ms.length() + 1;
	char *temp = new char[capacity];

	int j = 0, k = 0;
	for (int i = 0; i < capacity - 1; i++)
	{
		if (i < iPos)
			temp[i] = str[j++];
		else if (i < iPos + ms.length())
			temp[i] = ms.at(k++);
		else
			temp[i] = str[j++];
	}
	pos += ms.length();
	temp[pos] = '\0';

	delete[] str;
	str = temp;
	temp = NULL;
}
void MyString::insert(int iPos, const char* s)
{
	if (iPos < 0 || iPos >= pos)
		return;

	capacity = pos + strlen(s) + 1;
	char *temp = str;
	str = new char[capacity];

	int j = 0, k = 0;
	for (int i = 0; i < capacity - 1; i++)
	{
		if (i < iPos)
			str[i] = temp[j++];
		else if (i < iPos + strlen(s))
			str[i] = s[k++];
		else
			str[i] = temp[j++];
	}
	pos += strlen(s);
	str[pos] = '\0';

	delete[] temp;
	temp = NULL;
}
void MyString::erase(int firstPos, int lastPos)
{
	if (firstPos > lastPos || 0 > firstPos || pos <= firstPos || pos <= lastPos)
		return;

	char *temp = str;
	str = new char[capacity];

	int i = 0;
	for (int j = 0; j < firstPos; j++)
		str[i++] = temp[j];
	for (int j = lastPos + 1; j < pos; j++)
		str[i++] = temp[j];

	pos -= lastPos - firstPos + 1;
	str[pos] = '\0';

	delete[] temp;
	temp = NULL;
}
int MyString::find(const char *s, int iPos) const
{
	for (int i = iPos; i < pos; i++) {
		if (str[i] == s[0]) {
			for (int j = 0; j < strlen(s); j++) {
				if (str[i + j] != s[j])
					break;
				else if (j == strlen(s) - 1 && str[i + j] == s[j])
					return i;
			}
		}
	}

	return -1;
}
int MyString::find(const MyString &ms, int iPos) const
{
	for (int i = iPos; i < pos; i++) {
		if (str[i] == ms.at(0)) {
			for (int j = 0; j < ms.length(); j++) {
				if (str[i + j] != ms.at(j))
					break;
				else if (j == ms.length() - 1 && str[i + j] == ms.at(j))
					return i;
			}
		}
	}

	return -1;
}

const char* MyString::data() const
{
	return str;
}

bool getline(istream& inFile, MyString &output)
{
	MyString temp;
	char c;
	inFile.get(c);

	if (inFile.eof())
		return false;

	while (c != '\n' && !inFile.eof())
	{
		temp += c;
		inFile.get(c);
	}
	output = temp;

	return true;
}


const MyString& MyString::operator =(const char *s)
{
	if (capacity < strlen(s) + 1)
	{
		resize(strlen(s) + 1);
		pos = capacity - 1;
	}
	else
	{
		pos = strlen(s);
	}

	for (int i = 0; i < pos; i++)
	{
		str[i] = s[i];
	}

	str[pos] = '\0';

	return *this;
}
const MyString& MyString::operator =(const MyString& ms)
{
	if (capacity < ms.length() + 1)
	{
		resize(ms.length() + 1);
		pos = capacity - 1;
	}
	else
	{
		pos = ms.length();
	}

	for (int i = 0; i < pos; i++)
	{
		str[i] = ms.at(i);
	}

	str[pos] = '\0';

	return *this;
}

const MyString& MyString::operator +=(char c)
{
	if (capacity == pos + 1)
		resize(2 * capacity);

	str[pos++] = c;
	str[pos] = '\0';

	return *this;
}
const MyString& MyString::operator +=(const char* s)
{
	if (capacity < strlen(s) + pos + 1)
		resize(strlen(s) + pos + 1);

	for (int i = 0; i < strlen(s); i++)
		str[pos++] = s[i];

	str[pos] = '\0';

	return *this;
}
const MyString& MyString::operator +=(const MyString &ms)
{
	if (capacity < ms.length() + pos + 1)
		resize(ms.length() + pos + 1);

	for (int i = 0; i < ms.length(); i++)
		str[pos++] = ms.at(i);

	str[pos] = '\0';

	return *this;
}

const MyString MyString::operator +(const char* s) const
{
	MyString temp;

	temp += str;
	temp += s;

	return temp;
}
const MyString MyString::operator +(const MyString &ms) const
{
	MyString temp;
	
	temp += str;
	temp += ms;

	return temp;
}

ostream& operator <<(ostream& outputStream, const MyString &ms)
{
	for (int i = 0; i < ms.pos; i++) {
		outputStream << ms.str[i];
	}

	return outputStream;
}
istream& operator >>(istream& inputStream, MyString &ms)
{
	ms.pos = 0;

	char c;

	inputStream.get(c);
	while (1) {
		if (c == '\n')
			break;

		ms += c;

		inputStream.get(c);
	}

	return inputStream;
}

int min(int n1, int n2)
{
	if (n1 <= n2)
		return n1;
	else
		return n2;
}

bool MyString::operator ==(const MyString &ms) const
{
	if (pos == ms.pos) {
		for (int i = 0; i < pos; i++)
		{
			if (str[i] != ms.at(i))
				return false;
		}

		return true;
	}

	return false;
}
bool MyString::operator !=(const MyString &ms) const
{
	if (pos == ms.pos)
	{
		for (int i = 0; i < pos; i++)
		{
			if (str[i] != ms.at(i))
				return true;
		}

		return false;
	}

	return true;
}
bool MyString::operator <(const MyString &ms) const
{
	int len = min(pos, ms.pos);

	for (int i = 0; i < len; i++) {
		if (str[i] < ms.at(i))
			return true;
		else if (str[i] > ms.at(i))
			return false;
	}

	if (pos < ms.pos)
		return true;
	else
		return false;
}
bool MyString::operator <=(const MyString &ms) const
{
	int len = min(pos, ms.pos);

	for (int i = 0; i < len; i++) {
		if (str[i] > ms.at(i))
			return false;
		else if (str[i] < ms.at(i))
			return true;
	}

	if (pos > ms.pos)
		return false;
	else
		return true;
}
bool MyString::operator >=(const MyString &ms) const
{
	int len = min(pos, ms.pos);

	for (int i = 0; i < len; i++) {
		if (str[i] < ms.at(i))
			return false;
		else if (str[i] > ms.at(i))
			return true;
	}

	if (pos < ms.pos)
		return false;
	else
		return true;
}
bool MyString::operator >(const MyString &ms) const
{
	int len = min(pos, ms.pos);

	for (int i = 0; i < len; i++) {
		if (str[i] > ms.at(i))
			return true;
		else if (str[i] < ms.at(i))
			return false;
	}

	if (pos > ms.pos)
		return true;
	else
		return false;
}