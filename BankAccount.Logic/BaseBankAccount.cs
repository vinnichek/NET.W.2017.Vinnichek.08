using System;
namespace BankAccount.Logic
{
    public class BaseBankAccount : BankAccount
    {
        #region Properties
        protected override int BalanceValue => 2;
        protected override int ReplenishmentСost => 1;
        #endregion

        #region Ctors

        /// <summary>        
        /// Ctor for base bank account instance.
        /// </summary>
        /// <param name="numberOfBankAccount"> Number of bank account.</param>
        /// <param name="accountHolder">Holder of bank account.</param>
        /// <param name="balance">Balance of bank account.</param>
        /// <param name="bonusPoints">Bonus points of bank account.</param>
        public BaseBankAccount(long numberOfBankAccount, string accountHolder, decimal balance = 0, decimal bonusPoints = 0)
        {
            NumberOfBankAccount = numberOfBankAccount;
            AccountHolder = accountHolder;
            Balance = balance;
            BonusPoints = bonusPoints;
        }
        #endregion
    }
}
