using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMBuilder.Classes;

namespace VMBuilder.ViewModel
{
    class PropertyUCViewModel : Classes.ViewModelBase
    {
        private string _PropertyName = string.Empty;
        private object _PropertyType = string.Empty;


        public string PropertyName
        {
            get { return _PropertyName; }
            set
            {
                if (_PropertyName != value)
                {
                    _PropertyName = value;
                    RaisePropertyChanged("PropertyName");
                }
            }
        }

        public object PropertyType
        {
            get { return _PropertyType; }
            set
            {
                if (_PropertyType != value)
                {
                    var block =
                    value as System.Windows.Controls.TextBlock;
                    if (block != null)
                    {
                        value = block.Text;
                    }
                    _PropertyType = value;
                    RaisePropertyChanged("PropertyType");
                }
            }
        }

    }
}
