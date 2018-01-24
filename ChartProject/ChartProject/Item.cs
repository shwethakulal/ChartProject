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
        public long daily { set; get; }
        public long mtd { set; get; }
        public long ytd { set; get; }
    }
}
