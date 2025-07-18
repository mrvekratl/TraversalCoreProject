﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGuideDal : IGenericDal<Guide> //Dal: Data Access Layer
    {
        void ChangeToTrueByGuide(int id);
        void ChangeToFalseByGuide(int id);
    }
}
