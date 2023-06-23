using DAL_BMM.Interface;
using DL_BMM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DAL_BMM.Implementation
{
    public class LoginDAL : ILoginDAL
    {
        private readonly BookMyMealContext _db;

        public LoginDAL(BookMyMealContext db)
        {
            _db = db;
        }

        public Task<Employee> GetByUsernameAndPassword(string email, string password)
        {
           return _db.Employees.SingleOrDefaultAsync(x =>x.Email == email && x.Password == password);
        }
    }
}
