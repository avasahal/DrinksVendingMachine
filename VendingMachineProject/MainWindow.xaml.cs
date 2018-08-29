using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using VendingMachineProject.Beverages;

namespace VendingMachineProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MachineManager _machineManager;
        int _beverageNumber = 0;
        double _coin = 0;
        Button btn = new Button();
        bool beverageBtnClicked = false;

        public MainWindow()
        {
            InitializeComponent();
            
            MachineManager.beverageBtnList.Add(coffeeBtn);
            MachineManager.beverageBtnList.Add(teaBtn);
            MachineManager.beverageBtnList.Add(cappucinoBtn);
            MachineManager.beverageBtnList.Add(hotChocoBtn);
            MachineManager.moneyBtnList.Add(oneShkBtn);
            MachineManager.moneyBtnList.Add(twoShkBtn);
            MachineManager.moneyBtnList.Add(fiveShkBtn);
            MachineManager.moneyBtnList.Add(tenShkBtn);

            _machineManager = new MachineManager(msgTxtBlock);
            
        }

        private void selectBeverage_Click(object sender, RoutedEventArgs e)
        {
           
            btn = (Button)sender;
            _beverageNumber = int.Parse((btn.Tag).ToString());
            _machineManager.StartMachine(_beverageNumber);
            beverageBtnClicked = true;
        }

        private void selectCoin_Click(object sender, RoutedEventArgs e)
        {
            if(beverageBtnClicked == true)
            {
                _machineManager.ShowBeveragePrice();
                btn = (Button)sender;
                
                _coin = int.Parse((btn.Tag).ToString());
                _machineManager.AddMoney(_coin);
            }
            else
            {
                msgTxtBlock.Text = "Please select a drink first!";
            }

        }

        private async void payBtn_Click(object sender, RoutedEventArgs e)
        {
            
            if (_machineManager.CheckMoneyForBeverage() == true)
            {
                payBtn.IsEnabled = false;
                _machineManager.DisableBevButtons();
                _machineManager.PrepareDrink();
                
                _machineManager.EnableBevButtons();
            }
            else
            {
                //
                msgTxtBlock.Text = "Insuffisant funds - Please insert your coins ! \n " ;
                await Task.Delay(2000);
                _machineManager.AmountCashEntered();
            }
            await Task.Delay(10000);
            payBtn.IsEnabled = true;

        }

        private async void refundBtn_Click(object sender, RoutedEventArgs e)
        {
            _machineManager.RefundCustomer();
            await Task.Delay(3000);
            msgTxtBlock.Text = "Thank you !";
            await Task.Delay(3000);
            msgTxtBlock.Text = "Select a drink!";
        }
    }
}
