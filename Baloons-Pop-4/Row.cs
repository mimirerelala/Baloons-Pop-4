namespace BaloonsPopsGame
{
    using System;
    using System.Linq;
    public struct Row : IComparable<Row>
    {
        public int Value;
        public string Name;
        
        public Row(int value, string name)
        {

            Value = value;
            Name = name;
        }

        public int CompareTo(Row other)
        {
            return Value.CompareTo(other.Value);
        }
    }
}
