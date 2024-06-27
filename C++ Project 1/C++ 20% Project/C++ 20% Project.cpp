#include <iostream>
#include "project.h"
#include <string>
#include <fstream>
using namespace std;

int menu();
void inputFromKeyboard(SortedType& st);
void print(SortedType st);
void inputFromFile(SortedType& st);

int main()
{
    ifstream in_file("input.txt");
    int option = 0;
    string item;
    SortedType st1;
    SortedType st2;
    SortedType st3;

    do
    {
        option = menu();
        switch (option)
        {
        case 1:
            inputFromFile(st1);
            break;
        case 2:
            inputFromKeyboard(st2);
            break;
        case 3:
            st3.CombineLists(st1, st2);
            break;
        case 4:
            cout << "List 1: " << endl;
            print(st1);
            cout << "List 2: " << endl;
            print(st2);
            cout << "List 3: " << endl;
            print(st3);
            break;
        case 5:
            st3.ReverseList();
            break;
        case 6:
            cout << "Enter the item you would like to delete" << endl;
            cin >> item;
            st3.DeleteItem(item);
            break;
        case 7:
            break;
        default:
            cout << "Invalid Option! Please select an option between 1 and 7." << endl;
            break;
        }
    } while (option != 7);
    cout << "Thank you for using the program! Goodbye!" << endl;

}

int menu()
{
    int input;
    cout << "Please enter the option you would like to implement" << endl;
    cout << "Option 1. Input strings to ordered linked list (from file)." << endl;
    cout << "Option 2. Input strings to ordered linked list (from the keyboard)." << endl;
    cout << "Option 3. Populate 3rd list with strings from Option 1 and 2" << endl;
    cout << "Option 4. Print all lists" << endl;
    cout << "Option 5. Reverse the items in the list from Option 3." << endl;
    cout << "Option 6. Delete string from list in Option 3." << endl;
    cout << "Option 7. Exit" << endl;
    cin >> input;
    return input;
}

void inputFromFile(SortedType& st)
{
    string temp;
    ifstream in_file("input.txt");
    while (!in_file.eof())
    {
        in_file >> temp;
        st.InsertItem(temp);
    }
}

void inputFromKeyboard(SortedType& st)
{
    string temp;
    cout << "Please type in a word strings: " << endl;
    cin >> temp;
    st.InsertItem(temp);
}

void print(SortedType st)
{
    st.PrintList();
}