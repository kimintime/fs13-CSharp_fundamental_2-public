using System.Text;

class Program
{
    static void Main(string[] args)
    {
        //Challenge 1
        int[][] arr1 = { new int[] { 1, 2 }, new int[] { 2, 1, 5 } };
        int[] arr1Common = CommonItems(arr1);

        /* write method to print arr1Common */
        foreach (var number in arr1Common)
        {
            Console.WriteLine(number);
        }

        //Challenge 2
        int[][] arr2 = { new int[] { 1, 2 }, new int[] { 1, 2, 3 } };
        InverseJagged(arr2);
        /* write method to print arr2 */

        //Challenge 3
        int[][] arr3 = { new int[] { 1, 2 }, new int[] { 1, 2, 3 } };
        CalculateDiff(arr3);
        /* write method to print arr3 */

        //Challenge 4
        int[,] arr4 = { { 1, 2, 3 }, { 4, 5, 6 } };
        int[,] arr4Inverse = InverseRec(arr4);

        /* write method to print arr4Inverse */
        for (int i = 0; i < arr4Inverse.GetLength(0); i++)
        {
            for (int j = 0; j < arr4Inverse.GetLength(1); j++)
            {

                Console.WriteLine(arr4Inverse[i, j] + " ");
            }

            Console.WriteLine(" ");
        }

        // //Challenge 5
        Demo("hello", 1, 2, "world");

        //Challenge 6
        object objectString1 = "That's one small step for a coder";
        object objectString2 = "And one giant leap for a frog";
        object objectNumber1 = 21;
        object objectNumber2 = 22;

        SwapTwo(ref objectString1, ref objectString2);
        SwapTwo(ref objectNumber1, ref objectNumber2);
        // SwapTwo(ref objectNumber1, ref objectString2);

        //Challenge 7
        string firstName, middleName, lastName;
        ParseNames("Mary Elizabeth Smith", out firstName, out middleName, out lastName);
        Console.WriteLine($"First name: {firstName}, middle name: {middleName}, last name: {lastName}");

        //Challenge 8
        GuessingGame();
    }

    /*
    Challenge 1. Given a jagged array of integers (two dimensions).
    Find the common elements in the nested arrays.
    Example: int[][] arr = { new int[] {1, 2}, new int[] {2, 1, 5}}
    Expected result: int[] {1,2} since 1 and 2 are both available in sub arrays.
    */
    static int[] CommonItems(int[][] jaggedArray)
    {
        List<int> commonNumbers = new List<int>();
        int[] array1 = jaggedArray[0];
        int[] array2 = jaggedArray[1];

        Console.WriteLine("The numbers in common are: ");

        for (int i = 0; i < array1.Length; i++)
        {
            for (int j = 0; j < array2.Length; j++)
            {
                if (array1[i] == array2[j])
                {
                    commonNumbers.Add(array1[i]);
                    break;
                }
            }
        }
        return commonNumbers.ToArray();
    }

