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
		cout << "-파일]" << endl;
		cout << "경로: " << path << endl;
		cout << "내용: " << getText() << endl;
	}
}