// <copyright file="Row.cs" company="Team Baloons-Pop-4">
// Open source
// </copyright>
namespace BaloonsPopsGame
{
    using System;
    
    /// <summary>
    /// The Row class
    /// </summary>
    public class Row : IComparable<Row>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Row"/> class 
        /// </summary>
        /// <param name="name">The name of the row</param>
        /// <param name="value">The value of the row</param>
        public Row(string name, int value) 
        {
            this.Name = name;
            this.Value = value;
        }
        
        /// <summary>
        /// Gets or sets the name of the row
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value of the row
        /// </summary>
        public int Value { get; set; }
        
        /// <summary>
        /// Compares two instances of the <see cref="Row"/> class by their value
        /// </summary>
        /// <param name="other">An instance of the <see cref="Row"/></param>
        /// <returns>0 if the two rows are equal,
        /// 1 if the value of the first row is bigger than the value of the second
        /// and -1 if the value of the second row is bigger than the value of the first</returns>
        public int CompareTo(Row other)
        {
            return this.Value.CompareTo(other.Value);
        }
    }
}