    /* 
    Challenge 2. Inverse the elements of a jagged array.
    For example, int[][] arr = {new int[] {1,2}, new int[]{1,2,3}} 
    Expected result: int[][] arr = {new int[]{2, 1}, new int[]{3, 2, 1}}
     */
    static void InverseJagged(int[][] jaggedArray)
    {
        Console.WriteLine("The numbers in reverse are");

        foreach (int[] array in jaggedArray)
        {
            int[] result = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                result[array.Length - 1 - i] = array[i];
            }

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = result[i];
                Console.WriteLine(array[i]);
            }
        }
    }

    /* 
    Challenge 3.Find the difference between 2 consecutive elements of an array.
    For example, int[][] arr = {new int[] {1,2}, new int[]{1,2,3}} 
    Expected result: int[][] arr = {new int[] {-1}, new int[]{-1, -1}}
     */
    static void CalculateDiff(int[][] jaggedArray)
    {
        Console.WriteLine("The difference between the numbers are: ");

        for (int i = 0; i < jaggedArray.Length; i++)
        {
            int[] difference = new int[jaggedArray[i].Length - 1];

            for (int j = 0; j < jaggedArray[i].Length - 1; j++)
            {
                difference[j] = jaggedArray[i][j] - jaggedArray[i][j + 1];
            }
            jaggedArray[i] = difference;
        }

        for (int i = 0; i < jaggedArray.Length; i++)
        {
            for (int j = 0; j < jaggedArray[i].Length; j++)
            {
                Console.Write(jaggedArray[i][j] + " ");
            }
            Console.WriteLine(" ");
        }
    }

    /* 
    Challenge 4. Inverse column/row of a rectangular array.
    For example, given: int[,] arr = {{1,2,3}, {4,5,6}}
    Expected result: {{1,2},{3,4},{5,6}}
     */
    static int[,] InverseRec(int[,] recArray)
    {
        int row = recArray.GetLength(0);
        int col = recArray.GetLength(1);
        int[,] result = new int[col, row];

        int x = 0;
        int y = 0;

        Console.WriteLine("Two rows and three colums to three rows and two colums: ");

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                result[x, y] = recArray[i, j];

                if (y == row - 1)
                {
                    y = 0;
                    x += 1;
                }
                else
                {
                    y += 1;
                }
            }
        }

        return result;
    }

    /* 
    Challenge 5. Write a function that accepts a variable number of params of any of these types: 
    string, number. 
    - For strings, join them in a sentence. 
    - For numbers then sum them up. 
    - Finally print everything out. 
    Example: Demo("hello", 1, 2, "world") 
    Expected result: hello world; 3 */
    static void Demo(params Object[] args)
    {
        StringBuilder builder = new StringBuilder();
        int sum = 0;

        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] is string)
            {
                if (builder.Length != 0)
                {
                    builder.Append(' ');
                }
                builder.Append(args[i]);

            }
            else if (args[i] is int)
            {
                sum = sum + (int)args[i];
            }
        }

        builder.Append($"; {sum}");
        Console.WriteLine(builder);
    }



    /* Challenge 6. Write a function to swap 2 objects but only if they are of the same type 
    and if they’re string, lengths have to be more than 5. 
    If they’re numbers, they have to be more than 18. */
    static void SwapTwo(ref object obj1, ref object obj2)
    {
        Console.WriteLine($"The first order is: {obj1}, {obj2} ");

        if (obj1.GetType().ToString() != obj2.GetType().ToString())
        {
            throw new ArgumentException("These two objects are not the same type.");
        }
        else if (obj1.GetType().ToString() == "System.String")
        {
            string string1 = (string)obj1;
            string string2 = (string)obj2;

            if (string1.Length > 5 && string2.Length > 5)
            {
                obj1 = string2;
                obj2 = string1;
            }
        }
        else if (obj1.GetType().ToString() == "System.Int32")
        {
            int number1 = (int)obj1;
            int number2 = (int)obj2;

            if (number1 > 18 && number2 > 18)
            {
                obj1 = number2;
                obj2 = number1;
            }
        }

        Console.WriteLine($"The new order is: {obj1}, {obj2}");
    }

    /* Challenge 7. Write a function to parse the first name, middle name, last name given a string. 
    The names will be returned by using out modifier */
    static void ParseNames(
        string input,
        out string firstName,
        out string middleName,
        out string lastName)
    {
        string[] name = input.Split(' ');

        if (name.Length < 3)
        {
            throw new ArgumentException("Name must be first, middle, and last");
        }

        firstName = name[0];
        middleName = name[1];
        lastName = name[2];
    }

    /* Challenge 8. Write a function that does the guessing game. 
    The function will think of a random integer number (lets say within 100) 
    and ask the user to input a guess. 
    It’ll repeat the asking until the user puts the correct answer. */
    static void GuessingGame()
    {
        bool gameOn = true;

        Random randomNumber = new Random();
        int number = randomNumber.Next(0, 100);

        while (gameOn)
        {
            Console.WriteLine("Enter a number between 0 and 100. Type 'q' to quit.");

            var userChose = Console.ReadLine();

            if (userChose == "q")
            {
                gameOn = false;
            }

            int.TryParse(Console.ReadLine(), out var userInput);

            if (userInput < 0 || userInput > 100)
            {
                Console.WriteLine("Try again.");
            }

            else if (userInput == number)
            {
               Console.WriteLine($"The computer chose: {number}");
               Console.WriteLine("You won!");
               gameOn = false;
            }
            else {
                Console.WriteLine($"The computer chose: {number}");
                Console.WriteLine("You lost. Try again...");
            }
        }

    }
}
