using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    internal static class AttributeFactory
    {
        private static List<Attribute> _standardAttributes;

        static AttributeFactory()
        {
            _standardAttributes = new List<Attribute>();

            _standardAttributes.Add(new Attribute("Strength", "ST", 10));
            _standardAttributes.Add(new Attribute("Intelligence", "IQ", 20));
            _standardAttributes.Add(new Attribute("Dexterity", "DX", 20));
            _standardAttributes.Add(new Attribute("Health", "HT", 10));
            _standardAttributes.Add(new SecondaryAttribute("Hit Points", "HP", 2));
            _standardAttributes.Add(new SecondaryAttribute("Willpower", "WL", 3));
            _standardAttributes.Add(new SecondaryAttribute("Perception", "PR", 5));
            _standardAttributes.Add(new SecondaryAttribute("Fatique Points", "FP", 2));
        }

        public static Attribute getAttribute(string initials, Attribute link=null)
        {
            Attribute fetch = _standardAttributes.FirstOrDefault(att => att.Initials == initials);
            if(fetch == null)
            {
                throw new ArgumentException();
            }
            if (link == null)
            {
                return new Attribute(fetch.Name, fetch.Initials, fetch.LevelCost);
            } else {
                return new SecondaryAttribute(fetch.Name, fetch.Initials, fetch.LevelCost, link);
            }
        }
    }
}
