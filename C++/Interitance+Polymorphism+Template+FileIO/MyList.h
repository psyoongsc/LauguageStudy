#pragma once

#include "MyString.h"

#include <iostream>
using namespace std;

template <class T>
class MyList
{
public:
	MyList();
	MyList(T *head, T *tail);

	T& getHead() const;
	T& getTail() const;

	void setHead(T *docu);
	void setTail(T *docu);

	void insert(T *docu);
	void remove(int docuNum);
	void modify(int docuNum, T *docu);

	int length();

	void print(int i);
private:
	T *head;
	T *tail;
};
#include "MyList.hpp"