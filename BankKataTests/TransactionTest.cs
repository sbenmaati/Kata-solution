using System;
using BankKata;
using NUnit.Framework;

namespace BankKataTests
{
    [TestFixture]
    class TransactionTest
    {
        [Test]
        public void FormatDepositTransaction()
        {
            var transaction = new Transaction(500, new DateTime(2019, 03, 03),TypeTransaction.DEPOSIT);

            Assert.AreEqual(
                "DEPOSIT ||03/03/2019 ||500.00",
                transaction.ToString());
        }

        [Test]
        public void FormatWithdrawalTransaction()
        {
            var transaction = new Transaction(-500, new DateTime(2019, 01, 01),TypeTransaction.WITHDRAW);

            Assert.AreEqual(
                "WITHDRAW ||01/01/2019 ||500.00",
                transaction.ToString());
        }
    }
}
