using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Assignment4_ShubhangVigya_22224670
{
    public partial class MBSI : Form
    {

        const decimal CinnamonBagelPrice = 7.0m, ChoclateBagelPrice = 8.0m, PizzaBagelPrice = 9.0m, PlainBagelPrice = 10.0m, WheatHoneyBagelPrice = 11.0m,
                      JalapinoCheddarBegalPrice = 12.0m, SweetonionBagelPrice = 13.0m, EverythingGarlicBaglePrice = 14.0m, PoppyBagelPrice = 15.0m, MultiseedBaglePrice = 16.0m, CranberryBaglePrice = 17.0m,
                      SesameBagelPrice = 18.0m, ExclusiveRosemaryBaglePrice = 20.0m;

        // int StockBagel1 = 100, StockBagel2 = 100, StockBagel3 = 100, StockBagel4 = 100, StockBagel5 = 100, StockBagel6 = 100, StockBagel7 = 100, StockBagel8 = 100, StockBagel9 = 100, StockBagel10 = 100,
        //    StockBagel11 = 100, StockBagel12 = 100, StockBagel13 = 100
        int StockBagelSelected = 20, AddToOdrder = 0;
        string BagelName = "", Size = "";

        private static String[] BagelNames = { "Cinnamon Bagel", "Choclate Bagel", "Pizza Bagel", "Plain Bagel", "WheatHoney Bagel", "Jalapino Cheddar Bagel", "Sweet Onion Bagel", "Everything Garlic Bagel", "Poppy Bagel", "Multiseed Bagel", "Cranberry Bagel", "Sesame Bagel", "Exclusive Rosemary Bagel" };
        private static String[] BagleSize = { "Extra Small", "Small", "Medium", "Large", "Extra Large" };
        private static String[] BagleSizeAbbreviated = { "XS", "S", "M", "L", "XL" };
        /*private static decimal[,] BagelPrices =
        {
            {7m, 8m, 9m, 10m, 11m},
            {8m, 9m, 10m, 11m, 12m},
            {9m, 10m, 11m, 12m, 13m},
            {10m, 11m, 12m, 13m, 14m},
            {11m, 12m, 13m, 14m, 15m},
            {12m, 13m, 14m, 15m, 16m},
            {13m, 14m, 15m, 16m, 17m},
            {14m, 15m, 16m, 17m, 18m},
            {15m, 16m, 17m, 18m, 19m},
            {16m, 17m, 18m, 19m, 20m},
            {17m, 18m, 19m, 20m, 21m},
            {18m, 19m, 20m, 21m, 22m},
            {20m, 21m, 22m, 23m, 24m}
        }; */
        private int[,] StockLevels =
        {
            { 20,20,20,20,20},
            { 20,20,20,20,20},
            { 20,20,20,20,20},
            { 20,20,20,20,20},
            { 20,20,20,20,20},
            { 20,20,20,20,20},
            { 20,20,20,20,20},
            { 20,20,20,20,20},
            { 20,20,20,20,20},
            { 20,20,20,20,20},
            { 20,20,20,20,20},
            { 20,20,20,20,20},
            { 20,20,20,20,20}
        };

        private int[,] BaglesStock = new int[BagelNames.Length, BagleSize.Length];

        const int TRANSACTIONNOPOSITION = 0, DATEPOSITION = 1, ORDERTOTALPOSITION = 2, FIRSTLINEITEMPOSITION = 3;

        

        private int BagelNameIndex, BagelSizeIndex, OrderedItems = 0;

        private const char SEPARATOR = ',';

        private decimal RunningTotal;

        private const string TRANSACTIONFILE = "Transaction.txt";
        private const string PRICEFILE = "PriceDB.txt";
        private const string STOCKFILE = "BagelStockDB.txt";
        public const string ReceiptFile = "ReceiptDB.txt";
        private String Receipt;

        private List<int[]> OrderedItemsList;

        const int ROWPOSITION = 0, COLPOSITION = 1, QUANTITYPOSITION = 2;


        const decimal EXTRASMALLBAGELPRICE = 0.0m, SMALLBAGELPRICE = 1.0m, MEDIUMBAGELPRICE = 2.0m, LARGEBAGELPRICE = 3.0m, EXTRALARGEBAGELPRICE = 4.0m;


        decimal BAGELPRICE = 0m, BAGELSIZEPRICE = 0m, FINALBAGELPRICE = 0, TOTALBAGELPRICE = 0m;

        int NumberOfBaglesOrdered, QuantityOfBaglesOrdered = 0;
        public MBSI()
        {
            InitializeComponent();
        }

        private void MBSI_Load(object sender, EventArgs e)
        {
            OrderedItemsList = new List<int[]>();

            ScrollPanel.Height = OrderButton.Height;
            ScrollPanel.Top = OrderButton.Top;

            int count1 = 0, count2 = 0, count3 = 0;
            string line;

            System.IO.StreamReader file, BagelPrice, BagelNumber;

            file = new System.IO.StreamReader("BagelsDatabase.txt");
            while ((line = file.ReadLine()) != null)
            {
                BagleListbox.Items.Add(line);
                count1++;
            }

            BagelPrice = new System.IO.StreamReader("BaglePriceDatabase.txt");
            while ((line = BagelPrice.ReadLine()) != null)
            {
                BaglePriceListBox.Items.Add(line);
                count2++;
            }

            /*BagelNumber = new System.IO.StreamReader("BagelCount.txt");
            while((line = BagelNumber.ReadLine()) != null)
            {
                BagleNumberListBox.Items.Add(line);
                count3++;
            }*/

            BagleNumberListBox.Items.Clear();
            string x = "";
            for (int row = 0; row < StockLevels.GetLength(0); row++)
            {
                for (int col = 0; col < StockLevels.GetLength(1); col++)
                {
                    x += StockLevels[row, col].ToString() + "\t";
                    //BagleNumberListBox.Items.Add(StockLevels[row, col].ToString());
                }
                BagleNumberListBox.Items.Add(x);


            }


            BaglePriceListBox.Enabled = false;
            BagleNumberListBox.Enabled = false;




        }
        private void ExtraSmallRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            BAGELSIZEPRICE = EXTRASMALLBAGELPRICE;
            ReadBaglePrice();
            Size = "Extra Small";
            TotalPriceLabel.Text = TOTALBAGELPRICE.ToString("C");
        }
        private void SmallRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            BAGELSIZEPRICE = SMALLBAGELPRICE;
            ReadBaglePrice();
            Size = "Small";
            TotalPriceLabel.Text = TOTALBAGELPRICE.ToString("C");
        }

        private void MediumRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            BAGELSIZEPRICE = MEDIUMBAGELPRICE;
            ReadBaglePrice();
            Size = "Medium";
            TotalPriceLabel.Text = TOTALBAGELPRICE.ToString("C");
        }

        private void LargeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            BAGELSIZEPRICE = LARGEBAGELPRICE;
            ReadBaglePrice();
            Size = "Large";
            TotalPriceLabel.Text = TOTALBAGELPRICE.ToString("C");
        }

        private void ExtraLargeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            BAGELSIZEPRICE = EXTRALARGEBAGELPRICE;
            ReadBaglePrice();
            Size = "Extra Large";
            TotalPriceLabel.Text = TOTALBAGELPRICE.ToString("C");
        }

        private void OrderButton_Click(object sender, EventArgs e)
        {
            ScrollPanel.Height = OrderButton.Height;
            ScrollPanel.Top = OrderButton.Top;
        }

        private void AddToOrderButton_Click(object sender, EventArgs e)
        {
            ArrayList itemSelected = new ArrayList();

            AddToOdrder += 0;

            int Quantity, QuantityInStock;
            decimal OrderedPrice = 0;
            String OrderItem;

            if (BagelNameIndex == -1 || BagelSizeIndex == -1)
            {
                MessageBox.Show("Please select a Bagel and it's Size", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Quantity = (int)numericUpDownQuantity.Value;
                // QuantityInStock = BagelStockLevels[BagelNameIndex, BagelSizeIndex];
            }






            if (int.TryParse(NumberOfBaglesTextBox.Text, out NumberOfBaglesOrdered))
            {
                if (NumberOfBaglesOrdered > 0 && NumberOfBaglesOrdered < StockBagelSelected)
                {
                    FINALBAGELPRICE = TOTALBAGELPRICE * NumberOfBaglesOrdered;
                    //FinalPriceLabel.Text = FINALBAGELPRICE.ToString("C");


                }

                else if (NumberOfBaglesOrdered < 0 && NumberOfBaglesOrdered < StockBagelSelected)
                {
                    MessageBox.Show("Value cannot be Zero or Less than Zero", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (NumberOfBaglesOrdered > 0 && NumberOfBaglesOrdered > StockBagelSelected)
                {
                    MessageBox.Show("Stock Not Available", "Stock Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else
            {
                MessageBox.Show("Please ENter A Valid Numeric Value Here", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            QuantityOfBaglesOrdered = QuantityOfBaglesOrdered + NumberOfBaglesOrdered;

            CartListbox.Items.Add("Name of the Bagel Selected: " + BagelName);
            CartListbox.Items.Add("Size of the Bagel Selected: " + Size);
            CartListbox.Items.Add("Quantity of the selected Bagel: " + QuantityOfBaglesOrdered.ToString());
            CartListbox.Items.Add("Total Price of the selected Item: " + TOTALBAGELPRICE.ToString("C"));
            CartListbox.Items.Add("-----------------------------------------------");

            BagleListbox.ClearSelected();
            NumberOfBaglesTextBox.Text = "";
            TotalPriceLabel.Text = "TotalPrice";
            if (ExtraSmallRadioButton.Checked == true)
            {
                ExtraSmallRadioButton.Checked = false;
            }
            else if (SmallRadioButton.Checked == true)
            {
                SmallRadioButton.Checked = false;
            }
            else if (MediumRadioButton.Checked == true)
            {
                MediumRadioButton.Checked = false;
            }
            else if (LargeRadioButton.Checked == true)
            {
                LargeRadioButton.Checked = false;
            }
            else if (ExtraLargeRadioButton.Checked == true)
            {
                ExtraLargeRadioButton.Checked = false;
            }
        }
        private void CompleteOrderButton_Click(object sender, EventArgs e)
        {
            FINALBAGELPRICE += FINALBAGELPRICE;
            CartListbox.Items.Add("Final Price of the item is: " + FINALBAGELPRICE.ToString("C"));

            try
            {
                for (int i = 0; i <= CartListbox.Items.Count; i++)
                {

                    if (MessageBox.Show("MY BAGEL SHOP" + "\nHi, Your Receipt No is: " + UniqueTransactionID() + "\nThe Date is: " + DateTime.Now.ToLongDateString() + "\nThe Time is: " + DateTime.Now.ToShortDateString() + "\n" + CartListbox.Items[i].ToString() + "\n" + CartListbox.Items[i + 1].ToString() + "\n" + CartListbox.Items[i + 2].ToString() + "\n" + CartListbox.Items[i + 3].ToString() + "\n" + CartListbox.Items[i + 5].ToString(), "RECEIPT", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        StreamWriter outputFile = File.AppendText(ReceiptFile);
                        outputFile.WriteLine("MY BAGEL SHOP" + "\n" + UniqueTransactionID() + "\n" + DateTime.Now.ToLongDateString() + "\n" + DateTime.Now.ToShortDateString() + "\n" + CartListbox.Items[i].ToString() + "\n" + CartListbox.Items[i + 1].ToString() + "\n" + CartListbox.Items[i + 2].ToString() + "\n" + CartListbox.Items[i + 3].ToString() + "\n" + CartListbox.Items[i + 5].ToString());
                        outputFile.Close();
                    }
                    else
                    {
                        MessageBox.Show("File Write Error", "WRITE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }



                }




            }

            catch
            {
                return;
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            BagleListbox.ClearSelected();
            CartListbox.Items.Clear();
            NumberOfBaglesTextBox.Text = "";
            TotalPriceLabel.Text = "TotalPrice";
            if (ExtraSmallRadioButton.Checked == true)
            {
                ExtraSmallRadioButton.Checked = false;
            }
            else if (SmallRadioButton.Checked == true)
            {
                SmallRadioButton.Checked = false;
            }
            else if (MediumRadioButton.Checked == true)
            {
                MediumRadioButton.Checked = false;
            }
            else if (LargeRadioButton.Checked == true)
            {
                LargeRadioButton.Checked = false;
            }
            else if (ExtraLargeRadioButton.Checked == true)
            {
                ExtraLargeRadioButton.Checked = false;
            }
            else
            {
                MessageBox.Show("No Radio Button has been selected earlier", "No Filed to Clear", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public decimal ReadBaglePrice()
        {

            int BagleIndex = 0;
            if ((BagleListbox.SelectedIndex != -1))
            {

                BagleIndex = BagleListbox.SelectedIndex;

                switch (BagleIndex)
                {
                    case 0:
                        BAGELPRICE = CinnamonBagelPrice;
                        BagelName = "New Delhi Bagel";
                        break;

                    case 1:
                        BAGELPRICE = ChoclateBagelPrice;
                        BagelName = "New York Bagel";
                        break;

                    case 2:
                        BAGELPRICE = PizzaBagelPrice;
                        BagelName = "Kolkata Bagel";
                        break;

                    case 3:
                        BAGELPRICE = PlainBagelPrice;
                        BagelName = "Dublin Bagel";
                        //StockBagelSelected = StockBagel4;
                        break;
                    case 4:
                        BAGELPRICE = WheatHoneyBagelPrice;
                        BagelName = "Mumbai Bagel";
                        break;
                    case 5:
                        BAGELPRICE = JalapinoCheddarBegalPrice;
                        BagelName = "Galway Bagel";
                        break;
                    case 6:
                        BAGELPRICE = SweetonionBagelPrice;
                        BagelName = "Paris Bagel";
                        break;
                    case 7:
                        BAGELPRICE = EverythingGarlicBaglePrice;
                        BagelName = "London Bagel";
                        break;
                    case 8:
                        BAGELPRICE = PoppyBagelPrice;
                        BagelName = "Sanghai Bagel";
                        break;
                    case 9:
                        BAGELPRICE = MultiseedBaglePrice;
                        BagelName = "Tokyo Bagel";
                        break;
                    case 10:
                        BAGELPRICE = CranberryBaglePrice;
                        BagelName = "Berlin Bagel";
                        break;
                    case 11:
                        BAGELPRICE = SesameBagelPrice;
                        BagelName = "Dubai Bagel";
                        break;
                    case 12:
                        BAGELPRICE = ExclusiveRosemaryBaglePrice;
                        BagelName = "Bagel Shop Special Bagel";
                        break;

                }
                TOTALBAGELPRICE = BAGELPRICE + BAGELSIZEPRICE;

            }
            return TOTALBAGELPRICE;

        }

        public bool load2DArrayFromFile(String fileName, ref decimal[,] records)
        {
            int row = 0;
            string[] RecordRow, AllRecordRows;
            try
            {
                AllRecordRows = File.ReadAllLines(fileName); //Opens a text file and reads all lines of the file into a string array and then closes the file.

                for (row = 0; row < AllRecordRows.Length; row++)
                {
                    RecordRow = AllRecordRows[row].Split(SEPARATOR);

                    for (int col = 0; col < records.GetLength(1); col++)
                    {
                        records[row, col] = decimal.Parse(RecordRow[col]);
                    }
                }

            }
            catch
            {

            }
            return false;
        }


        public bool write2DIntArrayToFile(String filename, int[,] records)
        {
            int row = 0;
            int[] RecordRow = new int[records.GetLength(1)];

            try
            {
                StreamWriter stream = File.CreateText(filename);

                for (row = 0; row < records.GetLength(0); row++)
                {
                    for (int col = 0; col < records.GetLength(1); col++)
                    {
                        RecordRow[col] = records[row, col];
                    }
                    stream.WriteLine(String.Join(SEPARATOR.ToString(), RecordRow));
                }
            }
            catch
            {

            }
            return false;

        }

        private string UniqueTransactionID()
        {
            String TransactionNumber;
            Random random = new Random();
            {
                TransactionNumber = random.Next(10000, 99999).ToString();
            }
            return TransactionNumber;

        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            ScrollPanel.Height = SearchButton.Height;
            ScrollPanel.Top = SearchButton.Top;
        }

        private void SummaryButton_Click(object sender, EventArgs e)
        {
            ScrollPanel.Height = SummaryButton.Height;
            ScrollPanel.Top = SummaryButton.Top;
        }

        private void SalePerItemButton_Click(object sender, EventArgs e)
        {
            ScrollPanel.Height = SalePerItemButton.Height;
            ScrollPanel.Top = SalePerItemButton.Top;

            SALEPERITEMFORM F2 = new SALEPERITEMFORM();
            F2.Show();



        }

        private void StockButton_Click(object sender, EventArgs e)
        {
            ScrollPanel.Height = StockButton.Height;
            ScrollPanel.Top = StockButton.Top;
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            ScrollPanel.Height = ExitButton.Height;
            ScrollPanel.Top = ExitButton.Top;
            this.Close();
        }
    }


}