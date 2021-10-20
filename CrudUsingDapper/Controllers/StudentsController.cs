using CrudUsingDapper.IServices;
using CrudUsingDapper.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudUsingDapper.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudentService _oStudentService;

        public StudentsController(IStudentService oStudentService)
        {
            _oStudentService = oStudentService;
        }
        [Route("GetStudents")]
        //GET: api/Students
        [HttpGet]
        public IEnumerable<Student> GetStudent()
        {
            return _oStudentService.Gets();
        }
        [Route("GetStudentById")]
        //GET:api/Student/5
        [HttpGet("{id}",Name ="Get")]
        public Student Get(int id)
        {
            return _oStudentService.GetStudent(id);
        }
        //Post:api/Students
        [Route("Students")]
        [HttpPost]
        public Student Post([FromBody] Student oStudent)
        {
            if (ModelState.IsValid)
            {
                return _oStudentService.Save(oStudent);
            }
            return null;
        }
        //DELETE :api/ApiWithAction/5
        [HttpDelete("{id}")]
        public string Delete (int id)
        {
            return _oStudentService.Delete(id);
        }


       
    }
}
