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

MyString File::getPath() const { return path; }
void File::setPath(MyString path) { this->path = path; }

void File::print()
{
	cout << "°æ·Î:" << path << endl;
	cout << getText() << endl;
}