using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STVaustaehlung
{
    class Vote
    {
        public List<Option> Votes;

        public Vote(List<Option> Votes)
        {
            this.Votes = Votes;
        }
    }
}
