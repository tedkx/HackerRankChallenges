/*
* Print in Reverse
* https://www.hackerrank.com/challenges/print-the-elements-of-a-linked-list-in-reverse
*/

#include <iostream>

using namespace std;

struct Node
{
	int data;
	struct Node *next;
};

//Method to complete
void ReversePrint(Node *head)
{
	if (head == NULL)
		return;
	if (head->next == NULL)
	{
		cout << head->data << endl;
	}
	else
	{
		ReversePrint(head->next);
		cout << head->data << endl;
	}
}

int main() {
	Node *singleHead = new Node();
	singleHead->data = 5;
	ReversePrint(singleHead);

	singleHead->data = 0;
	ReversePrint(singleHead);

	singleHead->data = 2;
	ReversePrint(singleHead);

	Node *tail1 = new Node();
	tail1->data = 2;
	Node *head1 = new Node();
	head1->data = 1;
	head1->next = tail1;
	ReversePrint(head1);

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
	ReversePrint(head2);
}