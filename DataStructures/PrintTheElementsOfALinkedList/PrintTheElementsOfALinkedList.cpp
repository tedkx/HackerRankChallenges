// PrintTheElementsOfALinkedList.cpp : Defines the entry point for the console application.
//

//#include "stdafx.h"
#include <iostream>
using namespace std;

static int Print(Node *head);

struct Node
{
	int data;
	struct Node *next;
};

/// <summary>
/// Print the Elements of a Linked List
/// https://www.hackerrank.com/challenges/print-the-elements-of-a-linked-list
/// </summary>
int _tmain(int argc, char* argv[])
{
	return 0;

	Node node = {
		5,
		NULL
	};

	Print(&node);
}

//int _tmain(int argc, _TCHAR* argv[])
//{
//	return 0;
//}


static int Print(Node *head)
{
	cout << "asdf\n";
	cout << (*head).data << endl;
	//cout << head->data;
	//cout << head->next->data;
}

