using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using SortingAlgos.RelayCommads;
using SortingAlgos.Model;

namespace SortingAlgos.ViewModels
{
    public class mainDisplayViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand generateRand { get; }
        public ICommand bubbleSort   { get; }
        public ICommand selectionSort{ get; }
        public ICommand insertionSort { get; }

        mainDisplayModel sortModel;
        public mainDisplayViewModel()
        {
            sortModel = new mainDisplayModel();

            generateRand    = new RelayCommand(generateRandomArray);

            bubbleSort      = new RelayCommand(doBubbleSort);
            selectionSort   = new RelayCommand(doSelectionSort);
            insertionSort   = new RelayCommand(doInsertionSort);
        }

        private string arraySizeInput;

        public string ArraySize
        {
            get { return arraySizeInput; }
            set
            {
                if (arraySizeInput != value)
                {
                    arraySizeInput = value; OnPropertyChange(nameof(ArraySize));
                }
            } 
        }

        private string randomArrayShow;

        public string RandomArrayShow
        {
            get { return randomArrayShow; }
            set { randomArrayShow = value; OnPropertyChange(nameof(RandomArrayShow)); }
        }

        private string sortedArrayShow;

        public string SortedArrayShow
        {
            get { return sortedArrayShow; }
            set { sortedArrayShow = value; OnPropertyChange(nameof(SortedArrayShow)); }
        }

        int[] mainArray;
        int arraySize;
        public void generateRandomArray()
        {
            arraySize = int.Parse(ArraySize);
             mainArray = sortModel.generateRandomNumberArray(arraySize);
            string arrayString = string.Join("  ", mainArray);
            RandomArrayShow = arrayString;
        }


        public void doBubbleSort()
        {
            int[] array = sortModel.doBubbleSort(mainArray, arraySize);
            string arrayString = string.Join("  ",array);
            SortedArrayShow = arrayString;
        }

        public void doSelectionSort()
        {
            int[] array = sortModel.doSelectionSort(mainArray, arraySize);
            string arrayString = string.Join("  ", array);
            SortedArrayShow = arrayString;
        }

        public void doInsertionSort()
        {
            int[] array = sortModel.doInsertionSort(mainArray, arraySize);
            string arrayString = string.Join("  ", array);
            SortedArrayShow = arrayString;
        }
    }
}
