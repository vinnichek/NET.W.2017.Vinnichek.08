using System;
using System.Collections.Generic;
using System.IO;

namespace BankAccount.Logic.BankAccountStorage
{
    public class BankAccountBinaryStorage : IBankAccountStorage
    {
        #region Fields
        private readonly string path;
        #endregion

        #region Ctors
        public BankAccountBinaryStorage(string path)
        {
            this.path = path;
        }
        #endregion

        #region Properties
        public string Path => path;
        #endregion

        #region Public Methods

        /// <summary>
        /// Write information about bank accounts to file.
        /// </summary>
        /// <returns>Write list of bank accounts to file.</returns>
        public void WriteToStorage(IEnumerable<BankAccount> bankAccountList)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                if (ReferenceEquals(bankAccountList, null))
                    throw new ArgumentNullException($"{nameof(bankAccountList)} is null.");
                foreach (BankAccount bankAccount in bankAccountList)
                {
                    writer.Write(bankAccount.NumberOfBankAccount);
                    writer.Write(bankAccount.AccountHolder);
                    writer.Write(bankAccount.Balance);
                    writer.Write(bankAccount.BonusPoints);
                }
            }
        }

        /// <summary>
        /// Read information about books from file.
        /// </summary>
        /// <returns>Read from the file List of Book instances.</returns>
        public IEnumerable<BankAccount> ReadFromStorage()
        {
            List<BankAccount> bankAccountList = new List<BankAccount>();
            long numberOfBankAccount;
            string accountHolder;
            decimal amountOfMoney, bonusPoints;

            using (BinaryReader reader = new BinaryReader(File.Open(Path, FileMode.OpenOrCreate)))
            {
                while (reader.PeekChar() > -1)
                {
                    numberOfBankAccount = reader.ReadInt64();
                    accountHolder = reader.ReadString();
                    amountOfMoney = reader.ReadDecimal();
                    bonusPoints = reader.ReadDecimal();

                    Object bankAccount = new object[] { numberOfBankAccount, accountHolder, amountOfMoney, bonusPoints };
                    bankAccountList.Add(bankAccount as BankAccount);
                }
            }
            return bankAccountList;
        }
        #endregion
    }
}
