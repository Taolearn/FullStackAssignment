// See https://aka.ms/new-console-template for more information
using System;

/*1. What type would you choose for the following “numbers”?
A person’s telephone number --string
A person’s height --double/decimal
A person’s age --int
A person’s gender (Male, Female, Prefer Not To Answer) --string
A person’s salary --decimal/double
A book’s ISBN --long
A book’s price --double/decimal
A book’s shipping weight --double/decimal
A country’s population --uint
The number of stars in the universe --ulong
The number of employees in each of the small or medium businesses in the
United Kingdom (up to about 50,000 employees per business) --ushort
*/


/*2.What are the difference between value type and reference type variables? What is
boxing and unboxing?
The C# Type System contains three data types: Value Types (int, char, etc), Reference Types (object) and Pointer Types.
Basically, Boxing converts a Value Type variable into a Reference Type variable, and Unboxing achieves the vice-versa.
Boxing and Unboxing enable a unified view of the type system in which a value of any type can be treated as an object.

int num = 23; // 23 will assigned to num
Object Obj = num; // Boxing

int num = 23;         // value type is int and assigned value 23
Object Obj = num;    // Boxing
int i = (int)Obj;    // Unboxing
*/


/*3.What is meant by the terms managed resource and unmanaged resource in .NET
Managed resources are those that are pure .NET code and managed by the runtime and are under its direct control.

Unmanaged resources are those that are not. File handles, pinned memory, COM objects, database connections etc. 
*/


/*4.Whats the purpose of Garbage Collector in .NET?
 .NET's garbage collector manages the allocation and release of memory for your application.
Each time you create a new object, the common language runtime allocates memory for the object from the managed heap.
As long as address space is available in the managed heap, the runtime continues to allocate space for new objects.
However, memory is not infinite. Eventually the garbage collector must perform a collection in order to free some memory. 
*/


//Practice number sizes and ranges
/*1.Create a console application project named /02UnderstandingTypes/ that outputs the number of bytes in memory
that each of the following number types uses, and the minimum and maximum values they can have:
/sbyte, byte, short, ushort, int, uint, long, ulong, float, double, and decimal.*/

namespace Package1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("| Type \t|\tBytes of Memory \t|\t Min \t\t\t\t\t|\tMax \t\t\t\t\t|");
            Console.WriteLine($"| sbyte\t|\t {sizeof(sbyte)}\t\t\t|\t {sbyte.MinValue}\t\t\t\t\t|\t{sbyte.MaxValue} \t\t\t\t\t|");
            Console.WriteLine($"| byte \t|\t {sizeof(byte)} \t\t\t|\t {byte.MinValue} \t\t\t\t\t|\t {byte.MaxValue} \t\t\t\t\t|");
            Console.WriteLine($"| short\t|\t {sizeof(short)}\t\t\t|\t{short.MinValue}  \t\t\t\t|\t {short.MaxValue} \t\t\t\t\t|");
            Console.WriteLine($"| ushort|\t {sizeof(ushort)} \t\t\t|\t {ushort.MinValue} \t\t\t\t\t|\t {ushort.MaxValue} \t\t\t\t\t|");
            Console.WriteLine($"| int \t|\t {sizeof(int)} \t\t\t|\t {int.MinValue} \t\t\t\t|\t {int.MaxValue} \t\t\t\t|");
            Console.WriteLine($"| uint \t|\t {sizeof(uint)} \t\t\t|\t {uint.MinValue} \t\t\t\t\t|\t {uint.MaxValue} \t\t\t\t|");
            Console.WriteLine($"| long \t|\t {sizeof(long)} \t\t\t|\t {long.MinValue} \t\t\t|\t {long.MaxValue} \t\t\t|");
            Console.WriteLine($"| ulong\t|\t {sizeof(ulong)} \t\t\t|\t {ulong.MinValue} \t\t\t\t\t|\t {ulong.MaxValue} \t\t\t|");
            Console.WriteLine($"| float\t|\t {sizeof(float)} \t\t\t|\t {float.MinValue} \t\t\t|\t {float.MaxValue} \t\t\t\t|");
            Console.WriteLine($"| double|\t {sizeof(double)} \t\t\t|\t {double.MinValue} \t\t|\t{double.MaxValue} \t\t|");
            Console.WriteLine($"| decimal|\t {sizeof(decimal)} \t\t\t|\t {decimal.MinValue} \t|\t{decimal.MaxValue} \t\t|");
            Console.WriteLine();
        }
    }
}

