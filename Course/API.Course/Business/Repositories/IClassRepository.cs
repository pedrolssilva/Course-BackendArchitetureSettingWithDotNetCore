using API.Course.Business.Entities;
using System.Collections.Generic;

namespace API.Course.Business.Repositories
{
    public interface IClassRepository
    {
        void Add(Class classe);
        void Commit();
        IList<Class> GetByUserCode(int userCode);

    }
}
