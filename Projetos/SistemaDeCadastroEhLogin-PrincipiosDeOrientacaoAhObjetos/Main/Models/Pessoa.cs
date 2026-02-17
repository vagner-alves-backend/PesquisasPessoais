using System;
using System.Collections.Generic;
using System.Linq;
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
                if (string.IsNullOrEmpty(value)) throw new Exception("Name null.");
                _name = value;
            }
        }
        public string? Password
        {
            get => _password;
            set
            {
                if (string.IsNullOrEmpty(value)) throw new Exception("Password null.");
                if (!int.TryParse(value, out _)) throw new Exception("Not number.");
                if (Convert.ToInt32(value) > 10000 && Convert.ToInt32(value) < 99999) throw new Exception("Password invalid, não pode iniciar com [0].");
                if (Convert.ToInt32(value) < 100000) throw new Exception("Password invalid, minimo não atingido..: [000000]");
                if (Convert.ToInt32(value) > 999999) throw new Exception("Password invalid, maximo permitido ultrapassad..: [000000]");
                _password = value;
            }
        }
        public string? GetName() => _name;
        public string? GetPassword() => _password;
    }
}