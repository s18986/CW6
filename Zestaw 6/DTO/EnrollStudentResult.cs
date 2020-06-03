using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zestaw_6.DTO.Responses;
using static Zestaw_6.DTO.ResultCode;

namespace Zestaw_6.DTO
{
    public class EnrollStudentResult
    {
        public EnrollStudentResponse Response { get; set; }

        public ResultCodes ResultCode { get; set; }
    }
}
