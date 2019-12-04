#pragma once

#include "Document.h"

class Mail : public Document
{
public:
	Mail();
	Mail(MyString sender, MyString receiver, MyString titlte, MyString text);

	MyString getSender() const;
	MyString getReceiver() const;
	MyString getTitle() const;

	void setSender(MyString sender);
	void setReceiver(MyString receiver);
	void setTitle(MyString title);

	void print();
private:
	MyString sender;
	MyString receiver;
	MyString title;
};