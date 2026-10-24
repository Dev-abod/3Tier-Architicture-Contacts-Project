using System;
using System.Data;
using Business_Layer;

namespace Contacts_Project
{

    public class clsPresentationContact
    {
        public static void Find(int ID)
        {
            clsContact Contact = clsContact.Find(ID);

            if (Contact != null)
            {
                Console.WriteLine(Contact.FirstName + " " + Contact.LastName);
                Console.WriteLine(Contact.Email);
                Console.WriteLine(Contact.Phone);
                Console.WriteLine(Contact.Address);
                Console.WriteLine(Contact.DateOfBirth);
                Console.WriteLine(Contact.CountryID);
                Console.WriteLine(Contact.ImagePath);
            }
            else
                Console.WriteLine("Not Found");
        }

        public static void AddNewContact()
        {
            clsContact contact = new clsContact();

            contact.FirstName = "Abdullah";
            contact.LastName = "Abdulhamid";
            contact.Email = "ab3awd@gmail.com";
            contact.Phone = "77777777777";
            contact.Address = "zip123";
            contact.DateOfBirth = DateTime.Now;
            contact.CountryID = 1;
            contact.ImagePath = "";

            if (contact.Save())
            {
                Console.WriteLine("Add successfully");
            }

        }

        public static void Update(int ID)
        {
            clsContact Contact = clsContact.Find(ID);

            if (Contact != null)
            {
                Contact.FirstName = "maha";
                Contact.LastName = "awad";
                Contact.Email = "asem@gmail.com";
                Contact.Phone = "77777777777";
                Contact.Address = "zip123";
                Contact.DateOfBirth = new DateTime(1977, 11, 6, 10, 30, 0);
                Contact.CountryID = 1;
                Contact.ImagePath = "";

                if (Contact.Save())
                {
                    Console.WriteLine("Update successfully");
                }
            }
            else
                Console.WriteLine("Not Found");
        }

        public static void Delete(int ID)
        {
            if (clsContact.Delete(ID))
            {
                Console.WriteLine("Deleted");
            }

        }

        public static void ListContacts()
        {
            DataTable datatable = clsContact.GetAllContacts();

            foreach (DataRow row in datatable.Rows)
            {
                Console.WriteLine($"{row["ContactID"]}, {row["FirstName"]}, {row["LastName"]}");
            }
        }

        public static void isContactExist(int ID)
        {
            if (clsContact.isContactExist(ID))
                Console.WriteLine("Exist");
            else
                Console.WriteLine("no Exist");

        }
    }

    public class clsPresentationCountry
    {
        public static void FindCountryByID(int ID)
        {
            clsCountry country = clsCountry.FindCountryByID(ID);

            if(country != null)
                Console.WriteLine($"ID :{country.ID}, CountryName :{country.CountryName}");
            else
                Console.WriteLine("Not Found");

        }
    }


    public class Presentation
    {
        
        static void Main(string[] args)
        {
            clsPresentationCountry.FindCountryByID(20);
            //clsPresentationContact.AddNewContact();
            Console.ReadKey();
        }

        
    }
}
