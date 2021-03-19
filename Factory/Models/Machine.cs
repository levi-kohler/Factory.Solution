using System.Collections.Generic;

namespace Factory.Models
{
  public class Machine
  {
    public Machine()
    {
      this.JoinEntities = new HashSet<EmployeeMachine>();
    }

    public int MachineId { get; set; }
    public string Name { get; set; }

    public virtual ICollection<EmployeeMachine> JoinEntities { get;}
  }
}