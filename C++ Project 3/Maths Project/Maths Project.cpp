
#include <iostream>
#include <cmath>
using namespace std;
void PrimeFactor();
void DivAlg();
void ExtEucAlg();
void decryption();
void MatrixInversion3x3();
void question3();
int main()
{
    int option;
    cout << "**********************************************************************************************************************" << endl;
    cout << "*********************************************** MATHS PROJECT ********************************************************" << endl;
    cout << "**********************************************************************************************************************" << endl;
    cout << endl << endl << endl;
    do 
    {
        cout << "*********************************************** MENU BELOW ***********************************************************" << endl;
        cout << endl;
        cout << "Welcome to the program! Please select the option you would like to implement!" << endl;
        cout << endl;
        cout << "Option 1. Program for the Prime Factorization of a Natural Number." << endl;
        cout << endl;
        cout << "Option 2. Program for the Division Algorithm." << endl;
        cout << endl;
        cout << "Option 3. Program for the Extended Euclidean Algorithm." << endl;
        cout << endl;
        cout << "Option 4. Program for Inverting a 3x3 Matrix." << endl;
        cout << endl;
        cout << "Option 5. Exit." << endl;
        cout << endl;
        cout << "*********************************************** MENU ABOVE **********************************************************" << endl;
        cin >> option;
        switch (option)
        {
            case 1:
                PrimeFactor();
                break;
            case 2:
                DivAlg();
                break;
            case 3:
                question3();
                break;
            case 4:
                MatrixInversion3x3();
                break;
            case 5:
                break;
            default:
                cout << "Invalid option selected! Please select an option between 1 and 5 only!!" << endl;
                cout << endl;
                break;
        }
    } 
    while (option != 5);
    cout << endl;
    cout << "Thanks for using the program! Goodbye!" << endl;
  
}
void PrimeFactor()
{
    cout << endl;
    long long n, k = 2, temp;
    cout << "Please enter the natural number whose prime factors you would like to find: " << endl;
    cout << endl;
    cin >> n;
    cout << endl;
    cout << "The prime factor(s) are: ";
    while (sqrt(n) >= k)
    {
        temp = 0;
        if (n % k == 0)
        {
            temp = k;
            cout << temp << " ";
            n /= k;
        }
        else
        {
            k++;
        }
    }
    if (n != 1)
    {
        cout << n;
    }
    cout << endl << endl;
}

void DivAlg()
{
    cout << endl;
    int a, b, q, r, q1, r1, a1, b1;
    cout << "Please enter the dividend and the divisor: " << endl;
    cout << endl;
    cin >> a >> b;
    cout << endl;
    if (b != 0) 
    {

        if (b > a)
        {

            a1 = b;
            b1 = a;
            q = a / b;
            r = a % b;
            q1 = b / a;
            r1 = b % a;
            if (a < 0 && b < 0)
            {
                q += 1;
                q1 += 1;
                r = a - (b * q);
                r1 = b1 - (a1 * q1);

                cout << "The quotient is: " << q << " and the remainder is: " << r << ", but if a user input error occured and " << a << 
                    " was meant to be the divisor with " << b << " being the dividend, the quotient would be: " << q1 << " and the remainder would be: " << r1 << endl;
            }
            else
            {
                if (r >= 0)
                {
                    cout << "The quotient is: " << q << " and the remainder is: " << r << " but if a user input error occured and " << a <<
                        " was meant to be the divisor with " << b << " being the dividend, the quotient would be: " << q1 << " and the remainder would be: " << r1 << endl;
                }
                else
                {
                    q -= 1;
                    q1 -= 1;
                    r = a - (b * q);
                    r1 = b1 - (a1 * q1);
                    cout << "The quotient is: " << q << " and the remainder is: " << r << " but if a user input error occured and " << a <<
                        " was meant to be the divisor with " << b << " being the dividend, the quotient would be: " << q1 << " and the remainder would be: " << r1 << endl;
                }
            }
        }
        else 
        {
            q = 0;
            q = a / b;
            r = a % b;
            if (a < 0 && b < 0)
            {
                q += 1;
                r = a - (b * q);
                cout << "The quotient is: " << q << " and the remainder is: " << r << endl;
            }
            else
            {
                if (r >= 0)
                {
                    cout << "The quotient is: " << q << " and the remainder is: " << r << endl;
                }
                else
                {
                    q -= 1;
                    r = a - (b * q);
                    cout << "The quotient is: " << q << " and the remainder is: " << r << endl;
                }
            }
        }
    }
    else 
    {
        cout << "Error! The divisor must not be 0!" << endl;
    }
    cout << endl;
}

