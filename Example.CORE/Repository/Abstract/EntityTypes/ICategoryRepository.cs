using Example.CORE.Entities.Concrete;
using Example.CORE.Repository.Abstract.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.CORE.Repository.Abstract.EntityTypes
{
    public interface ICategoryRepository:IRepository<Category>
    {
    }
}
