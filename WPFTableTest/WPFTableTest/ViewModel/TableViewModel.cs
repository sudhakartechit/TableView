using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFTableTest.Common;
using WPFTableTest.Model;

namespace WPFTableTest.ViewModel
{
    public class TableViewModel : INotifyPropertyChanged
    {
        bool _isColumnAddEnabled = false;
        bool _isColumnDeleteEnabled = false;
        bool _isAddRowEnabled = false;
        bool _isDeleteRowEnabled = false;
        public TableViewModel() 
        {
            this.Description = "Table A. Revised third-quarter 2013 measure:percent change from previous quarter, at annual rate (Q to Q) and from same quarter ayear ago (Y to Y)";

            #region Dummy Model objects added
            this.Models = new ObservableCollection<TableModel>()
            {
                new TableModel()
                {
                    Sector = "Productivity",
                    NonfarmBusiness = new BusinessModel()
                        {
                             BusinessName = "Nonfarm Business",
                             Columns = new ObservableCollection<BusinessModelColumn>()
                             {
                                 new BusinessModelColumn()
                                 {
                                     Header = "Q to Q",
                                     Value = 3.0
                                 },
                                 new BusinessModelColumn()
                                 {
                                     Header = "Y to Y",
                                     Value = 0.3
                                 }
                             }
                    },
                    Business = new BusinessModel()
                    {
                             BusinessName = "Business",
                             Columns = new ObservableCollection<BusinessModelColumn>()
                             {
                                 new BusinessModelColumn()
                                 {
                                     Header = "Q to Q",
                                     Value = 2.7
                                 },
                                 new BusinessModelColumn()
                                 {
                                     Header = "Y to Y",
                                     Value = 0.8
                                 }
                             }
                    },
                    Manufacturing = new BusinessModel()
                    {
                             BusinessName = "Manufacturing",
                             Columns = new ObservableCollection<BusinessModelColumn>()
                             {
                                 new BusinessModelColumn()
                                 {
                                     Header = "Q to Q",
                                     Value = -0.1
                                 },
                                 new BusinessModelColumn()
                                 {
                                     Header = "Y to Y",
                                     Value = 2.2
                                 }
                             }
                    }
                },
                new TableModel()
                {
                    Sector = "Output",
                    NonfarmBusiness = new BusinessModel()
                        {
                             BusinessName = "Nonfarm Business",
                             Columns = new ObservableCollection<BusinessModelColumn>()
                             {
                                 new BusinessModelColumn()
                                 {
                                     Header = "Q to Q",
                                     Value = 4.7
                                 },
                                 new BusinessModelColumn()
                                 {
                                     Header = "Y to Y",
                                     Value = 2.1
                                 }
                             }
                    },
                    Business = new BusinessModel()
                    {
                             BusinessName = "Business",
                             Columns = new ObservableCollection<BusinessModelColumn>()
                             {
                                 new BusinessModelColumn()
                                 {
                                     Header = "Q to Q",
                                     Value = 4.9
                                 },
                                 new BusinessModelColumn()
                                 {
                                     Header = "Y to Y",
                                     Value = 2.4
                                 }
                             }
                    },
                    Manufacturing = new BusinessModel()
                    {
                             BusinessName = "Manufacturing",
                             Columns = new ObservableCollection<BusinessModelColumn>()
                             {
                                 new BusinessModelColumn()
                                 {
                                     Header = "Q to Q",
                                     Value = 1.1
                                 },
                                 new BusinessModelColumn()
                                 {
                                     Header = "Y to Y",
                                     Value = 2.3
                                 }
                             }
                    }
                },
                new TableModel()
                {
                    Sector = "Hours",
                    NonfarmBusiness = new BusinessModel()
                        {
                             BusinessName = "Nonfarm Business",
                             Columns = new ObservableCollection<BusinessModelColumn>()
                             {
                                 new BusinessModelColumn()
                                 {
                                     Header = "Q to Q",
                                     Value = 1.7
                                 },
                                 new BusinessModelColumn()
                                 {
                                     Header = "Y to Y",
                                     Value = 1.8
                                 }
                             }
                    },
                    Business = new BusinessModel()
                    {
                             BusinessName = "Business",
                             Columns = new ObservableCollection<BusinessModelColumn>()
                             {
                                 new BusinessModelColumn()
                                 {
                                     Header = "Q to Q",
                                     Value = 2.1
                                 },
                                 new BusinessModelColumn()
                                 {
                                     Header = "Y to Y",
                                     Value = 1.6
                                 }
                             }
                    },
                    Manufacturing = new BusinessModel()
                    {
                             BusinessName = "Manufacturing",
                             Columns = new ObservableCollection<BusinessModelColumn>()
                             {
                                 new BusinessModelColumn()
                                 {
                                     Header = "Q to Q",
                                     Value = 1.2
                                 },
                                 new BusinessModelColumn()
                                 {
                                     Header = "Y to Y",
                                     Value = 0.1
                                 }
                             }
                    }
                }
            };
            #endregion

            AddColumnCommand = new Command(OnAddColumnCommandExecuted, CanAddColumnEnabled());
            DeleteColumnCommand = new Command(OnDeleteColumnCommandExecuted, CanDeleteColumnEnabled());
            AddRowCommand = new Command(OnAddRowCommandExecuted, CanAddRowEnabled());
            DeleteRowCommand = new Command(OnDeleteRowCommandExecuted, CanDeleteRowEnabled());
            MouseActionCommand = new Command(OnMouseActionCommandExecuted, true);
        }

