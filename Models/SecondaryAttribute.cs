using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class SecondaryAttribute:Attribute
    {

        public Attribute Link { get; set; }
        public SecondaryAttribute(string name, string initials, int levelcost, Attribute link=null) : base(name, initials, levelcost)
        {
            Link = link;
            Level = Link.Level;
        }

        public new int Cost
        {
            get
            {
                int delta = Level - Link.Level;
                return delta * LevelCost;
            }
        }
    }
}
