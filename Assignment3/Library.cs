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

        public string[] GetCustomerList()
        {
            string[] customerDetails = new string[5];

            for (int i = 0; i < customerDetails.Length; i++)
            {
                if (customerArray[i] != null)
                    customerDetails[i] = customerArray[i].ToString();

            }
            return customerDetails;
        }

        public string[] GetBooksList()
        {
            string[] bookDetails = new string[5];

            for (int i = 0; i < bookDetails.Length; i++)
            {
                if (bookArray[i] != null)
                {
                    bookDetails[i] = bookArray[i].ToString();
                }
            }
            return bookDetails;
        }

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
                    bookArray[x] = new GeneralBook(bookTitle, bookAuthor, catalogNum);
                    
                    return true;
                }
            }
            return false;
        }

        public bool AddNewBook(string bTitle, string bAuthor, int edition)
        {
            catalogNum++;
            for (int i = 0; i < bookArray.Length; i++)
            {
                if (bookArray[i] == null)
                {
                    bookArray[i] = new TextBook(bTitle, bAuthor, edition, catalogNum);
                    return true;
                }
            }
            return false;
        }

        public bool IssueBook(int custId, int bookCatalogNum)
        {

            for (int i = 0; i < bookArray.Length; i++)
            {
                if (bookArray[i] != null && bookArray[i].CatalogNumber == bookCatalogNum)
                {
                    for (int j = 0; j < customerArray.Length; j++)
                    {
                        if (customerArray[j] != null && customerArray[j].Id == custId)
                        {
                            return bookArray[i].CheckOut(customerArray[j]);

                        }
                    }
                }
            }
            return false;
        }

        public bool ReturnBook(int bookCatalogNum)
        {
            for (int i = 0; i < bookArray.Length; i++)
            {
                if (bookArray[i] != null && bookArray[i].CatalogNumber == bookCatalogNum)
                {
                    return bookArray[i].CheckIn();

                }

            }
            return false;
        }

        public bool RenewBook(int bookCatalogNum)
        {
            for (int i = 0; i < bookArray.Length; i++)
            {
                if (bookArray[i] != null && bookArray[i].CatalogNumber == bookCatalogNum && bookArray[i] is IRenewable)
                {
                    return ((IRenewable)bookArray[i]).Renew();
                }
            }
            return false;
        }


        public override string ToString()
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
