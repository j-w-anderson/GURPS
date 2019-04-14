using Engine;
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
            _standardAttributes.Add(new Attribute("Hit Points", "HP", 2));
            _standardAttributes.Add(new Attribute("Willpower", "WL", 5));
            _standardAttributes.Add(new Attribute("Perception", "PR", 5));
            _standardAttributes.Add(new Attribute("Fatique Points", "FP", 2));
            _standardAttributes.Add(new SpeedAttribute("Basic Speed", "SP", 5));
            _standardAttributes.Add(new SpeedAttribute("Basic Move", "MV", 5));
        }

        public static Attribute getAttribute(string initials, Attribute link=null,Attribute link2=null)
        {
            Attribute fetch = _standardAttributes.FirstOrDefault(att => att.Initials == initials);
            if(fetch == null)
            {
                throw new ArgumentException();
            }
            if (link == null)
            {
                return new Attribute(fetch.Name, fetch.Initials, fetch.LevelCost);
            } else if(link2==null) {
                return new Attribute(fetch.Name, fetch.Initials, fetch.LevelCost, link);
            } else {
                return new SpeedAttribute(fetch.Name, fetch.Initials, fetch.LevelCost, link, link2);
            }
        }
    }
}
