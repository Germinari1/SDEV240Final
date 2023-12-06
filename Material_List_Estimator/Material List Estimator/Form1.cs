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
        private Item _item;
        public Form1()
        {
            InitializeComponent();
            _item = new Item();
        }
    }
}
