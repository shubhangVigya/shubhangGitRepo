/* Student Name: Shubhang Vigya
   Student ID: 22224670
   Date: 29/09/22
   Assignment: Table Order App Pizza Bothan */


using System.ComponentModel.Design.Serialization;
using System.Linq.Expressions;

namespace Assignment1_Shubhang_Vigya
{
    public partial class PizzaBothán : Form
    {
        private const bool F = false;
        private const bool T = true;

        public PizzaBothán()
        {
            InitializeComponent();
            Menu_Grpbx.Visible = F;
            Order_Panel.Visible = F;
            Company_Grpbx.Visible = F;
            PictureBox2.Visible = F;
            TableOrder_Grpbx.Visible = F;
            PictureBox1.Visible = T;

        }
        //Field Variables

        int TotalNumberof_Transactions; 
        int TotalPizzaOrdered;       
        int Totalcompanytransactions = 0;
        decimal Final_Price, Total_price, Average_price;
        double HamRate = 7.99, PepperRate = 8.99, PineappleRate = 9.99, CalzoniRate = 11.99;

        private void StartButton_Click(object sender, EventArgs e)
        {
            Text = ServerName1_tb.Text + " @ table" + tablenumber_tb.Text;
            Menu_Grpbx.Visible = T;
            Order_Panel.Visible = T;
            Company_Grpbx.Visible = F;
            PictureBox2.Visible = T;
            TableOrder_Grpbx.Visible = F;
            PictureBox1.Visible = F;
            Server_Panel.Visible = F;
            Summary_button.Enabled = F;
            Ham_textbx.Focus();
            HamPrice.Visible =  T;
            PepperonioPrice.Visible = T;
            PineapplePrice.Visible = T;
            CalzoniPrice.Visible = T;  
            
            // To initialize the Value in Text Box
            Ham_textbx.Text = "0";
            Pineapple_textbx.Text = "0";
            Pepperonio_textbx.Text = "0";
            Calzoni_textbx.Text = "0";

            Ham_textbx.Focus();
            Ham_textbx.SelectAll();

            // To Update Label Price
            HamPrice.Text = "@ " + HamRate.ToString("C");
            PepperonioPrice.Text = "@ " + PepperRate.ToString("C");
            PineapplePrice.Text = "@ " + PineappleRate.ToString("C");
            CalzoniPrice.Text = "@ " + CalzoniRate.ToString("C");
           
        }

       

