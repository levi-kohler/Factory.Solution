using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Factory.Models;

namespace Factory.Controllers
{
  public class MachinesController : Controller
  {
    private readonly FactoryContext _db;

    public MachinesController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Machines.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.EmployeeId = new SelectList(_db.Employees, "EmployeeId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Machine machine, int EmployeeId)
    {
      _db.Machines.Add(machine);
      _db.SaveChanges();
      if (EmployeeId != 0)
      {
        _db.EmployeeMachine.Add(new EmployeeMachine() { EmployeeId = EmployeeId, MachineId = machine.MachineId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Machine thisMachine = _db.Machines
          .Include(machine => machine.JoinEntities)
          .ThenInclude(join => join.Employee)
          .FirstOrDefault(machine => machine.MachineId == id);
      return View(thisMachine);
    }

    public ActionResult Edit(int id)
    {
      Machine thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      ViewBag.EmployeeId = new SelectList(_db.Employees, "EmployeeId", "Name");
      return View(thisMachine);
    }

    [HttpPost]
    public ActionResult Edit(Machine machine, int EmployeeId)
    {
      if (EmployeeId != 0)
      {
        _db.EmployeeMachine.Add(new EmployeeMachine() { EmployeeId = EmployeeId, MachineId = machine.MachineId });
      }
      _db.Entry(machine).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddEmployee(int id)
    {
      Machine thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      ViewBag.EmployeeId = new SelectList(_db.Employees, "EmployeeId", "Name");
      return View(thisMachine);
    }

    [HttpPost]
    public ActionResult AddEmployee(Machine machine, int EmployeeId)
    {
      if (EmployeeId != 0)
      {
      _db.EmployeeMachine.Add(new EmployeeMachine() { EmployeeId = EmployeeId, MachineId = machine.MachineId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Machine thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      return View(thisMachine);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Machine thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      _db.Machines.Remove(thisMachine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteEmployee(int joinId)
    {
      var joinEntry = _db.EmployeeMachine.FirstOrDefault(entry => entry.EmployeeMachineId == joinId);
      _db.EmployeeMachine.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}