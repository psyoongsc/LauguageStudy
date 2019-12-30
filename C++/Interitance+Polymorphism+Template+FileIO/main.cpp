#include "MyList.h"
#include "Document.h"
#include "File.h"
#include "Mail.h"

#include <iostream>
#include <fstream>
using namespace std;


int main(void)
{	
	MyList<Document> docuList;
	ifstream inFile;
	int selectedMenu, selectedDocu;
	MyString filePath;
	MyString line;
	Mail *newMail;
	File *newFile;
	

	while (true)
	{
		cout << "1. 문서 입력 2. 문서 출력 3. 문서 변경 4. 문서 삭제 5. 종료" << endl;
		cout << "메뉴를 입력하세요: ";
		cin >> selectedMenu;

		switch (selectedMenu)
		{

			/*
			1. 문서 입력
			2. 문서 출력
			3. 문서 변경
			4. 문서 삭제
			5. 종료
			*/

		case 1:
			cout << "파일명을 입력하세요[취소는 \"NONE\"] : ";
			cin.ignore(INT_MAX, '\n');
			cin >> filePath;

			if (filePath == "" || filePath == "NONE" || filePath == "none")
			{
				break;
			}

			inFile = ifstream(filePath.data());
			if (inFile.is_open())
			{
				getline(inFile, line);

				if (line.find("Sender", 0) == 0) // mail
				{
					newMail = new Mail();

					newMail->setSender(line.substr(8, line.length() - 1));

					getline(inFile, line);
					newMail->setReceiver(line.substr(10, line.length() - 1));

					getline(inFile, line);
					newMail->setTitle(line.substr(7, line.length() - 1));

					if (getline(inFile, line))
					{
						getline(inFile, line);
						newMail->setText(line);
						while (getline(inFile, line))
						{
							newMail->setText(newMail->getText() + "\n");
							newMail->setText(newMail->getText() + line);
						}
					}

					docuList.insert(newMail);
				}
				else // file
				{
					newFile = new File();
					newFile->setPath(filePath);

					newFile->setText(line);
					while (getline(inFile, line))
					{
						newFile->setText(newFile->getText() + "\n");
						newFile->setText(newFile->getText() + line);
					}

					docuList.insert(newFile);
				}
			}
			else
			{
				cout << "해당 문서가 존재하지 않습니다." << endl;
			}

			inFile.close();

			break;
		case 2:
			for (int i = 0; i < docuList.size(); i++)
			{
				cout << "[문서" << i + 1;
				docuList[i]->print();
				cout << endl;
			}
			break;
		case 3:
			cout << "변경할 문서 번호를 입력하세요: ";
			cin >> selectedDocu;
			cout << "파일명을 입력하세요 [취소는 \"NONE\"]: ";
			cin.ignore(INT_MAX, '\n');
			cin >> filePath;

			if (filePath == "" || filePath == "NONE" || filePath == "none") {
				break;
			}

			inFile = ifstream(filePath.data());
			if (inFile.is_open())
			{
				cout << "in" << endl;
				getline(inFile, line);

				if (line.find("Sender", 0) == 0) // mail
				{
					newMail = new Mail();

					newMail->setSender(line.substr(8, line.length() - 1));

					getline(inFile, line);
					newMail->setReceiver(line.substr(10, line.length() - 1));

					getline(inFile, line);
					newMail->setTitle(line.substr(7, line.length() - 1));

					if (getline(inFile, line))
					{
						getline(inFile, line);
						newMail->setText(line);
						while (getline(inFile, line))
						{
							newMail->setText(newMail->getText() + "\n");
							newMail->setText(newMail->getText() + line);
						}
					}

					docuList.modify(selectedDocu - 1, newMail);
				}
				else // file
				{
					newFile = new File();
					newFile->setPath(filePath);

					newFile->setText(line);
					while (getline(inFile, line))
					{
						newFile->setText(newFile->getText() + "\n");
						newFile->setText(newFile->getText() + line);
					}

					docuList.modify(selectedDocu - 1, newFile);
				}
			}
			else
			{
				cout << "해당 문서가 존재하지 않습니다." << endl;
			}

			break;
		case 4:
			cout << "삭제할 문서 번호를 입력하세요: ";
			cin >> selectedDocu;
			
			docuList.remove(selectedDocu - 1);

			break;
		case 5:
			return 0;
		}

		cout << endl;
	}

	return 0;
}