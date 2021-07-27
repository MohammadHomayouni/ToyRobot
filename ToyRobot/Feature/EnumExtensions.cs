using System;

namespace ToyRobot
{
    public static class EnumExtensions
    {
        public static T Next<T>(this T src) where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException(string.Format("Argument {0} is not an Enum", typeof(T).FullName));
            }

            var Arr = (T[])Enum.GetValues(src.GetType());
            var j = Array.IndexOf<T>(Arr, src) + 1;
            return (Arr.Length == j) ? Arr[0] : Arr[j];
        }

        public static T Previous<T>(this T src) where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException(string.Format("Argument {0} is not an Enum", typeof(T).FullName));
            }

            var arr = (T[])Enum.GetValues(src.GetType());
            var j = Array.IndexOf<T>(arr, src) - 1;
            return (j == -1) ? arr[arr.Length - 1] : arr[j];
        }
    }
}
