using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class TextBook : Book, IRenewable
    {
        private int edition;

        public TextBook(string title, string authors, int edition, int catalogNo) : base(title, authors, catalogNo)
        {
            this.edition = edition;
        }

        public override DateTime findDueDate()
        {
            return DateTime.Now.AddMonths(1);
        }

        public bool Renew()
        {
            if (this.c == null)
            {
                return false;
            }
            else
            {
                dueDate = dueDate.AddDays(15);
                return true;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("{0,-12}", "\tEdition:" + edition);
        }
    }
}
