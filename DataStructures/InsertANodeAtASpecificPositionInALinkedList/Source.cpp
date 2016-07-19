/*
* Insert a node at a specific position in a linked list
* https://www.hackerrank.com/challenges/insert-a-node-at-a-specific-position-in-a-linked-list
*/

#include <iostream>

using namespace std;

struct Node
{
	int data;
	struct Node *next;
};

//Method to complete
Node* Insert(Node *head, int data, int position)
{
	Node * currentNode = head;
	Node * parentNode = NULL;
	Node * newNode = new Node();
	newNode->data = data;
	int curr = 0;
	while (position > curr)
	{
		parentNode = currentNode;
		currentNode = currentNode->next;
		curr++;
	}
	newNode->next = currentNode;
	
	if (parentNode == NULL)
		return newNode;

	parentNode->next = newNode;
	return head;
}

int main() {
	Insert(NULL, 1, 0);

	Node *head = new Node();
	head->data = 1;
	Insert(head, 2, 0);
}