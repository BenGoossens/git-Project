﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Krekelhof.Models.Domain
{
    public class Boek : Item
    {
        public string Auteur { get; set; }
        public string Isbn { get; set; }
        public string Uitgeverij { get; set; }
        public virtual Categorie Categorie { get; set; } 
    }
}