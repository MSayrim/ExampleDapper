using Example.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.CORE.Entities.Abstract
{
    public interface IBaseEntity
    {
        public Guid ID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public Status Statu { get; set; }
    }
}
