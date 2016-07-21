/*
* Postorder Traversal
* https://www.hackerrank.com/challenges/tree-postorder-traversal
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
void postOrder(node *root) {
	if (root->left != NULL)
		postOrder(root->left);
	if (root->right != NULL)
		postOrder(root->right);
	cout << root->data << " ";
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

	postOrder(root);
}