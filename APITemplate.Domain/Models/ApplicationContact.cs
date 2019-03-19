namespace APITemplate.Domain.Models
{
    public class ApplicationContact
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public Application Application { get; set; }
    }
}