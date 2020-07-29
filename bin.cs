using System;


class program
{
	
	public static int IntArrayBinarySearch(double[] array, double key) 
	{
        int counter = 0;
		int min = 0;
        int N=key.Length;
        int max= N-1;
        do {
           int mid = (min+max) / 2;
           if (item > array[mid])
				min = mid + 1;
           
		   else
               max = mid - 1;
           
		   if (array[mid] == key)
               return mid;
            
			counter++;
			Console.WriteLine("counter value:{0}",counter);
         } while(min <= max);
         return -1;
    }
	
	
	
	
	
	
	public static void Main()
	{
		double[] array = {1,2,3,4,5,6,7,8,9,10};
		
		
		foreach(double s in array)
			Console.Write(s + " ");
			
		Console.WriteLine();
		
		
		
		Console.WriteLine("please enter a value for the binary search:");
		double input = Convert.ToDouble(Console.ReadLine());
		
		
		
		int result = IntArrayBinarySearch(array,input);
		if(result >= 0)
			Console.WriteLine("index value of the search:{0}",result);
		else
			Console.WriteLine("value was not found");
		
	}
	
	
	
	
	
	
}