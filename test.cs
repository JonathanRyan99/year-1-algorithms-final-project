using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;




class Program
{
    public class Algorithms
	{
		
		Requirments R = new Requirments();
		public int counter;//needs to be reset on every algorthim for repeat use
		
//-----------------------------------bubble------------------------------------------------------------------		
		public void bubble(double[] arr) //switch return type to void if no work
		{
			double temp = 0;
			counter=1;//me adding counter
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
			
		}//bubble
		
//-------------------------------quick_sort------------------------------------------------------------------------	
		public  void QuickSort(double[] data)
		{
			// pre: 0 <= n <= data.length
			// post: values in data[0 … n-1] are in ascending order
			Quick_Sort(data, 0, data.Length - 1);
		}
	
	
	
		public void Quick_Sort(double[] data, int left, int right)
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
					counter++;
				}	
			
			} 
			
			while (i <= j);
			{
			 if (left < j) 
			 {
				Quick_Sort(data, left, j);
				counter++;
			 }
			 
			 if (i < right) 
			 { 
				Quick_Sort(data, i, right);
				counter++;
			 }
			}
		 }//quick_sort
//------------------------------------------merge sort------------------------------------------------------------------		
		public double[] MergeSort(double[] array)
        {
            
            double[] result = MergeSort(array,0,array.Length);
            Array.Copy(result, array, result.Length);           
            return result;
        }

        //Merge sort class.
        public double[] MergeSort(double[] array, int start, int end)
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
            

            for (; index_left < left.Length && index_right < right.Length; result_pos++)
            {
                counter++;
                
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
                counter++;
            }
            while (index_right < right.Length)
            {
                result[result_pos++] = right[index_right++];
                counter++;
            }
      
            return result;
        }//mergesort	
	
//------------------------------insertion_sort----------------------------------------------------
		public void insertionsort(double[] numarray)
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
						counter++;

                    }
                    else
                        break;

				}//while loop end	
			}//for loop end


        }//insert function
//-------------------------------------------binary_search-----------------------------------------
		public int binary_search(double[] array) 
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
			
			
			int counter = 0;
			int min = 0;
			int N=array.Length;
			int max= N-1;
			do{
				int mid = (min+max) / 2;
				if (key > array[mid])
					min = mid + 1;
           
				else
					max = mid - 1;
           
				if (array[mid] == key)
					return mid;
            
				counter++;
			} while(min <= max);
         
		 int close =binaryclose(array, key);
		 Console.WriteLine("value not found\nclosest vaule found at index:{0}:vaule:{1}",close,array[close]);
		 return -1;
		}
		
//---------------------binary close-----------------------------------------------------------
		public int binaryclose(double[] arr, double val)
        {
            int l = 0;
            int h = arr.Length - 1;
            int its = 0;
            int b = l;
            while(l<=h)
            {
                its++;
                int m = (h + l) / 2;
                if (arr[m] < val)
                {
                    l = m + 1;

                }
                else if (arr[m] > val)
                {
                    h = m - 1;
                }
                else
                {
                    b = m;
                    break;
                }
                if(Math.Abs(arr[m] - val) <= Math.Abs(arr[b] - val))
                {
                    b = m;
                }

            }
            
            return b;
        }

		
		
		
		
	
//-------------------------------------------linear search ------------------------------------------------

		public void linear(double[] array)
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
			{
				counter++;
				if(array[i]== key)//checks if the array value is equal to the key 
				{
					found.Add(i);
				}
			}
			
			Console.WriteLine("number of iterations:{0}",counter);
			if(found.Count >= 1)//.Count works like length for lists
			{
				Console.WriteLine("your search term was found at the following indexs:");
				foreach(double s in found)
					Console.Write(s + " ");
			}
			else
			{
				Console.WriteLine("your search term was not found");
				int close = linearClostests(array,key);
				Console.WriteLine("the closest value found at index:{0} : value:{1}",close,array[close]);
			}
		
		
		}//linear function
	

		
	//-------------------------cloests for linear search--------------------------------------------
		public static int linearClostests(double[] arr, double val)
        {
            int nearest = 0;
            int its = 0;

            for(int i = 0; i < arr.Length; i++)
            {
                its++;
                if((arr[i] <= val))
                {
                    nearest = i;
                }
                else
                {
                    if (Math.Abs(arr[i] - val) <= Math.Abs(arr[nearest] - val))
                    {
                        nearest = i;
                    }
                    break;
                }
            }            
            return nearest;
        }
		

	
	}//Algorithms