        private void Order_Button_Click(object sender, EventArgs e)
        {
            Order_Button.Enabled = F;
            Summary_button.Enabled = T;
            TableOrder_Grpbx.Visible = T;
            Company_Grpbx.Visible = F;
            Menu_Grpbx.Enabled = F;
            HamPrice.Visible = T;
            PepperonioPrice.Visible = T;
            PineapplePrice.Visible = T;
            CalzoniPrice.Visible = T;
            Totalcompanytransactions++;

            

            //Local Variables

            int QuantityHamP = 0, QuantityPepperonioP = 0, QuantityPineappleP = 0, QuantityCalzoni = 0;


            //Bring in User Input and store in declared Variables
            try
            {
                QuantityHamP = int.Parse(Ham_textbx.Text);


                //Bring in User Input and store in declared Variables
                try
                {
                    QuantityPepperonioP = int.Parse(Pepperonio_textbx.Text);


                    //Bring in User Input and store in declared Variables
                    try
                    {
                        QuantityPineappleP = int.Parse(Pineapple_textbx.Text);

                        //Bring in User Input and store in declared Variables
                        try
                        {
                            QuantityCalzoni = int.Parse(Calzoni_textbx.Text);

                            //Calculation for Table Order Summary Data
                            TotalPizzaOrdered = (QuantityHamP + QuantityPepperonioP + QuantityPineappleP + QuantityCalzoni);

                            Total_price = (decimal)((QuantityHamP * HamRate) + (QuantityPepperonioP * PepperRate) + (QuantityPineappleP * PineappleRate) + (QuantityCalzoni * CalzoniRate));

                            //Calculation for Company Summary Data
                            Final_Price += Total_price;
                            TotalNumberof_Transactions += TotalPizzaOrdered;
                            Average_price = Final_Price / Totalcompanytransactions;

                            //Form name changes to table summary when order is Clicked with correct input
                            Text = "Table Summary";




                        }
                        catch
                        {
                            TableOrder_Grpbx.Visible = F;
                            Summary_button.Enabled = F;
                            MessageBox.Show("Please enter Numerical Value for Calzoni Pizza's !!", "PizzaBothan - Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Menu_Grpbx.Enabled = T;
                            TableOrder_Grpbx.Visible = F;
                            Order_Button.Enabled = T;
                            
                            Calzoni_textbx.Focus();
                            Calzoni_textbx.SelectAll();
                            Text = ServerName1_tb.Text + " @ table" + tablenumber_tb.Text;
                            Totalcompanytransactions = Totalcompanytransactions - 1; // To Prevent record of invalid Order Clicks

                        }
                    }
                    catch
                    {
                        TableOrder_Grpbx.Visible = F;
                        Summary_button.Enabled = F;
                        MessageBox.Show("Please enter Numerical Value for Pineapple Pizza's !!", "PizzaBothan - Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Menu_Grpbx.Enabled = T;
                        TableOrder_Grpbx.Visible = F;
                        Order_Button.Enabled = T;                       
                        Pineapple_textbx.Focus();
                        Pineapple_textbx.SelectAll();
                        Text = ServerName1_tb.Text + " @ table" + tablenumber_tb.Text;
                        Totalcompanytransactions = Totalcompanytransactions - 1;
                    }
                }
                catch
                {
                    TableOrder_Grpbx.Visible = F;
                    Summary_button.Enabled = F;
                    MessageBox.Show("Please enter Numerical Value for Pepperonio Pizza's !!", "PizzaBothan - Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Menu_Grpbx.Enabled = T;
                    TableOrder_Grpbx.Visible = F;
                    Order_Button.Enabled = T;                  
                    Pepperonio_textbx.Focus();
                    Pepperonio_textbx.SelectAll();
                    Text = ServerName1_tb.Text + " @ table" + tablenumber_tb.Text;
                    Totalcompanytransactions = Totalcompanytransactions - 1;
                }
            }
            catch
            {
                TableOrder_Grpbx.Visible = F;
                Summary_button.Enabled = F;
                MessageBox.Show("Please enter Numerical Value for Ham Pizza's !!", "PizzaBothan - Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Menu_Grpbx.Enabled = T;
                TableOrder_Grpbx.Visible = F;
                Order_Button.Enabled = T;              
                Ham_textbx.Focus();
                Ham_textbx.SelectAll();
                Text = ServerName1_tb.Text + " @ table" + tablenumber_tb.Text;
                Totalcompanytransactions = Totalcompanytransactions - 1;
            }
            

            // Output for Table Order Summary Data
            ServerName2_tb.Text = ServerName1_tb.Text;
            totalpizzaOrdered_tb.Text = TotalPizzaOrdered.ToString();
            totaltableReceipts_tb.Text = Total_price.ToString("C");

            

        }

        private void Summary_Button_Click(object sender, EventArgs e)
        {
            Order_Button.Enabled = F;
            Summary_button.Enabled = F;
            Company_Grpbx.Visible = T;
            Menu_Grpbx.Visible = T;
            TableOrder_Grpbx.Visible = F;
            Text = "Company Summary Data";
            HamPrice.Visible = F;
            PepperonioPrice.Visible = F;
            PineapplePrice.Visible = F;
            CalzoniPrice.Visible = F;

            //Output for Company Summary Data
            totaltransaction_tb.Text = Totalcompanytransactions.ToString();
            totalpizzaOrdered2_tb.Text = TotalNumberof_Transactions.ToString();
            totalCompanyreceipts_tb.Text = Final_Price.ToString("C");
            avgtransaction_tb.Text = Average_price.ToString("C");
            

        }

        private void Clear_Button_Click(object sender, EventArgs e)
        {
            Order_Button.Enabled = T;
            Menu_Grpbx.Enabled = T;
            Server_Panel.Visible = T;
            Menu_Grpbx.Visible = F;
            Order_Panel.Visible = F;
            Company_Grpbx.Visible = F;
            TableOrder_Grpbx.Visible = F;
            PictureBox2.Visible = F;
            PictureBox1.Visible = T;


            Text = "Welcome To PizzaBothán";
            Ham_textbx.Text = "";
            Pepperonio_textbx.Text = "";
            Pineapple_textbx.Text = "";
            Calzoni_textbx.Text = "";
            ServerName1_tb.Text = "";
            tablenumber_tb.Text = "";

            ServerName1_tb.Focus();



        }
        private void Exit_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}