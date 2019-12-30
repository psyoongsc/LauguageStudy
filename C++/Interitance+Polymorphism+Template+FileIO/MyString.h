#pragma once

#include <iostream>
using namespace std;

class MyString {
public:
	MyString();
	MyString(const MyString &ms);
	MyString(const char *s);
	~MyString();

	void resize(int size);
	int length() const;
	char at(int i) const;
	const MyString substr(int firstPos, int lastPos) const;
	void insert(int iPos, const MyString &ms);
	void insert(int iPos, const char* s);
	void erase(int firstPos, int lastPos);
	int find(const char *s, int iPos) const;
	int find(const MyString &ms, int iPos) const;

	const char* data() const;
	
	friend bool getline(istream& inFile, MyString& output);

	const MyString& operator =(const char *s);
	const MyString& operator =(const MyString &ms);

	const MyString& operator +=(char c);
	const MyString& operator +=(const char* s);
	const MyString& operator +=(const MyString &ms);

	const MyString operator +(const char* s) const;
	const MyString operator +(const MyString &ms) const;

	friend ostream& operator <<(ostream& outputStream, const MyString &ms);
	friend istream& operator >>(istream& inputStream, MyString &ms);

	bool operator ==(const MyString &ms) const;
	bool operator !=(const MyString &ms) const;
	bool operator <(const MyString &ms) const;
	bool operator <=(const MyString &ms) const;
	bool operator >=(const MyString &ms) const;
	bool operator >(const MyString &ms) const;

private:
	char *str;
	int capacity;
	int pos;
};