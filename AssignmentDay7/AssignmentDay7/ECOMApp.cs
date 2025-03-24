using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentDay7
{

    struct Product
    {
       public int ProductID { get; set; }
       public string Name { get; set; }
       public string Category { get; set; }
       public double Price { get; set; }

        public Product(int productID, string name, string category,double price)
        {
            ProductID = productID;
            Name = name;
            Category = category;
            Price = price;
        }
    }
    
}
