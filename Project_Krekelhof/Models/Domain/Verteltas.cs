﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Project_Krekelhof
{
    public class Verteltas : Item
    {
        public virtual ICollection<Item> Items { get; set; }
        }
}
