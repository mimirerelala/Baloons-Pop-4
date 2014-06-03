namespace BaloonsPopsGame
{
    using System;
    using System.Linq;
    public struct structOfRow : IComparable<structOfRow>
    {

        public int Value;
        public string Name;
        public structOfRow(int value, string name)
        {

            Value = value;
            Name = name;
        }

        public int CompareTo(structOfRow other)
        {
            return Value.CompareTo(other.Value);
        }
    }

}
