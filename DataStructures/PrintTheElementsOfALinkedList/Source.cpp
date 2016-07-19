/*
 * Print the Elements of a Linked List
 * https://www.hackerrank.com/challenges/print-the-elements-of-a-linked-list
 */

#include <iostream>

using namespace std;

struct Node
{
	int data;
	struct Node *next;
};

//The function to create
void Print(Node *head)
{
	if (head != NULL)
	{
		cout << head->data << endl;
		Print(head->next);
	}
}



int main() {
	Node * tail = new Node();
	tail->data = 3;

	Node * mid = new Node();
	mid->data = 4;
	mid->next = tail;

	Node * head = new Node();
	head->data = 5;
	head->next = mid;

	Print(head);

	int x = 0;
	cin >> x;
}