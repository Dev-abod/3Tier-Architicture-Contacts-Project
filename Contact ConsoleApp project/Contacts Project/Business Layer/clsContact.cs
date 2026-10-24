using System;
using System.Data;
using DataAccessLayer;

namespace Business_Layer
{
    public class clsContact
    {
        public enum enMode { Update =1 , AddNew =2};
        enMode Mode;

        private int _ID;
        private string _FirstName;
        private string _LastName;
        private string _Email;
        private string _Phone;
        private string _Address;
        private DateTime _DateOfBirth;
        private int _CountryID;
        private string _ImagePath;

        public int ID
        {
            get { return _ID; }
        }
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        public DateTime DateOfBirth
        {
            get { return _DateOfBirth; }
            set { _DateOfBirth = value; }
        }
        public int CountryID
        {
            get { return _CountryID; }
            set { _CountryID = value; }
        }
        public string ImagePath
        {
            get { return _ImagePath; }
            set { _ImagePath = value; }
        }


        private bool _AddNewContact()
        {
            this._ID = clsContactData.AddNewContact(_FirstName, _LastName,_Email, _Phone, _Address,
                _CountryID, _DateOfBirth, _ImagePath);

            return (this._ID != -1);
        }

        private bool _UpdateContact()
        {
            return clsContactData.UpdateContact(this.ID, this._FirstName, this._LastName, this._Email, this._Phone, this._Address,
                this._CountryID, this._DateOfBirth, this._ImagePath);
        }

        private clsContact(int ID, string FirstName, string LastName,
             string Email, string Phone, string Address, 
             int CountryID, DateTime DateOfBirth, string ImagePath)
        {
            this._FirstName = FirstName;
            this._LastName = LastName;
            this._Email = Email;
            this._Phone = Phone;
            this._Address = Address;
            this._DateOfBirth = DateOfBirth;
            this._CountryID = CountryID;
            this._ImagePath = ImagePath;

            Mode = enMode.Update;
        }

        public clsContact()
        {
            this._FirstName = FirstName;
            this._LastName = LastName;
            this._Email = Email;
            this._Phone = Phone;
            this._Address = Address;
            this._DateOfBirth = DateOfBirth;
            this._CountryID = CountryID;
            this._ImagePath = ImagePath;

            Mode = enMode.AddNew;

        }

        public static clsContact Find(int ID)
        {
            string FirstName="", LastName = "", ImagePath = "", Email = "", Phone = "", Address = "";
            DateTime DateOfBirth = DateTime.Now;
            int CountryID = -1;
            if (clsContactData.GetContactInfoById(ID, ref FirstName, ref LastName, ref Email, ref Phone, ref Address
                , ref CountryID, ref DateOfBirth, ref ImagePath))
                return new clsContact(ID, FirstName, LastName, Email, Phone, Address, CountryID, DateOfBirth, ImagePath);
            else
                return null;
        }

        public static bool Delete(int ID)
        {
            return clsContactData.Delete(ID);
        }

        public static DataTable GetAllContacts()
        {
            return clsContactData.GetAllContacts();
        }

        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if (_AddNewContact())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateContact();
                    

            }

            return false;
        }

        public static bool isContactExist(int ID)
        {
            return clsContactData.isContactExist(ID);
        }

    }
}
