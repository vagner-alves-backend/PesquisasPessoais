using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Main.Models
{
    public class Pessoa
    {
        private string? _name;
        private string? _password;
        public string? Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new Exception ("Value is null.");
                _name = value;
            }
        }
        public string? Password
        {
            get => _password;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new Exception ("Value is null");
                if (!int.TryParse(value, out int password)) throw new Exception ("Not number.");
                if (password > 10000 && password < 100000) throw new Exception ("The first digit cannot be 0.");
                if (password < 100000) throw new Exception ("Minimum 6-digit number not reached."); 
                if (password > 999999) throw new Exception ("maximum number of digits allowed exceeded.");
                _password = value;
            }
        }
        protected Pessoa() : this ("Name", "100000"){}
        protected Pessoa(string? name, string? password)
        {
            this.Name = name;
            this.Password = password;
        }
    }
}