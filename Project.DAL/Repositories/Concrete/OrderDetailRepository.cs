﻿using Project.DAL.ContextClasses;
using Project.DAL.Repositories.Abstract;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Concrete
{
    public class OrderDetailRepository : BaseRepository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(MyContext db) : base(db)
        {
            
        }
    }
}
