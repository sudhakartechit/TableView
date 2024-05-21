using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTableTest.Model
{
    public class TableModel : INotifyPropertyChanged, ICloneable
    {
		private string _sector;

		public string Sector
		{
			get { return _sector; }
			set { _sector = value; }
		}


		private BusinessModel _nonfarmBusiness;

		public BusinessModel NonfarmBusiness
        {
			get { return _nonfarmBusiness; }
			set { _nonfarmBusiness = value; OnPropertyRaised(nameof(NonfarmBusiness)); }
		}


        private BusinessModel _business;

        public BusinessModel Business
        {
            get { return _business; }
            set { _business = value; OnPropertyRaised(nameof(Business)); }
        }

        private BusinessModel _manufacturing;

        public BusinessModel Manufacturing
        {
            get { return _manufacturing; }
            set { _manufacturing = value; OnPropertyRaised(nameof(Manufacturing)); }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

    }
}
