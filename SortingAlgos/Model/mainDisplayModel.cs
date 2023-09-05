using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgos.Model
{
    public class mainDisplayModel
    {
        Random random;
        public mainDisplayModel()
        {
            random = new Random();
        }

        public int[] generateRandomNumberArray(int sizeofArray)
        {
            int[] arr = new int[sizeofArray];
            for (int i = 0; i < sizeofArray; i++)
            {
                arr[i] = random.Next(1, 1000);
            }

            return arr;
        }

        public int[] doBubbleSort(int[] arr, int sizeofArray)
        {
            for (int i = 0; i < sizeofArray - 1; i++)
            {
                for (int j = 0; j < sizeofArray - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        swap(ref arr[j], ref arr[j + 1]);
                    }
                }
            }


            return arr;
        }

        public int[] doInsertionSort(int[] arr, int sizeofArray)
        {
            for (int i = 1; i < sizeofArray; i++)
            {
                int temp = i;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (arr[j] > arr[i])
                    {
                        swap(ref arr[j], ref arr[i]);
                        i = j;
                    }

                    else break;
                }

                i = temp;
            }

            return arr;
        }

       public  int [] doSelectionSort(int[] arr, int sizeofArray)
        {
            for (int i = 0; i < sizeofArray; i++)
            {
                for (int j = i + 1; j < sizeofArray; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        swap(ref arr[i], ref arr[j]);

                    }
                }
            }

            return arr;
        }

        void swap(ref int var1, ref int var2)
        {
            int temp = var1;
            var1 = var2;
            var2 = temp;

        }
    }
}
