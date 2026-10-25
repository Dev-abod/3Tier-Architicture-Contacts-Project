using System;
using System.Data;
using DataAccessLayer;

namespace Business_Layer
{
    public class clsCountry
    {
        enum enMode { Update =1,AddNew=2};
        enMode Mode;
        private int _ID;
        private string _CountryName;
        private string _Code; 
        private string _PhoneCode;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string CountryName
        {
            get { return _CountryName; }
            set { _CountryName = value; }
        }

        public string Code
        {
            get { return _Code; }
            set { _Code = value; }
        }

        public string PhoneCode
        {
            get { return _PhoneCode; }
            set { _PhoneCode = value; }
        }




        public clsCountry()
        {
            this._ID = -1;
            this._CountryName = "";
            this._Code = "";
            this._PhoneCode = "";

            Mode = enMode.AddNew;
        }

        private clsCountry(int ID,string CountryName, string Code, string PhoneCode)
        {
            this._ID = ID;
            this._CountryName = CountryName;
            this._Code =Code;
            this._PhoneCode = PhoneCode;

            Mode = enMode.Update;
        }

        private bool _AddNewCountry()
        {
            this._ID = clsCountryData.AddNewCountry(this.CountryName,this._Code,this._PhoneCode);

            return (this._ID != -1);
        }

        private bool _UpdateCountry()
        {
            return clsCountryData.UpdateCountry(this._ID, this._CountryName, this._Code, this._PhoneCode);
        }
        public static clsCountry Find(int ID)
        {
            string CountryName = "";
            string Code = "";
            string PhoneCode = "";

            if (clsCountryData.FindCountryByID(ID, ref CountryName,ref Code,ref PhoneCode))
                return new clsCountry(ID, CountryName,Code, PhoneCode);
            else
                return null;
        }

        public static clsCountry Find(string CountryName)
        {
            int ID=-1;
            string Code = "";
            string PhoneCode = "";

            if (clsCountryData.FindCountryByName(ref ID,CountryName))
                return new clsCountry(ID, CountryName, Code, PhoneCode);
            else
                return null;
        }

        public static bool Delete(int ID)
        {
            return clsCountryData.Delete(ID);
        }


        public static bool IsExistCountry(string CountryName)
        {
            return clsCountryData.IsExistCountry(CountryName);
        }
        
        public bool Save()
        {
            switch (Mode)
            {

                case enMode.AddNew:
                    if(_AddNewCountry())
                    {
                        Mode = enMode.AddNew;
                        return true;
                    }
                    break;

                case enMode.Update:
                    return _UpdateCountry(); 
                    break;
                default:
                    break;
            }

            return false;
        }
    }

}