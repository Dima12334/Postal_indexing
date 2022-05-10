using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Postal_indexing
{
    public class User 
    {
        private string name;
        private string password;
        public int Id { get; set; }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public User() 
        { 

        }

        public User(string name,
            string password)
        {
            this.name = name;
            this.password = password;
        }
    }
}
