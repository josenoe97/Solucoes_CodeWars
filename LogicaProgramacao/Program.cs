using System.ComponentModel;
using System.Net.Sockets;

public class Program
{
    public static void Main()
    {
        Kata9.MinimumNumber(new int[]{2, 12, 8, 4, 6});
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

#region Exercicio 9#

public static class Kata9
{
    public static int MinimumNumber(int[] numbers)
    {
        return Enumerable.Range(0, int.MaxValue)
                         .First(x =>
                         {
                             var sum = numbers.Sum() + x;
                             return sum > 1 &&
                                    Enumerable.Range(2, (int)Math.Sqrt(sum) - 1)// seleção do 2 até soma - 1
                                              .All(i => sum % i != 0);// verificar se sum não é divisível por nenhum número de 2 até // OBS: o "i" ele incrementa até encontrar o próximo número primo.
                         });
    }
}


/*Tarefa
Dada uma lista de números inteiros positivos, determine o número inteiro não negativo mínimo que precisa ser inserido para que a soma de todos os elementos se torne um número primo.

Observações
- A lista sempre terá pelo menos 2 elementos.
- Todos os elementos serão números inteiros positivos (n > 0).
- A lista pode conter valores duplicados.
- A nova soma deve ser o número primo mais próximo que seja maior ou igual à soma atual.

Exemplos
[3, 1, 2] ==> Deve retornar 1
Explicação: A soma é 6
O número primo mais próximo maior ou igual a 6 é 7
Precisamos adicionar 1 para que a soma seja 7 (um primo)

[2, 12, 8, 4, 6] ==> Deve retornar 5
Explicação: A soma é 32
O primo mais próximo maior ou igual a 32 é 37
Precisamos adicionar 5 para fazer a soma 37 (um primo)

[50, 39, 49, 6, 17, 28] ==> Deveria retornar 2
Explicação: A soma é 189
O primo mais próximo maior ou igual a 189 é 191
Precisamos adicionar 2 para que a soma seja 191 (um primo)Tarefa
Dada uma lista de números inteiros positivos, determine o número inteiro não negativo mínimo que precisa ser inserido para que a soma de todos os elementos se torne um número primo.

Observações
A lista sempre terá pelo menos 2 elementos.
Todos os elementos serão números inteiros positivos (n > 0).
A lista pode conter valores duplicados.
A nova soma deve ser o número primo mais próximo que seja maior ou igual à soma atual.
Exemplos
[3, 1, 2] ==> Deve retornar 1
Explicação: A soma é 6
O número primo mais próximo maior ou igual a 6 é 7
Precisamos adicionar 1 para que a soma seja 7 (um primo)

[2, 12, 8, 4, 6] ==> Deve retornar 5
Explicação: A soma é 32
O primo mais próximo maior ou igual a 32 é 37
Precisamos adicionar 5 para fazer a soma 37 (um primo)

[50, 39, 49, 6, 17, 28] ==> Deveria retornar 2
Explicação: A soma é 189
O primo mais próximo maior ou igual a 189 é 191
Precisamos adicionar 2 para que a soma seja 191 (um primo)*/
#endregion
