using CurdAppWithStoredProcedure.Models;
using CurdAppWithStoredProcedure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurdAppWithStoredProcedure.Controllers
{
    public class StudentController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IStudentService _studentService;
        public StudentController(IConfiguration configuration, IStudentService studentService)
        {
            _configuration = configuration;
            _studentService = studentService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult StudentsList()
        {
            AllModels model = new AllModels();
            model.StudentsList = _studentService.GetStudentsList().ToList();
            return View(model);
        }
    }
}
