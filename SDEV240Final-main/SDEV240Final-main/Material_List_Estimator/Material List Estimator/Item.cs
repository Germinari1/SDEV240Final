using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Material_List_Estimator
{
    internal class Item
    {
        //FIELDS AND PROPERTIES
        private string _itemName;
        private double _price;
        private int _qnt; //quantity of items
        private string _description;
        private string _material;

        public string ItemName
        {
            get { return _itemName; }
            set { _itemName = value; }
        }

        public double Price
        {
            get { return _price; }
            set
            {
                if (value > 0 && double.TryParse(value.ToString(), out double temp_price))
                {
                    _price = value;
                }
                else
                {
                    _price = 0.0;
                }
            }
        }

        public int Qnt
        {
            get { return _qnt; }
            set
            {
                if (value > 0 && int.TryParse(value.ToString(), out int temp_qnt))
                {
                    _qnt = value;
                }
                else
                {
                    _qnt = 0;
                }
            }
        }
        public string Decription { get; set; }
        public string Material { get; set; }

        //CONSTRUCTORS and DESTRUCTORS
        public Item() { }

        public Item(string name="Null", double price = 0, int quantity = 0, string description = "Null")
        {
            ItemName = name;
            Price = price;
            Qnt = quantity;
            Decription = description;
        }

        //METHODS
        public double CalculateTotal()
        {
            return _qnt * _price;
        }
    }

}
