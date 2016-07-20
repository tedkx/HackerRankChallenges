/*
* Reverse a linked list
* https://www.hackerrank.com/challenges/reverse-a-linked-list
*/

#include <iostream>

using namespace std;

struct Node
{
	int data;
	struct Node *next;
};

//Method to complete
Node* Reverse(Node *head)
{
	if (head == NULL || head->next == NULL)
		return head;

	Node* node = head;
	Node* prevNode = NULL;
	Node* nextNode = NULL;
	while (node != NULL)
	{
		nextNode = node->next;
		node->next = prevNode;
		prevNode = node;
		node = nextNode;		
	}

	return prevNode;
}

int main() {
	Node *tail1 = new Node();
	tail1->data = 2;
	Node *head1 = new Node();
	head1->data = 1;
	head1->next = tail1;
	Reverse(head1);

	Node *tail2 = new Node();
	tail2->data = 5;
	Node *mid2 = new Node();
	mid2->data = 4;
	mid2->next = tail2;
	Node *premid2 = new Node();
	premid2->data = 1;
	premid2->next = mid2;
	Node *head2 = new Node();
	head2->data = 2;
	head2->next = premid2;
	Reverse(head2);
}