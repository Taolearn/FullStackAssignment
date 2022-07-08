// See https://aka.ms/new-console-template for more information

/*
1. What are the six combinations of access modifier keywords and what do they do?
public: Access is not restricted.
protected: Access is limited to the containing class or types derived from the containing class.
internal: Access is limited to the current assembly.
protected internal: Access is limited to the current assembly or types derived from the containing class.
private: Access is limited to the containing type.
private protected: Access is limited to the containing class or types derived from the containing class within the current assembly.

2.What is the difference between the static, const, and readonly keywords when applied to
a type member?
const: The const keyword converts nothing more but a constant. The specialty of these variables is that
they need to have a value at compile time and, by default, they are static.

readonly: The readonly keyword is a special modifier which bears significant resemblance to the const keyword.
It can be used on fields, but not on local variables.
These fields can either be initialized when declared or at the constructor of our object.

Constant and ReadOnly keyword is used to make a field constant which value cannot be modified.
The static keyword is used to make members static that can be shared by all the class objects.


3. What does a constructor do?
A constructor is a special method of a class or structure in object-oriented programming that initializes a newly created object of that type.
Whenever an object is created, the constructor is called automatically.

4. Why is the partial keyword useful?
The partial keyword indicates that other parts of the class, struct, or interface can be defined in the namespace.
All the parts must use the partial keyword. All the parts must be available at compile time to form the final type.
All the parts must have the same accessibility, such as public , private , and so on.
public partial class Employee
{
    public void DoWork()
    {
    }
}

public partial class Employee
{
    public void GoToLunch()
    {
    }
}

5. What is a tuple?
Tuples are used to store multiple items in a single variable.

Tuple is one of 4 built-in data types in Python used to store collections of data, the other 3 are List, Set, and Dictionary, all with different qualities and usage.

A tuple is a collection which is ordered and unchangeable.

Tuples are written with round brackets.

6. What does the C# record keyword do?
C# 9 introduces records, a new reference type that you can create instead of classes or structs.
C# 10 adds record structs so that you can define records as value types.
Records are distinct from classes in that record types use value-based equality.

The DailyTemperature record is a readonly record struct, because you don't intend to inherit from it, and it should be immutable. 

7. What does overloading and overriding mean?
Overloading occurs when two or more methods in one class have the same method name but different parameters.

Overriding occurs when two methods have the same method name and parameters. One of the methods is in the parent class, and the other is in the child class.
Overriding allows a child class to provide the specific implementation of a method that is already present in its parent class.​

8. What is the difference between a field and a property?
A field is a variable of any type that is declared directly in a class.
A property is a member that provides a flexible mechanism to read, write or compute the value of a private field.
A field can be used to explain the characteristics of an object or a class.

9. How do you make a method parameter optional?
a.)By using default value.
b.)By using Method Overloading: You can implement optional parameters concept by using method overloading.
In method overloading, we create methods with the same name but with the different parameter list.
c.)By using OptionalAttribute.
d.)By Params Keyword: You can implement optional parameters by using the params keyword.
It allows you to pass any variable number of parameters to a method. 

10. What is an interface and how is it different from abstract class?
The short answer: An abstract class allows you to create functionality that subclasses can implement or override.
An interface only allows you to define functionality, not implement it.
And whereas a class can extend only one abstract class, it can take advantage of multiple interfaces.

11. What accessibility level are members of an interface?
interface
public, protected, internal, private, protected internal, private protected

12. True/False. Polymorphism allows derived classes to provide different implementations
of the same method.
True.

13. True/False. The override keyword is used to indicate that a method in a derived class is
providing its own implementation of a method.
True.


14. True/False. The new keyword is used to indicate that a method in a derived class is
providing its own implementation of a method.
False.

15. True/False. Abstract methods can be used in a normal (non-abstract) class.
False.

16.True/False. Normal (non-abstract) methods can be used in an abstract class.
True.

17. True/False.Derived classes can override methods that were virtual in the base class.
True.

18. True/False.Derived classes can override methods that were abstract in the base class.
True.

19. True/False.In a derived class, you can override a method that was neither virtual non abstract in the
base class.
False.

20. True/False. A class that implements an interface does not have to provide an
implementation for all of the members of the interface.
False.

21. True/False. A class that implements an interface is allowed to have other members that
aren’t defined in the interface.
True.

22. True/False. A class can have more than one base class.
True.

23. True/False. A class can implement more than one interface.
True.
*/

