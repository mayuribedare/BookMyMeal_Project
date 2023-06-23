using DL_BMM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL_BMM.Interface
{
    public interface ILoginDAL
    {
        Task <Employee> GetByUsernameAndPassword (string email, string password);
    }
}
