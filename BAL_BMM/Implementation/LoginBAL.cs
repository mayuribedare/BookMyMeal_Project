using BAL_BMM.Interface;
using DL_BMM.Models;
using DAL_BMM.Interface;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_BMM.Response;
using DAL_BMM.Implementation;

namespace BAL_BMM.Implementation
{
    public class LoginBAL : ILoginBAL
    {
        private readonly ILoginDAL _LoginDAL ;
        public LoginBAL(ILoginDAL loginBAL)
        {
            _LoginDAL = loginBAL;
        }

      public async Task<LoginResponse> Authenticate(string email, string password)
        {
            var Employee = await _LoginDAL.GetByUsernameAndPassword(email, password);
            if (Employee == null)
            {
                return new LoginResponse { Success = false, ErrorMessage = "Invalid username or password" };
            }
            return new LoginResponse { Success = true  ,employee =Employee};

        }


    }
    }
