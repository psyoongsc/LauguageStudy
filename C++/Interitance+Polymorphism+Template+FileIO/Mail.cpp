#include "Mail.h"

Mail::Mail()
{
	sender = "";
	receiver = "";
	title = "";
	setText("");
}
Mail::Mail(MyString sender, MyString receiver, MyString title, MyString text) : sender(sender), receiver(receiver), title(title)
{
	setText(text);
}

MyString Mail::getSender() const { return sender; }
MyString Mail::getReceiver() const { return receiver; }
MyString Mail::getTitle() const { return title; }

void Mail::setSender(MyString sender) { this->sender = sender; }
void Mail::setReceiver(MyString receiver) { this->receiver = receiver; }
void Mail::setTitle(MyString title) { this->title = title; }

void Mail::print()
{
	cout << "수신자:" << receiver << endl;
	cout << "송신자:" << sender << endl;
	cout << "제목:" << title << endl;
	cout << "내용" << getText() << endl;
}