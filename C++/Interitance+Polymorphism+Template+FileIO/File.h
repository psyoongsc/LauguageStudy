#pragma once

#include "Document.h"

class File : public Document
{
public:
	File();
	File(MyString path, MyString text);

	~File();

	MyString getPath() const;
	void setPath(MyString path);

	void print() const;
private:
	MyString path;
};