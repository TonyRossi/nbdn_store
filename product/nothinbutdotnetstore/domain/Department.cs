using System;

namespace nothinbutdotnetstore.domain
{
    public class Department : IEquatable<Department>
    {
        public string name { get; set; }
        public string address { get; set; }
        public int number_of_items { get; set; }
        public DateTime created_on { get; set; }
        public string phone { get; set; }
        public Details details { get; set; }
        public Guid id { get; set; }

        public bool Equals(Department other)
        {
            return this.name == other.name &&
                this.address == other.address &&
                    this.number_of_items == other.number_of_items
                        && this.created_on == other.created_on &&
                            this.phone == other.phone;
        }
    }
}