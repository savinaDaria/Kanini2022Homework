using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOModelsLibrary
{
    class Product
    {
        //Id,Name, QuantityPerUnit, UnitPrice, Stock
        public int Id { get; set; }
        public string Name { get; set; }
        public string QuantityPerUnit { get; set; }
        public float UnitPrice { get; set; }
        public int Stock { get; set; }
        public override string ToString()
        {
            return "Product ID: " + Id +
                "\nName: " + Name +
                "\nQuantityPerUnit: " + QuantityPerUnit +
                "\nUnitPrice: " + UnitPrice +
                "\nUnitsInStock: " + Stock;
        }
    }
}
