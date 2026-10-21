using System;
using System.Data;
using Business_Layer;

namespace Contacts_Project
{
    public class Presentation
    {
        public static void Find(int ID)
         {
            clsContact Contact = clsContact.Find(ID);

            if (Contact != null)
            {
                Console.WriteLine(Contact.FirstName + " " +Contact.LastName);
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
            contact.DateOfBirth = DateTime.Now ;
            contact.CountryID = 1;
            contact.ImagePath = "";

            if(contact.Save())
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
                Contact.DateOfBirth = new DateTime(1977,11,6,10,30,0); 
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
        static void Main(string[] args)
        {
            //AddNewContact();
            Update(1);


            Console.ReadKey();
        }
    }
}
