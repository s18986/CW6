using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zestaw_6.DTO;
using Zestaw_6.DTO.Requests;
using Zestaw_6.DTO.Responses;

namespace Zestaw_6.Services
{
    
        public interface IStudentDbService
        {
            public EnrollStudentResult EnrollStudent(EnrollStudentRequest request);

            public EnrollStudentResponse PromoteStudents(PromoteStudentRequest request);
        }
    
}
