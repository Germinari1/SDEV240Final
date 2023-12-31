﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Material_List_Estimator
{
    internal class Item
    {
        //FIELDS AND PROPERTIES
        private string _itemName;     //item name
        private double _price;        //item unit price
        private int _qnt;             //item quantity
        private string _description;  //freeform item description (size, shape, etc)
        private string _material;     //primary material the item is composed of

        [DisplayName("Item Name")]    //Using display attributes to rename the DataGrid display columns for each property
        public string ItemName
        {
            get { return _itemName; }
            set { _itemName = value; }
        }
               
        public string Material { get; set; }

        public string Decription { get; set; }

        [DisplayName("Quantity")]
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

        [DisplayName("Unit Price")]
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


        //CONSTRUCTORS and DESTRUCTORS
        public Item() { }

        public Item(string name="Null", string material = "Null", string description = "Null", int quantity = 0, double price = 0)
        {
            ItemName = name;
            Price = price;
            Qnt = quantity;
            Decription = description;
            Material = material;
        }

        //METHODS
        public double CalculateTotal()
        {
            return _qnt * _price;
        }
    }

}
