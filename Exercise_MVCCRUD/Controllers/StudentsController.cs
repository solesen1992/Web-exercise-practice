using Exercise_MVCCRUD.Data;
using Exercise_MVCCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exercise_MVCCRUD.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<Student> currentStudents = StudentData.StudentList;

            return View(currentStudents);
        }

        [HttpGet]
        // GET: Student/Edit
        public IActionResult Edit(int studentId)
		{
			Student editStudent = StudentData.GetStudentById(studentId);
			return View(editStudent);
		}

        // Update student
        [HttpPost]
		public IActionResult Edit(Student inStudent)
		{
			StudentData.UpdateStudent(inStudent);
			//return RedirectToAction("Index");
            // Redirect to the Index action of the HomeController
            return RedirectToAction("Index", "Home");
        }

        // GET: Students/Create
        [HttpGet]
        public IActionResult Create() 
        { 
            return View(); // Display tje create view to the user
        }

        // POST: Students/Create
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                // Insert the new student using the data layer
                StudentData.InsertStudent(student);

                // Redirect to the HomeController's Index action after successful creation
                return RedirectToAction("Index", "Home");
            }

            // If the model is invalid, redisplay the form with validation errors
            return View(student);
        }

        // GET: Students/Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = StudentData.GetStudentById(id);
            if (student.StudentId == -1) // or some way to indicate not found
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            StudentData.DeleteStudent(id);
            return RedirectToAction("Index", "Home"); // Redirect back to index after deletion
        }

        // GET: Students/Details/5
        public IActionResult Details(int id)
        {
            var student = StudentData.GetStudentById(id);
            if (student.StudentId == -1) // or any condition to check if student was found
            {
                return NotFound(); // returns a 404 if the student is not found
            }
            return View(student);
        }
    }
}
