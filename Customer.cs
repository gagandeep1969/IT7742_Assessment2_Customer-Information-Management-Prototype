namespace BankApp
{
    public class Customer
    {
        private int customerNumber;
        private string name;
        private string contact;
        private bool isStaff;

        public Customer(int number, string name, string contact, bool staffFlag)
        {
            customerNumber = number;
            this.name = name;
            this.contact = contact;
            isStaff = staffFlag;
        }

        public int GetCustomerNumber() => customerNumber;
        public string GetName() => name;
        public string GetContact() => contact;
        public void SetContact(string v) => contact = v;
        public bool IsStaff() => isStaff;
    }
}