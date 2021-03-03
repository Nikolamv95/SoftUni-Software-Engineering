namespace Demo
{
    public class Person
    {
        public Person(string name, decimal money)
        {
            this.Name = name;
            this.SavedMoney = money;
        }

        public string Name { get; set; }
        public decimal SavedMoney { get; set; }

        public string GetName()
        {
            return $"My name is {this.Name}";
        }
    }
}
