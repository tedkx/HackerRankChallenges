/*
* Level Order Traversal
* https://www.hackerrank.com/challenges/tree-level-order-traversal
*/

#include <iostream>
#include <vector>
#include <string>

using namespace std;

struct node
{
	int data;
	node* left;
	node* right;
};

vector<string> appendNode(node * n, vector<string> levels, int currentLevel) {
	if (levels.size() <= currentLevel)
	{
		if (currentLevel == 0)
			levels.push_back(to_string(n->data));
		else
			levels.push_back(" " + to_string(n->data));
	}
	else
	{
		levels.at(currentLevel) += " " + to_string(n->data);
	}

	if (n->left != NULL)
		levels = appendNode(n->left, levels, currentLevel + 1);
	if (n->right != NULL)
		levels = appendNode(n->right, levels, currentLevel + 1);

	return levels;
}

//Method to complete
void LevelOrder(node * root) {
	vector<string> levels;
	levels = appendNode(root, levels, 0);

	for (vector<string>::iterator it = levels.begin(); it != levels.end(); ++it)
		cout << *it;
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

	LevelOrder(root);
}