﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanBalo
{
    public class Helper
    {
        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("HHmmssffff");
        }
    }
}
