#pragma once

#include "Document.h"

class File : public Document
{
public:
	File();
	File(MyString path, MyString text);

	MyString getPath() const;
	void setPath(MyString path);

	void print();
private:
	MyString path;
};