﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_14
{
    public class IdException:Exception
    {
        public IdException(string str):base(str) { }
    }
}
