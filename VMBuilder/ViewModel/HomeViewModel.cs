using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using VMBuilder.Classes;
using VMBuilder.Models;
using VMBuilder.Views;

namespace VMBuilder.ViewModel
{
    public class HomeViewModel : Classes.ViewModelBase
    {
        private string _ClassName = string.Empty;
        private string _Properties = string.Empty;
        private string _Delegates = string.Empty;
        private string _Constructors = string.Empty;
        private int _ScreenIndex = 0;
        private UserControl _PropertiesScreen;
        private UserControl _DelegateScreen;
        private UserControl _ConstructorScreen;
        private PropertiesScreenViewModel PropVM;
        private DelegateScreenViewModel DelVM;
        private ConstructorScreenViewModel ConVM;

        public DelegateCommand<object> TextBoxGotFocus { get; set; }

        public DelegateCommand<object> ClearButtonClicked { get; set; } 
        public DelegateCommand<object> GenerateButtonClicked { get; set; }


        public HomeViewModel()
        {
            TextBoxGotFocus = new DelegateCommand<object>(TextBoxGotFocus_Exec, TextBoxGotFocus_CanExec);
            ClearButtonClicked = new DelegateCommand<object>(ClearButtonClicked_Exec, ClearButtonClicked_CanExec);
            GenerateButtonClicked = new DelegateCommand<object>(GenerateButtonClicked_Exec, GenerateButtonClicked_CanExec);
        }
        #region Update ScreenIndex Deleagtes
        private void TextBoxGotFocus_Exec(object args)
        {
            ScreenIndex = Convert.ToInt32(args.ToString());
        }

        private bool TextBoxGotFocus_CanExec(object args)
        {
            return true;
        }
        #endregion
        #region Button Delegates

        private void ClearButtonClicked_Exec(object args)
        {
            ClassName = "";
            Properties = "";
            Delegates = "";
            Constructors = "";
        }

        private bool ClearButtonClicked_CanExec(object args)
        {
            return true;
        }

        private void GenerateButtonClicked_Exec(object args)
        {
            if(ConVM == null)
                ConVM = new ConstructorScreenViewModel();
            if(PropVM == null)
                PropVM = new PropertiesScreenViewModel();
            if(DelVM == null)
                DelVM = new DelegateScreenViewModel();
            var Code = new Code(ClassName, PropVM.PropertyCollection, DelVM.DelCollection, ConVM.ConCards);
            new CodeViewModel(Code);
        }

        private bool GenerateButtonClicked_CanExec(object args)
        {
            return true;
        }
#endregion
        #region Properties
        public int ScreenIndex
        {
            get { return _ScreenIndex; }
            set
            {
                if (_ScreenIndex != value)
                {
                    _ScreenIndex = value;
                    RaisePropertyChanged("ScreenIndex");
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

        public string Properties
        {
            get { return _Properties; }
            set
            {
                if (Regex.IsMatch(value, @"^[0-9]+$") || value == "")
                {
                    if (_Properties != value)
                    {
                        if (value != "")
                        {
                            if (PropertiesScreen == null)
                            {
                                PropertiesScreen = new PropertiesScreen();
                                PropVM = PropertiesScreen.DataContext as PropertiesScreenViewModel;
                                PropVM.ManageCards(Convert.ToInt32(value));
                            }
                            else
                            {
                                PropVM.ManageCards(Convert.ToInt32(value));
                            }
                        }
                        else
                            PropVM.ManageCards(0);
                        _Properties = value;
                        RaisePropertyChanged("Properties");
                    }
                }
            }
        }

        public string Delegates
        {
            get { return _Delegates; }
            set
            {
                if (Regex.IsMatch(value, @"^[0-9]+$") || value == "")
                {
                    if (_Delegates != value)
                    {
                        if (value != "")
                        {
                            if (DelegateScreen == null)
                            {
                                DelegateScreen = new DelegateScreen();
                                DelVM = DelegateScreen.DataContext as DelegateScreenViewModel;
                                DelVM.ManageCards(Convert.ToInt32(value));
                            }
                            else
                            {
                                DelVM.ManageCards(Convert.ToInt32(value));
                            }
                        }
                        else
                            DelVM.ManageCards(0);
                        _Delegates = value;
                        RaisePropertyChanged("Delegates");
                    }
                }
            }
        }

        public string Constructors
        {
            get { return _Constructors; }
            set
            {
                if (Regex.IsMatch(value, @"^[0-9]+$") || value == "")
                {
                    if (_Constructors != value)
                    {
                        if (value != "")
                        {
                            if (ConstructorScreen == null)
                            {
                                ConstructorScreen = new ConstructorScreen();
                                ConVM = ConstructorScreen.DataContext as ConstructorScreenViewModel;
                                ConVM.ManageCards(Convert.ToInt32(value));
                            }
                            else
                            {
                                ConVM.ManageCards(Convert.ToInt32(value));
                            }
                        }
                        else
                            ConVM.ManageCards(0);
                        _Constructors = value;
                        RaisePropertyChanged("Constructors");
                    }
                }
            }
        }

        public UserControl PropertiesScreen
        {
            get { return _PropertiesScreen; }
            set
            {
                if (_PropertiesScreen != value)
                {
                    _PropertiesScreen = value;
                    RaisePropertyChanged("PropertiesScreen");
                }
            }
        }

        public UserControl DelegateScreen
        {
            get { return _DelegateScreen; }
            set
            {
                if (_DelegateScreen != value)
                {
                    _DelegateScreen = value;
                    RaisePropertyChanged("DelegateScreen");
                }
            }
        }

        public UserControl ConstructorScreen
        {
            get { return _ConstructorScreen; }
            set
            {
                if (_ConstructorScreen != value)
                {
                    _ConstructorScreen = value;
                    RaisePropertyChanged("ConstructorScreen");
                }
            }
        }


        #endregion
    }
}
