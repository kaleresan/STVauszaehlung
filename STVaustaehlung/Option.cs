using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STVaustaehlung
{
    class Option
    {
        public string Name;
        public int ID;
        public int Votes = 0;

        public Option(string Name, int ID)
        {
            this.Name = Name;
            this.ID = ID;
        }
    }
}
