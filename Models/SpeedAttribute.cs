using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class SpeedAttribute:Attribute
    {
        public Attribute DX { get; set; }
        public Attribute HT { get; set; }

        private int _level;
        public override int Level
        {
            get { return _level; }
            set
            {
                _level = value;
                OnPropertyChanged(nameof(Level));
                OnPropertyChanged(nameof(Cost));
                OnPropertyChanged(nameof(Value));
            }
        }

        public double Value
        {
            get
            {
                if (Initials == "SP")
                {
                    return (HT + DX + Level) / 4.0;
                } else // MV
                {
                    return Convert.ToInt32((HT.Level + DX.Level) / 4.0) + Level;
                }
            }
        }

        public new int Cost
        {
            get
            {
                return Level * LevelCost;
            }
        }

        public SpeedAttribute(string name, string initials, int levelcost, Attribute dx=null, Attribute ht=null):base(name,initials,levelcost)
        {
            DX = dx;
            HT = ht;
            Level = 0;
        }

        public static implicit operator double(SpeedAttribute attribute)
        {
            return attribute.Value;
        }

        internal void UpdateValue()
        {
            OnPropertyChanged(nameof(Value));
        }
    }
}
