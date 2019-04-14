using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Attribute:BaseNotificationClass
    {
        public string Name { get; set; }
        public string Initials { get; set; }
        public int LevelCost { get; }
        public Attribute Link { get; set; }
        private int _level;
        public virtual int Level
        {
            get { return _level; }
            set
            {
                _level = value;
                OnPropertyChanged(nameof(Level));
                OnPropertyChanged(nameof(Cost));
            }
        }

        public int Cost
        {
            get
            {
                int basevalue = Link == null ? 10 : Link.Level;
                int delta = Level-10;
                return delta*LevelCost;
            }
        }

        public Attribute(string name,string initials,int levelcost,Attribute link=null)
        {
            Name = name;
            Initials = initials;
            LevelCost = levelcost;
            Level = 10;
            Link = link;
        }
        
        public static implicit operator int (Attribute attribute)
        {
            return attribute.Level;
        }
    }
}
