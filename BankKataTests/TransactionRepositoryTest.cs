using System;
using BankKata;
using NUnit.Framework;

namespace BankKataTests
{
    [TestFixture]
    public class TransactionRepositoryTest
    {
        [Test]
        public void AddDepositTest()
        {
            var transactionRepository = 
                new TransactionRepository();
            
            transactionRepository.AddDeposit(new Transaction(500, DateTime.Today,TypeTransaction.DEPOSIT));
            
            Assert.That(transactionRepository.GetTransactions().Contains(
                new Transaction(500, DateTime.Today,TypeTransaction.DEPOSIT)));
        }

        [Test]
        public void AddWithdrawalTest()
        {
            var transactionRepository =
                new TransactionRepository();

            transactionRepository.AddWithdrawal(new Transaction(-200, DateTime.Today,TypeTransaction.WITHDRAW));

            Assert.That(transactionRepository.GetTransactions().Contains(
                new Transaction(-200, DateTime.Today,TypeTransaction.WITHDRAW)));

        }


    }

    
}
