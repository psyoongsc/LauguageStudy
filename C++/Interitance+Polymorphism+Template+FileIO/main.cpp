#include "MyList.h"
#include "Document.h"
#include "File.h"
#include "Mail.h"

#include <iostream>
using namespace std;

int main(void)
{
	MyList<Document> docuList;

	docuList.print(0);

	return 0;
}