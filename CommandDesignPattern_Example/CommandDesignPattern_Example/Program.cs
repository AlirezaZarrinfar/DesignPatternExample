
using System;

namespace CommandDesignPattern_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            BankCommand_1 command1 = new BankCommand_1(new BankAccount());
            command1.Execute();
        }
        // Receiver
        public class BankAccount 
        {
            public void Execute()
            {
                Console.WriteLine("Your command has been done");
            }
        }
        // Command Interface / Abstract Class
        public abstract class BankCommand
        {
            public BankAccount BankAccount;
            public BankCommand(BankAccount BankAccount)
            {
                this.BankAccount = BankAccount;
            }
            public abstract void Execute();
        }
        // A Command
        public class BankCommand_1:BankCommand
        {
            public BankCommand_1(BankAccount account) : base(account)
            {

            }
            public override void Execute()
            {
                BankAccount.Execute();
            }
        }


    }
}
