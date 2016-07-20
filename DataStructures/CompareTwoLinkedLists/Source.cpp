/*
* Compare two linked lists
* https://www.hackerrank.com/challenges/compare-two-linked-lists
*/

#include <iostream>

using namespace std;

struct Node
{
	int data;
	struct Node *next;
};

//Method to complete
int CompareLists(Node* headA, Node* headB)
{
	if (headA == NULL || headB == NULL)
		return headA == headB ? 1 : 0;

	Node* nodeA = headA;
	Node* nodeB = headB;
	while (nodeA != NULL && nodeB != NULL)
	{
		if (nodeA->data != nodeB->data)
			return 0;

		nodeA = nodeA->next;
		nodeB = nodeB->next;
	}
	return nodeA == nodeB ? 1 : 0;
}

int main() {
	Node *tail1 = new Node();
	tail1->data = 2;
	Node *head1 = new Node();
	head1->data = 1;
	head1->next = tail1;

	Node *tail2 = new Node();
	tail2->data = 2;
	Node *head2 = new Node();
	head2->data = 1;
	head2->next = tail2;

	CompareLists(head1, head2);

	tail2->data = 3;
	CompareLists(head1, head2);
}