using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Сalculator.Config;

namespace Сalculator
{
    public class MainViewModel : ObservableObject
    {
        private string _textToShow;

        private string _textResult;

        public string TextToShow
        {
            get=> _textToShow;
            set=> SetProperty(ref _textToShow, value);
        }

        public string TextResult
        {
            get => _textResult;
            set => SetProperty(ref _textResult, value);
        }

        public MainViewModel()
        {
            WebConfig.RegisterClient();
            _textToShow = "";
            _textResult = "";
            Enter0Command = new RelayCommand(()=>EnterValue('0'));
            Enter00Command = new RelayCommand(() => {EnterValue('0'); EnterValue('0');});
            Enter1Command = new RelayCommand(() => EnterValue('1'));
            Enter2Command = new RelayCommand(() => EnterValue('2'));
            Enter3Command = new RelayCommand(() => EnterValue('3'));
            Enter4Command = new RelayCommand(() => EnterValue('4'));
            Enter5Command = new RelayCommand(() => EnterValue('5'));
            Enter6Command = new RelayCommand(() => EnterValue('6'));
            Enter7Command = new RelayCommand(() => EnterValue('7'));
            Enter8Command = new RelayCommand(() => EnterValue('8'));
            Enter9Command = new RelayCommand(() => EnterValue('9'));
            EnterDotCommand = new RelayCommand(() => EnterValue('.'));
            EnterSumCommand = new RelayCommand(() => EnterCommand('+'));
            EnterSubCommand = new RelayCommand(() => EnterCommand('-'));
            EnterDivCommand = new RelayCommand(() => EnterCommand('/'));
            EnterMultCommand = new RelayCommand(() => EnterCommand('*'));
            EraseCommand = new RelayCommand(Erase);
            ResultCommand = new RelayCommand(ResultCalc);
        }

        public ICommand Enter0Command { get; }
        public ICommand Enter00Command { get; }
        public ICommand Enter1Command { get; }
        public ICommand Enter2Command { get; }
        public ICommand Enter3Command { get; }
        public ICommand Enter4Command { get; }
        public ICommand Enter5Command { get; }
        public ICommand Enter6Command { get; }
        public ICommand Enter7Command { get; }
        public ICommand Enter8Command { get; }
        public ICommand Enter9Command { get; }
        public ICommand EnterDotCommand { get; }
        public ICommand EnterSumCommand { get; }
        public ICommand EnterSubCommand { get; }
        public ICommand EnterDivCommand { get; }
        public ICommand EnterMultCommand { get; }
        public ICommand EraseCommand { get; }
        public ICommand ResultCommand { get; }


        private void EnterCommand(char commandToEnter)
        {
            char check = TextToShow.Last();
            if (check == '+' || check=='-' || check=='*' || check=='/')
            {
                MessageBox.Show("Нужно ввести число, после операции!");
            }
            else if (TextToShow=="")
            {
                MessageBox.Show("Нужно ввести число!");
            }
            else
            {
                TextToShow += commandToEnter;
            }
        }

        private void EnterValue(char valueToEnter)
        {
            TextToShow += valueToEnter;
        }

        private void Erase()
        {
            if (TextToShow.Length==0)
            {
                MessageBox.Show("Нечего стирать. Введите цифру или команду");
            }
            else
            {
                TextToShow = TextToShow.Remove(TextToShow.Length - 1);
            }
        }

        private void ResultCalc()
        {
            string a = "";
            string b = "";
            string c = "";
            char command=' ';
            if (TextToShow.Length>0)
            {
                for (int count = 0; count < TextToShow.Length; count++)
                {
                    var d = TextToShow[count];
                    if (count == TextToShow.Length - 1)
                    {
                        c+=TextToShow[count];
                        b = c;
                        TextResult = StartCalc(a,b, command);
                    }
                    else if (d != '+' && TextToShow[count] != '-' && TextToShow[count] != '*' && TextToShow[count] != '/')
                    {
                        c += TextToShow[count];
                    }
                    else
                    {
                        if (command == ' ')
                        {
                            command = TextToShow[count];
                        }
                        if (a != "")
                        {
                            b = c;
                            c = "";
                        }
                        else
                        {
                            a = c;
                            c = "";
                        }
                        if (b != "")
                        {
                            a = StartCalc(a,b, command);
                            b = "";
                            c = "";
                            command = TextToShow[count];
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Не ввдено числ для расчета!");
            }
        }
        private string StartCalc(string a, string b, char command)
        {
            if (command =='+')
            {
                string result = "";
                Task commander= Task.Run(async () =>
                {
                    result = await WebConfig.GetValueResult(a, b, "api/sum");
                });
                commander.Wait();
                return result;
            }
            else if (command =='-')
            {
                string result = "";
                Task commander = Task.Run(async () =>
                {
                    result = await WebConfig.GetValueResult(a, b, "api/subtraction");
                });
                commander.Wait();
                return result;
            }
            else if (command=='*')
            {
                string result = "";
                Task commander = Task.Run(async () =>
                {
                    result = await WebConfig.GetValueResult(a, b, "api/multiplication");
                });
                commander.Wait();
                return result;
            }
            else
            {
                string result = "";
                Task commander = Task.Run(async () =>
                {
                    result = await WebConfig.GetValueResult(a, b, "api/division");
                });
                commander.Wait();
                return result;
            }
        }

    }
}
