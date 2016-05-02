using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RoommateUtilityBreak
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //When the user selects 3 roommates, this runs
            if (comboBox1.Text == "3")
            {
                //runs a check to make sure all the fields are filled.
                //8-12-2015: Error occured when payment fields not filled. Add a check before things are processed
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
                {
                    MessageBox.Show("Error!! Please make sure fields are all filled");
                }
                //passed the check, running the app
                else
                {
                    //initialize variables
                    double average, pay1diff, pay2diff, pay3diff;
                    string[] nameArray = new string[3];
                    double[] paymentArray = new double[3];

                    label6.Visible = false;
                    //calling variables
                    nameArray[0] = textBox1.Text;
                    nameArray[1] = textBox3.Text;
                    nameArray[2] = textBox5.Text;
                    paymentArray[0] = Convert.ToDouble(textBox2.Text);
                    paymentArray[1] = Convert.ToDouble(textBox4.Text);
                    paymentArray[2] = Convert.ToDouble(textBox6.Text);
                    //label17.Text = nameArray[0] + " " + paymentArray[0];

                    //average calculation
                    average = ((paymentArray[0] + paymentArray[1] + paymentArray[2]) / 3);

                    //Bubble sort the payments and name array to match who paid what
                    int i, j, h;
                    double temp;
                    string temp2;
                    for (j = 0; j < paymentArray.Length - 1; j++)
                    {
                        for (i = 0; i < paymentArray.Length - 1; i++)
                        {
                            if (paymentArray[i] > paymentArray[i + 1])
                            {
                                temp = paymentArray[i];
                                paymentArray[i] = paymentArray[i + 1];
                                paymentArray[i + 1] = temp;
                                temp2 = nameArray[i];
                                nameArray[i] = nameArray[i + 1];
                                nameArray[i + 1] = temp2;
                            }
                        }
                    }
                    //check if it sorted as well as kept everything the same
                    //label17.Text = nameArray[0] + " " + paymentArray[0] + " | " + nameArray[1] + " " + paymentArray[1] + " | " + nameArray[2] + " " + paymentArray[2] + " | ";


                    //difference between the average and how much was paid
                    //this is useful for determining how much to pay back
                    pay1diff = (paymentArray[0] - average);
                    pay2diff = (paymentArray[1] - average);
                    pay3diff = (paymentArray[2] - average);


                    //*****THIS IS WHERE PEOPLE ARE LIKE OH MY GOSH, HOW DID MATH JUST HAPPEN?*****
                    //Shut up and take my money!
                    //when the middle payment equals the average, only the lowest payment person pays difference to the highest payment person
                    if (pay2diff == 0)
                    {
                        label9.Visible = false;
                        label6.Visible = true;
                        label14.Visible = false;
                        label6.Text = nameArray[0] + " pays $" + Math.Round(Math.Abs(pay1diff), 2) + " to " + nameArray[2];
                        label15.Visible = true;
                        label15.Text = "Average: $" + Math.Round(average, 2);
                    }

                    //when the middle payment is more than the average, the lowest payment person pays both the middle and highest back
                    else if (pay2diff > 0)
                    {
                        label6.Visible = true;
                        label9.Visible = true;
                        label14.Visible = false;
                        label6.Text = nameArray[0] + " pays $" + Math.Round(Math.Abs(pay2diff), 2) + " to " + nameArray[1];
                        label9.Text = nameArray[0] + " pays $" + Math.Round(Math.Abs(pay3diff), 2) + " to " + nameArray[2];
                        label15.Visible = true;
                        label15.Text = "Average: $" + Math.Round(average, 2);
                    }

                    //when the middle payment is less than the average, the lowest payment and middle payment people pay back the highest person
                    else if (pay2diff < 0)
                    {
                        label6.Visible = true;
                        label9.Visible = true;
                        label14.Visible = false;
                        label6.Text = nameArray[0] + " pays $" + Math.Round(Math.Abs(pay1diff), 2) + " to " + nameArray[2];
                        label9.Text = nameArray[1] + " pays $" + Math.Round(Math.Abs(pay2diff), 2) + " to " + nameArray[2];
                        label15.Visible = true;
                        label15.Text = "Average: $" + Math.Round(average, 2);
                    }
                }
            }

            //When the user selects 4 roommates, this runs.
            else if (comboBox1.Text == "4")
            {
                //runs a check to make sure all the fields are filled.
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "")
                {
                    MessageBox.Show("Error!! Please make sure fields are all filled");
                }
                //passed the check, running the app
                else
                {
                    //initialize variables
                     
                    double average, pay1diff, pay2diff, pay3diff, pay4diff;
                    string[] nameArray = new string[4];
                    double[] paymentArray = new double[4];

                    //calling variables
                    nameArray[0] = textBox1.Text;
                    nameArray[1] = textBox3.Text;
                    nameArray[2] = textBox5.Text;
                    nameArray[3] = textBox7.Text;
                    paymentArray[0] = Convert.ToDouble(textBox2.Text);
                    paymentArray[1] = Convert.ToDouble(textBox4.Text);
                    paymentArray[2] = Convert.ToDouble(textBox6.Text);
                    paymentArray[3] = Convert.ToDouble(textBox8.Text);

                    //average calculation
                    average = ((paymentArray[0] + paymentArray[1] + paymentArray[2] + paymentArray[3]) / 4);

                    //Nested Bubble sort the payments and name array to match who paid what
                    int i,j;
                    double temp;
                    string temp2;
                    for (j = 0; j < paymentArray.Length - 1; j++)
                    {
                        for (i = 0; i < paymentArray.Length - 1; i++)
                        {
                            if (paymentArray[i] > paymentArray[i + 1])
                            {
                                temp = paymentArray[i];
                                paymentArray[i] = paymentArray[i + 1];
                                paymentArray[i + 1] = temp;
                                temp2 = nameArray[i];
                                nameArray[i] = nameArray[i + 1];
                                nameArray[i + 1] = temp2;
                            }
                        }
                    }
                    //check if it sorted as well as kept everything the same
                    //label17.Text = nameArray[0] + " " + paymentArray[0] + " | " + nameArray[1] + " " + paymentArray[1] + " | " + nameArray[2] + " " + paymentArray[2] + " | " + nameArray[3] + " " + paymentArray[3] + " | " ;
                    
                    
                    //difference between the average and how much was paid
                    //this is useful for determining how much to pay back
                    pay1diff = (paymentArray[0] - average);
                    pay2diff = (paymentArray[1] - average);
                    pay3diff = (paymentArray[2] - average);
                    pay4diff = (paymentArray[3] - average);

                    //*****THIS IS WHERE PEOPLE ARE LIKE, OH MY GOSH HOW DID MATH JUST HAPPEN?******
                    //When the 2 middle bills equal the average, only the lowest bill pays the highest bill
                    if (pay2diff == 0 && pay3diff == 0)
                    {
                        label9.Visible = false;
                        label14.Visible = false;
                        label6.Visible = true;
                        label6.Text = nameArray[0] + " pays $" + Math.Round(Math.Abs(pay1diff), 2) + " to " + nameArray[3];
                        label15.Visible = true;
                        label15.Text = "Average: $" + Math.Round(average, 2);
                    }

                    //When the 2 middle bills are more than the average, the lowest bill pays everyone the difference
                    else if (pay2diff > 0 && pay3diff > 0)
                    {
                        label6.Visible = true;
                        label9.Visible = true;
                        label14.Visible = true;
                        label6.Text = nameArray[0] + " pays $" + Math.Round(Math.Abs(pay2diff), 2) + " to " + nameArray[1];
                        label9.Text = nameArray[0] + " pays $" + Math.Round(Math.Abs(pay3diff), 2) + " to " + nameArray[2];
                        label14.Text = nameArray[0] + " pays $" + Math.Round(Math.Abs(pay4diff), 2) + " to " + nameArray[3];
                        label15.Visible = true;
                        label15.Text = "Average: $" + Math.Round(average, 2);
                    }

                    //when the 2 middle bills are less than the average, everyone pays the highest bill
                    else if (pay2diff < 0 && pay3diff < 0)
                    {
                        label6.Visible = true;
                        label9.Visible = true;
                        label14.Visible = true;
                        label6.Text = nameArray[0] + " pays $" + Math.Round(Math.Abs(pay1diff), 2) + " to " + nameArray[3];
                        label9.Text = nameArray[1] + " pays $" + Math.Round(Math.Abs(pay2diff), 2) + " to " + nameArray[3];
                        label14.Text = nameArray[2] + " pays $" + Math.Round(Math.Abs(pay3diff), 2) + " to " + nameArray[3];
                        label15.Visible = true;
                        label15.Text = "Average: $" + Math.Round(average, 2);
                    }

                    //now this is where it gets difficult, and how thinking can help you out.
                    //all the scenarios i play out this works.
                    //lowest pays highest bill. there is some left over
                    //2nd bill pays that diff to highest
                    //2nd bill pays the rest to the 3rd.
                    else if (pay2diff < 0 && pay3diff > 0)
                    {
                        label6.Visible = true;
                        label9.Visible = true;
                        label14.Visible = true;
                        label6.Text = nameArray[0] + " pays $" + Math.Round(Math.Abs(pay1diff), 2) + " to " + nameArray[3];
                        label9.Text = nameArray[1] + " pays $" + Math.Round(Math.Abs(pay4diff) - Math.Abs(pay1diff), 2) + " to " + nameArray[3];
                        label14.Text = nameArray[1] + " pays $" + Math.Round(Math.Abs(pay3diff), 2) + " to " + nameArray[2];
                        label15.Visible = true;
                        label15.Text = "Average: $" + Math.Round(average, 2);

                    }
                }

            }

            else if (comboBox1.Text == "5")
            {
                //runs a check to make sure all the fields are filled.
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "")
                {
                    MessageBox.Show("Error!! Please make sure fields are all filled");
                }
                //passed the check, running the app
                else
                {
                    //initialize variables
                    double average, pay1diff, pay2diff, pay3diff, pay4diff, pay5diff;;
                    string[] nameArray = new string[5];
                    double[] paymentArray = new double[5];


                    //calling variables
                    nameArray[0] = textBox1.Text;
                    nameArray[1] = textBox3.Text;
                    nameArray[2] = textBox5.Text;
                    nameArray[3] = textBox7.Text;
                    nameArray[4] = textBox9.Text;
                    paymentArray[0] = Convert.ToDouble(textBox2.Text);
                    paymentArray[1] = Convert.ToDouble(textBox4.Text);
                    paymentArray[2] = Convert.ToDouble(textBox6.Text);
                    paymentArray[3] = Convert.ToDouble(textBox8.Text);
                    paymentArray[4] = Convert.ToDouble(textBox10.Text);

                    //average calculation
                    average = ((paymentArray[0] + paymentArray[1] + paymentArray[2] + paymentArray[3] + paymentArray[4]) / 5);

                    //Nested Bubble sort the payments and name array to match who paid what
                    int i, j;
                    double temp;
                    string temp2;
                    for (j = 0; j < paymentArray.Length - 1; j++)
                    {
                        for (i = 0; i < paymentArray.Length - 1; i++)
                        {
                            if (paymentArray[i] > paymentArray[i + 1])
                            {
                                temp = paymentArray[i];
                                paymentArray[i] = paymentArray[i + 1];
                                paymentArray[i + 1] = temp;
                                temp2 = nameArray[i];
                                nameArray[i] = nameArray[i + 1];
                                nameArray[i + 1] = temp2;
                            }
                        }
                    }

                    //check if it sorted as well as kept everything the same
                    //label17.Text = nameArray[0] + " " + paymentArray[0] + " | " + nameArray[1] + " " + paymentArray[1] + " | " + nameArray[2] + " " + paymentArray[2] + " | " + nameArray[3] + " " + paymentArray[3] + " | " + nameArray[4] + " " + paymentArray[4] + " | ";
                    //difference between the average and how much was paid
                    //this is useful for determining how much to pay back
                    pay1diff = (paymentArray[0] - average);
                    pay2diff = (paymentArray[1] - average);
                    pay3diff = (paymentArray[2] - average);
                    pay4diff = (paymentArray[3] - average);
                    pay5diff = (paymentArray[4] - average);

                    

                    //*****THIS IS WHERE PEOPLE ARE LIKE, OH MY GOSH HOW DID MATH JUST HAPPEN?******
                    //When the 3 middle bills equal the average, only the lowest bill pays the highest bill
                    if (pay2diff == 0 && pay3diff == 0 && pay4diff == 0)
                    {
                        label9.Visible = false;
                        label14.Visible = false;
                        label16.Visible = false;
                        label6.Visible = true;
                        label6.Text = nameArray[0] + " pays $" + Math.Round(Math.Abs(pay1diff), 2) + " to " + nameArray[4];
                        label15.Visible = true;
                        label15.Text = "Average: $" + Math.Round(average, 2);
                    }

                    //When the 3 middle bills are more than the average, the lowest bill pays everyone the difference
                    else if (pay2diff > 0 && pay3diff > 0 && pay4diff > 0)
                    {
                        label6.Visible = true;
                        label9.Visible = true;
                        label14.Visible = true;
                        label16.Visible = true;
                        label6.Text = nameArray[0] + " pays $" + Math.Round(Math.Abs(pay2diff), 2) + " to " + nameArray[1];
                        label9.Text = nameArray[0] + " pays $" + Math.Round(Math.Abs(pay3diff), 2) + " to " + nameArray[2];
                        label14.Text = nameArray[0] + " pays $" + Math.Round(Math.Abs(pay4diff), 2) + " to " + nameArray[3];
                        label16.Text = nameArray[0] + " pays $" + Math.Round(Math.Abs(pay5diff), 2) + " to " + nameArray[4];
                        label15.Visible = true;
                        label15.Text = "Average: $" + Math.Round(average, 2);
                    }

                    //when the 3 middle bills are less than the average, everyone pays the highest bill
                    else if (pay2diff < 0 && pay3diff < 0 && pay4diff < 0)
                    {
                        label6.Visible = true;
                        label9.Visible = true;
                        label14.Visible = true;
                        label16.Visible = true;
                        label6.Text = nameArray[0] + " pays $" + Math.Round(Math.Abs(pay1diff), 2) + " to " + nameArray[4];
                        label9.Text = nameArray[1] + " pays $" + Math.Round(Math.Abs(pay2diff), 2) + " to " + nameArray[4];
                        label14.Text = nameArray[2] + " pays $" + Math.Round(Math.Abs(pay3diff), 2) + " to " + nameArray[4];
                        label16.Text = nameArray[3] + " pays $" + Math.Round(Math.Abs(pay4diff), 2) + " to " + nameArray[4];
                        label15.Visible = true;
                        label15.Text = "Average: $" + Math.Round(average, 2);
                    }

                    //now this is where it gets difficult, and how thinking can help you out.
                    //there are three scenarios that happen here. (-)(+)(+) | (-)(-)(+) | (-)(N)(+)
                    //UPDATE 8-18-2015: the final scenario (-)(N)(+) still trying to find the working case, once in a blue moon case
                    //This is the (-)(+)(+) case
                    //test case 20, 24, 101, 102, 200 ==> confirmed
                    else if (pay2diff < 0 && pay3diff > 0 && pay4diff > 0)
                    {
                        label6.Visible = true;
                        label9.Visible = true;
                        label14.Visible = true;
                        label16.Visible = true;
                        double oneTofive = Math.Abs(pay5diff) - Math.Abs(pay1diff);
                        double twoTofive = Math.Abs(oneTofive) - Math.Abs(pay2diff);
                        double twoTofour = Math.Abs(twoTofive) - Math.Abs(pay4diff);
                        //label6.Text = nameArray[0] + " pays $" + Math.Round(Math.Abs(pay1diff), 2) + " to " + nameArray[4];
                        if (Math.Abs(pay5diff) > Math.Abs(pay1diff))
                        {
                            label6.Text = nameArray[0] + " pays $" + Math.Round(Math.Abs(pay1diff), 2) + " to " + nameArray[4];
                            label9.Text = nameArray[1] + " pays $" + Math.Round(Math.Abs(pay3diff), 2) + " to " + nameArray[2];
                            label14.Text = nameArray[1] + " pays $" + Math.Round(Math.Abs(pay4diff), 2) + " to " + nameArray[3];
                            label16.Text = nameArray[1] + " pays $" + Math.Round(Math.Abs(pay5diff) - Math.Abs(pay1diff), 2) + " to " + nameArray[4];
                        }
                        else if (Math.Abs(pay5diff) < Math.Abs(pay1diff))
                        {
                            label6.Text = nameArray[0] + " pays $" + Math.Round(Math.Abs(pay5diff), 2) + " to " + nameArray[4];
                            label9.Text = nameArray[0] + " pays $" + Math.Round(Math.Abs(oneTofive), 2) + " to " + nameArray[3];
                            label14.Text = nameArray[1] + " pays $" + Math.Round(Math.Abs((Math.Abs(oneTofive)-pay4diff)), 2) + " to " + nameArray[3];
                            label16.Text = nameArray[1] + " pays $" + Math.Round(Math.Abs(pay3diff), 2) + " to " + nameArray[2];
                        }
                        label15.Visible = true;
                        label15.Text = "Average: $" + Math.Round(average, 2);
                    }
                    //This is the (-)(-)(+) case
                    //test case 2, 24, 50, 102, 200 ==> confirmed
                    //test case 20, 24, 50, 102, 190 ==> confirmed
                    //test case 1, 24, 50, 102, 190 ==> confirmed
                    else if (pay2diff < 0 && pay3diff < 0 && pay4diff > 0)
                    {
                        label6.Visible = true;
                        label9.Visible = true;
                        label14.Visible = true;
                        label16.Visible = true;
                        double oneTofive = Math.Abs(pay5diff) - Math.Abs(pay1diff);
                        double twoTofive = Math.Abs(oneTofive) - Math.Abs(pay2diff);
                        double twoTofour = Math.Abs(twoTofive) - Math.Abs(pay4diff);
                        if (Math.Abs(pay5diff) < Math.Abs(pay1diff))
                        {
                            label6.Text = nameArray[0] + " pays $" + Math.Round(Math.Abs(pay5diff), 2) + " to " + nameArray[4];
                            label9.Text = nameArray[0] + " pays $" + Math.Round(Math.Abs(Math.Abs(pay5diff) - Math.Abs(pay1diff)), 2) + " to " + nameArray[3];
                            label14.Text = nameArray[1] + " pays $" + Math.Round(Math.Abs(pay2diff), 2) + " to " + nameArray[3];
                            label16.Text = nameArray[2] + " pays $" + Math.Round(Math.Abs(pay3diff), 2) + " to " + nameArray[3];
                        }
                        else if (Math.Abs(pay5diff) > Math.Abs(pay1diff))
                        {
                            label6.Text = nameArray[0] + " pays $" + Math.Round(Math.Abs(pay1diff), 2) + " to " + nameArray[4];
                            label9.Text = nameArray[1] + " pays $" + Math.Round(Math.Abs(Math.Abs(pay5diff) - Math.Abs(pay1diff)), 2) + " to " + nameArray[4];
                            label14.Text = nameArray[1] + " pays $" + Math.Round(Math.Abs(Math.Abs(Math.Abs(pay5diff) - Math.Abs(pay1diff) - Math.Abs(pay2diff))), 2) + " to " + nameArray[3];
                            label16.Text = nameArray[2] + " pays $" + Math.Round(Math.Abs(pay3diff), 2) + " to " + nameArray[3];
                        }
                        label15.Visible = true;
                        label15.Text = "Average: $" + Math.Round(average, 2);
                    }
                }
            }
        }

        //this resets the form to all blanks.
        private void button2_Click(object sender, EventArgs e)
        {
            label6.Visible = false;
            label9.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "3")
            {
                textBox7.Visible = false;
                textBox8.Visible = false;
                label10.Visible = false;
                //label8.Location = new Point(12, 122);
                button1.Location = new Point(54, 145);
                button2.Location = new Point(168, 145);
                textBox9.Visible = false;
                textBox10.Visible = false;
                label11.Visible = false;
            }

            else if (comboBox1.Text == "4")
            {

                textBox7.Visible = true;
                textBox8.Visible = true;
                label10.Visible = true;
                //label8.Location = new Point(12, 148);
                button1.Location = new Point(54, 172);
                button2.Location = new Point(168, 172);
                textBox9.Visible = false;
                textBox10.Visible = false;
                label11.Visible = false;
            }

            else if (comboBox1.Text == "5")
            {

                textBox7.Visible = true;
                textBox8.Visible = true;
                label10.Visible = true;
                
                

                textBox9.Visible = true;
                textBox10.Visible = true;
                label11.Visible = true;
                //label8.Location = new Point(12, 172);
                button1.Location = new Point(54, 195);
                button2.Location = new Point(168, 195);
               
                
            }

            else if (comboBox1.Text == "6")
            {
                MessageBox.Show("You need to find a different place to live. Sorry bud");
                comboBox1.Text = "5";
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label12.Text = "Version 0.0.1.1";
            // Version key: Prod.Beta.Test.Dev
        }

        
    }
}
