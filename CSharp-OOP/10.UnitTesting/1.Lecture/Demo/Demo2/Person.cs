namespace Demo2
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

        public string GetSavedMoney()
        {
            return $"My money are {this.SavedMoney}";
        }
    }
}
