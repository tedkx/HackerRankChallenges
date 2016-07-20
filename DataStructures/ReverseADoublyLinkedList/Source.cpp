/*
* Reverse a doubly linked list
* https://www.hackerrank.com/challenges/reverse-a-doubly-linked-list
*/

#include <iostream>

using namespace std;

struct Node
{
	int data;
	Node *next;
	Node *prev;
};

//Method to complete
Node* Reverse(Node* head) {
	if (head == NULL)
		return NULL;
	if (head->next == NULL)
		return head;
	
	Node * currentNode = head;
	Node * tempNode = NULL;
	Node * nextNode = NULL;
	while (true)
	{
		nextNode = currentNode->next;
		currentNode->next = currentNode->prev;
		currentNode->prev = nextNode;
		if (nextNode == NULL)
			break;
		currentNode = nextNode;
	}
	
	return currentNode;
}

int main() {
	Node *tail1 = new Node();
	tail1->data = 4;
	Node *mid1 = new Node();
	mid1->data = 3;
	mid1->next = tail1;
	Node *premid1 = new Node();
	premid1->data = 2;
	premid1->next = mid1;
	Node *head1 = new Node();
	head1->data = 1;
	head1->next = premid1;

	tail1->prev = mid1;
	mid1->prev = premid1;
	premid1->prev = head1;

	cout << Reverse(head1) << endl;
}