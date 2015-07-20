using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMBuilder.Views.Controls;

namespace VMBuilder.ViewModel
{
    class DelegateScreenViewModel : Classes.ViewModelBase
    {
        private ObservableCollection<DelegateUC> _DelCollection = new ObservableCollection<DelegateUC>();

        public DelegateScreenViewModel()
        {
        }

        public void ManageCards(int i)
        {
            int p = DelCollection.Count;
            if (i == p)
            {
                return;
            }
            else if (i > p)
            {
                i -= p;
                for (int j = 0; j < i; j++)
                {
                    DelCollection.Add(new DelegateUC());
                }
            }
            else if (i < p)
            {
                p -= i;
                for (int j = 0; j < p; j++)
                {
                    DelCollection.Remove(DelCollection.Last());
                }
            }
        }

        public ObservableCollection<DelegateUC> DelCollection
        {
            get { return _DelCollection; }
            set
            {
                if (_DelCollection != value)
                {
                    _DelCollection = value;
                    RaisePropertyChanged("DelCollection");
                }
            }
        }
    }
}
