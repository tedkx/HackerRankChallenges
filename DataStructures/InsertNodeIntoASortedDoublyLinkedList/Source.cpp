/*
* Insert a node into a sorted doubly linked list
* https://www.hackerrank.com/challenges/insert-a-node-into-a-sorted-doubly-linked-list
*/

#include <iostream>
#include <vector>

using namespace std;

struct Node
{
	int data;
	Node *next;
	Node *prev;
};

//Method to complete
Node* SortedInsert(Node* head, int data) {
	Node * newNode = new Node();
	newNode->data = data;
	
	if (head == NULL)
		return newNode;
	if (head->next == NULL && head->data > data)
	{
		head->prev = newNode;
		newNode->next = head;
		return newNode;
	}

	Node * node = head;
	while (node->next != NULL)
	{
		if (node->next->data >= data)
			break;
		node = node->next;
	}

	newNode->prev = node;
	newNode->next = node->next;
	node->next = newNode;

	return head;
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

	cout << SortedInsert(head1, 3) << endl;

	Node * head = NULL;
	head = SortedInsert(head, 2);
	head = SortedInsert(head, 1);
	head = SortedInsert(head, 3);
	head = SortedInsert(head, 4);
}