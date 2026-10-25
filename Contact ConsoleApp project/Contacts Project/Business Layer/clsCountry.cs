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


        public clsCountry()
        {
            this._ID = -1;
            this._CountryName = "";

            Mode = enMode.AddNew;
        }

        private clsCountry(int ID,string CountryName)
        {
            this._ID = ID;
            this._CountryName = CountryName;

            Mode = enMode.Update;
        }

        private bool _AddNewCountry()
        {
            this._ID = clsCountryData.AddNewCountry(this.CountryName);

            return (this._ID != -1);
        }

        private bool _UpdateCountry()
        {
            return clsCountryData.UpdateCountry(this._ID, this._CountryName);
        }
        public static clsCountry Find(int ID)
        {
            string CountryName = "";

            if (clsCountryData.FindCountryByID(ID, ref CountryName))
                return new clsCountry(ID, CountryName);
            else
                return null;
        }

        public static clsCountry Find(string CountryName)
        {
            int ID=-1;

            if (clsCountryData.FindCountryByName(ref ID,CountryName))
                return new clsCountry(ID, CountryName);
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