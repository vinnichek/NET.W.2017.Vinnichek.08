using System;
namespace BankAccount.Logic
{
    public abstract class BankAccount
    {
        #region Fields
        private long numberOfBankAccount;
        private string accountHolder;
        private decimal balance;
        private decimal bonusPoints;
        #endregion

        #region Properties

        /// <summary>
        /// Number of bank account.
        /// </summary>
        public long NumberOfBankAccount
        {
            get => numberOfBankAccount;
            set
            {
                if (value <= 0)
                    throw new ArgumentException($"{nameof(value)} is not valid.");
                numberOfBankAccount = value;
            }
        }

        /// <summary>
        /// Holder of bank account.
        /// </summary>
        public string AccountHolder
        {
            get => accountHolder;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException($"{nameof(value)} is null or empty.");
                accountHolder = value;
            }
        }

        /// <summary>
        /// Balance of bank account.
        /// </summary>
        public decimal Balance
        {
            get => balance;
            set
            {
                if (value < 0)
                    throw new ArgumentException($"{nameof(value)} can't be less then 0.");
                balance = value;
            }
        }

        /// <summary>
        /// Bonus points of bank account.
        /// </summary>
        public decimal BonusPoints
        {
            get => bonusPoints;
            set
            {
                if (value < 0)
                    throw new ArgumentException($"{nameof(value)} can't be less then 0.");
                bonusPoints = value;
            }
        }

        protected abstract int BalanceValue { get; }
        protected abstract int ReplenishmentСost { get; }
        #endregion

        #region Public Methods

        /// <summary>
        /// Replenish balance.
        /// </summary>
        /// <param name="amountOfMoney">Amount of money for replenish.</param>
        public void ReplenishBalance(decimal amountOfMoney)
        {
            balance = balance + amountOfMoney;
            bonusPoints = bonusPoints + Bonus.CalculateBonusPoints(balance, amountOfMoney, BalanceValue, ReplenishmentСost) ;

            if (bonusPoints <= 0)
                bonusPoints = 0;
        }

        /// <summary>
        /// Withdraw money from balance.
        /// </summary>
        /// <param name="amountOfMoney">Amount of money for withdraw.</param>
        public void WithdrawMoney(decimal amountOfMoney)
        {
            if (balance < amountOfMoney)
                throw new ArgumentException("Amount of money to withdraw is greater than the balance.");

            balance = balance - amountOfMoney;
            bonusPoints = bonusPoints - Bonus.CalculateBonusPoints(balance, amountOfMoney, BalanceValue, ReplenishmentСost);

            if (bonusPoints <= 0)
                bonusPoints = 0;
        }

        /// <summary>
        /// Return string representation of bank account.
        /// </summary>
        /// <returns>String representation of bank account.</returns>
        public override string ToString() => $"{numberOfBankAccount} - {accountHolder}. {balance} BYN / {bonusPoints} bonus";

        /// <summary>
        /// Compare two bank accounts.
        /// </summary>
        /// <param name="other">Bank account for comparing.</param>
        /// <returns>True if bank accounts are equal; false if not.</returns>
        public bool Equals(BankAccount other)
        {
            if (ReferenceEquals(other, null)) return false;
            return this.numberOfBankAccount == other.numberOfBankAccount && this.accountHolder == other.accountHolder &&
                       this.balance == other.balance && this.bonusPoints == other.bonusPoints;
        }

        /// <summary>
        /// Check two bank accounts for equality.
        /// </summary>
        /// <param name="obj">Object for comparing.</param>
        /// <returns>True - if bank accounts are equal; false - if not.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            return Equals(obj as BankAccount);
        }

        /// <summary>
        /// Calculate hash code.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }        
}