/*2/Write program to enter an integer number of centuries and convert it to years, days, hours,
minutes, seconds, milliseconds, microseconds, nanoseconds. Use an appropriate data
type for every data conversion. Beware of overflows!
Input: 1
Output: 1 centuries = 100 years = 36524 days = 876576 hours = 52594560 minutes
= 3155673600 seconds = 3155673600000 milliseconds = 3155673600000000
microseconds = 3155673600000000000 nanoseconds
Input: 5
Output: 5 centuries = 500 years = 182621 days = 4382904 hours = 262974240
minutes = 15778454400 seconds = 15778454400000 milliseconds = 15778454400000000
microseconds = 15778454400000000000 nanoseconds*/
namespace Package2
{
    public class Program
    {
        public static void Converter(int num)
        {
            Console.WriteLine("Enter an interger number: ");
            num = Convert.ToInt32(Console.ReadLine());
            int years = num * 100;
            int days = num * 36524;
            int hours = num * 876576;
            int minutes = num * 52594560;
            long seconds = num * 3155673600;
            long milliseconds = num * 3155673600000;
            long microseconds = num * 3155673600000000;
            long nanoseconds = num * 3155673600000000000;
            Console.WriteLine($"years ={years}");
            Console.WriteLine();
        }
    }
}






/*
1. What happens when you divide an int variable by 0?
--Floating point division is govered by IEEE754, which specifies that divide by zero should be infinity.

2. What happens when you divide a double variable by 0?
--Floating point division is govered by IEEE754, which specifies that divide by zero should be infinity.

3. What happens when you overflow an int variable, that is, set it to a value beyond its
range?
--The program can not be excuted.

4. What is the difference between x = y++; and x = ++y;?
--both ++x and x++ are used to increment variable x by 1.. the prime difference is that,

++x i.e. pre-increment operator uses the principle ‘change-then-use’ while, x++ i.e. post-increment operator uses the principle ‘use-then-change’.

for example, the following code;

int a=10,b=15; 
int product = a * b++; 
cout<<product; 
This will produce an output 150. Obviously, b is first used then changed.

int a=10,b=15; 
int product = a * ++b; 
cout<<product; 
This will produce an output 160. Here b is first changed then it is used to evaluate the expression.

5. What is the difference between break, continue, and return when used inside a loop
statement?
--break statement: This statement terminates the smallest enclosing loop (i.e., while, do-while, for loop, or switch statement).
continue statement: This statement skips the rest of the loop statement and starts the next iteration of the loop to take place.
return: This will return a value and terminate whole class.

6. What are the three parts of a for statement and which of them are required?
--For x = Start to End
...Statements to be performed go here
EndFor
In all variants of C a for is comprised of three parts: initialization, condition and update.

7.What is the difference between the = and == operators?
-- = is for assigning value. == means euqal.

8. Does the following statement compile? for ( ; true; ) ;
--create a for that will check if true is true creating an infinite loop.

9. What does the underscore _ represent in a switch expression?
--The underscore (_) character replaces the default keyword to signify that it should match anything if reached. 

10. What interface must an object implement to be enumerated over by using the foreach
statement
--The IEnumerable interface permits enumeration by using a foreach loop.
*/

