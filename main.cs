using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;



namespace StockAppAssesment
{

    class Program
    {
        public static void Main()
		{
			
			//reference arrays
			string[] names = {"Change_1024.txt","Change_256.txt","Change_128.txt","Close_1024.txt","Close_256.txt","Close_128.txt","High_1024.txt","High_256.txt","High_128.txt","Low_1024.txt","Low_256.txt","Low_128.txt","Open_1024.txt","Open_256.txt","Open_128.txt"};
			string[] algorithms = {"bubble_sort","quick_sort","merge_sort","insertion_sort","binary_search","linear_search"};
			
			
			Console.Clear();
			int count = 0;
			foreach(string s in names)
			{
				Console.WriteLine("({0}) {1} ",count,s);
				count++;
			}//prints the names of the arrays
			
			
			
			
			
			
			
			 //gets user input of which array they want 
			Console.WriteLine("Please choose one off the arrays by typing the refernce number to the left");
			int input1;//array needed
			while (true)
			{			
				while (!int.TryParse(Console.ReadLine(), out input1))//only runs if its not a number 
				{
					
					Console.WriteLine("please enter a valid number");
				
				}
				if (input1 >= 0 && input1 <= 14)//makes sure input is within the list range
					break;
			}
		
			double[] array = read(names[input1]);//creates and array of selected file
		
			
			
			
			string order;//this sections gets the direction of the sorted array 
			while (true)
			{
				Console.WriteLine("would you like it in accending or decending order A/D");
				order = Console.ReadLine();
				order=order.ToLower();
					
				if(order =="a")
				{	
					Console.WriteLine("you've chosen accending order");
					break;
				}
				
				if(order =="d")
				{	
					Console.WriteLine("you've chosen decending order");
					break;
				}
				else
					Console.WriteLine("please choose a valid input");
			}
				
			
			
			Console.Clear();
			count = 0; // resets count from before
			foreach(string s in algorithms)
			{
				Console.WriteLine("({0}) {1} ",count,s);
				count++;
			}//prints the algorithm names
			
			Console.WriteLine("please enter the reference number of an algorithm on the left");
			
			int process;
			while (true)
			{			
				while (!int.TryParse(Console.ReadLine(), out process))//only runs if its not a number 
				{
					
					Console.WriteLine("not a valid reference");
				
				}
				if (process >= 0 && process <= 5)//makes sure input is within the list range
					break;
			}
			
			
			switch(process) //print needs to be changed, pain to send itterations
			{
				case 0:
				{
					Console.Clear();
					Console.WriteLine("bubble_sort");
					bubble(array);
					print(array,order);
					break;
				}	
				case 1:
				{
					Console.Clear();
					Console.WriteLine("quick_sort");
					QuickSort(array);
					print(array,order);
					
					break;
				}
				case 2:
				{
					Console.Clear();
					Console.WriteLine("merge_sort");
					array = MergeSort(array);
					print(array,order);
					break;
				}
				case 3:
				{
					Console.Clear();
					Console.WriteLine("insertion_sort");
					insertionsort(array);
					print(array,order);//iteration is non valid
					break;
				}
				case 4:
				{
					Console.Clear();
					Console.WriteLine("binary_search");
					bubble(array);
					print(array,order);
					binary_search(array);
					
					break;
				}
				case 5:
				{//works just think of way to print
					Console.Clear();
					Console.WriteLine("linear_search");
					QuickSort(array);
					print(array,order);
					linear(array);
					break;
			    }
				
				default:
					break;
				
			}
			//array = the array 
			//process = the operation
			//order = accedning/decending
			
			
			
			Console.ReadLine();
			Console.WriteLine("would you like to go again? y/n");
			string answer = Console.ReadLine();
			answer = answer.ToLower();
			if(answer == "y")
				Main();
			
		}//main
		
		
		
		
//---------------------------------------bubble_sort-------------------------------------------------------		
		public static int bubble(double[] arr) //switch return type to void if no work
		{
			double temp = 0;
			int counter=1;//me adding counter
			for (int write = 0; write < arr.Length; write++) {
				for (int sort = 0; sort < arr.Length - 1; sort++) {
					if (arr[sort] > arr[sort + 1]) {
						temp = arr[sort + 1];
						arr[sort + 1] = arr[sort];
						arr[sort] = temp;
						counter++;//me adding counter
					}
				}
			}
			return counter;
		}
		
		
//-----------------------------quick sort---------------------------------------------------------------------------		
		public static void QuickSort(double[] data)
		{
			// pre: 0 <= n <= data.length
			// post: values in data[0 … n-1] are in ascending order
			Quick_Sort(data, 0, data.Length - 1);
		}
	
	
	
		public static void Quick_Sort(double[] data, int left, int right)
		{
			int i, j;
			double pivot, temp;
			i = left;
			j = right;
			 
			pivot = data[(left + right) / 2];
			 
			do
			{
				while ((data[i] < pivot) && (i < right)) i++;
				while ((pivot < data[j]) && (j > left)) j--;
				if (i <= j)
				{
					temp = data[i];
			
					data[i] = data[j];
					data[j] = temp;
					i++;
					j--;
				}	
			
			} 
			
			while (i <= j);
			{
			 if (left < j) 
				 Quick_Sort(data, left, j);
			 
			 if (i < right) 
				 Quick_Sort(data, i, right);
			}
		 }
		
		
//-------------------------------merge_sort---------------------------------------------------------------------------
		static double[] MergeSort(double[] array)
        {
            
            double[] result = MergeSort(array,0,array.Length);
            Array.Copy(result, array, result.Length);           
            return result;
        }

