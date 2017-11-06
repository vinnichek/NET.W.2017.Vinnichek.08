using System;
using System.Collections.Generic;
using System.Text;
using BankAccount.Logic.BankAccountStorage;

namespace BankAccount.Logic
{
    public class BankAccountService
    {
        private List<BankAccount> bankAccountList = new List<BankAccount>();

        #region Public Methods
        /// <summary>
        /// Add bank account to the collection.
        /// </summary>
        /// <param name="bankAccount">Bank account for adding.</param>
        public void AddBankAccount(BankAccount bankAccount)
        {
            if (ReferenceEquals(bankAccount, null))
                throw new ArgumentException($"{nameof(bankAccount)} is null.");
            if (bankAccountList.Contains(bankAccount))
                throw new ArgumentException($"{nameof(bankAccount)} exists.");
            bankAccountList.Add(bankAccount);
        }
       
        /// <summary>
        /// Remove bank account from the collection.
        /// </summary>
        /// <param name="bankAccount">Bank account for removing.</param>
        public void RemoveBankAccount(BankAccount bankAccount)
        {
            if (ReferenceEquals(bankAccount, null))
                throw new ArgumentException($"{nameof(bankAccount)} is null.");
            if (!bankAccountList.Contains(bankAccount))
                throw new ArgumentException($"{nameof(bankAccount)} doesn't exist.");
            bankAccountList.Remove(bankAccount);
        }

        /// <summary>
        /// Save collection of bank accounts to storage.
        /// </summary>
        /// <param name="storage">Storage to save.</param>
        public void SaveToStorage(IBankAccountStorage storage)
        {
            if (ReferenceEquals(storage, null))
                throw new ArgumentException($"{nameof(storage)} is null.");
            storage.WriteToStorage(bankAccountList);
        }

        /// <summary>
        /// Load collection of bank accounts from storage.
        /// </summary>
        /// <param name="storage">Storage to load.</param>
        public void LoadFromStorage(IBankAccountStorage storage)
        {
            if (ReferenceEquals(storage, null)) throw new ArgumentException($"{nameof(storage)} is null.");
            IEnumerable<BankAccount> bookList = storage.ReadFromStorage();
            foreach (BankAccount bankAccount in bankAccountList)
            {
                this.AddBankAccount(bankAccount);
            }
        }

        /// <summary>
        /// Return string representation of collection of books.
        /// </summary>
        ///<returns>String representation of collection of books.</returns>
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append("Bank accounts:\r\n");
            foreach (BankAccount bankAccount in bankAccountList)
            {
                str.Append(bankAccount);
                str.Append("\r\n");
            }
            return str.ToString();
        }
        #endregion
    }
}
