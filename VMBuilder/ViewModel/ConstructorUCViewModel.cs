using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMBuilder.ViewModel
{
    class ConstructorUCViewModel : Classes.ViewModelBase
    {
        private string _ConstructorVars = string.Empty;

        /// <summary>
        /// Get/Set ConstructorVars
        /// </summary>
        public string ConstructorVars
        {
            get { return _ConstructorVars; }
            set
            {
                if (_ConstructorVars != value)
                {
                    _ConstructorVars = value;
                    RaisePropertyChanged("ConstructorVars");
                }
            }
        }


    }
}
