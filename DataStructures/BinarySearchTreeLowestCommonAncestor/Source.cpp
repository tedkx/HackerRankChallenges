/*
* Binary Search Tree : Lowest Common Ancestor
* https://www.hackerrank.com/challenges/binary-search-tree-lowest-common-ancestor
*/

#include <iostream>
#include <vector>
#include <sstream>

using namespace std;

struct node
{
	int data;
	node * left;
	node * right;
};

//returns 0 if none found, 1 if 1 value found, 2 if two values found
int CheckIfCommonAncestor(node * n, int v1, int v2, vector<node*> * lcaVector, bool isRoot) {
	if ((*lcaVector).size() > 0)
		return 2;
	
	int result = 0;
	int enterResult = 0;

	if (isRoot)
	{
		if (n->data == v1 || n->data == v2)
			result++;
	}

	if (n->left != NULL)
	{
		enterResult = result;
		if (n->left->data == v1 || n->left->data == v2)
			result++;
		result += CheckIfCommonAncestor(n->left, v1, v2, lcaVector, false);
		if (enterResult == 0 && result == 2 && (*lcaVector).size() == 0) {
			(*lcaVector).push_back(n->left);
			return 2;
		}
	}
	if (result < 2 && n->right != NULL)
	{
		enterResult = result;
		if (n->right->data == v1 || n->right->data == v2)
			result++;
		result += CheckIfCommonAncestor(n->right, v1, v2, lcaVector, false);
		if (enterResult == 0 && result == 2 && (*lcaVector).size() == 0) {
			(*lcaVector).push_back(n->right);
			return 2;
		}
	}
	if (result == 2 && (*lcaVector).size() == 0)
		(*lcaVector).push_back(n);

	return result;
}

//Method to complete
node * lca(node * root, int v1, int v2) {
	vector<node*> lcaVector;

	int result = CheckIfCommonAncestor(root, v1, v2, & lcaVector, true);
	
	return lcaVector.at(0);
}

void createNode(node * parent, int value) {
	if (value < parent->data) {
		if (parent->left == NULL)
		{
			parent->left = new node();
			parent->left->data = value;
		}
		else
		{
			createNode(parent->left, value);
		}
	} 
	else if (value > parent->data) 
	{
		if (parent->right == NULL)
		{
			parent->right = new node();
			parent->right->data = value;
		}
		else
		{
			createNode(parent->right, value);
		}
	}
}

node * createTree(string values) {
	string buf;
	stringstream ss(values);
	node * root = NULL;

	while (ss >> buf) {
		int i;
		std::istringstream(buf) >> i;
		if (root == NULL)
		{
			root = new node();
			root->data = i;
		}
		else
		{
			createNode(root, i);
		}
	}

	return root;
}


int main() {
	//node * tree = createTree("4 2 3 1 7 6");
	node * tree = createTree("7 9 4 2 6 3 5 1");

	lca(tree, 7, 9);
}