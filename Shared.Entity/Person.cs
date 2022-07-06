namespace Shared.Entity
{
    public abstract class Person
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Surname { get; set; }
        
        public int Age { get; set; }
        
        public string PhoneNumber { get; set; }
    }
}