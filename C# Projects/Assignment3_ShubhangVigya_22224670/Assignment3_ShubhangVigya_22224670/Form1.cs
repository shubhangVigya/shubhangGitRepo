using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Runtime.CompilerServices;
using System.IO;
using System.Transactions;
using System.Windows.Forms;
using System.Text;

namespace Assignment3_ShubhangVigya_22224670

{

    public partial class MadRoadForm : Form
    {
        public MadRoadForm()
        {
            InitializeComponent();
        }
        const string Password = "2Fast4U#";
        public const string FILE_NAME = "AuditOutput.txt";
        private string TransactionNumber = "";

        

        
        //Global Constant Variable
        const decimal Rate1Below40k = 0.06m, Rate3Below40k = 0.065m, Rate5Below40k = 0.07m, Rate7Below40k = 0.075m,
            Rate1Above40k = 0.08m, Rate3Above40k = 0.085m, Rate5Above40k = 0.09m, Rate7Above40k = 0.095m,
            Rate1Above80k = 0.085m, Rate3Above80k = 0.0875m, Rate5Above80k = 0.091m, Rate7Above80k = 0.0925m;
      
        private const decimal Range1MinimumBorrowing = 10000.0m, Range2MinimumBorrowing = 40000.0m, Range3MinimumBorrowing = 80000.0m, Range4MaximumBorrowing = 100000.0m;

        //Field Variable
        int IncorrectPasswordcount = 0, Term1 = 1, Term3 = 3, Term5 = 5, Term7 = 7, SelectedIndex = -1;
        decimal Borrowing, MonthlyInstallmentTermYr1= 0m, MonthlyInstallmentTermYr3 =0m, MonthlyInstallmentTermYr5=0m, MonthlyInstallmentTermYr7=0m, InterestPaidTerm1=0m, InterestPaidTerm3=0m, InterestPaidTerm5=0m, InterestPaidTerm7=0,
        MonthlyLoanInterestRateTermYr1 = 0m, MonthlyLoanInterestRateTermYr3 = 0m, MonthlyLoanInterestRateTermYr5 = 0m, MonthlyLoanInterestRateTermYr7 = 0m,
               FinalLoanRepaymentAmountTermYr1, FinalLoanRepaymentAmountTermYr3, FinalLoanRepaymentAmountTermYr5, FinalLoanRepaymentAmountTermYr7;
        decimal APRTerm1, APRTerm3, APRTerm5, APRTerm7, APRTerm;


        // String Format for ListBox Output
        string Format = "{0, -31}{1, -31}{2, -31}{3,-30}{4,-30}";

        //
        StreamReader dataStream;
        String line;


