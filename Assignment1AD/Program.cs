using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Reflection;

namespace Assignment1AD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region  
            //Create a generic Range<T> class that represents a range of values from a minimum value to a maximum value The range should support basic operations such as checking if a value is within the range and determining the length of the rangeRequirements:Create a generic class named Range<T> where T represents the type of values.Implement a constructor that takes the minimum and maximum values to define the range.Implement a method IsInRange(T value) that returns true if the given  value is within the range, otherwise false.Implement a method Length() that returns the length of the range (the difference between the maximum and minimum values).Note: You can assume that the type T used in the Range<T> class implements the IComparable<T> interface to allow for comparisons

            public class Range<T> where T : IComparable<T>
        {
            public T _Min { get; set; }
            public T _Max { get; set; }
            public Range(T min, T max)
            {
                _Min = min;
                _Max = max;
            }

            public bool IsInRange(T value)
            {
                return value.CompareTo(_Min) >= 0 && value.CompareTo(_Max) <= 0;
            }
            public T Length()
            {
                dynamic min = _Min;
                dynamic max = _Max;
                return max - min;
            }
            #endregion

            #region
            // you are given an ArrayList containing a sequence of elements. try to reverse the order of elements in the ArrayList in-place(in the same arrayList) without using the built-in Reverse.Implement a function that takes the ArrayList as input and modifies it to hav

            public class ReverseArrayList
            {
                public static void Reverse(ArrayList list)
                {
                    if (list == null || list.Count <= 1)
                    {
                        return; // No need to reverse for empty or single-element lists
                    }

                    int left = 0;
                    int right = list.Count - 1;

                    while (left < right)
                    {
                        // Swap elements at left and right indices
                        object temp = list[left];
                        list[left] = list[right];
                        list[right] = temp;

                        left++;
                        right--;
                    }
                }

                public static void Main(string[] args)
                {
                    // Create an ArrayList
                    ArrayList myList = new ArrayList() { 1, 2, 3, 4, 5 };

                    // Print the original list
                    Console.WriteLine("Original List:");
                    foreach (var item in myList)
                    {
                        Console.Write(item + " ");
                    }
                    Console.WriteLine();

                    // Reverse the list
                    Reverse(myList);

                    // Print the reversed list
                    Console.WriteLine("Reversed List:");
                    foreach (var item in myList)
                    {
                        Console.Write(item + " ");
                    }
                    Console.WriteLine();
                }
            }
            #endregion

            #region
            //you are given a list of integers.Your task is to find and return a new list containing only the even numbers from the given list

            public class EvenNumbers
            {
                public static List<int> FindEvenNumbers(List<int> numbers)
                {
                    // Method 1: Using LINQ
                    // return numbers.Where(x => x % 2 == 0).ToList();

                    // Method 2: Using a loop
                    List<int> evenNumbers = new List<int>();
                    foreach (int number in numbers)
                    {
                        if (number % 2 == 0)
                        {
                            evenNumbers.Add(number);
                        }
                    }
                    return evenNumbers;
                }

                public static void Main(string[] args)
                {
                    List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                    List<int> evenNumbers = FindEvenNumbers(numbers);

                    Console.WriteLine("Even numbers:");
                    foreach (int number in evenNumbers)
                    {
                        Console.Write(number + " ");
                    }
                    Console.WriteLine();
                }
                #endregion

                #region 
                //implement a custom list called FixedSizeList<T> with a predetermined capacity. This list should not allow more elements than its capacity and should provide clear messages if one tries to exceed it or access invalid indices Requirements:Create a generic class named FixedSizeList<T>.Implement a constructor that takes the fixed capacity of the list as aparameter.Implement an Add method that adds an element to the list, but throws an exception if the list is already full.Implement a Get method that retrieves an element at a specific index in the list but throws an exception for invalid indices

                public class FixedSizeList<T>
                {
                    private T[] _items;
                    private int _count;

                    public FixedSizeList(int capacity)
                    {
                        if (capacity <= 0)
                        {
                            throw new ArgumentException("Capacity must be greater than zero.", nameof(capacity));
                        }
                        _items = new T[capacity];
                        _count = 0;
                    }

                    public void Add(T item)
                    {
                        if (_count == _items.Length)
                        {
                            throw new InvalidOperationException("List is full.");
                        }

                        _items[_count] = item;
                        _count++;
                    }

                    public T Get(int index)
                    {
                        if (index < 0 || index >= _count)
                        {
                            throw new IndexOutOfRangeException("Index is out of range.");
                        }

                        return _items[index];
                    }
                }

                public class Example
                {
                    public static void Main(string[] args)
                    {
                        FixedSizeList<int> list = new FixedSizeList<int>(3);

                        try
                        {
                            list.Add(1);
                            list.Add(2);
                            list.Add(3);
                            list.Add(4); // This will throw an exception
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        try
                        {
                            Console.WriteLine(list.Get(0)); // Output: 1
                            Console.WriteLine(list.Get(2)); // Output: 3
                            Console.WriteLine(list.Get(3)); // This will throw an exception
                        }
                        catch (IndexOutOfRangeException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        Console.ReadLine();
                    }
                }
                #endregion
                #region
                // Given a string, find the first non-repeated character in it and return its index.If there is no such character, return 

                public class FirstUniqueCharacter
                {
                    public static int FirstUniqChar(string s)
                    {
                        if (string.IsNullOrEmpty(s))
                        {
                            return -1; // Empty string or null
                        }

                        Dictionary<char, int> charCounts = new Dictionary<char, int>();

                        // Count the occurrences of each character
                        foreach (char c in s)
                        {
                            if (charCounts.ContainsKey(c))
                            {
                                charCounts[c]++;
                            }
                            else
                            {
                                charCounts[c] = 1;
                            }
                        }

                        // Find the first character with count 1
                        for (int i = 0; i < s.Length; i++)
                        {
                            if (charCounts[s[i]] == 1)
                            {
                                return i;
                            }
                        }

                        return -1; // No unique character found
                    }

                    public static void Main(string[] args)
                    {
                        string s1 = "leetcode";
                        string s2 = "loveleetcode";
                        string s3 = "aabb";

                        Console.WriteLine($"First unique character in '{s1}': {FirstUniqChar(s1)}"); // Output: 0
                        Console.WriteLine($"First unique character in '{s2}': {FirstUniqChar(s2)}"); // Output: 2
                        Console.WriteLine($"First unique character in '{s3}': {FirstUniqChar(s3)}"); // Output: -1
                    }
                    #endregion
                }
            }
