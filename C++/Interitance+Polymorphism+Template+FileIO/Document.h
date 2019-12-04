#pragma once

#include "MyString.h"

class Document
{
public:
	Document();
	Document(MyString text);
	
	~Document();

	MyString getText() const;
	Document* getNext() const;

	void setText(MyString text);
	void setNext(Document* docu);

	virtual void print() const = 0;
private:
	MyString text;
	Document* next;
};