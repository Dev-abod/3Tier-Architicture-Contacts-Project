using System;
using System.Data;
using DataAccessLayer;

namespace Business_Layer
{
    public class clsCountry
    {
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
        }

        private clsCountry(int ID,string CountryName)
        {
            this._ID = ID;
            this._CountryName = CountryName;
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


    }

}