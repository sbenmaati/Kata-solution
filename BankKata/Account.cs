using System;
using System.Collections.Generic;

namespace BankKata
{
    public class Account
    {
        private readonly TransactionRepository _transactionRepository;
        private readonly StatementPrinter _statementPrinter;


        public Account(TransactionRepository transactionRepository ,StatementPrinter statementPrinter )
        {
           
            _transactionRepository = transactionRepository;
            _statementPrinter = statementPrinter;
            
                    
        }

        public void Deposit(int amount)
        {   if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("Amount must be positive");
            }
            var deposit = new Transaction(amount, DateTime.Today,TypeTransaction.DEPOSIT);
            _transactionRepository.AddDeposit(deposit);
        }

        public void Withdraw(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("Amount must be positive");
            }
            var withdrawal = new Transaction(-amount, DateTime.Today,TypeTransaction.WITHDRAW);
            _transactionRepository.AddWithdrawal(withdrawal);
        }

        public void PrintStatement()
        {
            List<Transaction> transactions = _transactionRepository.GetTransactions();

            _statementPrinter.Print(transactions);
        }

    }
}