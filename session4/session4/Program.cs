namespace session4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Using parameterized constructor
                BankAccount account1 = new BankAccount(
                    fullName: "Ali Hassan",
                    nationalID: "29807150123456",
                    phoneNumber: "01012345678",
                    address: "Cairo, Egypt",
                    balance: 1500.75m
                );

                // Using overloaded constructor (balance = 0 by default)
                BankAccount account2 = new BankAccount(
                    fullName: "Nour Ahmed",
                    nationalID: "30011250111222",
                    phoneNumber: "01123456789",
                    address: "Giza, Egypt"
                );

                // Display accounts
                account1.ShowAccountDetails();
                account2.ShowAccountDetails();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }




        }
    }
}
