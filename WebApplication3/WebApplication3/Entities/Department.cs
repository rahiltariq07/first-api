namespace WebApplication3.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Employee> Employeees { get; set; }
    }
}
