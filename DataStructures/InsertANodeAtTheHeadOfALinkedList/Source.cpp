/*
* Insert a node at the head of a linked list
* https://www.hackerrank.com/challenges/insert-a-node-at-the-head-of-a-linked-list
*/

#include <iostream>

using namespace std;

struct Node
{
	int data;
	struct Node *next;
};

//Method to complete
Node* Insert(Node *head, int data)
{
	Node * newHead = new Node();
	newHead->data = data;
	if (head != NULL)
	{
		newHead->next = head;
	}
	return newHead;
}

int main() {
	Insert(NULL, 1);

	Node *head = new Node();
	head->data = 1;
	Insert(head, 2);
}