using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine
{
    internal static class SkillFactory
    {
        private static List<Tuple<string,string>> _standardSkills;
        static SkillFactory()
        {
            _standardSkills = new List<Tuple<string,string>>();

            _standardSkills.Add(new Tuple<string, string>("Short Sword", "MA"));
            _standardSkills.Add(new Tuple<string, string>("Dancing", "PA"));
            _standardSkills.Add(new Tuple<string, string>("Riding (Horse)","PA"));
            _standardSkills.Add(new Tuple<string, string>("Stealth", "PE"));
        }

        public static Skill getSkill(string name)
        {
            Tuple<string,string> fetch = _standardSkills.FirstOrDefault(sk => sk.Item1 == name);
            if (fetch == null)
            {
                throw new ArgumentException();
            }
            return new Skill(fetch.Item1,fetch.Item2);
        }

        internal static int getCost(int level, DifficultyLevel difficulty, string SkillInitials)
        {
            throw new NotImplementedException();
        }

        internal static int getOffset(int level, DifficultyLevel difficulty, string SkillInitials)
        {
            throw new NotImplementedException();
        }
    }
}