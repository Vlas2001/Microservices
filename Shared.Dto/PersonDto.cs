namespace Shared.Dto
{
    public abstract class PersonDto
    {
        public string Name { get; set; }
        
        public string Surname { get; set; }
        
        public int Age { get; set; }
        
        public string PhoneNumber { get; set; }
    }
}