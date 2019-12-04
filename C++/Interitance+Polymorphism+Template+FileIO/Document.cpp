#include "Document.h"

Document::Document()
{
	this->text = "";
	next = nullptr;
}
Document::Document(MyString text) : text(text) {}

Document::~Document()
{
	next = nullptr;
	delete next;
}

MyString Document::getText() const { return this->text; }
Document* Document::getNext() const { return this->next; }

void Document::setText(MyString text) { this->text = text; }
void Document::setNext(Document* docu) { this->next = docu; }