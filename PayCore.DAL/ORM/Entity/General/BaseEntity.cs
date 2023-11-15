﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCore.DAL.ORM
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public DateTime AddDate { get; set; }

        public DateTime ModifiedDate { get; set;}

        public DateTime? DeletedDate { get; set; }

        public bool IsDeleted { get; set; }

    }
}
