#pragma once

template <typename T>
MyList<T>::MyList()
{
	head = nullptr;
	tail = nullptr;
}
template <typename T>
MyList<T>::MyList(T *head, T *tail)
{
	this->head = head;
	this->tail = tail;
}

template <typename T>
MyList<T>::~MyList()
{
	if(head != nullptr)
		deleteList(head);
}
template <typename T>
void MyList<T>::deleteList(T *docu)
{
	if (docu->getNext() != nullptr)
	{
		deleteList(docu->getNext());
	}

	delete docu;
}

template <typename T>
T* MyList<T>::getHead() const
{
	return head;
}
template <typename T>
T* MyList<T>::getTail() const
{
	return tail;
}

template <typename T>
void MyList<T>::setHead(T *docu)
{
	head = docu;
}
template <typename T>
void MyList<T>::setTail(T *docu)
{
	tail = docu;
}

template <typename T>
void MyList<T>::insert(T *docu)
{
	// head 의 값이 없을 경우
	if (head == nullptr)
	{
		head = docu;
		tail = docu;
	}
	// head 가 이미 있을 경우
	else
	{
		tail->setNext(docu);
		tail = docu;
	}
}
template <typename T>
void MyList<T>::remove(int docuNum)
{
	// index 범위를 넘어선 docuNum에 엑세스 시도한 경우
	if (head == nullptr || docuNum >= size())
	{
		cout << "remove(" << docuNum << ") : Out Of Index!" << endl;
		return;
	}

	// 커서를 삭제할 document 한칸 앞의 document로 이동한다
	// 한칸 앞에 커서를 두는 이유는 getFront() 없이 구현하고 있기 때문
	T* cur = head;

	for (int i = 0; i < docuNum-1; i++)
	{
		cur = cur->getNext();
	}

	// list에 document가 하나 밖에 없을 경우
	if (this->getHead() == this->getTail())
	{
		delete head;
		head = nullptr;
		tail = nullptr;
	}
	// 삭제할 document가 첫번째 document일 경우
	else if (docuNum == 0)
	{
		T* tmp = head;
		head = head->getNext();
		delete tmp;
	}
	// 삭제할 document가 중간에 있거나 마지막에 있을 경우
	else
	{
		T* tmp = cur->getNext();
		cur->setNext(tmp->getNext());
		delete tmp;
	}
}
template <typename T>
void MyList<T>::modify(int docuNum, T *docu)
{
	if (head == nullptr || docuNum >= size())
	{
		cout << "modify(" << docuNum << ") : Out Of Index!" << endl;
		return;
	}

	T* cur = head;

	for (int i = 0; i < docuNum - 1; i++)
	{
		cur = cur->getNext();
	}

	// list에 document가 하나 밖에 없을 경우
	if (this->getHead() == this->getTail())
	{
		head = docu;
		tail = docu;
	}
	// 수정할 document가 첫번째 document일 경우
	else if (docuNum == 0)
	{
		T* tmp = head;
		head = docu;
		head->setNext(tmp->getNext());
		delete tmp;
	}
	// 삭제할 document가 중간에 있거나 마지막에 있을 경우
	else
	{
		T* target = cur->getNext();
		cur->setNext(docu);
		docu->setNext(target->getNext());
		delete target;
	}
}

template <typename T>
T* MyList<T>::operator[](int i) const
{
	return this->at(i);
}

template <typename T>
T* MyList<T>::at(int i) const
{
	if (i >= size())
	{
		cout << "at(" << i << ") : Out Of Index!" << endl;
		return nullptr;
	}

	T *docu = head;
	
	for (int j = 0; j < i; j++)
	{
		docu = docu->getNext();
	}

	return docu;
}
template <typename T>
int MyList<T>::size() const
{
	T *docu = head;
	int length = 0;

	while (true)
	{
		if (docu == nullptr)
			break;
		else
		{
			length++;
			docu = docu->getNext();
		}
	}

	return length;
}