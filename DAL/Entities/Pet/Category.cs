namespace DAL.Entities.Pet
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public ICollection<Cat> Cats { get; set; }
    }
}
