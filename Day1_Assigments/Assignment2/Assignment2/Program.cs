using Assignment2;

// Solution for Practice Array

//Question 1
int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
CopyingArray cp = new CopyingArray(arr);

// Question 2
ToDoList td = new ToDoList();

// Question 3
FindPrime fp = new FindPrime();

//Question 4
Console.WriteLine("Enter the array of integers (space separated):");
int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
Console.WriteLine("Enter the number of rotations:");
int k = int.Parse(Console.ReadLine());
RotatedArray r = new RotatedArray(array,k);

//Question 5
int[] arr1 = {2,1,1,2,3,3,2,2,2,1,2,2,2};
LongestEqual le=new LongestEqual(arr1);

//Question 7
int[] arr2 = {1,5,5,5,2,3,4,4,5 };
MostFrequestNumber mfn = new MostFrequestNumber(arr2);

// Solution for Practice String

//Question 1
Console.WriteLine("Enter String: ");
string str = Console.ReadLine();
StringReversal strRev = new StringReversal(str);

//Question 2
Console.WriteLine("Enter String: ");
string str1 = Console.ReadLine();
ReverseWord rword = new ReverseWord(str1);

//Question 3
Console.WriteLine("Enter text:");
string text = Console.ReadLine();
AllPalindrome extPal = new AllPalindrome(text);

//Question 4
Console.WriteLine("Enter URL:");
string url = Console.ReadLine();
UrlParser urlParser=new UrlParser(url);