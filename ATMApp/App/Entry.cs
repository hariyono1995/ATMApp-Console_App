using ATMApp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApp.App
{
    internal class Entry
    {
        static void Main(string[] args)
        {
            AppScreen.Welcome();

            //long cardNumber = Validator.Convert<long>("your card number");
            //Console.WriteLine($"Your card number is {cardNumber}");
            AppScreen.Welcome();
            ATMApp atmApp = new ATMApp();
            atmApp.InitializeData();
            atmApp.CheckUserCardNumAndPassword();
            atmApp.Welcome();
            //Utility.PressEnterToContinue();
        }
    }
}
