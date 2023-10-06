using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrganizationProfile
{
    public partial class frmRegistration : Form
    {
        private string _FullName;
        private int _Age;
        private long _ContactNo;
        private string _StudentNo;

        public frmRegistration()
        {
            InitializeComponent();
        }

        public string StudentNumber(string studNum) 
        { 
            _StudentNo = studNum; 
            return _StudentNo;      
        }

        public long ContactNo(string Contact) 
        { 
            if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$")) 
            { 
                _ContactNo = long.Parse(Contact);
            } 
            return _ContactNo; 
        }

        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") || Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") || Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$")) 
            { 
                _FullName = LastName + ", " + FirstName + ", " + MiddleInitial; 
            }
            return _FullName;
        }

        public int Age(string age) 
        { 
            if (Regex.IsMatch(age, @"^[0-9]{1,3}$")) 
            { 
                _Age = Int32.Parse(age); 
            } 
            return _Age; 
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtStudentNo.Text) || String.IsNullOrEmpty(txtLastName.Text) || String.IsNullOrEmpty(txtFirstName.Text) 
                || String.IsNullOrEmpty(txtMiddleInitial.Text) || String.IsNullOrEmpty(txtAge.Text) || String.IsNullOrEmpty(txtContactNo.Text))
            {
                MessageBox.Show("Fill in the blank!!!");
            }
            else
            {
                _FullName = txtLastName.Text + txtFirstName.Text + txtMiddleInitial.Text;
                frmConfirmation frm = new frmConfirmation();
                frm.Show();

            }
        }



        private void frmRegistration_Load(object sender, EventArgs e)
        {
            string[] ListOfProgram = new string[] { "BS Information Technology",
                                                    "BS Computer Science",
                                                    "BS Information Systems",
                                                    "BS in Accountancy",
                                                    "BS in Hospitality Management",
                                                    "BS in Tourism Management" }; 
            for (int i = 0; i < 6; i++) 
            { 
                cbPrograms.Items.Add(ListOfProgram[i].ToString()); 
            }

            string[] listGender = new string[] { "Male", "Female" };
            
            for(int i = 0; i < 2; i++)
            {
                cbGender.Items.Add(listGender[i].ToString());
            }
        }

       
    }
}
