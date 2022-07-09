/*
1. Describe the problem generics address.
Generics allow you to define type-safe data structures, without committing to actual data types.
This results in a significant performance boost and higher quality code, because you get to reuse data processing algorithms without duplicating type-specific code.

2. How would you create a list of strings, using the generic List class?
public list<> ge_list<T>: where T: List
{
}
List<T> ge_list = new List<T>();

3. How many generic type parameters does the Dictionary class have?
Generic. Dictionary<TKey,TValue> generic type has two type parameters, TKey and TValue ,
that represent the types of its keys and values.

4. True/False. When a generic class has multiple type parameters, they must all match.
False.

5. What method is used to add items to a List object?
C# List<T> class represents a collection of a type in C#.
List.Add(), List.AddRange(), List.Insert(), and List.InsertRange() methods are used to add and insert items to a List<T>.

6. Name two methods that cause items to be removed from a List.
remove()
pop()
del()

7. How do you indicate that a class has a generic type parameter?
A generic type is declared by specifying a type parameter in an angle brackets after a type name,
e.g. TypeName<T> where T is a type parameter.

8. True/False. Generic classes can only have one generic type parameter.
False.

9. True/False. Generic type constraints limit what can be used for the generic type.
True. Declaring those constraints means you can use the operations and method calls of the constraining type.

10. True/False. Constraints let you use the methods of the thing you are constraining to.
True.
*/



namespace day3
{
class program
{
public static void Main(string[] args)
{

}
}
}

/*1Create a custom Stack class MyStack<T> that can be used with any data type which
has following methods
1. int Count()
2.T Pop()
3.Void Push()*/
using System;
using System.Collections.Generic;

class Example
{
    public static void Main()
    {
        Stack<string> numbers = new Stack<string>();
        numbers.Push("one");
        numbers.Push("two");
        numbers.Push("three");
        numbers.Push("four");
        numbers.Push("five");

        // A stack can be enumerated without disturbing its contents.
        foreach( string number in numbers )
        {
            Console.WriteLine(number);
        }

        Console.WriteLine("\nPopping '{0}'", numbers.Pop());
        Console.WriteLine("Peek at next item to destack: {0}",
            numbers.Peek());
        Console.WriteLine("Popping '{0}'", numbers.Pop());

        // Create a copy of the stack, using the ToArray method and the
        // constructor that accepts an IEnumerable<T>.
        Stack<string> stack2 = new Stack<string>(numbers.ToArray());

        Console.WriteLine("\nContents of the first copy:");
        foreach( string number in stack2 )
        {
            Console.WriteLine(number);
        }

        // Create an array twice the size of the stack and copy the
        // elements of the stack, starting at the middle of the
        // array.
        string[] array2 = new string[numbers.Count * 2];
        numbers.CopyTo(array2, numbers.Count);

        // Create a second stack, using the constructor that accepts an
        // IEnumerable(Of T).
        Stack<string> stack3 = new Stack<string>(array2);

        Console.WriteLine("\nContents of the second copy, with duplicates and nulls:");
        foreach( string number in stack3 )
        {
            Console.WriteLine(number);
        }

        Console.WriteLine("\nstack2.Contains(\"four\") = {0}",
            stack2.Contains("four"));

        Console.WriteLine("\nstack2.Clear()");
        stack2.Clear();
        Console.WriteLine("\nstack2.Count = {0}", stack2.Count);
    }
}

/* This code example produces the following output:

five
four
three
two
one

Popping 'five'
Peek at next item to destack: four
Popping 'four'

Contents of the first copy:
one
two
three

Contents of the second copy, with duplicates and nulls:
one
two
three




stack2.Contains("four") = False

stack2.Clear()

stack2.Count = 0
 */