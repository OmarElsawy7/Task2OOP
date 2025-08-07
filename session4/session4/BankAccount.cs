using System;

class BankAccount
{
    // Fields
    public const string BankCode = "BNK001"; // constant
    public readonly DateTime CreatedDate;    // read-only

    private int _accountNumber;
    private string _fullName;
    private string _nationalID;
    private string _phoneNumber;
    private string _address;
    private decimal _balance;

    private static int _accountCounter = 1000;

    // Properties
    public string FullName
    {
        get => _fullName;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Full name cannot be null or empty.");
            _fullName = value;
        }
    }

    public string NationalID
    {
        get => _nationalID;
        set
        {
            if (!IsValidNationalID(value))
                throw new ArgumentException("National ID must be exactly 14 digits.");
            _nationalID = value;
        }
    }

    public string PhoneNumber
    {
        get => _phoneNumber;
        set
        {
            if (!IsValidPhoneNumber(value))
                throw new ArgumentException("Phone number must start with '01' and be 11 digits.");
            _phoneNumber = value;
        }
    }

    public string Address
    {
        get => _address;
        set => _address = value; // optional, no validation
    }

    public decimal Balance
    {
        get => _balance;
        set
        {
            if (value < 0)
                throw new ArgumentException("Balance cannot be negative.");
            _balance = value;
        }
    }

    public int AccountNumber => _accountNumber;

    // Constructors
    public BankAccount()
    {
        _accountNumber = ++_accountCounter;
        CreatedDate = DateTime.Now;
        FullName = "Unknown";
        NationalID = "00000000000000";
        PhoneNumber = "01000000000";
        Address = "N/A";
        Balance = 0;
    }

    public BankAccount(string fullName, string nationalID, string phoneNumber, string address, decimal balance)
    {
        _accountNumber = ++_accountCounter;
        CreatedDate = DateTime.Now;
        FullName = fullName;
        NationalID = nationalID;
        PhoneNumber = phoneNumber;
        Address = address;
        Balance = balance;
    }

    public BankAccount(string fullName, string nationalID, string phoneNumber, string address)
        : this(fullName, nationalID, phoneNumber, address, 0) { }

    // Methods
    public void ShowAccountDetails()
    {
        Console.WriteLine("----- Account Details -----");
        Console.WriteLine($"Bank Code     : {BankCode}");
        Console.WriteLine($"Account No.   : {_accountNumber}");
        Console.WriteLine($"Created Date  : {CreatedDate}");
        Console.WriteLine($"Full Name     : {FullName}");
        Console.WriteLine($"National ID   : {NationalID}");
        Console.WriteLine($"Phone Number  : {PhoneNumber}");
        Console.WriteLine($"Address       : {Address}");
        Console.WriteLine($"Balance       : {Balance:C}");
        Console.WriteLine();
    }

    public static bool IsValidNationalID(string nationalID)
    {
        return nationalID != null && nationalID.Length == 14 && long.TryParse(nationalID, out _);
    }

    public static bool IsValidPhoneNumber(string phone)
    {
        return phone != null && phone.Length == 11 && phone.StartsWith("01") && long.TryParse(phone, out _);
    }
}

// Program Entry Point

