using System;

namespace JinnHouse.Entities.Enums.Enums
{
    public class DescriptionAttribute : Attribute
    {
        public DescriptionAttribute(string description)
        {
            this.Description = description;
        }

        public string Description { get; }
    }
}
