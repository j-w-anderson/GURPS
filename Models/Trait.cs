using System;

namespace Engine
{
    public class Trait : BaseNotificationClass
    {
        public int Cost { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Trait()
        {
            Name = "blank";
            Description = "<empty>";
            Cost = 0;
        }
    }
}