using System;

namespace BankKata
{
    public class Transaction
    {
        private readonly int _amount;
        private readonly DateTime _transactionDate;
        private readonly TypeTransaction _type;

        public Transaction(int amount, DateTime transactionDate ,TypeTransaction type)
        {
            this._amount = amount;
            this._transactionDate = transactionDate;
            this._type = type;
        }


        public int getAmount()
        {
            return _amount;
        }
        public override string ToString()
        {
           
            return $"{_type} ||{ _transactionDate.ToShortDateString()} ||{Math.Abs(_amount)}.00";
        }

        public override bool Equals(object obj)
        {
            Transaction t = obj as Transaction;

            if ((object) t == null) return false;

            return _amount == t._amount
                   && _transactionDate == t._transactionDate
                   && _type == t._type;
        }

        public bool Equals(Transaction t)
        {
            return _amount == t._amount
                   && _transactionDate == t._transactionDate
                    && _type == t._type;
        }
    }
}