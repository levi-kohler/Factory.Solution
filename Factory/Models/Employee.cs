using System.Collections.Generic;

namespace Factory.Models
{
  public class Employee
  {
    public Employee()
    {
      this.JoinEntities = new HashSet<EmployeeMachine>();
    }

    public int EmployeeId { get; set; }
    public string Name { get; set; }

    public virtual ICollection<EmployeeMachine> JoinEntities { get;}
  }
}