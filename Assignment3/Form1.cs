using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment3
{
    public partial class Form1 : Form
    {
        Library lib = new Library();
        private int temp1 = 0;
        private int temp2 = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Customer Name";
            button1.Enabled = true;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            label1.Text = "Title";
            textBox2.Enabled = true;
            textBox3.Enabled = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            label1.Text = "Title";
            textBox2.Enabled = true;
            textBox3.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isCustAdded = false;
            if (radioButton1.Checked)
            {
                button1.Enabled = true;
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Please enter the customer name");
                }
                else
                {
                    isCustAdded = lib.AddNewCustomer(textBox1.Text);
                    if (isCustAdded)
                    {
                        string[] customerDetails = lib.GetCustomerList();
                        listBox1.Items.Add(customerDetails[temp1]);
                        temp1++;
                    }
                    else
                    {
                        MessageBox.Show("You cant add more than 5 customers");
                        button1.Enabled = false;
                    }
                    textBox1.Clear();
                }
            }
            else if (radioButton2.Checked)
            {
                bool isBookAdded = false;
                if (textBox1.Text == "" && textBox2.Text == "")
                {
                    MessageBox.Show("Please enter the Title and Author");
                }
                else if (textBox1.Text == "")
                {
                    MessageBox.Show("Please enter the Title");
                }
                else if (textBox2.Text == "")
                {
                    MessageBox.Show("Please enter the Author's name");
                }
                else
                {
                    isBookAdded = lib.AddNewBook(textBox1.Text, textBox2.Text);
                    if (isBookAdded)
                    {
                        string[] bookDetails = lib.GetBooksList();
                        listBox2.Items.Add(bookDetails[temp2]);
                        temp2++;

                    }
                    else
                    {
                        MessageBox.Show("You cant add more than 5 Books");
                        button1.Enabled = false;
                    }
                    textBox1.Clear();
                    textBox2.Clear();
                }
            }
            else if (radioButton3.Checked)
            {

                bool isBookAdded = false;
                if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "")
                {
                    MessageBox.Show("Please enter the Title, Author and Edition");
                }
                else if (textBox2.Text == "" && textBox3.Text == "")
                {
                    MessageBox.Show("Please enter the Author and Edition");
                }
                else if (textBox1.Text == "")
                {
                    MessageBox.Show("Please enter the Title");
                }
                else if (textBox2.Text == "")
                {
                    MessageBox.Show("Please enter the Author");
                }
                else if (textBox3.Text == "")
                {
                    MessageBox.Show("Please enter the Edition");
                }
                else
                {
                    isBookAdded = lib.AddNewBook(textBox1.Text, textBox2.Text, Int32.Parse(textBox3.Text));
                    if (isBookAdded)
                    {
                        string[] bookDetails = lib.GetBooksList();
                        listBox2.Items.Add(bookDetails[temp2]);
                        temp2++;
                    }
                    else
                    {
                        MessageBox.Show("You cant add more than 5 Books");
                        button1.Enabled = false;
                    }
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a customer from the Customers List");
            }
            else if (listBox2.SelectedItem == null)
            {
                MessageBox.Show("Please select a Book from the Books List");
            }
            else
            {
                // Issuing Books           
                int cust_ID = 0;
                int catalogNo = 0;


                //Finding cust id from listbox 1
                string customerListBoxString = listBox1.SelectedItem.ToString();
                var customerStringParts = customerListBoxString.Split(' ');

                string custId = customerStringParts[0];


                if (custId != null || custId != "")
                    cust_ID = Convert.ToInt32(custId);

                string bookListBoxString = listBox2.SelectedItem.ToString();
                var bookStringParts = bookListBoxString.Split(' ');

                string bookCatNo = bookStringParts[0];


                if (bookCatNo != null || bookCatNo != "")
                    catalogNo = Convert.ToInt32(bookCatNo);

                if (cust_ID > 0 && catalogNo > 0)
                {
                    bool isbookIssued = false;
                    listBox2.Items.Clear();
                    isbookIssued = lib.IssueBook(cust_ID, catalogNo);

                    if (isbookIssued)
                    {
                        string[] bookList = lib.GetBooksList();

                        for (int i = 0; i < bookList.Length; i++)
                        {
                            if (bookList[i] != null)
                            {
                                listBox2.Items.Add(bookList[i]);
                            }
                        }
                    }
                    else
                    {
                        string[] bookList = lib.GetBooksList();

                        for (int i = 0; i < bookList.Length; i++)
                        {
                            if (bookList[i] != null)
                            {
                                listBox2.Items.Add(bookList[i]);
                            }
                        }
                        MessageBox.Show("Sorry! We cant issue the book");
                    }
                }
                else
                {
                    string[] bookList = lib.GetBooksList();
                    for (int i = 0; i < bookList.Length; i++)
                    {
                        if (bookList[i] != null)
                        {
                            listBox2.Items.Add(bookList[i]);
                        }
                    }
                    MessageBox.Show("Sorry! We cant issue the book");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem == null)
            {

                MessageBox.Show("Please select a book from the Books List to return");
            }
            else
            {
                int bookCatalogNo = 0;
                string bookListBoxString = listBox2.SelectedItem.ToString();
                var bookStringParts = bookListBoxString.Split(' ');

                string bookCatNo = bookStringParts[0];


                if (bookCatNo != null || bookCatNo != "")
                    bookCatalogNo = Convert.ToInt32(bookCatNo);

                if (bookCatalogNo > 0)
                {
                    bool isbookReturned = false;
                    listBox2.Items.Clear();
                    isbookReturned = lib.ReturnBook(bookCatalogNo);

                    if (isbookReturned)
                    {

                        string[] bookList = lib.GetBooksList();

                        for (int i = 0; i < bookList.Length; i++)
                        {
                            if (bookList[i] != null)
                            {
                                listBox2.Items.Add(bookList[i]);
                            }
                        }
                    }
                    else
                    {
                        string[] bookList = lib.GetBooksList();
                        for (int i = 0; i < bookList.Length; i++)
                        {
                            if (bookList[i] != null)
                            {
                                listBox2.Items.Add(bookList[i]);
                            }
                        }
                        MessageBox.Show("Sorry! You cant return the book");
                    }
                }

                else
                {
                    string[] bookList = lib.GetBooksList();

                    for (int i = 0; i < bookList.Length; i++)
                    {
                        if (bookList[i] != null)
                        {
                            listBox2.Items.Add(bookList[i]);
                        }
                    }
                    MessageBox.Show("Sorry! You cant return the book");
                }
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem == null)
            {
                MessageBox.Show("Please select a book from the Books List to Renew!");
            }
            else
            {
                int bookCatalogNo = 0;
                string bookListBoxString = listBox2.SelectedItem.ToString();
                var bookStringParts = bookListBoxString.Split(' ');
                string bookcNo = bookStringParts[0];
                if (bookcNo != null || bookcNo != "")
                    bookCatalogNo = Convert.ToInt32(bookcNo);
                
                /* Renewing the book */

                if (bookCatalogNo > 0)
                {
                    bool renewBook = false;
                    listBox2.Items.Clear();
                    renewBook = lib.RenewBook(bookCatalogNo);

                    if (renewBook)
                    {
                        string[] bookList = lib.GetBooksList();

                        for (int i = 0; i < bookList.Length; i++)
                        {
                            if (bookList[i] != null)
                            {
                                listBox2.Items.Add(bookList[i]);
                            }
                        }
                    }
                    else
                    {
                        string[] bookList = lib.GetBooksList();
                        for (int i = 0; i < bookList.Length; i++)
                        {
                            if (bookList[i] != null)
                            {
                                listBox2.Items.Add(bookList[i]);
                            }
                        }
                        MessageBox.Show("Sorry! We cant renew the book");
                    }
                }
                else
                {
                    string[] bookList = lib.GetBooksList();
                    for (int i = 0; i < bookList.Length; i++)
                    {
                        if (bookList[i] != null)
                        {
                            listBox2.Items.Add(bookList[i]);
                        }
                    }

                    MessageBox.Show("Sorry! We cant renew the book");
                }
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();

            }

        }
    }
}
