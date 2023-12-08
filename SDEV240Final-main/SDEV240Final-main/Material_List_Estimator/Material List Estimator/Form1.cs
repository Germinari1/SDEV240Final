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
        //declaring item object
        private Item _item;
        //list of items
        BindingList<Item> items;

        public Form1()
        {
            InitializeComponent();
            
            _item = new Item();

            // Set up list and datagridview
            items = new BindingList<Item>();
            //bind data source
            gridItems.DataSource = items;

            //[TEST]
            Item item = new Item("wood", 5000, 3, "construction wood");
            items.Add(item);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            /////adds a new item to the table

            //check if required fields have user-generate data. If yes, add the item
            if (txtItem.TextLength!=0 && txtPrice.TextLength!=0)
            {
                //instanciate new Item
                Item newItem = new Item();
                //populate fields of new item
                newItem.ItemName = txtItem.Text;
                newItem.Qnt = Convert.ToInt32(txtQuantity.Text);
                newItem.Decription = txtDescription.Text;
                newItem.Material = txtMaterial.Text;
                newItem.Price = Convert.ToDouble(txtPrice.Text);
                //add new item to list 
                items.Add(newItem);
            }

        }

        private void label7_Click(object sender, EventArgs e)
        {

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
            txtHomeName.Clear();
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
    }
}
