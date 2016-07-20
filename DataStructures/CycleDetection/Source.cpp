/*
* Cycle detection
* https://www.hackerrank.com/challenges/detect-whether-a-linked-list-contains-a-cycle
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
bool has_cycle(Node* head) {
	if (head == NULL)
		return false;

	vector<Node*> v;
	while(head != NULL) {
		for (vector<Node*>::iterator it = v.begin(); it != v.end(); ++it)
			if (head == *it)
				return true;
		v.push_back(head);
		head = head->next;
	}
	return false;
}

int main() {
	Node *tail1 = new Node();
	tail1->data = 1;
	Node *mid1 = new Node();
	mid1->data = 1;
	mid1->next = tail1;
	Node *head1 = new Node();
	head1->data = 1;
	head1->next = mid1;

	tail1->next = head1;

	cout << has_cycle(head1) << endl;

	tail1->next = mid1;

	cout << has_cycle(head1) << endl;

	tail1->next = NULL;

	cout << has_cycle(head1) << endl;
}