using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Material_List_Estimator
{
    public partial class Form1 : Form
    {
        //list of items
        BindingList<Item> items;

        public Form1()
        {
            InitializeComponent();

            // Set up list and datagridview
            items = new BindingList<Item>();
            //bind data source
            gridItems.DataSource = items;

            //Change the text format of the last column of datagrid to currency after it has been populated
            gridItems.Columns[gridItems.ColumnCount - 1].DefaultCellStyle.Format = "c";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            /////adds a new item to the table

            //check if required fields have user-generate data. If yes, add the item
            if (txtItem.TextLength!=0 && txtPrice.TextLength!=0 && txtPriceCents.TextLength!=0)
            {
                //instanciate new Item
                Item newItem = new Item();
                //populate fields of new item
                newItem.ItemName = txtItem.Text;
                newItem.Qnt = Convert.ToInt32(txtQuantity.Text);
                newItem.Decription = txtDescription.Text;
                newItem.Material = txtMaterial.Text;
                newItem.Price = Convert.ToDouble(txtPrice.Text) + (Convert.ToDouble(txtPriceCents.Text)/100);
                //add new item to list 
                items.Add(newItem);
            }
            else 
            {                
                MessageBox.Show("You must enter an Item Name, Quantity, and Price \nbefore adding this item to the Material List.", "Error Adding Item", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            /////clears the data source of the datagrid (also clearing the table as a consequence) and input fields
            
            //clear data source (list)
            items.Clear();

            //clear input fields
            txtDescription.Clear();
            txtPrice.Clear();
            txtMaterial.Clear();
            txtPriceCents.Clear();
            txtItem.Clear();
            txtTotalCost.Clear();
            txtQuantity.Value = txtQuantity.Minimum;
            
        }

        private void PriceKeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only numbers
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //Sums the total costs from each added and updates the display
            
            //Establish an accumulator to the total
            double total = 0.0;

            //Iterate over all items and read from their internal calculation method
            for (int i = 0; i < items.Count; i++)
            {
                total += items[i].CalculateTotal();                
            }

            //Update GUI with total formatted to currency
            txtTotalCost.Text = total.ToString("C");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {        
            //Formats the file output as CSV and saves it to a user provided location

            //string array to hold the lines of csv
            string[] output = new string[items.Count];

            //Iterate over all items and adds their data + comma delimiter to the string array
            for (int i = 0;i < items.Count;i++) 
            {
                output[i] += items[i].ItemName.ToString() + ",";
                output[i] += items[i].Material.ToString() + ",";
                output[i] += items[i].Decription.ToString() + ",";
                output[i] += items[i].Qnt.ToString() + ",";
                output[i] += items[i].Price.ToString();
            }

            //Opens a save file dialog prompt with .txt format selected and title set
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Plain Text|*.txt";
            saveFileDialog.Title = "Save Material List";

            //If the user clicks OK, write all lines of the string array to the provided file location
            if(saveFileDialog.ShowDialog() == DialogResult.OK) 
            {
                System.IO.File.WriteAllLines(saveFileDialog.FileName, output);
            }
        }
    }
}
