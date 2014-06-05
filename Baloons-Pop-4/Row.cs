namespace BaloonsPopsGame
{
    public struct Row : IComparable<Row>
    {
        public Row(int value, string name) 
            : this()
        {
            this.Value = value;
            this.Name = name;
        }
        
        public int Value { get; set; }
        
        public string Name { get; set; }
        
        public int CompareTo(Row other)
        {
            return this.Value.CompareTo(other.Value);
        }
    }
}
