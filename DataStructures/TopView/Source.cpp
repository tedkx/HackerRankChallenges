/*
* Top View
* https://www.hackerrank.com/challenges/tree-top-view
*/

#include <iostream>

using namespace std;

struct node
{
	int data;
	node* left;
	node* right;
};

void printNode(node * n, int direction) {
	node *nodeToPrint = NULL;
	if (direction == 1) {
		if (n->left != NULL)
		{
			nodeToPrint = n->left;
			printNode(nodeToPrint, direction);
		}
		cout << n->data << " ";
	}
	else if (direction == 2) {
		cout << n->data << " ";
		if (n->right != NULL)
		{
			nodeToPrint = n->right;
			printNode(nodeToPrint, direction);
		}
	}
}

//Method to complete
void top_view(node * root)
{
	if (root->left != NULL)
		printNode(root->left, 1);
	cout << root->data << " ";
	if (root->right != NULL)
		printNode(root->right, 2);
}

node* createNode(int data) {
	node* n = new node();
	n->data = data;
	return n;
}

int main() {
	node * root = createNode(3);
	root->left = createNode(5);
	root->left->left = createNode(1);
	root->left->right = createNode(4);
	root->right = createNode(2);
	root->right->left = createNode(6);

	top_view(root);
}