using System.Collections.Generic;

namespace BankKata
{
    public class StatementPrinter 
    {
        private readonly OutputWriter _outputWriter;

        public StatementPrinter(OutputWriter outputWriter)
        {
            _outputWriter = outputWriter;
        }

        public void Print(List<Transaction> transactions)
        {
            PrintStatementHeader();

            PrintStatementLines(FormatStatementLines(transactions));
        }

        private void PrintStatementLines(IList<string> lines)
        {
            foreach (var line in lines)
            {
                _outputWriter.Print(line);
            }
        }

        private static List<string> FormatStatementLines(List<Transaction> transactions)
        {
            int balance = 0;
            List<string> formattedTransactions = new List<string>();

            foreach (var transaction in transactions)
            {
                balance += transaction.getAmount();
                formattedTransactions.Add(
                    $"{transaction.ToString()} ||{balance}.00");
            }

            formattedTransactions.Reverse();

            return formattedTransactions;
        }

        private void PrintStatementHeader()
        {
            _outputWriter.Print("OPERATION || DATE || AMOUNT || BALANCE");
        }
    }
}