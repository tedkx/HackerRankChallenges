/*
* Is This a Binary Search Tree?
* https://www.hackerrank.com/challenges/is-binary-search-tree
*/

#include <iostream>
#include <vector>
#include <limits>

using namespace std;

struct Node {
	int data;
	Node* left;
	Node* right;
};

class Tree {

public:
	// List of node data values:
	std::vector<int> values;
	// Total number of nodes in the tree:
	int count;


	Tree() {
		this->count = 0;
	}
	//Method to complete
	bool checkBST(Node * root) {
		return checkBST(root, std::numeric_limits<int>::min(), std::numeric_limits<int>::max());
	}

	bool checkBST(Node * root, int min, int max) {
		if (root == NULL)
			return true;

		return root->data > min &&
			root->data > max &&
			checkBST(root->left, min, root->data) &&
			checkBST(root->right, root->data, max);
	}

	void inOrder(Node* root, int levels) {
		if (root != NULL) {
			// If there are still unfilled levels, fill left subtree:
			if (levels > 0) {
				// Create a new left child node:
				root->left = new Node();
				inOrder(root->left, levels - 1);
			}

			// Set node data:
			root->data = values.at(count);
			count++;

			// If there are still unfilled levels, fill right subtree:
			if (levels > 0) {
				// Create a new right child node:
				root->right = new Node();
				inOrder(root->right, levels - 1);
			}
		}
	}
};

int main() {
	Tree* tree = new Tree();
	Node* root = new Node();
	int height = 2;
	int arr[] = { 1, 2, 3, 5, 4, 6, 7 };

	for (int i = 0; i < sizeof(arr); i++) {
		tree->values.push_back(arr[i]);
	}

	tree->inOrder(root, height);

	cout << tree->checkBST(root) << endl;
}