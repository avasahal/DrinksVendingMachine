using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using VendingMachineProject.Beverages;
using VendingMachineProject.Manager;

namespace VendingMachineProject
{
    //enum MyBeverages { Coffee, Tea, Cappuccino, HotChocolate}

    public class MachineManager
    {
        MoneyManager _moneyManager = new MoneyManager();
        ProductManager _productManager = new ProductManager();
        //MainWindow _mainWindow = new MainWindow();
        private static List<Beverage> _beverageList;
        private int _selectedBeverage;
        public static List<Button> beverageBtnList;
        public static List<Button> moneyBtnList;
        private double _refund;
        private static string _startMsg;
        private TextBlock _msgTxtBlock;
        //private TextBlock _refundTxtBlock;

        static MachineManager()
        {
            _startMsg = "Select your drink !";

            beverageBtnList = new List<Button>();
            moneyBtnList = new List<Button>();

            _beverageList = new List<Beverage>();
            _beverageList.Add(new Coffee());
            _beverageList.Add(new Tea());
            _beverageList.Add(new Cappuccino());
            _beverageList.Add(new HotChocolate());
            
        }

        public MachineManager(TextBlock textBlock)
        {
            _msgTxtBlock = textBlock;
            _msgTxtBlock.Text = _startMsg;
        }

        public async void StartMachine(int selectBeverage)
        {
            _selectedBeverage = selectBeverage;
            
            if(CheckIngredientsAvailability())
            {
                _msgTxtBlock.Text = "Beverage cost: " + ShowBeveragePrice() + "\n Please enter your coins: ";
                
                if(CheckMoneyForBeverage())
                {
                   
                    await Task.Delay(5000);
                    //PrepareDrink();
                }
                else
                {
                    //
                    AmountCashEntered();
                    _msgTxtBlock.Text = "Please enter the amount of the selected drink - \n \n Beverage Cost: "
                        + ShowBeveragePrice() + ".00 Shekels";
                }
            }
            else
            {
                _msgTxtBlock.Text = "SORRY ! The selected drink is out of stock ! \n" +
                    "You can choose another one or come back another time !\n \n" +_startMsg;
               
            }
        }

        public void AddMoney(double money)
        {
            _moneyManager.AddMoney(money);
            AmountCashEntered();
        }

        public void AmountCashEntered()
        {
            if (_moneyManager.CashEntered() > 0)
            {
                _msgTxtBlock.Text = "The amount of cash entered: \n \n" + _moneyManager.CashEntered() + " Shekels";
            }
        }

        private bool CheckIngredientsAvailability()
        {
            return _productManager.CheckIngredientsAvailability(_beverageList[_selectedBeverage]);
            //return _productManager.CheckIngredientsAvailability[CheckIngredientsSupply]
        }

        public bool CheckMoneyForBeverage()
        {
            return _moneyManager.CheckCashEntered(_beverageList[_selectedBeverage]);
        }

        private void ReturnChangeToCustomer()
        {
            _refund = _moneyManager.ReturnChange(_beverageList[_selectedBeverage]);
            if (_refund > 0)
            {
                _msgTxtBlock.Text = "Take your change ! \n \n Refund: " + _refund + " Shekels";
            }
            //set the refund to 0 when transaction is finished
        }

        public void RefundCustomer()
        {
            _refund = _moneyManager.CashEntered();
            _msgTxtBlock.Text = "Please take your refund: \n" + _refund + ".00 Shekels";
        }

        public async void PrepareDrink()
        {
            ReturnChangeToCustomer();
            await Task.Delay(4000);
            _beverageList[_selectedBeverage].Prepare(_msgTxtBlock);
            await Task.Delay(6000);
            _msgTxtBlock.Text = "Your drink is prepared ! You can take it ! \n Thank you for buying !";
            
            await Task.Delay(5000);
            TakeIngredientsSupply();
            _moneyManager.ResetCash();
            _msgTxtBlock.Text = _startMsg;
        }

        private void TakeIngredientsSupply()
        {
            _productManager.IngredientsSupply(_beverageList[_selectedBeverage]);
        }

        public double ShowBeveragePrice()
        {
            return _beverageList[_selectedBeverage].Price;
        }

        public void EnableBevButtons()
        {
            foreach (var bevBtn in beverageBtnList)
            {
                bevBtn.IsEnabled = true;
            }
        }

        public void DisableBevButtons()
        {
            foreach (var bevBtn in beverageBtnList)
            {
                bevBtn.IsEnabled = false;
            }
        }
      

    }

    
}
