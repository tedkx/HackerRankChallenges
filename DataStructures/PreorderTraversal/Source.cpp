/*
* Preorder Traversal
* https://www.hackerrank.com/challenges/tree-preorder-traversal
*/

#include <iostream>

using namespace std;

struct node
{
	int data;
	node* left;
	node* right;
};

//Method to complete
void preOrder(node *root) {
	cout << root->data << " ";
	if (root->left != NULL)
		preOrder(root->left);
	if (root->right != NULL)
		preOrder(root->right);
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

	preOrder(root);
}