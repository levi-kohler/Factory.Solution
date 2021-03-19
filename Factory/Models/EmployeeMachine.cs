namespace Factory.Models
{
  public class EmployeeMachine
  {       
    public int EmployeeMachineId { get; set; }
    public int EmployeeId { get; set; }
    public int MachineId { get; set; }
    public virtual Employee Employee { get; set; }
    public virtual Machine Machine { get; set; }
  }
}