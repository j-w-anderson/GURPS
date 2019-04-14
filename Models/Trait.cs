using System;

namespace Engine
{
    public class Trait : BaseNotificationClass
    {
        public int Cost { get; set; }
        public int Level { get { return Level; }
            set
            {
                if(value < 0 || value >= LevelCosts.Length)
                {
                    throw new ArgumentOutOfRangeException();
                }
                Level = value;
                Cost = LevelCosts[Level];
            }
        }
        public string Name { get; }
        public string Description { get; }
        private int[] LevelCosts { get; }

        public Trait(string name, int cost, string description)
        {
            Name = name;
            Description = description;
            Cost = cost;
        }

        public Trait(string name, int[] levelcosts, string description)
        {
            Name = name;
            LevelCosts = levelcosts;
            Level = 1;
            Cost = LevelCosts[Level];
        }
    }
}