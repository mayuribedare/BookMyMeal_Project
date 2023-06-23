using DL_BMM.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_BMM.Response;

namespace BAL_BMM.Interface
{
    public interface ILoginBAL
    {
        Task<LoginResponse> Authenticate(string email, string password);
    }
  

}
