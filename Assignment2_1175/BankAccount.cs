using System;

namespace Assignment2_1175
{
    class BankAccount
    {
        public int account_number { get; set; }
        private string full_name;
        private DateTime date_of_birth;
        public decimal initial_balance { get; set; }

        public BankAccount()
        {

        }

        public BankAccount(int account_number, string full_name, DateTime date_of_birth, decimal initial_balance)
        {
            this.account_number = account_number;
            this.full_name = full_name;
            this.date_of_birth = date_of_birth;
            this.initial_balance = initial_balance;
        }

        public string GetLastName()
        {
            return full_name.Substring(full_name.IndexOf(" ") + 1, full_name.Length - (full_name.IndexOf(" ") + 1));
        }

        public string GetBirthYear()
        {
            return date_of_birth.Year.ToString();
        }
    }
}
