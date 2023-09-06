using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using SortingAlgos.RelayCommads;
using SortingAlgos.Model;
using System.Diagnostics;

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

        Stopwatch stopwatch;

        mainDisplayModel sortModel;
        public mainDisplayViewModel()
        {
            stopwatch = new Stopwatch();
            stopwatch.Reset();
            sortModel = new mainDisplayModel();

            generateRand    = new RelayCommand(generateRandomArray);

            bubbleSort      = new RelayCommand(doBubbleSort);
            selectionSort   = new RelayCommand(doSelectionSort);
            insertionSort   = new RelayCommand(doInsertionSort);
        }

        /// <summary>
        /// //////////////////////////////////              Binding Properties Defined   ///////////////////////////////////////////////////////
        /// </summary>

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

        private string bubbleTimeShow;

        public string BubbleTimeShow
        {
            get { return bubbleTimeShow; }
            set { bubbleTimeShow = value; OnPropertyChange(nameof(BubbleTimeShow)); }
        }

        private string selectionTimeShow;

        public string SelectionTimeShow
        {
            get { return  selectionTimeShow; }
            set {  selectionTimeShow = value; OnPropertyChange(nameof(SelectionTimeShow)); }
        }

        private string insertionTimeShow;

        public string InsertionTimeShow
        {
            get { return insertionTimeShow; }
            set { insertionTimeShow = value; OnPropertyChange(nameof(InsertionTimeShow)); }
        }


        /// <summary>
        /// ////////////////////////////////////////////////////  Actions Defined //////////////////////////////////////////////////////////////////////
        /// </summary>
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
            long elapsedMicroSeconds = 0;
            TimeSpan elapsedTime;

            stopwatch.Start();
            int[] array = sortModel.doBubbleSort(mainArray, arraySize);
            stopwatch.Stop();
            elapsedTime = stopwatch.Elapsed;
            elapsedMicroSeconds = elapsedTime.Ticks / 10;

            BubbleTimeShow = elapsedMicroSeconds.ToString();
            stopwatch.Reset();
            string arrayString = string.Join("  ",array);
            SortedArrayShow = arrayString;
        }

        public void doSelectionSort()
        {
            long elapsedMicroSeconds =0;
            TimeSpan elapsedTime;

            stopwatch.Start();
            int[] array = sortModel.doSelectionSort(mainArray, arraySize);
            stopwatch.Stop();
            elapsedTime = stopwatch.Elapsed;
            elapsedMicroSeconds = elapsedTime.Ticks / 10;

            SelectionTimeShow = elapsedMicroSeconds.ToString();
            stopwatch.Reset();
            string arrayString = string.Join("  ", array);
            SortedArrayShow = arrayString;
        }

        public void doInsertionSort()
        {
            long elapsedMicroSeconds =0;
            TimeSpan elapsedTime;

            stopwatch.Start();
            int[] array = sortModel.doInsertionSort(mainArray, arraySize);
            stopwatch.Stop();
            elapsedTime = stopwatch.Elapsed;
            elapsedMicroSeconds = elapsedTime.Ticks / 10;

            InsertionTimeShow = elapsedMicroSeconds.ToString();
            stopwatch.Reset();
            string arrayString = string.Join("  ", array);
            SortedArrayShow = arrayString;
        }
    }
}
