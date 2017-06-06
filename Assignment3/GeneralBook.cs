using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class GeneralBook : Book
    {
        public GeneralBook(string title, string authors, int catalogNumber) : base(title, authors, catalogNumber)
        {

        }

        public override DateTime findDueDate()
        {
            return DateTime.Now.AddDays(7);
        }
    }
}
