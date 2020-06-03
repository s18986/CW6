using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zestaw_6.DTO
{
    public class ResultCode
    {
        public enum ResultCodes
        {
            Nie_Wpisano_Wszystkich_Danych_Studenta,
            Nie_Istnieja_Studia,
            Student_Jest_Juz_Zapisany_Na_Semest,
            Student_Juz_Istnieje,
            Student_Dodany,
            Studenci_Awansowani,
            NieWpisanoWszystkichDanychStudenta
        }
    }
}