        private void AddColumn(BusinessModelColumn businessModelColumn, string modelName)
        {
            if (modelName.ToString().Equals("NonfarmBusiness"))
            {
                TableModel tModel = this.Models.Where(x => x.NonfarmBusiness.Columns.Any(c => c.Equals(businessModelColumn))).Select(x => x).FirstOrDefault();
                int index = tModel.NonfarmBusiness.Columns.IndexOf(businessModelColumn);
                foreach (TableModel tableModel in this.Models)
                {
                    BusinessModelColumn newColumn = new BusinessModelColumn()
                    {
                        Header = "Test" + tableModel.NonfarmBusiness.Columns.Count()
                    };
                    tableModel.NonfarmBusiness.Columns.Insert(index + 1, newColumn);
                }
            }
            else if (modelName.ToString().Equals("Business"))
            {
                TableModel tModel = this.Models.Where(x => x.Business.Columns.Any(c => c.Equals(businessModelColumn))).Select(x => x).FirstOrDefault();
                int index = tModel.Business.Columns.IndexOf(businessModelColumn);
                foreach (TableModel tableModel in this.Models)
                {
                    BusinessModelColumn newColumn = new BusinessModelColumn()
                    {
                        Header = "Test" + tableModel.NonfarmBusiness.Columns.Count()
                    };
                    tableModel.Business.Columns.Insert(index + 1, newColumn);
                }
            }
            else if (modelName.ToString().Equals("Manufacturing"))
            {
                TableModel tModel = this.Models.Where(x => x.Manufacturing.Columns.Any(c => c.Equals(businessModelColumn))).Select(x => x).FirstOrDefault();
                int index = tModel.Manufacturing.Columns.IndexOf(businessModelColumn);
                foreach (TableModel tableModel in this.Models)
                {
                    BusinessModelColumn newColumn = new BusinessModelColumn()
                    {
                        Header = "Test" + tableModel.NonfarmBusiness.Columns.Count()
                    };
                    tableModel.Manufacturing.Columns.Insert(index + 1, newColumn);
                }
            }
        }
        private void DeleteColumn(BusinessModelColumn businessModelColumn, string modelName)
        {
            if (modelName.ToString().Equals("NonfarmBusiness"))
            {
                TableModel tModel = this.Models.Where(x => x.NonfarmBusiness.Columns.Any(c => c.Equals(businessModelColumn))).Select(x => x).FirstOrDefault();
                int index = tModel.NonfarmBusiness.Columns.IndexOf(businessModelColumn);
                foreach (TableModel tableModel in this.Models)
                {
                    tableModel.NonfarmBusiness.Columns.RemoveAt(index);
                }
            }
            else if (modelName.ToString().Equals("Business"))
            {
                TableModel tModel = this.Models.Where(x => x.Business.Columns.Any(c => c.Equals(businessModelColumn))).Select(x => x).FirstOrDefault();
                int index = tModel.Business.Columns.IndexOf(businessModelColumn);
                foreach (TableModel tableModel in this.Models)
                {
                    tableModel.Business.Columns.RemoveAt(index);
                }
            }
            else if (modelName.ToString().Equals("Manufacturing"))
            {
                TableModel tModel = this.Models.Where(x => x.Manufacturing.Columns.Any(c => c.Equals(businessModelColumn))).Select(x => x).FirstOrDefault();
                int index = tModel.Manufacturing.Columns.IndexOf(businessModelColumn);
                foreach (TableModel tableModel in this.Models)
                {
                    tableModel.Manufacturing.Columns.RemoveAt(index);
                }
            }
        }
        private void AddRow(string sector)
        {
            TableModel tModel = this.Models.Where(x => x.Sector.Equals(sector)).Select(x => x).FirstOrDefault();
            int index = this.Models.IndexOf(tModel);
            TableModel newTablemodel = (TableModel)tModel.Clone();
            newTablemodel.Sector = "New Sector " + this.Models.Count();
            this.Models.Insert(index + 1, newTablemodel);
        }
        private void DeleteRow(string sector)
        {
            TableModel tModel = this.Models.Where(x => x.Sector.Equals(sector)).Select(x => x).FirstOrDefault();
            int index = this.Models.IndexOf(tModel);
            this.Models.RemoveAt(index);
        }
        

        

