using System;
using System.Collections.Generic;
using System.Text;

namespace StructuralPatterns_Facade
{
    internal class Client
    {
        private string _fio;
        private string _adress;
        public string FIO => _fio;
        public string Adress => _adress;
        public Client(string fio, string adress)
        {
            _fio = fio; _adress = adress;
        }
    }
}
