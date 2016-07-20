/*
* Get Node Value
* https://www.hackerrank.com/challenges/get-the-value-of-the-node-at-a-specific-position-from-the-tail
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
int GetNode(Node* head, int positionFromTail)
{
	if (head == NULL)
		return NULL;
	if (head->next == NULL)
		return head->data;

	std::vector<Node*> v;
	v.push_back(head);

	int listLength = 1;
	Node *node = head;
	while (v.at(v.size() - 1)->next != NULL)
		v.push_back(v.at(v.size() - 1)->next);

	return v.at(v.size() - positionFromTail - 1)->data;
}

int main() {
	Node *tail1 = new Node();
	tail1->data = 3;
	Node *head1 = new Node();
	head1->data = 1;
	head1->next = tail1;

	GetNode(head1, 0);

	Node *tail2 = new Node();
	tail2->data = 5;
	Node *mid2 = new Node();
	mid2->data = 4;
	mid2->next = tail2;
	Node *head2 = new Node();
	head2->data = 2;
	head2->next = mid2;

	GetNode(head2, 1);
}