// Task 1: Modular Payment System
// Task: Develop a payment processing system where multiple payment methods (credit card, PayPal, bank transfer) are supported.
// Ensure that new payment methods can be added without modifying existing logic.
// Restrict direct modification of transaction details while allowing validation checks.
// Implement automatic transaction fee calculation based on the payment method.
// Allow dynamic selection of payment methods during checkout.

using System;

class User {
    public string Name {get;}
    private decimal _balance;
    public decimal Balance {
        get {
            return _balance;
        }
        set {
            if (value < 0) {
                throw new ArgumentOutOfRangeException("\n\nBalance can not be negative\n");
            }
            _balance = value;
        }
    }
    public User (string name, decimal balance) {
        Name = name;
        Balance = balance;
    }
    public void Display () {
        Console.WriteLine ($"\nName: {Name}\nBalance: {Balance}\n");

    }
}

interface IPaymentMethod {
    string Name { get;  }
    decimal CalculateTransactionFee (decimal amount);
    bool ProcessPayment (decimal amount, User user);
}

class CreditCardPayment : IPaymentMethod {
    
    public string Name {get {return "CreditCardPayment";}}

    // public CreditCardPaymnt (string name) {

    //     Name = name;
    // }
    
    public decimal CalculateTransactionFee (decimal amount) {
        if (amount <= 0) {
            Console.WriteLine ("\nAmount can not be 0 or less(CalculateTransactinfee)\n");
            
        }
        return amount * 0.02m;
    }
    
    public bool ProcessPayment (decimal amount , User user) {
        if (amount <= 0) {
            throw new ArgumentException ("\n\nAmount can npot be negativ or 0");
            return false;
        }
        decimal Percentage = CalculateTransactionFee (amount);
        decimal a = amount + Percentage;
        user.Balance -= a;
        //Console.WriteLine ("\n%%%%" + Percentage + "\n");
        Console.WriteLine  ($"\na == {a}\n");
        Console.WriteLine ($"Transaction percentage is {Percentage}\nFinel sum is {a}\n");
        return true;
    }
}

class PayPalPayment {

    public string Name {get {return "PayPalPayment";}}

    public decimal CalculateTransactionFee (decimal amount) {

        if (amount <= 0) {
            Console.WriteLine ("\nAmount can not be 0 or less(CalculateTransactinfee)\n");
        }    
        return amount * 0.03m;
    }
    public bool ProcessPayment (decimal amount, User user) {

        if (amount <= 0) {
            throw new ArgumentException ("\n\nAmoount can not be 0 or less\n\n");
            return false;
        }

        decimal Percentage = CalculateTransactionFee (amount) + amount;
        decimal a = amount + Percentage;
        Console.WriteLine ($"Transaction percentage is {Percentage}\nFinel sum is {a}\n");
        return true;
    }
}

class BankTransferPayment {

    public string Name {get {return "BankTransferPayment";}}

    public decimal CalculateTransactionFee (decimal amount) {
        if (amount <= 0) {
            Console.WriteLine ("\nAmount can not be 0 or less(CalculateTransactinfee)\n");
        }
        
        return amount * 0.04m;

    }

    public bool ProcessPayment (decimal amount, User user) {
        if (amount <= 0) {
            throw new ArgumentException ("\n\nAmount can npot be negativ or 0");
            return false;
        }
        decimal Percentage = CalculateTransactionFee (amount) + amount;
        return true;
    }
}

 
class Program {
    static void Main (string[] args) {

        User user1 = new User ("Tigran", 200);
        User user2 = new User ("Davit", 10000);
        CreditCardPayment credit = new CreditCardPayment();
        PayPalPayment Paypal = new PayPalPayment();
        BankTransferPayment Bank = new BankTransferPayment();
        Console.WriteLine ();
        user1.Display();
        credit.ProcessPayment(100, user1);
        user1.Display();



    }
}