        private string _description;

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyRaised(nameof(Description));
            }
        }

        private ObservableCollection<TableModel> _models;

        public ObservableCollection<TableModel> Models
        {
            get { return _models; }
            set
            {
                _models = value;
                OnPropertyRaised(nameof(Models));
            }
        }

#region Command
        public ICommand AddColumnCommand { get; set; }
        public ICommand DeleteColumnCommand { get; set; }
        public ICommand AddRowCommand { get; set; }
        public ICommand DeleteRowCommand { get; set; }
        public ICommand MouseActionCommand { get; set; }

        private bool CanAddColumnEnabled()
        {
            return true;
        }
        private void OnAddColumnCommandExecuted(object obj)
        {
            _isColumnAddEnabled = true;
        }

        private bool CanDeleteRowEnabled()
        {
            return true;
        }
        private void OnDeleteRowCommandExecuted(object obj)
        {
            _isDeleteRowEnabled = true;
        }

        private bool CanAddRowEnabled()
        {
            return true;
        }
        private void OnAddRowCommandExecuted(object obj)
        {
            _isAddRowEnabled = true;
        }

        private bool CanDeleteColumnEnabled()
        {
            return true;
        }
        private void OnDeleteColumnCommandExecuted(object obj)
        {
            _isColumnDeleteEnabled = true;
        }

        private void OnMouseActionCommandExecuted(object obj)
        {
            BusinessModelColumn businessModelColumn = (BusinessModelColumn)(obj as object[])[0];
            string modelName = (obj as object[])[1].ToString();
            string sector = (obj as object[])[2].ToString();
            if (_isColumnAddEnabled)
            {
                AddColumn(businessModelColumn, modelName);
                _isColumnAddEnabled = false;
            }
            else if (_isColumnDeleteEnabled)
            {
                DeleteColumn(businessModelColumn, modelName);
                _isColumnDeleteEnabled = false;
            }
            else if (_isAddRowEnabled)
            {
                AddRow(sector);
                _isAddRowEnabled = false;
            }
            else if (_isDeleteRowEnabled)
            {
                DeleteRow(sector);
                _isDeleteRowEnabled = false;
            }
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}
