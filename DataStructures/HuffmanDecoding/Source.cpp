/*
* Tree: Huffman Decoding
* https://www.hackerrank.com/challenges/tree-huffman-decoding
*/

#include <iostream>
#include <string>

using namespace std;

struct node
{
	int freq;
	char data;
	node * left;
	node * right;
};

char get_char(node * n, string & str) {
	if (str[0] == '0')
	{
		str = str.substr(1);
		if (n->left->data == '\0')
			return get_char(n->left, str);
		else
			return n->left->data;
	}
	else
	{
		str = str.substr(1);
		if (n->right->data == '\0')
			return get_char(n->right, str);
		else
			return n->right->data;
	}
}

//Method to complete
void decode_huff(node * root, string s) {
	string output = "";
	while (s.length() > 0)
	{
		char c = get_char(root, s);
		output += c;
	}

	cout << output << endl;
}

node* createNode(char data, int freq) {
	node* n = new node();
	n->data = data;
	n->freq = freq;
	return n;
}

int main() {
	node * root = createNode('\0', 5);
	root->left = createNode('\0', 2);
	root->left->left = createNode('B', 1);
	root->left->right = createNode('C', 1);
	root->right = createNode('A', 3);
	//root->right->left = createNode(6);

	decode_huff(root, "1001011");
}