// Program 3
// CIS 199-75
// Due: 4/11/2017
// Grading ID: C3527
// This program takes a user inputted last name, and based on their class standing
// will output the date and time that the student may registration for classes. 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void showDateButton_Click(object sender, EventArgs e)
        {
            const string TIME1 = "8:30";                            // Constant to hold first time
            const string TIME2 = "10:00";                           // Constant to hold second time
            const string TIME3 = "11:30";                           // Constant to hold third time
            const string TIME4 = "2:00";                            // Constant to hold fourth time
            const string TIME5 = "4:00";                            // Constant to hold fifth time

            const string SENIOR_DATE = "Wednesday, March 29th";     // Constant to hold the first date for seniors
            const string JUNIOR_DATE = "Thursday, March 30th";      // Constant to hold the first date for juniors
            const string SOPHOMORE_DATE_1 = "Friday, March 31st";   // Constant to hold the first possible date for sophomores
            const string SOPHOMORE_DATE_2 = "Monday, April 3rd";    // Constant to hold the second possible date for sophomores
            const string FRESHMAN_DATE_1 = "Tuesday, April 4th";    // Constant to hold the first possible date for freshman
            const string FRESHMAN_DATE_2 = "Wednesday, April 5th";  // Constant to hold the second possible date for freshman

            string lastName = lastNameTextBox.Text;             // Variable to hold the last name
            char lastNameLetter = char.ToUpper(lastName[0]);    // Variable to hold the first letter of the last name and changes it to lowercase
            bool isUpperClass;                                  // Variable to hold whether student is upper class

            if (char.IsLetter(lastNameLetter)) // Tests if the lastNameLetter variable is a letter
            {
                isUpperClass = (seniorButton.Checked || juniorButton.Checked);

                if (isUpperClass)
                {
                    if (seniorButton.Checked)
                        dateOutputLabel.Text = SENIOR_DATE;
                    else
                        dateOutputLabel.Text = JUNIOR_DATE;

                    char[] lastNameLowLimit = { 'A', 'E', 'J', 'P', 'T' };
                    string[] times = { TIME3, TIME4, TIME5, TIME1, TIME2 };
                    bool found = false;

                    int index = lastNameLowLimit.Length - 1; 

                    while (index >= 0 && !found)
                    {
                        if (lastNameLetter >= lastNameLowLimit[index])
                            found = true;
                        else
                            --index;
                    }
                    if (found)
                        timeOutputLabel.Text = times[index]; 
                }
                else // Must be sophomore/freshman
                {
                    if(sophomoreButton.Checked)
                    {
                        if ((lastNameLetter >= 'C') &&
                            (lastNameLetter <= 'O'))
                            dateOutputLabel.Text = SOPHOMORE_DATE_2;
                        else
                            dateOutputLabel.Text = SOPHOMORE_DATE_1;    
                    }
                    else
                    {
                        if ((lastNameLetter >= 'C') &&
                            (lastNameLetter <= 'O'))
                            dateOutputLabel.Text = FRESHMAN_DATE_2;
                        else
                            dateOutputLabel.Text = FRESHMAN_DATE_1;
                    }
                

                }

            }
             else
            {
                MessageBox.Show("Please enter your last name.");
            }
        }
    }
}
