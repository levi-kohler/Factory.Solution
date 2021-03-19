using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Factory.Models;

namespace Factory.Controllers
{
  public class EmployeesController : Controller
  {
    private readonly FactoryContext _db;

    public EmployeesController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Employees.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Employee employee, int MachineId)
    {
      _db.Employees.Add(employee);
      _db.SaveChanges();
      if (MachineId != 0)
      {
        _db.EmployeeMachine.Add(new EmployeeMachine() { MachineId = MachineId, EmployeeId = employee.EmployeeId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Employee thisEmployee = _db.Employees
          .Include(employee => employee.JoinEntities)
          .ThenInclude(join => join.Machine)
          .FirstOrDefault(employee => employee.EmployeeId == id);
      return View(thisEmployee);
    }

    public ActionResult Edit(int id)
    {
      Employee thisEmployee = _db.Employees.FirstOrDefault(employee => employee.EmployeeId == id);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      return View(thisEmployee);
    }

    [HttpPost]
    public ActionResult Edit(Employee employee, int MachineId)
    {
      if (MachineId != 0)
      {
        _db.EmployeeMachine.Add(new EmployeeMachine() { MachineId = MachineId, EmployeeId = employee.EmployeeId });
      }
      _db.Entry(employee).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddMachine(int id)
    {
      Employee thisEmployee = _db.Employees.FirstOrDefault(employee => employee.EmployeeId == id);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      return View(thisEmployee);
    }

    [HttpPost]
    public ActionResult AddMachine(Employee employee, int MachineId)
    {
      if (MachineId != 0)
      {
      _db.EmployeeMachine.Add(new EmployeeMachine() { MachineId = MachineId, EmployeeId = employee.EmployeeId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Employee thisEmployee = _db.Employees.FirstOrDefault(employee => employee.EmployeeId == id);
      return View(thisEmployee);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Employee thisEmployee = _db.Employees.FirstOrDefault(employee => employee.EmployeeId == id);
      _db.Employees.Remove(thisEmployee);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteMachine(int joinId)
    {
      var joinEntry = _db.EmployeeMachine.FirstOrDefault(entry => entry.EmployeeMachineId == joinId);
      _db.EmployeeMachine.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}