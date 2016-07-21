/*
* Height of a Binary Tree
* https://www.hackerrank.com/challenges/tree-height-of-a-binary-tree
*/

#include <iostream>

using namespace std;

struct node
{
	int data;
	node* left;
	node* right;
};

int checkHeight(node * node, int currentHeight) {
	int maxHeight = currentHeight;
	int tempHeight = 0;
	if (node->left != NULL)
	{
		tempHeight = checkHeight(node->left, currentHeight + 1);
		if (tempHeight > maxHeight)
			maxHeight = tempHeight;
	}
	if (node->right != NULL)
	{
		tempHeight = checkHeight(node->right, currentHeight + 1);
		if (tempHeight > maxHeight)
			maxHeight = tempHeight;
	}
	return maxHeight;
}

//Method to complete
int height(node *root) {
	return checkHeight(root, 0);
}

node* createNode(int data) {
	node* n = new node();
	n->data = data;
	return n;
}

int main() {
	node * root = createNode(3);
	root->left = createNode(2);
	root->left->left = createNode(1);
	root->right = createNode(5);
	root->right->left = createNode(4);
	root->right->right = createNode(6);
	root->right->right->right = createNode(7);

	height(root);
}