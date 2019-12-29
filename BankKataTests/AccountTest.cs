using System;

using BankKata;
using NSubstitute;
using NUnit.Framework;

namespace BankKataTests
{
   
    [TestFixture]
    public class AccountTest
    {
        private TransactionRepository _transactionRepository;
        private Account _account;
        private StatementPrinter _statementPrinter;
    


        [SetUp]
        public void SetUp()
        {
           
           
            _transactionRepository = Substitute.For<TransactionRepository>();
         

            _account = new Account(
                _transactionRepository,_statementPrinter);
        }

        [Test]
        public void DepositTest()
        {
            _account.Deposit(500);

            _transactionRepository.Received().AddDeposit(
                new Transaction(500, DateTime.Today,TypeTransaction.DEPOSIT));
        }

        [Test]
        public void WithdrawalTest()
        {
            _account.Withdraw(200);

            _transactionRepository.Received().AddWithdrawal(
                new Transaction(-200, DateTime.Today,TypeTransaction.WITHDRAW));
        }

       

        
    }
}
