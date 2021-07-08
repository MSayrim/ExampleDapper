using Example.CORE.Entities.Concrete;
using Example.CORE.Repository.Abstract.EntityTypes;
using Example.CORE.Repository.Concrete.EntityFrameWorkcore.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.CORE.Repository.Concrete.EntityFrameWorkCore.EntityTypes
{
    public class CategoryRepository:BaseRepository<Category>,ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context) { }
    }
}
