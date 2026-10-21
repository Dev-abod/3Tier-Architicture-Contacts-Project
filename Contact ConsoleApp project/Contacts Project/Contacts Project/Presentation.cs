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
        static void Main(string[] args)
        {
            Find(1);

            Console.ReadKey();
        }
    }
}
