/*
* Delete a node
* https://www.hackerrank.com/challenges/delete-a-node-from-a-linked-list
*/

#include <iostream>

using namespace std;

struct Node
{
	int data;
	struct Node *next;
};

//Method to complete
Node* Delete(Node *head, int position)
{
	int cur = 0;
	Node * currentNode = head;
	Node * parentNode = NULL;
	while (position > cur)
	{
		parentNode = currentNode;
		currentNode = currentNode->next;
		cur++;
	}
	if (parentNode == NULL && head->next == NULL)
		return NULL;
	else if (parentNode == NULL)
		return head->next;
	
	parentNode->next = currentNode->next;
	return head;
}

int main() {
	Node * head1 = new Node();
	Delete(head1, 0);

	Node *head2 = new Node();
	head2->data = 1;
	Node *mid = new Node();
	mid->data = 2;
	head2->next = mid;
	Node * tail = new Node();
	tail->data = 3;
	mid->next = tail;
	Delete(head2, 0);
}