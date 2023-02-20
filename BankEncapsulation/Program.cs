namespace BankEncapsulation
{
    public class Program
    {
        static void Main(string[] args)
        {
            string cmd;
            var yourBA = new BankAccount();

            do
            {
                yourBA.Help();
                cmd = Console.ReadLine();
                try
                {
                    switch (cmd.ToUpper().Substring(0, 1))
                    {
                        case "B":
                            Console.WriteLine($"Your current balance is {yourBA.GetBalance()}");
                            break;
                        case "D":
                            yourBA.Deposit(double.Parse(cmd.Substring(1)));
                            break;
                        case "W":
                            yourBA.Withdraw(double.Parse(cmd.Substring(1)));
                            break;
                    }
                }
                catch (Exception ex)
                { 
                    Console.WriteLine(ex.Message);
                }
            } while (cmd.ToUpper() != "E");
        }
    }

    public class BankAccount
    {
        private double _balance;

        public BankAccount()
        {
            _balance= 0;
        }

        public void Deposit(double amt)
        {
            if (amt < 0.01)
                throw new Exception("You must deposit at least one penny.");
            else
                _balance += amt;
        }

        public void Withdraw(double amt)
        {
            if (amt < 0.01)
                throw new Exception("You must withdraw at least one penny.");
            else if (amt > _balance)
                throw new Exception("You cannot overdraw your account.");
            else
                _balance -= amt;
        }

        public double GetBalance()
        {
            return _balance;
        }

        public void Help()
        {
            Console.WriteLine();
            Console.WriteLine("---Four case-insensitive commands are available---");
            Console.WriteLine("DEPOSITS: D followed by the amount, e.g. D44.2 will deposit $44.20 into your account.");
            Console.WriteLine("WITHDRAWALS: W followed by the amount, e.g. W2 will withdraw $2.00 from your account.");
            Console.WriteLine("BALANCE: B will cause your balance to be displayed.");
            Console.WriteLine("EXIT: E will exit this program.");
            Console.WriteLine();
        }
    }
}
