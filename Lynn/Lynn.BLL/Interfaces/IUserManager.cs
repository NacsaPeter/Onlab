using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.BLL.Interfaces
{
    public interface IUserManager
    {
        Task<User> GetUserByNameAsync(string username);
    }
}