//Practice loops and operators
//1.FizzBuzz.
using System;
namespace fizzbuzz
{
    public class fizzbuzzcode_chegg
    {
        static void Main(string[] args)
        {
            for (int k = 1; k <= 100; k++)
            {
                if (k % 3 == 0 && k % 5 == 0)
                {
                    Console.Write("FizzBuzz, ");
                }
                else if (k % 3 == 0)
                {
                    Console.Write("Fizz, ");
                }
                else if (k % 5 == 0)
                {
                    Console.Write("Buzz, ");
                }
                else
                {
                    Console.Write(k + ", ");
                }
            }
        }
    }
}

//2.Print-a-Pyramid.
using System;  
public class Pyramid
{
    public static void Main()
    {
        int i, j, n;

        Console.Write("\n\n");
        Console.Write("Display the pattern like pyramid containing odd number of asterisks:\n");
        Console.Write("----------------------------------------------------------------------");
        Console.Write("\n\n");

        Console.Write("Input number of rows for this pattern :");
        n = Convert.ToInt32(Console.ReadLine());
        for (i = 0; i < n; i++)
        {
            for (j = 1; j <= n - i; j++)
                Console.Write(" ");
            for (j = 1; j <= 2 * i - 1; j++)
                Console.Write("*");
            Console.Write("\n");
        }
    }
}


//3.Guess Number
using System;
public class GuessNumber
{
    static void Main(string[] args)
    {
        Random rnd = new Random();
        int value = rnd.Next(1, 11);
        string str;
        int Number = 0;
        int attempt = 0;
        Console.WriteLine("Please guess a random number");
        while (Number != value && attempt < 3)
        {
            attempt++;
            str = Console.ReadLine();
            if (int.TryParse(str, out Number))
                if (Number >= 1 && Number <= 10)
                    if (Number == value)
                        Console.WriteLine("Congratulations – your guess is correct!");
                    else if (Number < value)
                        Console.WriteLine("Sorry – your guess was too low!");
                    else if (Number > value)
                        Console.WriteLine("Sorry – your guess was too high!");
        }
        if (attempt == 3 && Number != value)
            Console.WriteLine("The random number was " + value);
        else
            Console.WriteLine("You guessed the number on attempt number " + attempt);


    }
}

//4.Age Calcualte

//5.Greeting
using System;

namespace Greeting
{
    public class Program
    {

        public static void Main()
        {


            DateTime currentDateTime = DateTime.Now;
            //DateTime currentDateTime = new DateTime(2017, 9, 3, 8, 4, 0); //Test data
            int currentHour = currentDateTime.Hour;
            int startMorningHour = 6;
            int startAfternoonHour = 12;
            int startEveningHour = 17;
            int startNightHour = 22;

            if (startMorningHour <= currentHour && currentHour < startAfternoonHour)
            {
                Console.WriteLine("Good morning!");
            }

            ;
            if (startAfternoonHour <= currentHour && currentHour < startEveningHour)
            {
                Console.WriteLine("Good Afternoon!");
            }

            ;
            if (startEveningHour <= currentHour && currentHour < startNightHour)
            {
                Console.WriteLine("Good Evening!");
            }

            ;
            if (startNightHour <= currentHour || currentHour < startMorningHour)
            {
                Console.WriteLine("Good Night!");
            }

            ;

            Console.WriteLine("Right now it is {0}:{1} o'clock.", currentDateTime.Hour, currentDateTime.Minute);
        }
    }
}

//6.Count up to 24
using System;

public class Program
{
    public static void Main()
    {

        CountTo24();
    }

    private static void CountTo24()
    {
        for (int countBase = 1; countBase <= 24; countBase += 1)
        {
            Console.Write(countBase.ToString().PadLeft(4) + "|");
            for (int countUp = 0; countUp <= 24; countUp += countBase)
            {
                Console.Write(countUp.ToString().PadLeft(4));
            }

            Console.WriteLine();
        }
    }
}













//PDFFA3846254A30E341

