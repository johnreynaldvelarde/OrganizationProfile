using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrganizationProfile
{
    public partial class frmConfirmation : Form
    {
        

        public frmConfirmation()
        {
            InitializeComponent();
        }

        private void frmConfirmation_Load(object sender, EventArgs e)
        {
            lblName.Text = StudentInformationClass.SetFullName;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            
           // StudentInformationClass.SetFullName = FullName(txtLastName.Text, txtFirstName.Text, txtMiddleInitial.Text); 
           // StudentInformationClass.SetStudentNo = StudentNumber(txtStudentNo.Text); 
           //StudentInformationClass.SetProgram = cbPrograms.Text;
        }
    }
}
