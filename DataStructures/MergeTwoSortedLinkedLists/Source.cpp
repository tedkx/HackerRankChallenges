/*
* Merge two sorted linked lists
* https://www.hackerrank.com/challenges/merge-two-sorted-linked-lists
*/

#include <iostream>

using namespace std;

struct Node
{
	int data;
	struct Node *next;
};

//Method to complete
Node* MergeLists(Node* headA, Node* headB)
{
	if (headA == NULL && headB == NULL)
		return NULL;
	else if (headA == NULL)
		return headB;
	else if (headB == NULL)
		return headA;

	Node* nodeA = headA;
	Node* nodeB = headB;
	Node* newHead = NULL;
	Node* newNode = NULL;
	while (nodeA != NULL || nodeB != NULL)
	{
		Node *tempNode = NULL;
		if (nodeA == NULL || (nodeB != NULL && nodeA->data >= nodeB->data))
		{
			tempNode = nodeB;
			nodeB = nodeB->next;
		}
		else// if (nodeB == NULL || nodeA->data > nodeB->data)
		{
			tempNode = nodeA;
			nodeA = nodeA->next;
		}

		if (newHead == NULL)
		{
			newHead = tempNode;
			newNode = newHead;
		}
		else
		{
			newNode->next = tempNode;
			newNode = newNode->next;
		}
	}
	return newHead;
}

int main() {
	Node *tail1 = new Node();
	tail1->data = 3;
	Node *head1 = new Node();
	head1->data = 1;
	head1->next = tail1;

	Node *tail2 = new Node();
	tail2->data = 5;
	Node *mid2 = new Node();
	mid2->data = 4;
	mid2->next = tail2;
	Node *head2 = new Node();
	head2->data = 2;
	head2->next = mid2;

	MergeLists(head1, head2);

	MergeLists(head2, NULL);

	Node * singleNode1 = new Node();
	singleNode1->data = 15;
	Node * singleNode2 = new Node();
	singleNode2->data = 12;

	MergeLists(singleNode1, singleNode2);
}