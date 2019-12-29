using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using BankKata;

namespace BankKataTests
{
    [TestFixture]
    public class StatementPrinterTest
    {
        private Mock<OutputWriter> _outputWriter;
        private StatementPrinter _statementPrinter;

        [SetUp]
        public void Initialise_Test()
        {
            _outputWriter = new Mock<OutputWriter>();

            _statementPrinter = new StatementPrinter(_outputWriter.Object);
        }

        [Test]
        public void PrintStatementWithAllTransactions()
        {
            var transactions = GetTransactionsForTest();

            _statementPrinter.Print(transactions);
            string Header = "OPERATION || DATE || AMOUNT || BALANCE";
            string DEPOSIT = "DEPOSIT ||10/10/2019 ||1000.00 ||1000.00";
            string WITHDRAW = "WITHDRAW ||12/12/2019 ||100.00 ||900.00";
            _outputWriter.Verify(x => x.Print(Header), Times.Once());
            _outputWriter.Verify(x=>x.Print(DEPOSIT), Times.Once());
            _outputWriter.Verify(x => x.Print(WITHDRAW), Times.Once());
            
        }

        private static List<Transaction> GetTransactionsForTest()
        {
            var transactions = new List<Transaction>
            {
                new Transaction(1000 ,new DateTime(2019, 10, 10),TypeTransaction.DEPOSIT),
                new Transaction(-100 ,new DateTime(2019, 12, 12),TypeTransaction.WITHDRAW),
               
            };
            return transactions;
        }
    }
}