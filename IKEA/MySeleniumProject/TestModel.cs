using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySeleniumProject
{

    class TestModel
    {
        public string TestClass { get; set; }
        public string TestName { get; set; }
        public DateTime TestTime { get; set; }
        public string TestStatus { get; set; }
        public string[] TestCategory { get; set; }
        public double DurationTime { get; set; }
    }
}
