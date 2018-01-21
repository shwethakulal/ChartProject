using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChartProject
{
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int ID { set; get; } 
        public string name { set; get; }
        public int daily { set; get; }
        public int mtd { set; get; }
        public int ytd { set; get; }
    }
}
