using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media.TextFormatting;
using System.Xml;
using VMBuilder.Models;
using VMBuilder.Views.Windows;

namespace VMBuilder.ViewModel
{
    class CodeViewModel : Classes.ViewModelBase
    {
        private string _FullCode = string.Empty;

        public CodeViewModel(Code codeModel)
        {
            var View =  new CodeView();
            View.DataContext = this;
            foreach (var backProp in codeModel.BackingProperties)
            {
                FullCode += backProp;
            }
            FullCode += "/r";
            foreach (var backDel in codeModel.BackingDelegates)
            {
                FullCode += backDel;
            }
            FullCode += "/r/r";
            foreach (var con in codeModel.Constructors)
            {
                FullCode += con;
            }
            FullCode += "/r/r #region DelegateMethods/r";
            foreach (var delMethod in codeModel.DelegateMethods)
            {
                FullCode += delMethod;
            }
            FullCode += "#endregion/r/r#region Properties/r";
            foreach (var foreProp in codeModel.ForegroundProperties)
            {
                FullCode += foreProp;
            }
            FullCode += "#endregion";
            FullCode = FullCode.Replace("/r", Environment.NewLine);
            View.Show();
        }

        public string FullCode
        {
            get { return _FullCode; }
            set
            {
                if (_FullCode != value)
                {
                    _FullCode = value;
                    RaisePropertyChanged("FullCode");
                }
            }
        }
    }
}
