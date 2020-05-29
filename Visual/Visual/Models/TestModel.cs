using System;
using System.Collections.Generic;
using System.Text;

namespace Visual.Models
{
    public class TestModel
    {
        public string Nombre { get; set; }
        public string Edad { get; set; }
        public string Correo { get; set; }
        public string Sueldo { get; set; }

        public TestModel(string n, string e, string c, string s)
        {
            Nombre = n;
            Edad = e;
            Correo = c;
            Sueldo = s;
        }
    }
}
