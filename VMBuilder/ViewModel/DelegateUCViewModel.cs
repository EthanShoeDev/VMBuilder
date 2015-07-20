using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMBuilder.ViewModel
{
    class DelegateUCViewModel : Classes.ViewModelBase
    {
        private string _DelegateName = string.Empty;


        public string DelegateName
        {
            get { return _DelegateName; }
            set
            {
                if (_DelegateName != value)
                {
                    _DelegateName = value;
                    RaisePropertyChanged("DelegateName");
                }
            }
        }

    }
}
