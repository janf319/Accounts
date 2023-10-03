using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Jan_AccountNameSpace
{
    public abstract class Account
    {
        private string name;        //Account holder name
        private decimal balance;
        private string accountType; //Account type checking or savings
        private ArrayList transactionList = new ArrayList(); //documents all transactions

        public Account(string name, decimal balance, string accountType)
        {
            this.name = name;
            this.balance = balance;
            this.accountType = accountType;
            logTransaction("\n" + accountType + ": Account created with starting balance " + balance);
        }

        public decimal Balance { get { return balance; } }
        public String Name { get { return Name; } }
        public ArrayList TransactionList { get { return transactionList; } }
        public string AccountType { get { return accountType; } }


        public void deposit(decimal amount)
        {
            balance += amount;
            logTransaction(accountType + ": Deposit " + amount + "\tbalance " + balance);
        }

        public virtual bool withdraw(decimal amount)
        {
            bool complete = false;
            if (amount <= balance)
            {
                balance -= amount;
                logTransaction(accountType + ": Withdraw " + amount + "\tbalance " + balance);
                complete = true;
            }
            else
            {
                logTransaction(accountType + ": INSUFFICENT FUNDS for the transaction");
            }
            return complete;
        }

        public void logTransaction(string transaction)
        {
            transactionList.Add(transaction);
        }

        public abstract bool transferTo(Account account, decimal amount);
    }
}
