using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachineProject.Beverages;

namespace VendingMachineProject
{
    class MoneyManager
    {
        private static double _cashEntered;

        static MoneyManager()
        {
            _cashEntered = 0;
        }

        public bool CheckCashEntered(Beverage beverage)
        {
            if (_cashEntered >= beverage.Price)
            {
                return true;
            }
            return false;
        }

        public double CashEntered()
        {
            return _cashEntered;
        }
        
        public void AddMoney(double money)
        {
            _cashEntered += money;
        }

        public double ReturnChange (Beverage beverage)
        {
            return _cashEntered - beverage.Price;
        }

        public void ResetCash()
        {
            _cashEntered = 0;
        }
    }
}
