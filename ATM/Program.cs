using System;

public class cardHolder
{
    string firstName;
    string lastName;
    int pin;
    string cardNum;
    double balance;

    //constructor for the cardholder class
    public cardHolder(string firstName, string lastName, int pin, string cardNum, double balance)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.pin = pin;
        this.cardNum = cardNum;
        this.balance = balance;
    }

    //getter methods below
    public string getNum() 
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public string getFirstName()
    {
        return firstName;
    }

    public string getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    //setter methods below
    public void setNum(string newCardNum)
    {
        this.cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        this.pin = newPin;
    }

    public void setFirstName(string newFirstName)
    {
        this.firstName = newFirstName;
    }

    public void setLastName(string newLastName)
    {
        this.lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        this.balance = newBalance;
    }

    public static void Main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Depost");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much would you like to deposti? ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank you for your deposit. Your new ballance is " + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much would you like to withdraw: ");
            double withdrawal = Double.Parse(Console.ReadLine());

            if(currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insufficient balance :(");
            }
            else
            {
                double newBalance = currentUser.getBalance() - withdrawal;
                Console.WriteLine("You are good to go!");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("John", "Griffith", 1234, "1111222233334444", 150.31));
        cardHolders.Add(new cardHolder("Ashley", "Jones", 4321, "4444333322221111", 321.13));
        cardHolders.Add(new cardHolder("Dawn", "Smith", 4826, "5555666677778888", 54.27));

        // Prompt user
        Console.WriteLine("Welcome to SimpleATM");
        Console.WriteLine("Please insert your debit card: ");
        String debitCardNum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                //Check against db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Card not recognized. Please try again"); }
            }
            catch { Console.WriteLine("Card mpt recognized. Please try again."); }

        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect pin. Please try again"); }
            }
            catch { Console.WriteLine("Incorrect pin. Please try again."); }
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName() + " :)");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if(option == 1) {  deposit(currentUser); }
            else if(option == 2) { withdraw(currentUser); }
            else if(option == 3) { balance(currentUser); }
            else if(option == 4) { break; }
            else { option = 0; }
        }
        while (option != 4);
        Console.WriteLine("Thank you, have a nice day!");
    }
}