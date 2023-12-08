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
<<<<<<< Updated upstream
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

=======
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
>>>>>>> Stashed changes
        }
    }
}
