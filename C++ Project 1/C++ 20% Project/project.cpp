using namespace std;
#include <iostream>
#include "project.h"

struct NodeType {
    string info;
    NodeType* next;
};

SortedType::SortedType() 
{
    // Class constructor
    length = 0;
    listData = NULL;
}

void SortedType::InsertItem(string item) {
    // Function:Adds item to the correct position in the sorted list
    // Post:    item is in the list; length has been incremented.
    NodeType* newNode;
    // pointer to node being inserted
    NodeType* predLoc;
    // trailing pointer
    NodeType* location;
    // traveling pointer
    bool moreToSearch;
    location = listData;
    predLoc = NULL;
    moreToSearch = (location != NULL);
    // Find insertion point.
    while (moreToSearch) {
        if (location->info < item) {
            predLoc = location;
            location = location->next;
            moreToSearch = (location != NULL);
        }
        else
            moreToSearch = false;
    }
    // Prepare node for insertion
    newNode = new NodeType;
    newNode->info = item;
    // Insert node into list.
    if (predLoc == NULL) {
        // Insert as first
        newNode->next = listData;
        listData = newNode;
    }
    else {
        newNode->next = location;
        predLoc->next = newNode;
    }
    length++;
}

NodeType* SortedType::GetListData() const 
{
    return listData;
}

void SortedType::MakeEmpty() {
    // Function:    Initializes list to empty state
    // Post:        All items have been deallocated, length is 0
    NodeType* tempPtr;
    while (listData != NULL) {
        tempPtr = listData;
        listData = listData->next;
        delete tempPtr;
    }
    length = 0;
}

void SortedType::CombineLists(const SortedType& st1, const SortedType& st2)
{
    // Clear the current list
    MakeEmpty();

    // Insert items from st1
    NodeType* tempPtr1 = st1.GetListData();
    while (tempPtr1 != NULL) {
        InsertItem(tempPtr1->info);
        tempPtr1 = tempPtr1->next;
    }

    // Insert items from st2
    NodeType* tempPtr2 = st2.GetListData();
    while (tempPtr2 != NULL) {
        InsertItem(tempPtr2->info);
        tempPtr2 = tempPtr2->next;
    }
}

void SortedType::PrintList() {
    NodeType* tempPtr;
    tempPtr = listData;
    if (tempPtr == NULL)
        cout << "EMPTY LIST" << endl;
    else {
        while (tempPtr != NULL) {
            cout << tempPtr->info << " ";
            tempPtr = tempPtr->next;
        }
        cout << endl;
    }
    cout << endl;
}

void SortedType::ReverseList() {
    NodeType* current = listData;
    NodeType* prev = nullptr;
    NodeType* next = nullptr;

    while (current != nullptr) {
        next = current->next;
        current->next = prev;
        prev = current;
        current = next;
    }

    listData = prev;  // Update the head of the list
}

void SortedType::DeleteItem(string item) {
    // Pre:     item's key has been initialized.
    //          An element in the list has a key that matches item's.
    // Post:    No element in the list has a key that matches item's.
    NodeType* location = listData;
    NodeType* tempLocation;
    // Locate node to be deleted.
    if (item == listData->info) {
        tempLocation = location;
        listData = listData->next;
        // Delete first node.
    }
    else {
        while (!(item == (location->next)->info))
            location = location->next;
        // Delete node at location->next
        tempLocation = location->next;
        location->next = (location->next)->next;
    }
    delete tempLocation;
    length--;
}