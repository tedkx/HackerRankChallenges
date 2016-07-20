/*
* Find Merge Point of Two Lists
* https://www.hackerrank.com/challenges/find-the-merge-point-of-two-joined-linked-lists
*/

#include <iostream>
#include <vector>

using namespace std;

struct Node
{
	int data;
	struct Node *next;
};

//Method to complete
int FindMergeNode(Node *headA, Node *headB) {
	Node * nodeA = headA;
	while (nodeA != NULL)
	{
		Node * nodeB = headB;
		while (nodeB != NULL)
		{
			if (nodeB == nodeA)
				return nodeA->data;
			nodeB = nodeB->next;
		}
		nodeA = nodeA->next;
	}
	return 0;
}

int main() {
	Node *mergeTail = new Node();
	mergeTail->data = 6;
	Node *mergePoint = new Node();
	mergePoint->data = 5;
	mergePoint->next = mergeTail;

	Node *tail1 = new Node();
	tail1->data = 2;
	tail1->next = mergePoint;
	Node *head1 = new Node();
	head1->data = 1;
	head1->next = tail1;

	Node *tail2 = new Node();
	tail2->data = 4;
	tail2->next = mergePoint;
	Node *head2 = new Node();
	head2->data = 3;
	head2->next = tail2;

	cout << FindMergeNode(head1, head2) << endl;
}