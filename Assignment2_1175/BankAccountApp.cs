using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Assignment2_1175
{
    class BankAccountApp
    {
        static void Main(string[] args)
        {
            try
            {
                List<BankAccount> bankAccounts = new List<BankAccount>();

                ConsoleKeyInfo key_info = new ConsoleKeyInfo();

                while (key_info.Key != ConsoleKey.E)
                {
                    Console.WriteLine("Please select an option from the given menu: ");
                    Console.WriteLine("\tAdd to the database.......enter 'A'");
                    Console.WriteLine("\tSearch the database.......enter 'S'");
                    Console.WriteLine("\tDisplay all the records in the database....enter 'D'");
                    Console.WriteLine("\tExit....enter 'E'");

                    Console.Write("Enter your choice here: ");
                    key_info = Console.ReadKey();

                    if (key_info.Key == ConsoleKey.A)
                    {
                        Console.Write("\n\nEnter account number: ");
                        int account_number = Convert.ToInt32(Console.ReadLine());

                        if (bankAccounts.Count >= 15)
                        {
                            Console.WriteLine("\nSorry - the array is full -- cannot add a record");
                            continue;
                        }

                        if (bankAccounts.Exists(x => x.account_number == account_number))
                        {
                            Console.WriteLine("\nSorry account already exists");
                            continue;
                        }

                        string full_name = "";
                        do
                        {
                            Console.Write("Enter full name in firstname space lastname format: ");
                            full_name = Console.ReadLine();
                        } while (full_name.IndexOf(" ") == -1 || full_name.IndexOf(" ") == full_name.Length - 1);

                        full_name = full_name.Trim(' ');

                        string date = "";
                        Regex regex = new Regex(@"\d\d/\d\d/\d\d\d\d");
                        do
                        {
                            Console.Write("Enter date of birth in mm/dd/yyyy format: ");
                            date = Console.ReadLine();

                        } while (!regex.IsMatch(date));

                        DateTime date_of_birth = Convert.ToDateTime(date);

                        Console.Write("Enter initial balance: ");
                        decimal initial_balance = 0;
                        try
                        {
                            initial_balance = Convert.ToDecimal(Console.ReadLine());
                            if (initial_balance < 0) throw new ArithmeticException("Balance cannot be less than zero.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine("Initial balance: 0");
                            initial_balance = 0;
                        }

                        bankAccounts.Add(new BankAccount(account_number, full_name, date_of_birth, initial_balance));

                        Console.WriteLine("A new bank account is added");
                    }
                    else if (key_info.Key == ConsoleKey.S)
                    {
                        if (bankAccounts.Count < 1)
                        {
                            Console.WriteLine("\nSorry the database is empty\n");
                            continue;
                        }

                        Console.WriteLine("\nChoice is search");
                        Console.Write("Enter account number to search: ");
                        int account_number = Convert.ToInt32(Console.ReadLine());
                        BankAccount ba = bankAccounts.Find(x => x.account_number == account_number);
                        if (ba != null)
                        {
                            Console.WriteLine($"Searching the database for account number = {account_number} has finished successfully.");
                            Console.WriteLine($"Last name: {ba.GetLastName()}");
                            Console.WriteLine($"Year of birth: {ba.GetBirthYear()}");
                            Console.WriteLine($"Balance: {ba.initial_balance}");
                        }
                        else
                        {
                            Console.WriteLine("Record not found.");
                        }

                    }
                    else if (key_info.Key == ConsoleKey.D)
                    {
                        if (bankAccounts.Count < 1)
                        {
                            Console.WriteLine("\nSorry the database is empty\n");
                            continue;
                        }

                        Console.WriteLine("\nChoice is display all records");
                        foreach (BankAccount ba in bankAccounts)
                        {
                            Console.WriteLine($"\nLast name: {ba.GetLastName()}");
                            Console.WriteLine($"Year of birth: {ba.GetBirthYear()}");
                            Console.WriteLine($"Account number: {ba.account_number}");
                            Console.WriteLine($"Balance: {ba.initial_balance}");
                        }
                    }
                    else if (key_info.Key == ConsoleKey.E)
                    {
                        Console.WriteLine("\nGood bye");
                        Console.ReadKey();
                    }

                    Console.WriteLine("\n");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}
