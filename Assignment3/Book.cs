using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class Book
    {
        private int catalogNumber;
        private string title;
        private string authors;
        Customer c;
        bool available;

        public int CatalogNumber
        {
            get { return catalogNumber; }
        }

        public Book(string title, string authors, int catalogNo)
        {
            this.title = title;
            this.authors = authors;
            this.catalogNumber = catalogNo;
        }

        public string ToString() 
        {
            string s =String.Format( "{0,-5}{1,-20}{2,-10}",catalogNumber,title ,authors);
            if(this.c == null)
            {
                s = s + "\tAvailable";
            }
            else if (available == true)
            {
                s = s + "\tAvailable";
            }
            else if (available == false)
            {
                s = s + "\tChecked out to Customer" +" "+ c.Id;
            }
            return s;
        }

        public bool CheckOut(Customer c)
        {            
            if (this.c == null)
            {
                this.c = c;
                available = true;
            }
            else
            {
                available = false;
            }
            return available;
        }

        public bool CheckIn()
        {
            if(this.c!=null)
            {
                this.c = null;
                return true;
            }
            else
            {
                return false;
            }            
        }
    }
}
