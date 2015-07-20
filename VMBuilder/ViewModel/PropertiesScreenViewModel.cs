using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using VMBuilder.Views.Controls;

namespace VMBuilder.ViewModel
{
    class PropertiesScreenViewModel : Classes.ViewModelBase
    {
        private ObservableCollection<PropertyUC> _PropertyCollection = new ObservableCollection<PropertyUC>();

        public PropertiesScreenViewModel()
        {
            
        }

        public void ManageCards(int i)
        {
            int p = PropertyCollection.Count;
            if (i == p)
            {
                return;
            }
            else if(i > p)
            {
                i -= p;
                for (int j = 0; j < i; j++)
                {
                    PropertyCollection.Add(new PropertyUC());
                }
            }
            else if (i < p)
            {
                p -= i;
                for (int j = 0; j < p; j++)
                {
                    PropertyCollection.Remove(PropertyCollection.Last());
                }
            }
        }

        public ObservableCollection<PropertyUC> PropertyCollection
        {
            get { return _PropertyCollection; }
            set
            {
                if (_PropertyCollection != value)
                {
                    _PropertyCollection = value;
                    RaisePropertyChanged("PropertyCollection");
                }
            }
        }
    }
}
