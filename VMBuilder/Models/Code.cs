using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMBuilder.ViewModel;
using VMBuilder.Views.Controls;

namespace VMBuilder.Models
{
    class Code : Classes.ViewModelBase
    {
        private string _ClassName;
        private List<string> _PropertyTypes = new List<string>();
        private List<string> _PropertyNames = new List<string>();
        private List<string> _DelegateNames = new List<string>();
        private List<string> _Constructors = new List<string>();

        private List<string> _BackingProperties = new List<string>();
        private List<string> _BackingDelegates = new List<string>();

        private List<string> _ForegroundProperties = new List<string>();
        private List<string> _DelegateMethods = new List<string>();

        public Code()
        {
            
        }

        public Code(string className, ObservableCollection<PropertyUC> PropertyCollection,
            ObservableCollection<DelegateUC> DelegateCollection,
            ObservableCollection<ConstructorUC> ConstructorCollection)
        {
            ClassName = className;
            if (ClassName == "")
                ClassName = "CLASSNAME";
            foreach (PropertyUC PropCard in PropertyCollection)
            {
                var vm = PropCard.DataContext as PropertyUCViewModel;
                PropertyNames.Add(vm.PropertyName);
                PropertyTypes.Add(vm.PropertyType as string);
                BackingProperties.Add("private " + vm.PropertyType + " _" + vm.PropertyName + ";/r");
            }
            foreach (DelegateUC DelCard in DelegateCollection)
            {
                var vm = DelCard.DataContext as DelegateUCViewModel;
                DelegateNames.Add(vm.DelegateName);
                BackingDelegates.Add("public DelegateCommand<object> " + vm.DelegateName + " { get; set; }/r");
            }
            foreach (ConstructorUC ConCard in ConstructorCollection)
            {
                var vm = ConCard.DataContext as ConstructorUCViewModel;
                Constructors.Add("public " + ClassName + "(" + vm.ConstructorVars + ")/r" + "{/r}/r");
            }
            if(Constructors.Count == 0 && DelegateNames.Count > 0)
                Constructors.Add("public " + ClassName + "()/r" + "{/r}/r");
            for (int i = 0; i < Constructors.Count; i++)
            {
                Constructors[i] = DelegateNames.Aggregate(Constructors[i], (current, Del) => current.Replace("{/r", "{/r   " + Del + " = new DelegateCommand<object>(" + Del + "_Exec, " + Del + "_CanExec);/r"));
            }
            for (int i = 0; i < PropertyNames.Count; i++)
            {
                ForegroundProperties.Add("public " + PropertyTypes[i] + " " + PropertyNames[i] + "/r{/r get { return _"
                    + PropertyNames[i] + "; }/r set/r {/r     if (_" + PropertyNames[i] +
                    " != value)/r       {/r           _" + PropertyNames[i] +
                    " = value;/r            RaisePropertyChanged(\"" + PropertyNames[i] + "\");/r       }/r }/r}/r");
            }
            foreach (var DelName in DelegateNames)
            {
                DelegateMethods.Add("private void " + DelName + "_Exec(object args)/r{/r}/r");
                DelegateMethods.Add("private bool " + DelName + "_CanExec(object ags)/r{/r  return true;/r}/r");
            }
        }

#region Properties


        public List<string> PropertyNames
        {
            get { return _PropertyNames; }
            set
            {
                if (_PropertyNames != value)
                {
                    _PropertyNames = value;
                    RaisePropertyChanged("Properties");
                }
            }
        }

        public List<string> DelegateNames
        {
            get { return _DelegateNames; }
            set
            {
                if (_DelegateNames != value)
                {
                    _DelegateNames = value;
                    RaisePropertyChanged("Delegates");
                }
            }
        }

        public List<string> Constructors
        {
            get { return _Constructors; }
            set
            {
                if (_Constructors != value)
                {
                    _Constructors = value;
                    RaisePropertyChanged("Constructors");
                }
            }
        }

        public string ClassName
        {
            get { return _ClassName; }
            set
            {
                if (_ClassName != value)
                {
                    _ClassName = value;
                    RaisePropertyChanged("ClassName");
                }
            }
        }

        public List<string> BackingProperties
        {
            get { return _BackingProperties; }
            set
            {
                if (_BackingProperties != value)
                {
                    _BackingProperties = value;
                    RaisePropertyChanged("BackingProperties");
                }
            }
        }

        public List<string> BackingDelegates
        {
            get { return _BackingDelegates; }
            set
            {
                if (_BackingDelegates != value)
                {
                    _BackingDelegates = value;
                    RaisePropertyChanged("BackingDelegates");
                }
            }
        }

        public List<string> ForegroundProperties
        {
            get { return _ForegroundProperties; }
            set
            {
                if (_ForegroundProperties != value)
                {
                    _ForegroundProperties = value;
                    RaisePropertyChanged("ForegroundProperties");
                }
            }
        }

        public List<string> DelegateMethods
        {
            get { return _DelegateMethods; }
            set
            {
                if (_DelegateMethods != value)
                {
                    _DelegateMethods = value;
                    RaisePropertyChanged("DelegateMethods");
                }
            }
        }

        public List<string> PropertyTypes
        {
            get { return _PropertyTypes; }
            set
            {
                if (_PropertyTypes != value)
                {
                    _PropertyTypes = value;
                    RaisePropertyChanged("PropertyTypes");
                }
            }
        }


        #endregion
    }
}
