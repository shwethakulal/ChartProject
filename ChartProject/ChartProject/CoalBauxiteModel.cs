using System;
using System.Collections.Generic;
using System.Text;

namespace ChartProject
{
    public class CoalBauxiteModel
    {
        public string name { set; get; }
        public long daily { set; get; }
        public long mtd { set; get; }
        public long ytd { set; get; }

        public CoalBauxiteModel()
        {
        }

        public CoalBauxiteModel(string name, long daily, long mtd, long ytd)
        {
            this.name = name;
            this.daily = daily;
            this.mtd = mtd;
            this.ytd = ytd;
        }
    }
}
