using Example.CORE.Entities.Abstract;
using Example.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.CORE.Entities.Concrete
{
    public class Product: IBaseEntity
    {
        private Status _statu = Status.Active;
        public Guid ID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public Status Statu
        {
            get { return _statu; }
            set { _statu = value; }
        }
        public string ProductName { get; set; }


    }
}
