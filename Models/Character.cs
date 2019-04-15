using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Character : BaseNotificationClass
    {
        public Attribute ST { get; set; } = AttributeFactory.getAttribute("ST");
        public Attribute IQ { get; set; } = AttributeFactory.getAttribute("IQ");
        public Attribute DX { get; set; } = AttributeFactory.getAttribute("DX");
        public Attribute HT { get; set; } = AttributeFactory.getAttribute("HT");

        public Attribute HP { get; set; }
        public Attribute WL { get; set; }
        public Attribute PR { get; set; }
        public Attribute FP { get; set; }


        public SpeedAttribute SP { get; set; }
        public SpeedAttribute MV { get; set; }

        public ObservableCollection<Trait> Traits { get; set; } = new ObservableCollection<Trait>();
        public ObservableCollection<Skill> Skills { get; set; } = new ObservableCollection<Skill>();
        public ObservableCollection<Spell> Spells { get; set; } = new ObservableCollection<Spell>();
        public ObservableCollection<Item> Equipment { get; set; } = new ObservableCollection<Item>();
        public ObservableCollection<Weapon> Weapons { get; set; } = new ObservableCollection<Weapon>();


        private List<Attribute> Attributes { get; set; }

        public Character()
        {

            HP = AttributeFactory.getAttribute("HP", ST);
            WL = AttributeFactory.getAttribute("WL", IQ);
            PR = AttributeFactory.getAttribute("PR", IQ);
            FP = AttributeFactory.getAttribute("FP", HT);
            SP = (SpeedAttribute)AttributeFactory.getAttribute("SP", DX, HT);
            MV = (SpeedAttribute)AttributeFactory.getAttribute("MV", DX, HT);
            Attributes = new List<Attribute>() { ST, IQ, DX, HT, HP, WL, PR, FP,SP,MV };
            AddTrait();
        }

        public void AddTrait()
        {
            Traits.Add(new Trait());
        }

        public void AdjustAttribute(string initials, int direction)
        {
            if (direction != 1 && direction != -1)
            {
                throw new ArgumentOutOfRangeException();
            }
            Attribute target = Attributes.FirstOrDefault(att => att.Initials == initials);
            if (target == null)
            {
                throw new ArgumentException();
            }
            if (target.GetType() == typeof(SpeedAttribute))
            {
                target = (SpeedAttribute)target;
            }
            target.Level += direction;
            AdjustSecondaries(initials, direction);
        }

        private void AdjustSecondaries(string initials, int direction)
        {
            switch (initials)
            {
                case "ST":
                    AdjustAttribute("HP", direction);
                    break;
                case "DX":
                    SP.UpdateValue();
                    MV.UpdateValue();
                    break;
                case "IQ":
                    AdjustAttribute("WL", direction);
                    AdjustAttribute("PR", direction);
                    break;
                case "HT":
                    AdjustAttribute("FP", direction);
                    SP.UpdateValue();
                    MV.UpdateValue();
                    break;
            }
        }
    }
}
