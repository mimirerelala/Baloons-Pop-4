namespace BaloonsPopsGame
{
    using System;
    
    public class Row : IComparable<Row>
    {
        public Row(string name, int value) 
        {
            this.Name = name;
            this.Value = value;
        }
        
        public string Name { get; set; }
        
        public int Value { get; set; }
        
        public int CompareTo(Row other)
        {
            return this.Value.CompareTo(other.Value);
        }
    }
}
