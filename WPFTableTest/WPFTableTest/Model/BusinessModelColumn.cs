using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTableTest.Model
{
    public class BusinessModelColumn
    {
        private string _header;

        public string Header
        {
            get { return _header; }
            set { _header = value; }
        }

        private double _value;

        public double Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
}
