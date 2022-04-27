using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Postal_indexing
{
    internal class Field
    {
        private string country, region, district, city, code, address, status, timetable;

        public int id { get; set; }

        public string Country
        {
            get { return country; }
            set { country = value; }
        }

        public string Region
        {
            get { return region; }
            set { region = value; }
        }

        public string District
        {
            get { return district; }
            set { district = value; }
        }
        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public string Timetable
        {
            get { return timetable; }
            set { timetable = value; }
        }



        public Field() { }

        public Field(string country, string region, string district, string city, string code, string address, string status, string timetable)
        {
            this.country = country;
            this.region = region;
            this.district = district;
            this.city = city;
            this.code = code;
            this.address = address;
            this.status = status;
            this.timetable = timetable;
        }

        public override string ToString()
        {
            return " Країна : " + Country + "\n" + " Область (край) : " + Region + "\n" + " Район : " + District + "\n" + " Населений пункт : " + City + "\n" + " Поштовий індекс : " + Code + "\n" + " Адреса відділення : " + Address + "\n" + " Статус відділення: " + Status + "\n" + " Графік роботи: " + Timetable + "\n";
        }
    }
}
