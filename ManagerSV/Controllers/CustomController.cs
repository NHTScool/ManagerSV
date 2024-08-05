using ManagerSV.Sevives;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ManagerSV.Sevives;
using ManagerSV.Models;

namespace ManagerSV.Controllers
{
    public class CustomController : Controller
    {
            private readonly IstudentSevices studentServices;

        public CustomController(IstudentSevices studentServices)
        {
            this.studentServices = studentServices;
        }
        // GET: /Custom/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Custom/Create
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                studentServices.Create(student);
                return RedirectToAction("Index", "ManagerSV");

            }
            return View(student);
        }

        public IActionResult Edit()
        {
            return View();
        }

        [HttpGet("GetStudentByNameAll")]
        public IActionResult GetByNameAll(string name)
        {
            var student = studentServices.GetByNameAll(name);
            if (student == null)
            {
                ViewBag.ErrorMessage = "No students found.";
            }
            return View("Edit", student);
        }
        //GET: /Custom/Edit/5
        //public IActionResult Edit(string id)
        //{
        //    var student = studentServices.Get(id);
        //    if (student == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(student);
        //}

        // POST: /Custom/Edit/5
        [HttpPost]
        public IActionResult Edit(string id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                studentServices.update(id, student);
                return RedirectToAction("Index", "ManagerSV");
            }
            return View(student);
        }

        // GET: /Custom/Delete/5
        //public IActionResult Delete(string id)
        //{
        //    var student = studentServices.Get(id);
        //    if (student == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(student);
        //}

        // POST: /Custom/Delete/5
        //public IActionResult delete(string id)
        //{
        //    return View();
        //}
        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(string id)
        {
            studentServices.delete(id);
            TempData["SuccessMessage"] = "Student deleted successfully.";
            return RedirectToAction("Index", "ManagerSV");
        }
    }
}