//-------------------------------------------------------------------------------------------------------	
	
	
	public class extra
	{
		
		public void print(double[] array, string order, int its)//prints arrays that it is handed 
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
			Console.WriteLine("number of iterations:{0}",its);
		}//print
		
		
		public void print(double[] array, string order)//prints arrays that it is handed 
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
		
		
	}
	
	public class Requirments//stores the 3 requirements for this program
	{
		public int iterations=1;
		public string order;
		public double[] array;		
		
	}
	
	
	static public double[] read_single(string name)//creates the array of one file
	{
		double[] array = Array.ConvertAll(File.ReadAllLines(name), double.Parse);
		return array;
	}
		
	
	public static void Main()
	{
		extra E = new extra();
		Requirments R = new Requirments();
		Algorithms A = new Algorithms();
		
		
		//R.array= read_single("Open_128.txt");
		//A.sort(R.array);
		//E.print(R.array);

		
		
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
			//part of the display	
			
			
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
		
			R.array = read_single(names[input1]);//creates and array of selected file
			//its stored in Requirements
		
			
			//this sections gets the direction of the sorted array 
			while (true)
			{
				Console.WriteLine("would you like it in accending or decending order A/D");
				R.order = Console.ReadLine();
				R.order=R.order.ToLower();
					
				if(R.order =="a")
				{	
					Console.WriteLine("you've chosen accending order");
					break;
				}
				
				if(R.order =="d")
				{	
					Console.WriteLine("you've chosen decending order");
					break;
				}
				else
					Console.WriteLine("please choose a valid input");
			}
			Console.ReadKey();
			//R.order is set here
			
			
			
			//the following section is for getting the algorithm
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
			
			
			switch(process) 
			{
				case 0:
				{
					Console.Clear();
					Console.WriteLine("bubble_sort");
					A.bubble(R.array);
					R.iterations = A.counter;
					A.counter = 0;
					E.print(R.array,R.order,R.iterations);
					
					
					
					break;
				}	
				case 1:
				{
					Console.Clear();
					Console.WriteLine("quick_sort");
					A.QuickSort(R.array);
					R.iterations = A.counter;
					A.counter=0;
					E.print(R.array,R.order,R.iterations);
					
					
					break;
				}
				case 2:
				{
					Console.Clear();
					Console.WriteLine("merge_sort");
					R.array = A.MergeSort(R.array);
					R.iterations = A.counter;
					A.counter = 0;
					E.print(R.array,R.order,R.iterations);
					
					break;
				}
				case 3:
				{
					Console.Clear();
					Console.WriteLine("insertion_sort");
					A.insertionsort(R.array);
					R.iterations = A.counter;
					A.counter= 0;
					E.print(R.array,R.order,R.iterations);
					
					
					break;
				}
				case 4:
				{//iterations is still broken on this
					Console.Clear();
					Console.WriteLine("binary_search");
					A.QuickSort(R.array);
					E.print(R.array,R.order);
					A.counter =0;
					int result =A.binary_search(R.array);
					Console.WriteLine("iterations:{0}",R.iterations);
					if(result >= 0)
						Console.WriteLine("your search was found at index:{0}",result);
					else
					{	
						Console.WriteLine();
					}
					
					
					
					break;
				}
				case 5:
				{
					Console.Clear();
					Console.WriteLine("linear_search");
					A.QuickSort(R.array);
					E.print(R.array,R.order);
					A.linear(R.array);
					R.iterations = A.counter;
					A.counter = 0;
					
					
					
					break;
			    }
				
				default:
					break;
				
				
				
			}//switch statement
			
			Console.WriteLine();
			Console.WriteLine("go again? y/n");
			string input = Console.ReadLine();
			input = input.ToLower();
			
			if(input == "y")
				Main();
			
			
		
			
		
	
	
	}//main
	
}//program
