using CRUD_Web_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDBContext _studentDBContext;

        public StudentController(StudentDBContext studentDBContext)
        {
            _studentDBContext = studentDBContext;
        }

        [HttpGet]
        [Route("GetStudent")]

        public async Task<IEnumerable<Students>> GetStudents()
        {
            return await _studentDBContext.Students.ToListAsync();
        }

        [HttpPost]
        [Route("AddStudent")]

        public async Task<Students> AddStudent(Students objStudent)
        {
            _studentDBContext.Students.Add(objStudent);
            await _studentDBContext.SaveChangesAsync(); 
            return objStudent;

        }

        [HttpHead]
        [Route("UpdateStudent/{Id}")]

        public async Task<Students> UpdateStudent(Students objStudent)
        {
            _studentDBContext.Entry(objStudent).State = EntityState.Modified;
            await _studentDBContext.SaveChangesAsync();
            return objStudent;
        }

        [HttpDelete]
        [Route("DeleteStudent/{Id}")]

        public bool DeleteStudent(int Id) 
        {
            bool a = false;
            var Student = _studentDBContext.Students.Find(Id);
            if (Student != null) 
            {
                a = true;
                _studentDBContext.Entry(Student).State = EntityState.Deleted;
                _studentDBContext.SaveChanges();
            }
            else
            {
                a = false;
            }

            return a;

        }
    }
}