        //Merge sort class.
        static double[] MergeSort(double[] array, int start, int end)
        {
            if (end - start < 2)
            {
                return new double[] { array[start] };
            }

            int middle = start + ((end - start) / 2);
            double[] left = MergeSort(array, start, middle);
            double[] right = MergeSort(array, middle, end);

            double[] result = new double[left.Length + right.Length];

            int index_left = 0;
            int index_right = 0;
            int result_pos = 0;
            int its = 0;

            for (; index_left < left.Length && index_right < right.Length; result_pos++)
            {
                its++;
                
                if (left[index_left] < right[index_right])
                {
                    result[result_pos] = left[index_left];
                    index_left++;
                }
                else
                {
                    result[result_pos] = right[index_right];
                    index_right++;
                }

            }
            while (index_left < left.Length)
            {
                result[result_pos++] = left[index_left++];
                its++;
            }
            while (index_right < right.Length)
            {
                result[result_pos++] = right[index_right++];
                its++;
            }
            //DisplaySteps(its); its = itterations 
            return result;
        }//mergesort
		
//-------------------------------insertion_sort--------------------------------------------------------------
		public static void insertionsort(double[] numarray)
        {
			
            
			int max = numarray.Length;//get max from array length
			//needs array to be passed to it called "numarray" and a max value of the array 
            for(int i = 1; i < max; i++)
            {

                int j = i;

                while(j > 0)
                {

                    if(numarray[j-1] > numarray[j])
                    {

                        double temp = numarray[j - 1];

                        numarray[j - 1] = numarray[j];

                        numarray[j] = temp;

                        j--;

                    }
                    else
                        break;

				}//while loop end	
			}//for loop end


        }//insert function

//--------------------------------binary_search-------------------------------------------------------------------------		
		//if it cant find the number it just crashes 
		public static void binary_search(double[] array)
		{
			Console.WriteLine("please enter your search term");
			double key;
			while (true)
				{			
					while (!double.TryParse(Console.ReadLine(), out key))//only runs if its not a number 
					{
						
						Console.WriteLine("please enter a valid number");
					
					}
					
					break;
				}
				
			
			
			
			object output =BinarySearchRecursive(array,key,0,array.Length-1);
			int answer = Convert.ToInt32(output)-1; //shits off and i dont know why 
			Console.WriteLine("\n\n\nindex location: " + answer);	
				
				
				
		}
		
	
		public static object BinarySearchRecursive(double[] inputArray, double key, int min, int max)  
		{  
			  if (min > max) //returns max index is larger than min, becaues array not big enough.
			  {  
				  return "Not found";  
			  }  
			  else  
			  {  
				  int mid = (min+max)/2;  
				  if (key == inputArray[mid])  //case for if it is found 
				  {  
					 return ++mid;  //return index location of key
				   }  
				   else if (key < inputArray [mid])  //chooses which side to go for next based on size of key
				   {  
					   return BinarySearchRecursive(inputArray, key, min, mid - 1);  
				   }  
				   else  
				   {  
					  return BinarySearchRecursive(inputArray, key, mid + 1, max);  
				   }  
			  }  
		 }
	
		



	
//--------------------------------linear_search-------------------------------------------------------------		
		
	
		public static void linear(double[] array)
		{
			
			
			Console.WriteLine("please enter your search term");
			double key;
			while (true)
				{			
					while (!double.TryParse(Console.ReadLine(), out key))//only runs if its not a number 
					{
						
						Console.WriteLine("please enter a valid number");
					
					}
					
					break;
				}
				
			List<double> found = new List<double>();//array to store index key
			for(int i = 0; i<array.Length-1;i++)//array.Length-1 because array.Length gives 1-6 
				if(array[i]== key)//checks if the array value is equal to the key 
				{
					found.Add(i);
				}
			
			
			if(found.Count >= 1)
			{
				Console.WriteLine("your search term was found at the following indexs:");
				foreach(double s in found)
					Console.Write(s + " ");
			}
			else
			{
				Console.WriteLine("your search term was not found");
			}
		
		
		}//linear function









//------------------utility functions--------------------------------------------------------------------------------------

		public static double[] read(string name)//reads in array from file 
		{
			double[] array = Array.ConvertAll(File.ReadAllLines(name), double.Parse);
			return array;
		}//read
		
		
		

		
		public static void print(double[] array, string order)//prints arrays that it is handed 
		{
			if(order == "a")
			{
				for(int i = 0; i <= array.Length-1;i++)
					Console.WriteLine("index:{0} value:{1}",i,array[i]);
			}
			if(order == "d")
			{
				int count = 0;//use this to flip displayed index values 
				for(int i = array.Length-1; i>= 0;i--)//prints array backwards
				{
					Console.WriteLine("index:{0} value:{1}",count,array[i]);
					count++;
				}
			}
		
		}//print
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
	}//class

}//namespace