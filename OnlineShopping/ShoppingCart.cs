using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopping
{
    public class ShoppingCart
    {
        private readonly IList<string> _items;

        public string CustomerName { get; set; }
        public string CustomerId { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public ShoppingCart()
        {
            this._items = new List<string>();
        }

        public void Scan(string item)
        {
            this._items.Add(item);
        }

        public int TotalItems()
        {
            return this._items.Count;
        }

        public decimal TotalPrice()
        {
            var itemsGrouped = this._items
                .GroupBy(x => x)
                .ToDictionary(item => item.Key, itemCount => itemCount.Count());
            
            return itemsGrouped.Sum(item => Program.CalculatePrice(item.Key, item.Value));
        }

        public Order CreateOrder()
        {
            var order = new Order();
            order.Items = this._items
                .GroupBy(x => x)
                .ToDictionary(item => item.Key, itemCount => itemCount.Count());
            return order;
        }

        public string GetPaymentProcessingUrl(Order order)
        {
            //Converting String Money Value Into Decimal



            decimal price = Convert.ToDecimal(order.TotalPrice());



            //declaring empty String



            string returnURL = "";



            returnURL += "https://www.paypal.com/xclick/business=bangarubabu.p@gmail.com";



            //PassingItem Name as dynamic



            returnURL += "&item_name=" + order.Items.First().Key;



            //AssigningName as Statically to Parameter



            returnURL += "&first_name" + "Raghunadh Babu";



            //AssigningCity as Statically to Parameter



            returnURL += "&city" + "Hyderabad";



            //Assigning State as Statically to Parameter



            returnURL += "&state" + "Andhra Pradesh";



            //Assigning Country as Statically to Parameter



            returnURL += "&country" + "India";



            //Passing Amount as Dynamic



            returnURL += "&amount=" + price;



            //Passing Currency as your 



            returnURL += "&currency=USD";



            //retturn Url if Customer wants To return to Previous Page



            returnURL += "&return=http://bangarubabupureti.spaces.live.com";



            //retturn Url if Customer Wants To Cancel the Transaction



            returnURL += "&cancel_return=http://bangarubabupureti.spaces.live.com";



            return returnURL;
        }
    }

    public class Order
    {
        public Dictionary<string, int> Items { get; set; }

        public decimal TotalPrice()
        {

            return Items.Sum(item => this.CalculatePrice(item.Key, item.Value));
        }

        private decimal CalculatePrice(string item, int quantity)
        {
            switch (item)
            {
                case "A99":
                    return quantity * 50 - ((quantity / 3) * 20);
                case "B15":
                    return quantity * 30 - ((quantity / 2) * 15);
                case "C40":
                    return 60;
                case "T34":
                    return 99;
                default:
                    return 0;
            }
        }
    }
}
