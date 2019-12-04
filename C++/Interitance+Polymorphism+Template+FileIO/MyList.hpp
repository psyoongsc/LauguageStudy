#pragma once

template <class T>
MyList<T>::MyList()
{
	head = nullptr;
	tail = nullptr;
}

template <class T>
MyList<T>::MyList(T *head, T *tail)
{
	this->head = head;
	this->tail = tail;
}

template <class T>
T& MyList<T>::getHead() const
{
	return *head;
}
template <class T>
T& MyList<T>::getTail() const
{
	return *tail;
}

template <class T>
void MyList<T>::setHead(T *docu)
{
	docu->setNext(head);
	head = docu;
}
template <class T>
void MyList<T>::setTail(T *docu)
{
	tail->setNext(docu);
	tail = docu;
}

template <class T>
void MyList<T>::insert(T *docu)
{
	if (tail == nullptr)
	{
		head = docu;
		tail = docu;
	}
	else
	{
		tail->setNext(docu);
		tail = docu;
	}
}

template <class T>
int MyList<T>::length()
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

template <class T>
void MyList<T>::print(int i)
{
	if (i<0 || i>=length())
	{
		cout << i << " is Out Of Index" << endl;
	}
	else
	{
		T *docu = head;
		for (int j = 0; j < i; j++) {
			docu = docu->getNext();
		}

		docu->print();
	}
}

