using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.DAL.RepositoryInterfaces
{
    public interface IEditRepository
    {
        Task<DbCourse> CreateCourseAsync(DbCourse course);
        Task<DbCourse> EditCourseAsync(DbCourse course);
        Task<DbTest> CreateTestAsync(DbTest test);
        Task<DbTest> EditTestAsync(DbTest test);
    }
}
