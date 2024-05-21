using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTableTest.Model
{
    public class BusinessModel : INotifyPropertyChanged
    {
        private string _businessName;

        public string BusinessName
        {
            get { return _businessName; }
            set { _businessName = value; }
        }

        private ObservableCollection<BusinessModelColumn> _columns;

        public ObservableCollection<BusinessModelColumn> Columns
        {
            get { return _columns; }
            set { _columns = value; OnPropertyRaised(nameof(Columns)); }
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
