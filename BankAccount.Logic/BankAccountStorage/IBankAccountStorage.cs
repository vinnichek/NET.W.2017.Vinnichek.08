using System;
using System.Collections.Generic;

namespace BankAccount.Logic.BankAccountStorage
{
    public interface IBankAccountStorage
    {
        /// <summary>
        /// Read information from storage.
        /// </summary>
        /// <returns>Collection of objects.</returns>
        IEnumerable<BankAccount> ReadFromStorage();

        /// <summary>
        /// Write information to storage.
        /// </summary>
        /// <param name="bankAccountList">Collection of objects.</param>
        void WriteToStorage(IEnumerable<BankAccount> bankAccountList);
    }
}
