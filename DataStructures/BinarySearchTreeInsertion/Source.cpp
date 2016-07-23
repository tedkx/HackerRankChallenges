/*
* Binary Search Tree : Insertion
* https://www.hackerrank.com/challenges/binary-search-tree-insertion
*/

#include <iostream>

using namespace std;

struct node
{
	int data;
	node * left;
	node * right;
};

//Method to complete
node * insert(node * root, int value)
{
	if (root == NULL)
	{
		root = new node();
		root->data = value;
		return root;
	}

	if (value < root->data)
		root->left = insert(root->left, value);
	else
		root->right = insert(root->right, value);

	return root;
}

node* createNode(int data) {
	node* n = new node();
	n->data = data;
	return n;
}

int main() {
	node * root = createNode(4);
	root->left = createNode(2);
	root->left->left = createNode(1);
	root->left->right = createNode(3);
	root->right = createNode(7);
	//root->right->left = createNode(6);

	insert(root, 6);
}