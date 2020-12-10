using JeuDuCoffre.Commanding;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace JeuDuCoffre.ViewModels
{
    public class ButtonViewModel : RandomViewModelBase
    {
        private ButtonViewModel _linkedButton;
        private int _value;
        private ICommand _changeValueCommand;

        public int Value
        {
            get
            {
                return _value;
            }

            set
            {
                if (_value != value)
                {
                    _value = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ICommand ChangeValueCommand
        {
            get
            {
                return _changeValueCommand ??= new RelayCommand(ChangeValue);
            }
        }

        private ButtonViewModel LinkedButton
        {
            get
            {
                return _linkedButton;
            }

            set
            {
                _linkedButton = value;
            }
        }

        public ButtonViewModel(ButtonViewModel linkedButton = null)
        {
            LinkedButton = linkedButton;
            Value = Random.Next(4) + 1;
        }

        private void ChangeValue()
        {
            Value = (Value < 4) ? Value + 1 : 1;
            LinkedButton?.ChangeValue();
        }
    }
}
