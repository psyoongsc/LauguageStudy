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

Mail::~Mail() {}

MyString Mail::getSender() const { return sender; }
MyString Mail::getReceiver() const { return receiver; }
MyString Mail::getTitle() const { return title; }

void Mail::setSender(MyString sender) { this->sender = sender; }
void Mail::setReceiver(MyString receiver) { this->receiver = receiver; }
void Mail::setTitle(MyString title) { this->title = title; }

void Mail::print() const
{
	cout << "-����]" << endl;
	cout << "������: " << receiver << endl;
	cout << "�۽���: " << sender << endl;
	cout << "����: " << title << endl;
	cout << "����: " << getText() << endl;
}