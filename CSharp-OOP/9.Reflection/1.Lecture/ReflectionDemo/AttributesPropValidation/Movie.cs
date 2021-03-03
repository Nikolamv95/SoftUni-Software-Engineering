namespace AttributesPropValidation
{
    public class Movie
    {
        [Range(0, 10)]
        public string Name{ get; set; }
        public int Year{ get; set; }
        public string Description{ get; set; }
        public decimal Price{ get; set; }
    }
}
