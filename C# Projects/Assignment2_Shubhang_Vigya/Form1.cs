
using Microsoft.VisualBasic.Devices;
using System.DirectoryServices.ActiveDirectory;

namespace Assignment2_Shubhang_Vigya
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Declaring Constant Field Variables
        const string COURSE1 = "C# Fundamentals", COURSE2 = "C# Basics for Beginners", COURSE3 = "C# Intermediate"
            , COURSE4 = "C# Advance Topics", COURSE5 = "ASP.NET with C# Part A", COURSE6 = "ASP.NET with C# Part B",
            Location1 = "Be Imullet", Location2 = "Clifden", Location3 = "Cork", Location4 = "Dublin",
            Location5 = "Killarney", Location6 = "Letterkenny", Location7 = "Sligo"; 

        

        const int C1TrainingDay = 2, C2TrainingDay = 4, C3TrainingDay = 4, C4TrainingDay = 2, C5TrainingDay = 5, C6TrainingDay = 5;


        const decimal COURSE1Fees = 900, COURSE2Fees = 1500, COURSE3Fees = 1800, COURSE4Fees = 2300, COURSE5Fees = 1250, COURSE6Fees = 1250,
                      Location1Fees = 219.99m, Location2Fees = 119.99m, Location3Fees = 149.99m, Location4Fees = 179.99m,
                      Location5Fees = 149.99m, Location6Fees = 89.99m, Location7Fees = 119.99m, UpgradeRate1 = 99.99m, UpgradeRate2 = 69.99m, UpgradeRate3 = 49.99m, CertifationFee = 39.99m;

        // Declaring Field Variables
             decimal TotalCourseCost, CostAfterDiscount, OptionalCost, LodgingCost, EnrollmentCost, FinalLodgingCost, EnrollmentCostSummary, LodgingCostSummary, OptionalCostSummary, GroupDiscountBooking,AverageRevenueSummary, FinalCourseCost = 0;

             int AttendeesNum = 0, TotalCompanyTransactions = 0 ;

             string Course = "", Location = "";







        private void Form1_Load(object sender, EventArgs e)
        {

            // Initializing Form Load by Disabling and Enabling every Form Component

            UserDetailPanel.Visible = true;
            CourseDetailPanel.Visible = false;
            CompamyPictureBox.Visible = false;          
            CompanySummaryGrpBX.Visible = false;          
            CourseReviewGrpBX.Visible = false;          
            UserDetailPanel.Enabled = true;
            CompanyPictureBox2.Visible = true;
            DiscountAppliedLabel.Visible = false;
            // .Focus to Keep Focus on Textbox
            NameInputTxtBX.Focus();
            AttendeesInputTxtBX.Text = "0"; // Initializing input textbox 
                      

        }

        private void Submit_Button_Click(object sender, EventArgs e)
        {
            // Component that will be Visible after Submit Button is clicked
            CompanyPictureBox2.Visible = false;
            CompamyPictureBox.Visible =true;
            UserDetailPanel.Enabled = false;
            CourseDetailPanel.Visible = true;
            SummaryButton.Enabled = false;
            BookButton.Enabled = false;

            // Parsing Attendee Number into Integer
            try
            {
                AttendeesNum = int.Parse(AttendeesInputTxtBX.Text);
                if (AttendeesNum >= 3)
                {
                    // Info for Customer to avail Room Upgrade if they are more than or equal to Three participant
                    MessageBox.Show(" You are eligible for group discount of 7.5% on this Purchase if you select Room Upgrade", "Hooray!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    // Info for Customer to avail Room Upgrade if they are less than three participant
                    MessageBox.Show(" Get Discount of 7.5% if number of Attendees are more than or equal to 3 and if you with our Room Upgrade option", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch
            {
                CourseDetailPanel.Visible = false;
                 // Infor for Cust if they enter value in wrong format   
                MessageBox.Show("Please enter valid number for Attendees!!", "Wrong Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AttendeesInputTxtBX.Focus();
                AttendeesInputTxtBX.SelectAll();
                
            }

        }
             
        private void Display_Button_Click(object sender, EventArgs e)
        {
            //Local Variable
            int CoursesIndex = 0, LocationIndex = 0;
            decimal EnrollmentFees = 0, TrainingDay = 0, AccommodationFee = 0;

            // Component that will be Visible after Display Button is clicked
            CourseReviewGrpBX.Visible = true;
            BookButton.Enabled = true;
            CompamyPictureBox.Visible = true;
            DiscountAppliedLabel.Visible = false;

            // Fetch user name details from textbox
            Name = NameInputTxtBX.Text;

            

            if ((CourseLstBX.SelectedIndex != -1)) // Validate if user have not selected any input from Course Listbox
            {
                if ((LocationLstBX.SelectedIndex != -1)) // Validate if user have not selected any input from Course Listbox
                {
                    
                        CoursesIndex = CourseLstBX.SelectedIndex;  
                        LocationIndex = LocationLstBX.SelectedIndex;
                        
                       switch (CoursesIndex) // Cases Within Index starting with Case 0
                        {
                            case 0: Course = COURSE1; TrainingDay = C1TrainingDay; EnrollmentFees = COURSE1Fees; break;
                            case 1: Course = COURSE2; TrainingDay = C2TrainingDay; EnrollmentFees = COURSE2Fees; break;
                            case 2: Course = COURSE3; TrainingDay = C3TrainingDay; EnrollmentFees = COURSE3Fees; break;
                            case 3: Course = COURSE4; TrainingDay = C4TrainingDay; EnrollmentFees = COURSE4Fees; break;
                            case 4: Course = COURSE5; TrainingDay = C5TrainingDay; EnrollmentFees = COURSE5Fees; break;
                            case 5: Course = COURSE6; TrainingDay = C6TrainingDay; EnrollmentFees = COURSE6Fees; break;
                            

                        }
                        switch (LocationIndex) // Cases Within Index starting with Case 0
                    {
                            case 0: Location = Location1; AccommodationFee = Location1Fees; break;
                            case 1: Location = Location2; AccommodationFee = Location2Fees; break;
                            case 2: Location = Location3; AccommodationFee = Location3Fees; break;
                            case 3: Location = Location4; AccommodationFee = Location4Fees; break;
                            case 4: Location = Location5; AccommodationFee = Location5Fees; break;
                            case 5: Location = Location6; AccommodationFee = Location6Fees; break;
                            case 6: Location = Location7; AccommodationFee = Location7Fees; break;


                        }
                    
                    EnrollmentCost = (EnrollmentFees * AttendeesNum); // Calculation for Course Cost
                    LodgingCost = (AccommodationFee * TrainingDay * AttendeesNum); // Calculation for Accommodation cost
                    
                    
                    
                    
                    if (MasterRadio.Checked == true) // Validate if first room upgrade is checked
                    {
                       
                        FinalLodgingCost = LodgingCost + (UpgradeRate1 * AttendeesNum * TrainingDay); // Upgrade Cost will add to different global variable
                        
                        

                    }
                    else if (ExecutiveRadio.Checked == true) // Validate if second room upgrade is checked
                    {
                        
                        FinalLodgingCost = LodgingCost + (UpgradeRate2 * AttendeesNum * TrainingDay); // Upgrade Cost will add to different global variable


                    }
                    else if (JuniorRadio.Checked == true) // Validate if third room upgrade is checked
                    {
                        
                        FinalLodgingCost = LodgingCost + (UpgradeRate3 * AttendeesNum * TrainingDay); //Upgrade Cost will add to different global variable

                    }
                    else if (NoUpgradeRadio.Checked == true) // When user havn't selected any room
                    {
                        
                        FinalLodgingCost = LodgingCost; // Upgrade cost will not be added 
                    }
                    else
                    {
                        MessageBox.Show("Please Select a Value for Optional Room Upgrade", "A CHOICE IS NEEDED", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Message box if No option room is selected
                    }
                    if (CertCheckBoxYes.Checked == true) //When Checbox is selected it will be added to Optional Cost
                    {
                        OptionalCost =  CertifationFee ; // Declared Certificate fee global variable 
                        
                        TotalCourseCost = EnrollmentCost + FinalLodgingCost + (CertifationFee * AttendeesNum); // Calculation for Total Course cost
                    }
                    else
                    {
                        TotalCourseCost = EnrollmentCost + FinalLodgingCost; 
                    }

                    if (MasterRadio.Checked || ExecutiveRadio.Checked || JuniorRadio.Checked && AttendeesNum >= 3)
                    {
                        CostAfterDiscount = TotalCourseCost - (TotalCourseCost * 0.075m); // Discount calculation 
                        DiscountAppliedLabel.Visible = true;
                    }
                    else
                    {
                        CostAfterDiscount = TotalCourseCost;
                    }

                    OptionalCost = TotalCourseCost - (EnrollmentCost + LodgingCost); // Calculation for Optional Cost

                     // Output value for Course Review
                    CourseSelectedTxtBX.Text = Course;
                    EnrollmentCostTxtBX.Text = EnrollmentCost.ToString("C");
                    LodgingCostTxtBX.Text = FinalLodgingCost.ToString("C");
                    OptionalCostTxtBX.Text = OptionalCost.ToString("C");
                    OverallCostTxtBX.Text = CostAfterDiscount.ToString("C");


                }
                
                else
                {
                    MessageBox.Show("Please Select a Location for your Course", "LOCATION SELECTION NEEDED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Please Select a Course", "COURSE SELECTION NEEDED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }
        private void Book_Button_Click(object sender, EventArgs e)
        {
            // Dialogue Box for Asking user Confirmation

            DialogResult BookingConfirmation = MessageBox.Show("you have selected the course  " + Course + "The location you have selected is  " + Location + "Your overall cost for the selected course will be " + FinalCourseCost, "Booking Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (BookingConfirmation == DialogResult.OK)
            {
               // Dialogue box for Confirmation of Booking
                DialogResult FinalConfirmation = MessageBox.Show("Hi " + Name + " Your Booking is Confirmed !! \nPlease Check your Email for Booking Confirmation","Booking Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SummaryButton.Enabled = true;
                CourseReviewGrpBX.Visible = false;
                DiscountAppliedLabel.Visible = false;
                TotalCompanyTransactions++;

                EnrollmentCostSummary = EnrollmentCostSummary + TotalCourseCost;
                LodgingCostSummary = LodgingCostSummary + FinalLodgingCost;
                OptionalCostSummary = OptionalCostSummary + OptionalCost;
                FinalCourseCost = FinalCourseCost + CostAfterDiscount;
                if (MasterRadio.Checked == true || ExecutiveRadio.Checked == true || JuniorRadio.Checked == true)
                {
                    GroupDiscountBooking = GroupDiscountBooking + 1;

                }
                else
                {
                    GroupDiscountBooking = 0;
                }
                
            }
            else
            {
                Display_Button_Click(sender, e); // Reset Display to Display Button

            }

           
        }
        private void Summary_Button_Click(object sender, EventArgs e)
        {
            CompanySummaryGrpBX.Visible = true;
            BookButton.Enabled = false;
            CompamyPictureBox.Visible = true;
            // Output for Company Summary

            AverageRevenueSummary = FinalCourseCost / TotalCompanyTransactions;
            TotalBookingsTxtBX.Text = TotalCompanyTransactions.ToString();
            TotalEnrollmentFeesTxtBX.Text = EnrollmentCostSummary.ToString("c");
            TotalLodgingFeesTxtBX.Text = LodgingCostSummary.ToString("c");
            TotalOptionalCostTxtBX.Text = OptionalCostSummary.ToString("c");
            TotalBookingWithGroupDiscountTxtBX.Text = GroupDiscountBooking.ToString();
            AverageRevenueTxtBX.Text = AverageRevenueSummary.ToString("c");


            
        }
        private void Clear_Button_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, e); // Reset to Form Lad Page
        }
        private void Exit_Button_Click(object sender, EventArgs e)
        {
            this.Close(); // Exit the application
        }







    }
}


           