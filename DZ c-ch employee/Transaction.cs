using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_c_ch_employee
{
    public interface ITransaction
    {
        string TransactionId { get; }
        decimal Amount { get; }
        DateTime Date { get; }


    }


    public class Transaction : ITransaction
    {
        public string TransactionId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date {  get; set; }

        public Transaction(string transactionId, decimal amount, DateTime date)
        {
            TransactionId = transactionId;
            Amount = amount;
            Date = date;
        }


    }


    public class TransactionOperetion<T>where T : ITransaction
    {
        List<T> transactions = new List<T>();

        public void Add(T t) 
        {
            transactions.Add(t);
        }
        public void Remove(T t)
        {
            transactions.Remove(t);
        }


        public decimal SrSummTransaction(DateTime dateTimeStart, DateTime dateTimeEnd)
        {
            transactions = transactions.OrderBy(t=>t.Date).ToList();
            var SortListTransaction = transactions.Where(a => a.Date >= dateTimeStart && a.Date <= dateTimeEnd);        
            var MidllSumTransaction = SortListTransaction.Sum(s => s.Amount) / SortListTransaction.Count();


            return MidllSumTransaction;
        }

    }
}
