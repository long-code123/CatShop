namespace DAL.Entities
{
    public class Cat : BaseEntity
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public int CategoryId { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public bool IsSold { get; set; }

        public Category Category { get; set; }
    }
}