        private void Mad4RoadForm(object sender, EventArgs e)
        {
            // Initializing Form Load by Disabling and Enabling every Form Component
            PictureBoxPageLoad1.Visible = true;
            PictureBoxPageLoad2.Visible = true;
            PictureBoxPageLoad3.Visible = false;
            PasswordGrpBX.Visible = true;
            CatalogueGrpBX.Visible = false;
            SummaryGrpBX.Visible = false;
            CustDetailGrpBX.Visible = false;
            SearchGrpBX.Visible = false;
            SearchResultGrpBX.Visible = false;
            LogoutButton.Visible = false;
            ExitButton.Visible = false;

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            IncorrectPasswordcount++;
            if (PasswordTxtBx.Text == Password) // if condition when Password is matched
            {
                //Component that will be Visible after Login Button is Clicked
                CatalogueGrpBX.Visible = true;
                CustDetailGrpBX.Visible = true;
                SearchGrpBX.Visible = true;
                SearchResultGrpBX.Visible = true;
                SummaryGrpBX.Visible = true;              
                PictureBoxPageLoad3.Visible = true;
                PictureBoxPageLoad1.Visible = false;
                PictureBoxPageLoad2.Visible = false;
                PasswordGrpBX.Visible = false;
                LogoutButton.Visible = true;
                ExitButton.Visible = true;
                //SummaryGrpBX.Enabled = false;
                CustDetailGrpBX.Enabled = false;
                //SearchGrpBX.Enabled = false;
                //SearchResultGrpBX.Enabled = false;
            }
            else if (string.IsNullOrEmpty(PasswordTxtBx.Text))
            {
                // Display message when Password field is left empty
                MessageBox.Show(" Please Enter Login Password to Continue", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                PasswordTxtBx.Select();
                PasswordTxtBx.Focus();
            }
            else if (IncorrectPasswordcount == 1)
            {
                // Display message when password entered incorrect for the first time
                MessageBox.Show(" You have Entered Incorrect Password. Please Try Again !! \n                           (Only 1 Attempt left)", "Incorrect Password!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PasswordTxtBx.Text = string.Empty;
                PasswordTxtBx.Select();
                PasswordTxtBx.Focus();
            }
            else if (IncorrectPasswordcount ==2)
            {
               // Display message when user entered incorrect password for consecutive two times
                MessageBox.Show(" You have Entered Incorrect Password twice. Please Try again later !!", "Closing Application!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Close Application when Password is wrongly entered for two times
                this.Close();
            }
            

        }
        // calculation Method define for  Monthly Repayment 
        private decimal MonthlyInstallment(decimal MonthlyInterestRate, int TermMonth, decimal BorrowMoney)
        {
            
            return Math.Round(BorrowMoney * ((MonthlyInterestRate * (decimal)(Math.Pow(1 + (double)(MonthlyInterestRate), (double)(TermMonth)))) / (decimal)(Math.Pow(1 + (double)(MonthlyInterestRate), (double)(TermMonth)) - 1)), 2);
        }
        // Calculation Method define for Cost of the loan at the end of term
        private decimal FinalLoanAmount(decimal MonthlyInstallment, int TermMonth)
        {
            return Math.Round((MonthlyInstallment * TermMonth), 2);
        }

        private void DisplayButton_Click(object sender, EventArgs e)
        {
            // Local Variable         
            int MonthlyPaymentTermYr1 = Term1 * 12, // Converting Term into Months
                MonthlyPaymentTermYr3 = Term3 * 12, // Converting Term into Months
                MonthlyPaymentTermYr5 = Term5 * 12, // Converting Term into Months
                MonthlyPaymentTermYr7 = Term7 * 12; // Converting Term into Months

            if (decimal.TryParse(BorrowingTxtBX.Text, out Borrowing)) // Taking TextBox valur to variable
            {
                // Range for 10k to 40k
                if (Borrowing >= Range1MinimumBorrowing && Borrowing <= Range2MinimumBorrowing)
                {
                    MonthlyLoanInterestRateTermYr1 = (Rate1Below40k / 12);
                    MonthlyLoanInterestRateTermYr3 = (Rate3Below40k / 12);
                    MonthlyLoanInterestRateTermYr5 = (Rate5Below40k / 12);
                    MonthlyLoanInterestRateTermYr7 = (Rate7Below40k / 12);

                    APRTerm1 = Math.Round((Rate1Below40k * 100), 2); // Rounding Variable in 2 Decimal Value
                    APRTerm3 = Math.Round((Rate3Below40k * 100), 2);
                    APRTerm5 = Math.Round((Rate5Below40k * 100), 2);
                    APRTerm7 = Math.Round((Rate7Below40k * 100), 2);
                }
                // Range for 40k to 80k
                else if (Borrowing > Range2MinimumBorrowing && Borrowing <= Range3MinimumBorrowing)
                {
                    MonthlyLoanInterestRateTermYr1 = (Rate1Above40k / 12);
                    MonthlyLoanInterestRateTermYr3 = (Rate3Above40k / 12);
                    MonthlyLoanInterestRateTermYr5 = (Rate5Above40k / 12);
                    MonthlyLoanInterestRateTermYr7 = (Rate7Above40k / 12);

                    APRTerm1 = Math.Round((Rate1Above40k * 100), 2); // Rounding Variable in 2 Decimal Value
                    APRTerm3 = Math.Round((Rate3Above40k * 100), 2);
                    APRTerm5 = Math.Round((Rate5Above40k * 100), 2);
                    APRTerm7 = Math.Round((Rate7Above40k * 100), 2);
                }
                // Range for 80k to 100k
                else if (Borrowing > Range3MinimumBorrowing && Borrowing <= Range4MaximumBorrowing)
                {
                    MonthlyLoanInterestRateTermYr1 = Math.Round(Rate1Above80k / 12);
                    MonthlyLoanInterestRateTermYr3 = Math.Round(Rate3Above80k / 12);
                    MonthlyLoanInterestRateTermYr5 = Math.Round(Rate5Above80k / 12);
                    MonthlyLoanInterestRateTermYr7 = Math.Round(Rate7Above80k / 12);

                    APRTerm1 = Math.Round((Rate1Above80k * 100), 2); // Rounding Variable in 2 Decimal Value
                    APRTerm3 = Math.Round((Rate3Above80k * 100), 2);
                    APRTerm5 = Math.Round((Rate5Above80k * 100), 2);
                    APRTerm7 = Math.Round((Rate7Above80k * 100), 2);
                }
                else
                {
                    MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Calculation for Monthly Repayment
                MonthlyInstallmentTermYr1 = MonthlyInstallment(MonthlyLoanInterestRateTermYr1, MonthlyPaymentTermYr1, Borrowing);
                MonthlyInstallmentTermYr3 = MonthlyInstallment(MonthlyLoanInterestRateTermYr3, MonthlyPaymentTermYr3, Borrowing);
                MonthlyInstallmentTermYr5 = MonthlyInstallment(MonthlyLoanInterestRateTermYr5, MonthlyPaymentTermYr5, Borrowing);
                MonthlyInstallmentTermYr7 = MonthlyInstallment(MonthlyLoanInterestRateTermYr7, MonthlyPaymentTermYr7, Borrowing);

                //Calculation for Final cost of loan at the end of the term
                FinalLoanRepaymentAmountTermYr1 = FinalLoanAmount(MonthlyInstallmentTermYr1, MonthlyPaymentTermYr1);
                FinalLoanRepaymentAmountTermYr3 = FinalLoanAmount(MonthlyInstallmentTermYr3, MonthlyPaymentTermYr3);
                FinalLoanRepaymentAmountTermYr5 = FinalLoanAmount(MonthlyInstallmentTermYr5, MonthlyPaymentTermYr5);
                FinalLoanRepaymentAmountTermYr7 = FinalLoanAmount(MonthlyInstallmentTermYr7, MonthlyPaymentTermYr7);

                //Calculation of Total Interest paid
                InterestPaidTerm1 = FinalLoanRepaymentAmountTermYr1 - Borrowing;
                InterestPaidTerm3 = FinalLoanRepaymentAmountTermYr3 - Borrowing;
                InterestPaidTerm5 = FinalLoanRepaymentAmountTermYr5 - Borrowing;
                InterestPaidTerm7 = FinalLoanRepaymentAmountTermYr7 - Borrowing;

                DisplayLstBX.Items.Clear(); // CLearListbox

                // Output for Catalogue Listbox
                DisplayLstBX.Items.Add(string.Format(Format, "Term1", (APRTerm1+"%").ToString(), (MonthlyInstallmentTermYr1).ToString("C"), (InterestPaidTerm1).ToString("C"), (FinalLoanRepaymentAmountTermYr1).ToString("C")));
                DisplayLstBX.Items.Add(string.Format(Format, "Term3", (APRTerm3+"%").ToString(), (MonthlyInstallmentTermYr3).ToString("C"), (InterestPaidTerm3).ToString("C"), (FinalLoanRepaymentAmountTermYr3).ToString("C")));
                DisplayLstBX.Items.Add(string.Format(Format, "Term5", (APRTerm5+"%").ToString(), (MonthlyInstallmentTermYr5).ToString("C"), (InterestPaidTerm5).ToString("C"), (FinalLoanRepaymentAmountTermYr5).ToString("C")));
                DisplayLstBX.Items.Add(string.Format(Format, "Term7", (APRTerm7+"%").ToString(), (MonthlyInstallmentTermYr7).ToString("C"), (InterestPaidTerm7).ToString("C"), (FinalLoanRepaymentAmountTermYr7).ToString("C")));

            }
            else
            {
                // Message box when user has not made any selection for the Catalogue Listbox
                MessageBox.Show("Please Provide any selection for the available term period !!", "NO SELECTION MADE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayClearButton_Click(object sender, EventArgs e)
        {
            DisplayLstBX.Items.Clear(); // Clear entry for the Catalogue Listbox
            BorrowingTxtBX.Text = ""; // Reset user Input
            BorrowingTxtBX.Select();
            BorrowingTxtBX.Focus();

        }

        private string getUniqueRandomTransactionNumber() // Method to generate Unique Transaction Number
        {
         
            // Create an Object
            Random random = new Random();
            return random.Next(10000, 100000).ToString(); // Returns Random Value Between (10000, 100000)


        }

        private void ProceedButton_Click(object sender, EventArgs e)
        {
            // Enabling component when Proceed button is clicked
            

            SelectedIndex = DisplayLstBX.SelectedIndex;
            if (SelectedIndex  != -1) // when no selection for Catalogue Listbox has been made
            {
                TransactionNumber = getUniqueRandomTransactionNumber(); // Calling Unique transaction method and assigning it to variable
                SummaryGrpBX.Enabled = true;
                CustDetailGrpBX.Enabled = true;
                SearchGrpBX.Enabled = true;
                SearchResultGrpBX.Enabled = true;
            }
            else
            {
                MessageBox.Show("Please Provide any selection for the available term period !!", "NO SELECTION MADE", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            
            TransactionNumberLabel.Text = TransactionNumber.ToString(); // Display unique generated Transaction number to Label

        }
        private void CustDetailSubmitButton_Click(object sender, EventArgs e)
        {
            //Local Variables
            int TermSelectedIndex = 0, Term = 0; 

            decimal MonthlyInstallment = 0m, InterestPaid = 0m, FinalLoanRepaymentAmount = 0m;

            string Name, Phone, PostCode, Email = "", DialogString;

            // Assigning user input into Variable
            Name = ClientNameTxtBX.Text;
            Phone = PhoneNumTxtBX.Text;
            PostCode = EirTxtBX.Text;
            Email = EmailTxtBX.Text;          

            if (DisplayLstBX.SelectedIndex != -1) // when no selection is made
            {
                TermSelectedIndex = DisplayLstBX.SelectedIndex; // Assigning Index Value into variable
                switch(TermSelectedIndex)
                {
                    // Assigning value into variable when 0 index is selected by user
                    case 0:
                        Term =Term1; APRTerm = APRTerm1; MonthlyInstallment = MonthlyInstallmentTermYr1;
                        InterestPaid = InterestPaidTerm1; FinalLoanRepaymentAmount = FinalLoanRepaymentAmountTermYr1;
                        break;

                   // Assigning value into variable when First index is selected by user
                    case 1:
                        Term = Term1; APRTerm = APRTerm3; MonthlyInstallment = MonthlyInstallmentTermYr3;
                        InterestPaid = InterestPaidTerm3; FinalLoanRepaymentAmount = FinalLoanRepaymentAmountTermYr3;
                        break;
                    // Assigning value into variable when second index is selected by user
                    case 2:
                        Term = Term1; APRTerm = APRTerm5; MonthlyInstallment = MonthlyInstallmentTermYr5;
                        InterestPaid = InterestPaidTerm5; FinalLoanRepaymentAmount = FinalLoanRepaymentAmountTermYr5;
                        break;
                    // Assigning value into variable when third index is selected by user
                    case 3:
                        Term = Term1; APRTerm = APRTerm7; MonthlyInstallment = MonthlyInstallmentTermYr7;
                        InterestPaid = InterestPaidTerm7; FinalLoanRepaymentAmount = FinalLoanRepaymentAmountTermYr7;
                        break;
                }               
            }

            if (File.Exists(FILE_NAME))
            {
                //String Format for Loan Confirmation
                DialogString = String.Format("Hi " + Name + "\nPlease Confirm your Personal Details as you entered" + "\nAdress: " + PostCode + "\nPhone: " + Phone + "\nEmail: " + Email + "\nYour Transaction ID is: " + TransactionNumber + "\nYour Loan details are: " + "\nInterest Rate:  " + APRTerm +"%" + "\nMonthly Repayment Amount: " + MonthlyInstallment + "\nTotal Interest Payable: " + InterestPaid+ "\nTotal Cost of Loan: " + FinalLoanRepaymentAmount + "\nWould you like to submit your application?");



                if (MessageBox.Show(DialogString, "Mad4Road - Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    StreamWriter outputFile = File.AppendText(FILE_NAME); 

                    outputFile.WriteLine(TransactionNumber + "\n" + Name + "\n" + Email + "\n" + PostCode + "\n" + Phone + "\n" + Borrowing + "\n" + APRTerm + "\n" + Term + "\n" + MonthlyInstallment + "\n" + InterestPaid + "\n" + FinalLoanRepaymentAmount);
                    outputFile.Close(); // Close the Connection between output file


                }
                //reset form
            }
            else
            {
                MessageBox.Show("File Doesn't Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        
        private void SearchButton_Click(object sender, EventArgs e)
        {
           // Local variable
            string ClientName, Phone, PostCode, Email, TransactionNumber, BorrowedAmount, Term, InterestRate, MonthlyRepayment, TotalInterestPaid, TotalLoanCost;
            
            try
            {
                StreamReader FileSearch;
                FileSearch = File.OpenText(FILE_NAME);
                while (!FileSearch.EndOfStream)
                {
                    // Assigning values in the string from Audit file
                    TransactionNumber = FileSearch.ReadLine();
                    ClientName = FileSearch.ReadLine();
                    Email = FileSearch.ReadLine();
                    PostCode = FileSearch.ReadLine();
                    Phone = FileSearch.ReadLine();
                    BorrowedAmount = FileSearch.ReadLine();
                    Term = FileSearch.ReadLine();
                    InterestRate = FileSearch.ReadLine();
                    MonthlyRepayment = FileSearch.ReadLine();
                    TotalInterestPaid = FileSearch.ReadLine();
                    TotalLoanCost = FileSearch.ReadLine();

                    // Checks condition when Search Transaction radio buttons and Textbox entry matches the value entered by user
                    if (TransactionRadio.Checked && SearchEntryTxtBX.Text == TransactionNumber)
                    {
                        //Output for Search Listbox
                        SearchLstBX.Items.Add("Transaction Number" + TransactionNumber);                      
                        SearchLstBX.Items.Add("Name - " + ClientName);
                        SearchLstBX.Items.Add("Email - " + Email);
                        SearchLstBX.Items.Add("Address - " + PostCode);
                        SearchLstBX.Items.Add("Phone NO - " + Phone);
                        SearchLstBX.Items.Add("Borrowed Amount - " + BorrowedAmount);
                        SearchLstBX.Items.Add("Loan Terms in Years - " + Term);
                        SearchLstBX.Items.Add("Interest Rate - " + InterestRate);
                        SearchLstBX.Items.Add("Monthly Repayment - " + MonthlyRepayment);
                        SearchLstBX.Items.Add("Total Interest Paid - " + TotalInterestPaid);
                        SearchLstBX.Items.Add("Total Loan Cost - " + TotalLoanCost);
                        SearchLstBX.Items.Add("******************************************");
                    }
                    // Checks condition when Search Email radio buttons and Textbox entry matches the value entered by user
                    else if (EmailRadio.Checked && SearchEntryTxtBX.Text == Email)
                    {
                        //Output for Search Listbox
                        SearchLstBX.Items.Add("Transaction Number" + TransactionNumber);
                        SearchLstBX.Items.Add("Name - " + ClientName);
                        SearchLstBX.Items.Add("Email - " + Email);
                        SearchLstBX.Items.Add("Address - " + PostCode);
                        SearchLstBX.Items.Add("Phone NO - " + Phone);
                        SearchLstBX.Items.Add("Borrowed Amount - " + BorrowedAmount);
                        SearchLstBX.Items.Add("Loan Terms in Years - " + Term);
                        SearchLstBX.Items.Add("Interest Rate - " + InterestRate);
                        SearchLstBX.Items.Add("Monthly Repayment - " + MonthlyRepayment);
                        SearchLstBX.Items.Add("Total Interest Paid - " + TotalInterestPaid);
                        SearchLstBX.Items.Add("Total Loan Cost - " + TotalLoanCost);
                        SearchLstBX.Items.Add("******************************************");
                    }

                }
            }
            catch
            {
                // When no Matching Record found
                MessageBox.Show("No Matching Transaction Record Found", "No Match Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearSearchButton_Click(object sender, EventArgs e)
        {
            SearchLstBX.Items.Clear(); // Clear entry for the Search Listbox
            SearchEntryTxtBX.Text = ""; // Reset user Input
            SearchEntryTxtBX.Select();
            SearchEntryTxtBX.Focus();
        }

        private void SummaryButton_Click(object sender, EventArgs e)
        {
            //Local Variable
            int TotalTransactions = 0;
            decimal TotalBorrowing = 0, TotalInterest = 0, TotalTerms = 0;
            
            try
            {
                //Handle the textFile
                dataStream = File.OpenText(FILE_NAME);
                {
                    while (!dataStream.EndOfStream)
                    {

                        // Skips to 5th Index in Audit File
                        for (int i = 0; i <= 5; i++)
                        {
                            line = dataStream.ReadLine();
                        }
                        TotalTransactions++;
                        TotalBorrowing += decimal.Parse(line);
                        line = dataStream.ReadLine();
                        TotalTerms += decimal.Parse(line);
                        line = dataStream.ReadLine();
                        line = dataStream.ReadLine();
                        line = dataStream.ReadLine();
                        TotalInterest += decimal.Parse(line);
                        line = dataStream.ReadLine();


                    }
                    // Checks for any duplicate record in the data file
                    if (TotalTransactions != 0)
                    {
                        // Output for Summary labels
                        TotalBorrowingOutputSummaryLabel.Text = TotalBorrowing.ToString();
                        TotalInterestOutputSummaryLabel.Text = TotalInterest.ToString();
                        AvgBorrowingOutputSummaryLabel.Text = (TotalBorrowing / TotalTransactions).ToString();
                        AvgLoanPeriodOutputSummaryLabel.Text = (TotalTerms * 12 / TotalTransactions).ToString();


                    }

                }
            }
            catch
            {
                MessageBox.Show("File Read Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SummaryClearButton_Click(object sender, EventArgs e)
        {
            //Reset Summary Labels
            TotalBorrowingOutputSummaryLabel.Text = "##########";
            TotalInterestOutputSummaryLabel.Text = "##########";
            AvgBorrowingOutputSummaryLabel.Text = "##########";
            AvgLoanPeriodOutputSummaryLabel.Text = "##########";
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            Mad4RoadForm(sender, e); // Rollback to Formload page
            PasswordTxtBx.Text = "";
            PasswordTxtBx.Select();
            PasswordTxtBx.Focus();

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
             this.Close(); // Close the form
        }
    }
}