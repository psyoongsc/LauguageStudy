#pragma once

#include "MyString.h"

#include <iostream>
using namespace std;

template <typename T>
class MyList
{
public:
	MyList();
	MyList(T *head, T *tail);

	~MyList();
	void deleteList(T *docu);

	T* getHead() const;
	T* getTail() const;

	void setHead(T *docu);
	void setTail(T *docu);

	void insert(T *docu);
	void remove(int docuNum);
	void modify(int docuNum, T *docu);

	T* operator [](int i) const;

	T* at(int i) const;
	int size() const;
private:
	T *head;
	T *tail;
};
#include "MyList.hpp"