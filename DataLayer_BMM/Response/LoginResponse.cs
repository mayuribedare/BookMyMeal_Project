using DL_BMM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL_BMM.Response
{
    public class LoginResponse
    {
        public int Eid { get; set; }
        public string ErrorMessage { get; set; }
        public bool Success { get; set; }
        public Employee employee { get; set; }
    }
}
