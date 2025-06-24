using System.ComponentModel;
using System.Net.Sockets;

public class Program
{
    public static void Main()
    {
        int[] numbers = new int[] { 13, 10, 5, 2, 9 };

        Console.WriteLine(numbers
            .OrderBy(i => i)
            .Skip(1)
            .Zip(numbers.OrderBy(i => i), (a, b) => Math.Abs(b - a))
            .Max());
    }
}

#region Teste - estudos

/*
var dict = new Dictionary<string, int>();
dict.Add("um", 1);
dict["dois"] = 2;
Console.WriteLine(dict["um"]);
Console.WriteLine(dict.ContainsKey("tres"));
dict.Remove("dois");
Console.WriteLine($"Itens no dicionário: {dict.Count}");

var set = new HashSet<int>();
Console.WriteLine(set.Add(10));
Console.WriteLine(set.Add(10));
set.Add(20);
set.Add(30);
Console.WriteLine(set.Contains(20));
Console.WriteLine($"Contém 40? {set.Contains(40)}");
set.Remove(30);
Console.WriteLine($"Itens no conjunto: {set.Count}");

var cidades = new Dictionary<string, string>
{
    ["SP"] = "São Paulo",
    ["RJ"] = "Rio de Janeiro",
    ["MG"] = "Minas Gerais"
};
var resultado = cidades
    .Where(kvp => kvp.Key.Contains("S"))
    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
foreach (var kvp in resultado)
    Console.WriteLine($"Chave: {kvp.Key}, Valor: {kvp.Value}");

int[] numbers = { 1, 2, 3, 4 };
string[] words = { "one", "two", "three" };

var numbersAndWords = numbers.Zip(words, (first, second) => first + " " + second);
foreach (var item in numbersAndWords)
    Console.WriteLine(item);
*/

#endregion

#region Exercicio 1#

public class Kata1
{
    public static object[] IsVow(object[] a)
    {
        return ObjectConvertASCII(a);
    }

    public static object[] ObjectConvertASCII(object[] a)
    {
        object[] newArray = new object[a.Count()];

        for (int i = 0; i < a.Length; i++)
        {
            switch ((int)a[i])
            {
                case 97:
                    newArray[i] = "a";
                    break;
                case 101:
                    newArray[i] = "e";
                    break;
                case 105:
                    newArray[i] = "i";
                    break;
                case 111:
                    newArray[i] = "o";
                    break;
                case 117:
                    newArray[i] = "u";
                    break;
                default:
                    newArray[i] = a[i];
                    break;
            }
        }

        return newArray;
    }
}

#endregion

#region Exercicio 2#

public class Kata2
{
    public static int[] ProductValuesOrder(int[] array)
    {
        int[] productArray = new int[array.Length];

        for (int i = 0; i < array.Count(); i++)
        {
            var tempArray = array.Where(y => y != array[i]).ToArray();

            int product = 0;

            for (int j = 0; j < tempArray.Count(); j++)
            {
                if (product != 0)
                    product = product * tempArray[j];
                else
                    product = tempArray[j] * tempArray[j + 1];

                productArray[i] = product;
                break;
            }
        }

        return productArray;
    }
}

#endregion

#region Exercicio 3#

public static class Kata3
{
    public static string getIssuer(long number)
    {
        string stringNumber = number.ToString().Trim();
        int countCaracter = stringNumber.Length;

        if (countCaracter.Equals(15) && (stringNumber.StartsWith("34") || stringNumber.StartsWith("37")))
            return "AMEX";
        else if (countCaracter.Equals(16) && stringNumber.StartsWith("6011"))
            return "Discover";
        else if (countCaracter.Equals(16) &&
            (stringNumber.StartsWith("51") || stringNumber.StartsWith("52") ||
             stringNumber.StartsWith("53") || stringNumber.StartsWith("54") ||
             stringNumber.StartsWith("55")))
            return "MasterCard";
        else if ((countCaracter.Equals(13) || countCaracter.Equals(16)) && stringNumber.StartsWith("4"))
            return "VISA";
        else
            return "Unknown";
    }
}

#endregion

#region Exercicio 4#

public class Kata4
{
    public static int AdjacentElementsProduct(int[] array)
    {
        if (array.Length == 2) return 0;

        int[] resultArray = new int[array.Length - 1];

        for (int i = 0; i < resultArray.Length; i++)
        {
            resultArray[i] = array[i] * array[i + 1];
        }

        return resultArray.Max();
    }
}

#endregion

#region Exercicio 5#

public static class Kata5
{
    public static string ReturnEvenOrOdd(int number)
    {
        return number % 2 == 0 ? "Even" : "Odd";
    }
}

#endregion

#region Exercicio 6#

public static class Kata6
{
    public static int MaxProduct(int[] arr, int size)
    {
        var ordenado = arr.OrderByDescending(x => x).ToArray();
        int produto = 1;

        for (int i = 0; i < size; i++)
        {
            produto *= ordenado[i];
        }

        return produto;
    }
}

#endregion

#region Exercicio 7#

public static class Kata7
{
    public static int[] ArrayLeaders(int[] numbers)
    {
        var sum = numbers.Sum();
        List<int> resultado = new List<int>();

        foreach (var num in numbers)
        {
            if (num > (sum -= num))
                resultado.Add(num);
        }

        return resultado.ToArray();
    }
}

#endregion

#region Exercicio 8#

public static class Kata8
{
    public static int MaxGap(int[] numbers)
    {
        int maiorValor = 0;
        numbers = numbers.OrderByDescending(x => x).ToArray();

        for (int i = 0; i < numbers.Length - 1; i++)
        {
            int diferenca = numbers[i] - numbers[i + 1];

            if (diferenca < 0)
                diferenca *= -1;

            if (diferenca > maiorValor)
                maiorValor = diferenca;
        }

        return maiorValor;
    }
}

#endregion
