using CalculatorApp.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CalculatorApp.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private int firstNumber;
        public int FirstNumber
        {
            get { return firstNumber; }
            set
            {
                if (firstNumber != value)
                {
                    firstNumber = value;
                    OnPropertyChanged("FirstNumber");
                }
            }
        }

        private int secondNumber;
        public int SecondNumber
        {
            
            get { return secondNumber; }
            set
            {
                if (secondNumber != value)
                {
                    secondNumber = value;
                    OnPropertyChanged("SecondNumber");
                }
            }
        }

        private string resultNumber;
        public string ResultNumber
        {
            get { return resultNumber; }
            set
            {
                if (resultNumber != value)
                {
                    resultNumber = value;
                    OnPropertyChanged("ResultNumber");
                }
            }
        }


        private readonly char[] operations = new char[4] { '+', '-', '*', '/' };
        public char[] Operations
        {
            get { return operations; }
        }

        public char SelectedOperation { get; set; }


        private ICommand calculateCommand;
        public ICommand CalculateCommand
        {
            get
            {
                if(calculateCommand == null)
                {
                    calculateCommand = new RelayCommand(Calculate, CanCalculate);
                    return calculateCommand;
                }
                return calculateCommand;
            }
        }

        private void Calculate(object obj)
        {   
            switch (SelectedOperation)
            {
                case '+': int addResult = Convert.ToInt32(firstNumber) + Convert.ToInt32(secondNumber); ResultNumber = addResult.ToString(); break;
                case '-': int substrationResult = Convert.ToInt32(firstNumber) - Convert.ToInt32(secondNumber); ResultNumber = substrationResult.ToString(); break;
                case '*': int multiplicationResult = Convert.ToInt32(firstNumber) * Convert.ToInt32(secondNumber); ResultNumber = multiplicationResult.ToString(); break;
                case '/': int divisonResult = Convert.ToInt32(firstNumber) / Convert.ToInt32(secondNumber); ResultNumber = divisonResult.ToString(); break; 
                default:
                    break;
            }
        }

        private bool CanCalculate(object obj)
        {
            return true;            
        }



        private ICommand resetCommand;
        public ICommand ResetCommand
        {
            get
            {
                if (resetCommand == null)
                {
                    resetCommand = new RelayCommand(Reset, CanReset);
                    return resetCommand;
                }
                return resetCommand;
            }
        }

        private void Reset(object obj)
        {
            FirstNumber = 0;
            SecondNumber = 0;
            ResultNumber = "0";
        }

        private bool CanReset(object obj)
        {
            return true;
        }
    }
}
