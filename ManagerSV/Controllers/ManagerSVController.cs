using ManagerSV.Sevives;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ManagerSV.Sevives;
using ManagerSV.Models;

namespace ManagerSV.Controllers
{
    public class ManagerSVController : Controller
    {
        private readonly IstudentSevices studentServices;

        public ManagerSVController(IstudentSevices studentServices)
        {
            this.studentServices = studentServices;
        }

        // GET: /ManagerSV/
        //public IActionResult Index()
        //{
        //    var students = studentServices.GetNumber(10);
        //    return View(students);
        //}
        public IActionResult Index(int page = 1, int pageSize = 10)
        {
            // Tính toán số lượng bản ghi cần bỏ qua
            int skip = (page - 1) * pageSize;

            // Lấy danh sách sinh viên từ vị trí hiện tại với kích thước trang
            var students = studentServices.GetPage(skip, pageSize);

            // Lấy tổng số sinh viên
            var totalStudents = studentServices.GetTotalCount();

            // Tạo đối tượng phân trang 
            var pageViewModel = new PageViewModel<Student>
            {
                Items = students,
                PageNumber = page,
                PageSize = pageSize,
                TotalItems = totalStudents
            };
            return View(pageViewModel);
        }
   
    //public IActionResult Create()
    //{
    //    return View();
    //}

    //// POST: /Custom/Create
    //[HttpPost]
    //public IActionResult Create(Student student)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        studentServices.Create(student);
    //        return RedirectToAction(nameof(Index));
    //    }
    //    return View(student);
    //}

    //// GET: /Custom/Edit/5
    //public IActionResult Edit(string id)
    //{
    //    var student = studentServices.Get(id);
    //    if (student == null)
    //    {
    //        return NotFound();
    //    }
    //    return View(student);
    //}

    //// POST: /Custom/Edit/5
    //[HttpPost]
    //public IActionResult Edit(string id, Student student)
    //{
    //    if (id != student.Id)
    //    {
    //        return BadRequest();
    //    }

    //    if (ModelState.IsValid)
    //    {
    //        studentServices.update(id, student);
    //        return RedirectToAction(nameof(Index));
    //    }
    //    return View(student);
    //}

    //// GET: /Custom/Delete/5
    //public IActionResult Delete(string id)
    //{
    //    var student = studentServices.Get(id);
    //    if (student == null)
    //    {
    //        return NotFound();
    //    }
    //    return View(student);
    //}

    //// POST: /Custom/Delete/5
    //[HttpPost, ActionName("Delete")]
    //public IActionResult DeleteConfirmed(string id)
    //{
    //    studentServices.delete(id);
    //    return RedirectToAction(nameof(Index));
    //}
}
}