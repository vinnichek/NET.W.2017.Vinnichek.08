using System;
using BankAccount.Logic;
using BankAccount.Logic.BankAccountStorage;

namespace ConsoleAppForBankAccount
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            BaseBankAccount firstBankAccount = new BaseBankAccount(1234, "Vinnichek Ira");
            GoldBankAccount secondBankAccount = new GoldBankAccount(3456, "Petrov Petya");
            PlatinumBankAccount thirdBankAccount = new PlatinumBankAccount(4567, "Ivanov Ivan");
            PlatinumBankAccount fourthBankAccount = new PlatinumBankAccount(4567, "Ivanov Ivan");

            Console.WriteLine(firstBankAccount);

            Console.WriteLine(firstBankAccount.Equals(secondBankAccount)); //false
            Console.WriteLine(thirdBankAccount.Equals(fourthBankAccount)); //true

            firstBankAccount.ReplenishBalance(1000);
            secondBankAccount.ReplenishBalance(1000);
            thirdBankAccount.ReplenishBalance(1000);
            thirdBankAccount.WithdrawMoney(200);

            BankAccountService service = new BankAccountService();
            service.AddBankAccount(firstBankAccount);
            service.AddBankAccount(secondBankAccount);
            Console.WriteLine(service);

            service.RemoveBankAccount(secondBankAccount);
            Console.WriteLine(service);

            service.AddBankAccount(secondBankAccount);
            service.AddBankAccount(thirdBankAccount);

            Console.WriteLine("\r\n");
            Console.WriteLine("------List of bank accounts.------");
            Console.WriteLine(service);

            IBankAccountStorage binaryStorage = new BankAccountBinaryStorage(@"/Users/vinnichek/Projects/Task/ConsoleAppForBankAccount/BankAccounts.txt"); 
            //service.SaveToStorage(binaryStorage);
            //service.LoadFromStorage(binaryStorage);
        }
    }
}
