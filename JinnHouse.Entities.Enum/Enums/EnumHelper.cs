using System;

namespace JinnHouse.Entities.Enums.Enums
{
    public static class EnumHelper 
    {
        public static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var atttributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return (T)atttributes[0];
        }

        public static string GetDescription(this Enum value)
        {
            var attribute = value.GetAttribute<DescriptionAttribute>();
            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}
