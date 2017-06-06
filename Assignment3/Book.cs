using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    abstract class Book
    {
        private int catalogNumber;
        private string title;
        private string authors;
        protected Customer c;
        protected DateTime dueDate;
        bool available = false;

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

        public override  string ToString() 
        {
            string s;
            if (this.c == null)
            {
                s = "\tAvailable";
            }
            else
            {
                s = "\tChecked out to Customer" + " " + c.Id + " " + "Due on" + " " + dueDate;
            }
            return String.Format("{0,-6}{1,-22}{2,-15}{3,-60}", catalogNumber, title, authors, s);
        }

        public abstract DateTime findDueDate();
       
        public bool CheckOut(Customer c)
        {            
            if (this.c == null)
            {
                this.c = c;
                this.dueDate = findDueDate();
                return true;
            }
            else
            {
                return false;
            }
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