void question3()
{
    cout << endl << endl;
    int option;
    cout << "*********************************************** SUB-MENU BELOW ********************************************************" << endl;
    cout << "Option 3 has 2 sub-options! Please select one." << endl;
    cout << endl;
    cout << "Part 1. Greatest Common Divisor Calculator" << endl;
    cout << endl;
    cout << "Part 2. RSA Cryptosystem Decryption Key Calculator" << endl;
    cout << endl;
    cout << "*********************************************** SUB-MENU BELOW ********************************************************" << endl;
    cin >> option;
    switch (option)
    {
    case 1:
        ExtEucAlg();
        break;
    case 2:
        decryption();
        break;
    default:
        cout << "Invalid Option selected! Please select between parts 1 and 2!" << endl;
        break;
    }
}
void ExtEucAlg()
{
    cout << endl;
    int a, b, d, x, y, q, temp1, temp2, temp3, A1, A2, A3, B1, B2, B3;
    cout << "Please enter two positive integers: " << endl;
    cout << endl;
    cin >> a >> b;
    cout << endl;
    if (a > 0 && b > 0) 
    {
        if (a >= b)
        {
             A1 = 1, A2 = 0, A3 = a;
             B1 = 0, B2 = 1, B3 = b;
             while (B3 != 0)
             {
                 q = A3 / B3;
                 temp1 = A1 - q * B1;
                 temp2 = A2 - q * B2;
                 temp3 = A3 - q * B3;
                 A1 = B1;
                 A2 = B2;
                 A3 = B3;
                 B1 = temp1;
                 B2 = temp2;
                 B3 = temp3;
             }
             d = A3;
             x = A1;
             y = A2;
             cout << "The Greatest Common Divisor (gcd) = " << d << ", x = " << x << " and y = " << y << endl;
        }
        else
        {
            cout << "Error! The first integer must be greater than or equal to the second integer." << endl;
        }
    }
    else 
    {
        cout << "Error! Both integers must be greater than 0!" << endl;
    }
    cout << endl;
}

void decryption()
{
    cout << endl;
    int n, p, q, e, x, d, v;
    cout << "Please enter the values of p, q and e respectively: " << endl;
    cout << endl;
    cin >> p >> q >> e;
    cout << endl;
    n = p * q;
    x = (p - 1) * (q - 1);
    v = 1;
    while ((x * v + 1) % e != 0)
    {
        d = 0;
        d = ((x * v) + 1) / e;
        if ((x * v + 1) % e != 0)
        {
            v++;
        }
    }
    d = ((x * v) + 1) / e;
    cout << "The smallest possible decryption key is: " << d << " (and it occurs when v is: " << v << ")" << endl;
    cout << endl;
}

void MatrixInversion3x3()
{
    cout << endl;
    double a11, a12, a13, a21, a22, a23, a31, a32, a33, b, c, d, b11, b12, b13, b21, b22, b23, b31, b32, b33;
    cout << "Please enter the 9 elements in the 3x3 matrix: " << endl;
    cout << endl;
    cin >> a11 >> a12 >> a13 >> a21 >> a22 >> a23 >> a31 >> a32 >> a33;
    cout << endl;
    b = (a11 * a22 * a33) + (a12 * a23 * a31) + (a13 * a21 * a32) - (a13 * a22 * a31) - (a11 * a23 * a32) - (a12 * a21 * a33);
    if (b == 0)
    {
        cout << "ERROR: the matrix is not invertible." << endl;
    }
    else 
    {
        c = 1 / b;
        b11 = c * (a22 * a33 - a23 * a32);
        b12 = c * (a13 * a32 - a12 * a33);
        b13 = c * (a12 * a23 - a22 * a13);
        b21 = c * (a23 * a31 - a33 * a21);
        b22 = c * (a11 * a33 - a31 * a13);
        b23 = c * (a13 * a21 - a11 * a23);
        b31 = c * (a21 * a32 - a22 * a31);
        b32 = c * (a12 * a31 - a11 * a32);
        b33 = c * (a11 * a22 - a12 * a21);
        cout << "The inverse of the matrix provided is: " << endl;
        cout << b11 << " " << b12 << " " << b13 << endl;
        cout << b21 << " " << b22 << " " << b23 << endl;
        cout << b31 << " " << b32 << " " << b33 << endl;
    }
    cout << endl;
}

