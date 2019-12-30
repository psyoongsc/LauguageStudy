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
	// head �� ���� ���� ���
	if (head == nullptr)
	{
		head = docu;
		tail = docu;
	}
	// head �� �̹� ���� ���
	else
	{
		tail->setNext(docu);
		tail = docu;
	}
}
template <typename T>
void MyList<T>::remove(int docuNum)
{
	// index ������ �Ѿ docuNum�� ������ �õ��� ���
	if (head == nullptr || docuNum >= size())
	{
		cout << "remove(" << docuNum << ") : Out Of Index!" << endl;
		return;
	}

	// Ŀ���� ������ document ��ĭ ���� document�� �̵��Ѵ�
	// ��ĭ �տ� Ŀ���� �δ� ������ getFront() ���� �����ϰ� �ֱ� ����
	T* cur = head;

	for (int i = 0; i < docuNum-1; i++)
	{
		cur = cur->getNext();
	}

	// list�� document�� �ϳ� �ۿ� ���� ���
	if (this->getHead() == this->getTail())
	{
		delete head;
		head = nullptr;
		tail = nullptr;
	}
	// ������ document�� ù��° document�� ���
	else if (docuNum == 0)
	{
		T* tmp = head;
		head = head->getNext();
		delete tmp;
	}
	// ������ document�� �߰��� �ְų� �������� ���� ���
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

	// list�� document�� �ϳ� �ۿ� ���� ���
	if (this->getHead() == this->getTail())
	{
		head = docu;
		tail = docu;
	}
	// ������ document�� ù��° document�� ���
	else if (docuNum == 0)
	{
		T* tmp = head;
		head = docu;
		head->setNext(tmp->getNext());
		delete tmp;
	}
	// ������ document�� �߰��� �ְų� �������� ���� ���
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