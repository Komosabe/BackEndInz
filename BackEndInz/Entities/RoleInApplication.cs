namespace BackEndInz.Entities
{
    public class RoleInApplication
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public ICollection<User> Users { get; set; }
    }
}
