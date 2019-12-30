#include "File.h"

File::File()
{
	path = "";
	setText("");
}
File::File(MyString path, MyString text) : path(path)
{
	setText(text);
}

File::~File() {}

MyString File::getPath() const { return path; }
void File::setPath(MyString path) { this->path = path; }

void File::print() const
{

	{
		cout << "-����]" << endl;
		cout << "���: " << path << endl;
		cout << "����: " << getText() << endl;
	}
}