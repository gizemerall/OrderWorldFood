using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderWorldFood.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber{ get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public EnumOrderState OrderState { get; set; }

        public string UserName { get; set; }     
        public string AdressHead { get; set; }    
        public string Adress1 { get; set; }   
        public string City { get; set; }   
        public string Distrinct { get; set; } 
        public string Street { get; set; }  
        public string postalCode { get; set; }
        public virtual List<OrderLine> Orderlines { get; set; }

    }


    public class OrderLine //tamamlanmış bir kayıt
    {
        public int Id { get; set; }
        public int OrderId { get; set;}
        public virtual Order Order { get; set; }

        public int Quantity { get; set; }
        public double price { get; set; }

        public int ProductId { get; set;}
        public virtual Product Product { get; set; }

    }
}