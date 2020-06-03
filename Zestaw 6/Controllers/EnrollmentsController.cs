using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zestaw_6.DTO.Requests;
using Zestaw_6.Services;
using static Zestaw_6.DTO.ResultCode;

namespace Cw5.Controllers
{

    [Route("api/enrollments")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {

        private IStudentDbService service;

        public EnrollmentsController(IStudentDbService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult EntrollStudent(EnrollStudentRequest request)
        {
            var result = service.EnrollStudent(request);

            switch (result.ResultCode)
            {
                case ResultCodes.Nie_Wpisano_Wszystkich_Danych_Studenta:
                    return BadRequest("Nie wpisano poprawnie wszystkich danych studenta");

                case ResultCodes.Nie_Istnieja_Studia:
                    return BadRequest("Studia nie istnieją");

                case ResultCodes.Student_Jest_Juz_Zapisany_Na_Semest:
                    return BadRequest("Student już jest zapisany na semestr 1!");

                case ResultCodes.Student_Juz_Istnieje:
                    return BadRequest("Student już istnieje");
            }

            return Created("", result.Response);


        }

        [HttpPost("promotions")]
        public IActionResult PromoteStudent(PromoteStudentRequest request)
        {


            var result = service.PromoteStudents(request);

            return Created("", result);
        }
    }
}