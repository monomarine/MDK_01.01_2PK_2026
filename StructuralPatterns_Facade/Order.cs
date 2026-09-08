using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace StructuralPatterns_Facade
{
    internal class Order
    {
        private DateTime _timeStamp;
        public bool isVIP {  get; set; } //приоритетный заказ
        public bool isBoxing { get; set; }
        public bool isNotify { get;set;  }
        private double _price;
        private string _title;
        private Client _client;
        public Order(Client client, string title)
        {
            _client = client;
            _title = title;
            _timeStamp = DateTime.UtcNow;
        }
        public void SetPrice(double amount)
        {
            if( _price != amount)
                _price = amount;
        }
        public override string ToString()
        {
            return new string($"заказ {_title} \n" +
                $"стоимость {_price}\n" +
                $"клиент - {_client.FIO}\n" +
                $"приоритетный заказ {(isVIP ? "Да" : "Нет")}\n" +
                $"дата заказа {_timeStamp:d}");
        }
    }
}
