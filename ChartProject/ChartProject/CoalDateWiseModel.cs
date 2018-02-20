using System;
using System.Collections.Generic;
using System.Text;

namespace ChartProject
{
    public class CoalDateWiseModel
    {
        public DateTime date { set; get; }
        public double dailyDespatch { set; get; }

        public CoalDateWiseModel()
        {
        }

        public CoalDateWiseModel(DateTime date, double dailyDespatch)
        {
            this.date = date;
            this.dailyDespatch = dailyDespatch;
        }
    }
}
