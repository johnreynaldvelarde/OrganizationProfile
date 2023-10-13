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
        private long _StudentNo;

        public frmRegistration()
        {
            InitializeComponent();
        }

        public long StudentNumber(long studNum) 
        { 
            _StudentNo = studNum; 
            return _StudentNo;      
        }

        public long ContactNo(string Contact) 
        {
            try
            {
                if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
                {
                    _ContactNo = long.Parse(Contact);
                }
                else
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            finally
            {
                Console.WriteLine("Input 11 index or ");    
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
                frmConfirmation frm = new frmConfirmation();
                StudentInformationClass.SetFullName = FullName(txtLastName.Text, txtFirstName.Text, txtMiddleInitial.Text);
                StudentInformationClass.SetStudentNo = StudentNumber(Convert.ToInt64(txtStudentNo.Text));
                StudentInformationClass.SetProgram = cbPrograms.SelectedItem.ToString();
                StudentInformationClass.SetGender = cbGender.SelectedItem.ToString();
                StudentInformationClass.SetContactNo = (int)ContactNo(txtContactNo.Text);
                StudentInformationClass.SetAge = Age(txtAge.Text);
                StudentInformationClass.SetBirthDay = datePickerBirtday.Value.ToString("yyyy-MM-dd");
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
