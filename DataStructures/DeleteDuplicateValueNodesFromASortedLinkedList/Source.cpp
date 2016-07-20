/*
* Delete duplicate-value nodes from a sorted linked list
* https://www.hackerrank.com/challenges/delete-duplicate-value-nodes-from-a-sorted-linked-list
*/

#include <iostream>

using namespace std;

struct Node
{
	int data;
	struct Node *next;
};

//Method to complete
Node* RemoveDuplicates(Node *head)
{
	Node * node = head;
	while (node != NULL && node->next != NULL)
	{
		while (node->next != NULL && node->data == node->next->data)
			node->next = node->next->next;
		node = node->next;
	}
	return head;
}

int main() {
	Node *tail1 = new Node();
	tail1->data = 1;
	Node *head1 = new Node();
	head1->data = 1;
	head1->next = tail1;

	RemoveDuplicates(head1);

	Node *tail2 = new Node();
	tail2->data = 2;
	Node *mid2 = new Node();
	mid2->data = 1;
	mid2->next = tail2;
	Node *premid2 = new Node();
	premid2->data = 1;
	premid2->next = mid2;
	Node *head2 = new Node();
	head2->data = 1;
	head2->next = premid2;

	RemoveDuplicates(head2);
}