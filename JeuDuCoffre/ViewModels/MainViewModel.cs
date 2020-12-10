using JeuDuCoffre.Commanding;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace JeuDuCoffre.ViewModels
{
    public class MainViewModel : RandomViewModelBase
    {
        private ObservableCollection<int> _code;
        private ObservableCollection<ButtonViewModel> _buttons;
        private ICommand _restartCommand;

        public MainViewModel()
        {

        }

        public ObservableCollection<int> Code
        {
            get
            {
                return _code ??= GenerateCode();
            }
        }

        public ObservableCollection<ButtonViewModel> Buttons
        {
            get
            {
                return _buttons ??= GenerateButton();
            }
        }

        public ICommand RestartCommand
        {
            get
            {
                return _restartCommand ??= new RelayCommand(Restart);
            }
        }

        private ObservableCollection<ButtonViewModel> GenerateButton()
        {
            ButtonViewModel buttonViewModel1 = new ButtonViewModel();
            ButtonViewModel buttonViewModel2 = new ButtonViewModel(buttonViewModel1);
            ButtonViewModel buttonViewModel3 = new ButtonViewModel(buttonViewModel2);
            ButtonViewModel buttonViewModel4 = new ButtonViewModel(buttonViewModel3);
            ButtonViewModel[] buttonViewModels = { buttonViewModel1, buttonViewModel2, buttonViewModel3, buttonViewModel4 };

            Dictionary<int, ButtonViewModel> placement = new Dictionary<int, ButtonViewModel>();
            for (int i = 0; i < 4; i++)
            {
                int random;

                do
                {
                    random = Random.Next(1000);
                } while (placement.ContainsKey(random));


                placement.Add(random, buttonViewModels[i]);
            }

            return new ObservableCollection<ButtonViewModel>(placement.OrderBy(kvp => kvp.Key).Select(kvp => kvp.Value));
        }

        private void Restart()
        {
            IList<int> code = GenerateCode();
            for (int i = 0; i < 4; i++)
            {
                Code[i] = code[i];
            }

            IList<ButtonViewModel> buttons = GenerateButton();
            for (int i = 0; i < 4; i++)
            {
                Buttons[i] = buttons[i];
            }
        }

        private ObservableCollection<int> GenerateCode()
        {
            return new ObservableCollection<int>(new int[] { Random.Next(4) + 1, Random.Next(4) + 1, Random.Next(4) + 1, Random.Next(4) + 1 });
        }
    }
}
