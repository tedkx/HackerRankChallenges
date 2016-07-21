/*
* Inorder Traversal
* https://www.hackerrank.com/challenges/tree-inorder-traversal
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
void inOrder(node *root) {
	if (root->left != NULL)
		inOrder(root->left);
	cout << root->data << " ";
	if (root->right != NULL)
		inOrder(root->right);
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

	inOrder(root);
}