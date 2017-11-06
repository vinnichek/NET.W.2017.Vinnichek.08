using System;
namespace BankAccount.Logic
{
    public static class Bonus
    {
        /// <summary>
        /// Calculate bonus points of bank account.
        /// </summary>
        /// <param name="balance">Balance of bank account.</param>
        /// <param name="amountOfMoney">Amount of money for transaction.</param>
        /// <param name="balanceValue">Balance value.</param>
        /// <param name="replenishmentСost">Replenishment cost.</param>
        /// <returns>Bonus points.</returns>
        public static decimal CalculateBonusPoints(decimal balance, decimal amountOfMoney, int balanceValue, int replenishmentСost)
        {
            return (balanceValue * balance + amountOfMoney * replenishmentСost) / 1000;
        }
    }
}
