namespace Simple_Contacts_Manager
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Contact
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }

    class Program
    {
        static List<Contact> contacts = new List<Contact>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Contacts Manager");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. View List of Contacts");
                Console.WriteLine("3. Remove Contact by email");
                Console.WriteLine("Press Esc to go back to main menu");

                var key = Console.ReadKey();
                Console.WriteLine();

                if (key.Modifiers == ConsoleModifiers.Control && key.Key == ConsoleKey.Escape)
                    continue;

                switch (key.KeyChar)
                {
                    case '1':
                        AddContact();
                        break;
                    case '2':
                        ViewContacts();
                        break;
                    case '3':
                        RemoveContact();
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }

        static void AddContact()
        {
            Console.WriteLine("Enter Name:");
            var name = Console.ReadLine();

            Console.WriteLine("Enter Phone:");
            var phone = Console.ReadLine();

            Console.WriteLine("Enter Email:");
            var email = Console.ReadLine();

            if (!IsValidEmail(email))
            {
                Console.WriteLine("Invalid email format");
                return;
            }

            if (!IsValidPhoneNumber(phone))
            {
                Console.WriteLine("Invalid phone number format");
                return;
            }

            if (string.IsNullOrWhiteSpace(name) || name.Length < 3)
            {
                Console.WriteLine("Name must be at least 3 characters long");
                return;
            }

            contacts.Add(new Contact { Name = name, Phone = phone, Email = email });
            Console.WriteLine("Contact added successfully");
        }

        static void ViewContacts()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts found");
                return;
            }

            Console.WriteLine("List of saved contacts:");
            foreach (var contact in contacts)
            {
                Console.WriteLine($"Name: {contact.Name}, Phone: {contact.Phone}, Email: {contact.Email}");
            }
        }

        static void RemoveContact()
        {
            Console.WriteLine("Enter the email of the contact to remove:");
            var email = Console.ReadLine();

            var contactToRemove = contacts.FirstOrDefault(c => c.Email == email);
            if (contactToRemove == null)
            {
                Console.WriteLine("No contact found with that email");
                return;
            }

            contacts.Remove(contactToRemove);
            Console.WriteLine("Contact removed successfully");
        }

        static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        static bool IsValidPhoneNumber(string phone)
        {
            
            return phone.All(char.IsDigit);
        }
    }

}
