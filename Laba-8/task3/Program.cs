using System;
using System.Linq;
using System.Reflection;

class Programm
{
    public static void Main()
    {
        var array = new string[] { "code", "doce", "ecod", "framer", "frame" };       

        string[] arraycopy;
        arraycopy = new string[array.Length];

        

        for (int i = 0; i < arraycopy.Length; i++) 
        {
            arraycopy[i] = array[i].Sort();            
        }
        
        while (true)
        {
            string[] result;
            result = new string[array.Length];
            for (int i = 1; i < arraycopy.Length - 1; i++) 
            {
                if (arraycopy[i] == arraycopy[i - 1])
                {
                    arraycopy = Delete(arraycopy, i);
                    array = Delete(array, i);
                    i-=1;
                }
            }
            Array.Sort(array, (x, y) => String.Compare(x, y));
            foreach (var e in array)
                Console.WriteLine(e);
            break;
        }
    }
    
    static string[] Delete(string[] array, int index)
    {
        int c = 0;
        string[] newArray = new string[array.Length - 1];
        for (int i = 0; i < array.Length; i++)
        {
            if (i != index)
            {
                newArray[c] = array[i];
                c++;
            }
        }        

        return newArray;
    }


}
public static class StringExtensions
{
    public static String Sort(this String input)
    {
        char[] chars = input.ToCharArray();
        Array.Sort(chars);
        return new String(chars);
    }
}
