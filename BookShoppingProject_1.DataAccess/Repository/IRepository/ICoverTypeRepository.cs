﻿using BookShoppingProject_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShoppingProject_1.DataAccess.Repository.IRepository
{
   public interface ICoverTypeRepository:IRepository<CoverType>
    {
        void Update(CoverType coverType);
    }
}
