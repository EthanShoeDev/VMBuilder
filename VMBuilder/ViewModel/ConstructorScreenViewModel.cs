using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMBuilder.Views.Controls;

namespace VMBuilder.ViewModel
{
    class ConstructorScreenViewModel : Classes.ViewModelBase
    {
        private ObservableCollection<ConstructorUC> _ConCards = new ObservableCollection<ConstructorUC>();

        public ConstructorScreenViewModel()
        {
        }

        public void ManageCards(int i)
        {
            int p = ConCards.Count;
            if (i == p)
            {
                return;
            }
            else if (i > p)
            {
                i -= p;
                for (int j = 0; j < i; j++)
                {
                    ConCards.Add(new ConstructorUC());
                }
            }
            else if (i < p)
            {
                p -= i;
                for (int j = 0; j < p; j++)
                {
                    ConCards.Remove(ConCards.Last());
                }
            }
        }

        public ObservableCollection<ConstructorUC> ConCards
        {
            get { return _ConCards; }
            set
            {
                if (_ConCards != value)
                {
                    _ConCards = value;
                    RaisePropertyChanged("ConCards");
                }
            }
        }
    }
}