//1. Reverse Numbers
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReversingAnArray
{
    class Program
    {
        /// <summary>
        /// The main method. Generates a list of numbers, reverses the
        /// order, and prints the reversed array.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] numbers = GenerateNumbers();
            Reverse(numbers);
            PrintNumbers(numbers);

            Console.ReadKey();
        }

        /// <summary>
        /// Generates an array of 10 numbers.
        /// </summary>
        /// <returns></returns>
        static int[] GenerateNumbers()
        {
            int[] numbers = new int[10];

            for (int index = 0; index < 10; index++)
            {
                // We add 1 here, because the index starts
                // at 0, but we want to start with 1, we add
                // 1 here.
                numbers[index] = index + 1;
            }

            return numbers;
        }

        /// <summary>
        /// Generates a list of numbers of any size required.
        /// </summary>
        /// <param name="amount">The amount to generate.</param>
        /// <returns></returns>
        static int[] GenerateNumbers(int amount)
        {
            int[] numbers = new int[amount];

            for (int index = 0; index < amount; index++)
            {
                numbers[index] = index + 1;
            }

            return numbers;
        }

        /// <summary>
        /// Prints any array of numbers in order.
        /// </summary>
        /// <param name="numbers"></param>
        static void PrintNumbers(int[] numbers)
        {
            for (int index = 0; index < numbers.Length; index++)
            {
                Console.Write(numbers[index] + " ");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Reverses the contents of an array that is passed in.
        /// </summary>
        /// <param name="numbers"></param>
        static void Reverse(int[] numbers)
        {
            // Initialize one index at the start of the array, and another
            // at the end of the array. The index of the last item in the
            // array is the length of the array - 1.
            int firstIndex = 0;
            int secondIndex = numbers.Length - 1;

            while (firstIndex < secondIndex)
            {
                // To swap two numbers, we need to copy one value out
                // to a safe place so that it doesn't get overwritten.
                int temp = numbers[firstIndex];
                numbers[firstIndex] = numbers[secondIndex];
                numbers[secondIndex] = temp;

                // Move on to the next pair.
                firstIndex++;
                secondIndex--;
            }
        }
    }
}

/*
namespace ReversingAnArray
{
    class mylearning
    {
        static void Main(string[] args)
        {
            int[] numbers = GenerateNumbers();
            Reverse(numbers);
            PrintNumbers(numbers);

            Console.ReadKey();
        }

        static int[] GenerateNumbers()
        {
            int[] numbers = new int[10];
            for (int index = 0; index < numbers.Length; index++)
            {
                numbers[index] = index + 1;
            }
            return numbers;

        }

        static void PrintNumbers(int[] numbers)
        {
            for (int index = 0; index < numbers.Length; index++)
            {
                Console.Write(numbers[index] + " ");
            }
            Console.WriteLine();
        }

        static void Reverse(int[] numbers)
        {
            int secondIndex = numbers.Length - 1;

            for (int firstIndex = 0; firstIndex < numbers.Length - 1; firstIndex++)
            {
                numbers[firstIndex] = numbers[secondIndex];
            }
        }
    }
}

 */

//2.Fibonacci Sequence
class Fibonacci
{
    static void Main(string[] args)
    {

    }
    static int GenerateNums(int n)
    {
        int[] nums = new int[n-1];
        nums[0] = 1;
        nums[1] = 1;
        for (int index = 2; index < n; index++)
        {
            nums[index] = nums[index - 1] + nums[index - 2];
        }
        return nums[n - 1];
    }
}



