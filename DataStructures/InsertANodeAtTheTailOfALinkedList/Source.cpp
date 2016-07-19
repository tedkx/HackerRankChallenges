/* 
 * Insert a Node at the Tail of a Linked List
 * https://www.hackerrank.com/challenges/insert-a-node-at-the-tail-of-a-linked-list
 */

#include <iostream>

using namespace std;

struct Node
{
	int data;
	struct Node *next;
};

//Method to complete
Node* Insert(Node *head, int data)
{
	Node *newNode = new Node();
	newNode->data = data;
	if (head == NULL)
	{
		return newNode;
	}
	else if (head->next == NULL)
	{
		head->next = newNode;
		return head;
	}
	else
	{
		Node * tempNode = head->next;
		while (tempNode->next != NULL)
			tempNode = tempNode->next;
		tempNode->next = newNode;
		return head;
	}
}

int main() {
	Insert(NULL, 2);

	Node *head = new Node();
	head->data = 2;
	Insert(head, 3);
}