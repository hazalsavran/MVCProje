﻿using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayes.Abstract
{
  public  interface IimageService
    {
        List<ImageFile> GetList();
    }
}
