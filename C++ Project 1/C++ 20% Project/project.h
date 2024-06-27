#pragma once
using namespace std;
struct NodeType;

class SortedType
{
public: 
    SortedType();

void InsertItem(string item);

void PrintList();

NodeType* GetListData() const;

void CombineLists(const SortedType& st1, const SortedType& st2);

void MakeEmpty();

void ReverseList();

void DeleteItem(string item);

private:
	NodeType* listData;
	int length;
	NodeType* currentPos;
};