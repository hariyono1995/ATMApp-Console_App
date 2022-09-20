using ATMApp.Domain.Entities;
using ATMApp.Domain.Interfaces;
using ATMApp.UI;
using System;

namespace ATMApp.App
{
    internal class ATMApp : IUserLogin
    {
        private List<UserAccount> userAccountList;
        private UserAccount selectedAccount;

        public void InitializeData()
        {
            userAccountList = new List<UserAccount> 
            { 
            new UserAccount { Id = 1, FullName = "Joe Doe", CardNumber = 1234, CardPin = 111111, AccountNumber = 1, AccountBalance = 500.00m, IsLocked = false },
            new UserAccount { Id = 2, FullName = "Lorep Ipsum", CardNumber = 2345, CardPin = 5432, AccountNumber = 2, AccountBalance = 6500.00m, IsLocked = false },
            new UserAccount { Id = 3, FullName = "Jhon Loe", CardNumber = 3456, CardPin = 6543, AccountNumber = 3, AccountBalance = 0.00m, IsLocked = true },
            };
        }

        public void CheckUserCardNumAndPassword()
        {
            bool isCorrectLogin = false;
            while (isCorrectLogin == false)
            {
                UserAccount inputAccount = AppScreen.UserLoginForm();
                AppScreen.LoginProgress();
                foreach (UserAccount account in userAccountList)
                {
                    selectedAccount = account;
                    if (inputAccount.CardNumber.Equals(selectedAccount.CardNumber))
                    {
                        selectedAccount.TotalLogin++;
                        if (inputAccount.CardPin.Equals(selectedAccount.CardPin))
                        {
                            selectedAccount = account;
                            if (selectedAccount.IsLocked || selectedAccount.TotalLogin > 3)
                            {
                                AppScreen.PrintLockScreen();
                            }
                            else
                            {
                                selectedAccount.TotalLogin = 0;
                                isCorrectLogin = true;
                                break;
                            }
                        }
                    }
                    if(isCorrectLogin == false)
                    {
                        Utility.PrintMessage("\nInvalid card number or PIN.", false);
                        selectedAccount.IsLocked = selectedAccount.TotalLogin == 3;
                        if (selectedAccount.IsLocked)
                        {
                            AppScreen.PrintLockScreen();
                        }
                    }
                    Console.Clear();
                }
            }
        }

        public void Welcome()
        {
            Console.WriteLine($"Welcome back, {selectedAccount.FullName}");
            Utility.PressEnterToContinue();
        }
    }
}