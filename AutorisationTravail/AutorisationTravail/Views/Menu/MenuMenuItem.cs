﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutorisationTravail.Views.Menu
{
    public class MenuMenuItem
    {
        public MenuMenuItem()
        {
            TargetType = typeof(MenuDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
        public int TopMarging { get; set; }

        public string Icon { get; set; }
    }
}
