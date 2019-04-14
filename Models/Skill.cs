using System;

namespace Engine
{
    public class Skill : BaseNotificationClass
    {

        public string Name { get; }
        public string AttributeInitials { get; set; }
        public DifficultyLevel Difficulty { get; set; }
        public int Level
        {
            get { return Level; }
            set
            {
                Level = value;
                Cost =  SkillFactory.getCost(Level, Difficulty, AttributeInitials);
            }
        }
        public int Target {
            get
            {
                return Attribute + SkillFactory.getOffset(Level, Difficulty, AttributeInitials);
            }
        }
        public int Cost { get; set; }
        public Attribute Attribute { get; set; }
        private int[] LevelCosts { get; }

        public Skill(string name, DifficultyLevel difficulty, string attributeInitials)
        {
            Name = name;
            Difficulty = difficulty;
            AttributeInitials = attributeInitials;
        }
        public Skill(string name, string code)
        {
            Name = name;
            switch (code[0])
            {
                case 'M':
                    AttributeInitials = "IQ";
                    break;
                case 'P':
                    AttributeInitials = "DX";
                    break;
                case 'S':
                    AttributeInitials = "ST";
                    break;
                case 'H':
                    AttributeInitials = "HT";
                    break;
                default:
                    throw new ArgumentException();
            }
            switch(code[1])
            {
                case 'E':
                    Difficulty = DifficultyLevel.Easy;
                    break;
                case 'A':
                    Difficulty = DifficultyLevel.Average;
                    break;
                case 'H':
                    Difficulty = DifficultyLevel.Hard;
                    break;
                case 'V':
                    Difficulty = DifficultyLevel.VeryHard;
                    break;
                default:
                    throw new ArgumentException();
            }

        }

    }


    public enum DifficultyLevel
    {
        Easy,
        Average,
        Hard,
        VeryHard
    }
}