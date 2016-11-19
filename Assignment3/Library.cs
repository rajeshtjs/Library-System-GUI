using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class Library
    {
        private Customer[] customerArray = new Customer[5];
        private Book[] bookArray = new Book[5];
        private int custId = 0;
        private int catalogNum = 100;

        public bool AddNewCustomer(string customerName)
        {
            custId = custId + 1;
            for (int i = 0; i < customerArray.Length; i++)
            {
                
                if (customerArray[i] == null)
                {
                    Customer c1 = new Customer(customerName, custId);
                    customerArray[i] = c1;
                    return true;

                }
                else continue;
            }
            return false;
        }

        public bool AddNewBook(string bookTitle, string bookAuthor)
        {
            catalogNum = catalogNum + 1;
            for (int x = 0; x < bookArray.Length; x++)
            {
                if (bookArray[x] == null)
                {
                    Book b1 = new Book(bookTitle, bookAuthor, catalogNum);
                    bookArray[x] = b1;
                    return true;
                }
                else continue;
            }
            return false;
        }

        public string ToString()
        {
            string s = "";
            for (int i = 0; i < customerArray.Length; i++)

            {
                if (customerArray[i] != null)
                {
                    s = s+customerArray[i].ToString()+"\n" ;
                }
            }
            s = s + "\n";

            for (int m = 0; m<bookArray.Length; m++)
            {
                if (bookArray[m] != null)
                {
                    s = s + bookArray[m].ToString()+"\n";
                }
            }
            return s;     
        }
    }

    
}
