using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binarios
{
    internal class persona
    {
        public string Age { get; set; }

        public string name { get; set; }

        public string subname { get; set; }

        public persona() 
        {
            Age = "";
            name = "";
            subname = "";
        }

        public override string ToString()
        {
            return Age.ToString() + name.ToString()+ subname.ToString();
        }
    }
}
