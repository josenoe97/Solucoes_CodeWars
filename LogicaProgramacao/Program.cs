
using System.ComponentModel;
using System.Net.Sockets;

public class Program
{
    public static void Main()
    {
        int[] numbers = new int[] {13,10,5,2,9};

        Console.WriteLine(numbers
       .OrderBy(i => i)
       .Skip(1)
       .Zip(numbers.OrderBy(i => i), (a, b) => Math.Abs(b - a))
       .Max());
    }

}

#region Teste - estudos

/* // Exemplo de uso básico de Dictionary
 var dict = new Dictionary<string, int>();  // cria dicionário (namespace System.Collections.Generic)
 dict.Add("um", 1);                         // adiciona elemento (chave "um", valor 1)
 dict["dois"] = 2;                          // outra forma de adicionar (indexador)
 Console.WriteLine(dict["um"]);             // acessa pelo índice da chave -> imprime 1
 Console.WriteLine(dict.ContainsKey("tres")); // verifica presença de chave -> false
 dict.Remove("dois");                       // remove o par com chave "dois"
 Console.WriteLine($"Itens no dicionário: {dict.Count}");  // exibe contagem de pares



 // Exemplo de uso básico de HashSet
 var set = new HashSet<int>();       // cria HashSet de inteiros
 Console.WriteLine(set.Add(10));     // true (elemento adicionado)
 Console.WriteLine(set.Add(10));     // false (10 já existe; não permite duplicata)
 set.Add(20);
 set.Add(30);
 Console.WriteLine(set.Contains(20)); // true (verifica existência rápida)
 Console.WriteLine($"Contém 40? {set.Contains(40)}"); // false
 set.Remove(30);                     // remove o elemento 30
 Console.WriteLine($"Itens no conjunto: {set.Count}"); // exibe quantidade (2)*/

/*      var cidades = new Dictionary<string, string>
      {
          ["SP"] = "São Paulo",
          ["RJ"] = "Rio de Janeiro",
          ["MG"] = "Minas Gerais"
      };
      // Filtra entradas cujas chaves contenham "S"
      var resultado = cidades
          .Where(kvp => kvp.Key.Contains("S"))
          .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
      foreach (var kvp in resultado)
          Console.WriteLine($"Chave: {kvp.Key}, Valor: {kvp.Value}");*/


//Uso do ZIP

/*int[] numbers = { 1, 2, 3, 4 };
string[] words = { "one", "two", "three" };

var numbersAndWords = numbers.Zip(words, (first, second) => first + " " + second);

foreach (var item in numbersAndWords)
    Console.WriteLine(item);

// This code produces the following output:

// Concatenou os "numbers" com "words" OBS: mas serve para outra coisas além de concatenação.
// 1 one 
// 2 two
// 3 three*/

#endregion

#region Exercicio 1#
public class Kata1
{
    //object[] resultado = Kata.IsVow(new object[] { // MOCK
    //        118, 117, 120, 121, 117, 98, 122, 97, 120,
    //        106, 104, 116, 113, 114, 113, 120, 106
    //    });

    public static object[] IsVow(object[] a)
    {
        return ObjectConvertASCII(a);
    }

    //public static object[] IsVow(object[] a)
    //{
    //    return a.Select(x => "aeiou".Contains(Convert.ToChar(x)) ? Convert.ToChar(x).ToString() : x).ToArray(); //Solução Alternativa
    //}

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

//productArray({ 1,5,2}) ==> return { 10,2,5}

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

    /*    public static int[] ProductArray(int[] array) //  --MELHOR PRATICA CODEWARS--
        {
            var product = array.Aggregate((x, y) => x * y);
            return array.Select(x => product / x).ToArray();
        }*/

    //public static int[] ProductValuesOrder(int[] array) // IA CODIGO
    //{
    //    int n = array.Length;
    //    int[] result = new int[n];

    //    for (int i = 0; i < n; i++)
    //    {
    //        int product = 1;

    //        for (int j = 0; j < n; j++)
    //        {
    //            if (i != j)
    //                product *= array[j];
    //        }

    //        result[i] = product;
    //    }

    //    return result;
    //}
}


//                              Exemplo:
//productArray({ 10,3,5,6,2}) return ==> { 180,600,360,300,900}
//Explicação:
//O primeiro elemento 180 é o produto de todos os elementos da matriz, exceto o primeiro elemento 10

//O segundo elemento 600 é o produto de todos os elementos da matriz, exceto o segundo elemento 3

//O terceiro elemento 360 é o produto de todos os elementos da matriz, exceto o terceiro elemento 5

//O quarto elemento 300 é o produto de todos os elementos da matriz, exceto o quarto elemento 6

//Finalmente, o quinto elemento 900 é o produto de todos os elementos da matriz, exceto o quinto elemento 2
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
        else if (countCaracter.Equals(16) && (stringNumber.StartsWith("51") || stringNumber.StartsWith("52") || stringNumber.StartsWith("53") || stringNumber.StartsWith("54") || stringNumber.StartsWith("55")))
            return "MasterCard";
        else if ((countCaracter.Equals(13) || countCaracter.Equals(16)) && stringNumber.StartsWith("4"))
            return "VISA";
        else
            return "Unknown";
    }

    /*    public static string getIssuer(long number) ------ Mais bem avaliado -----
        {
            var card = number.ToString();
            if (Regex.IsMatch(card, "^3[47][0-9]{13}$")) return "AMEX";
            if (Regex.IsMatch(card, "^6011[0-9]{12}$")) return "Discover";
            if (Regex.IsMatch(card, "^5[1-5][0-9]{14}$")) return "Mastercard";
            if (Regex.IsMatch(card, "^4([0-9]{12}|[0-9]{15})$")) return "VISA";
            return "Unknown";
        }*/
}



/*Dado um número de cartão de crédito, podemos determinar quem é o emissor / fornecedor com alguns conhecimentos básicos.

Conclua a função que usará os valores mostrados abaixo para determinar o emissor do cartão para um determinado número de cartão.
Se o número não puder ser correspondido, a função deverá retornar a cadeia de caracteres .getIssuer()Unknown

| Card Type  | Begins With          | Number Length |
|------------|----------------------|---------------|
| AMEX       | 34 or 37             | 15            |
| Discover   | 6011                 | 16            |
| Mastercard | 51, 52, 53, 54 or 55 | 16            |
| VISA       | 4                    | 13 or 16      |
Exemplos
getIssuer(4111111111111111) == "VISA"
getIssuer(4111111111111) == "VISA"
getIssuer(4012888888881881) == "VISA"
getIssuer(378282246310005) == "AMEX"
getIssuer(6011111111111117) == "Discover"
getIssuer(5105105105105100) == "Mastercard"
getIssuer(5105105105105106) == "Mastercard"
getIssuer(9111111111111111) == "Unknown"*/
#endregion

#region Exercicio 4#
public class Kata4 // 1 2 3 4 5
{                  //  1 2 3 4
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
//    public static int AdjacentElementsProduct(int[] array)
//{
//    return array.Skip(1).Select((x, i) => x * array[i]).Max();
//}

/*Dada uma matriz (array) de inteiros, encontre o produto máximo obtido da multiplicação de dois números adjacentes na matriz.

    O array tem pelo menos 2 elementos.

    Os números podem ser positivos, negativos ou zero.

📌 Exemplos:
[1, 2, 3] → produto máximo é 2 * 3 = 6

[9, 5, 10, 2, 24, -1, -48] → produto máximo é 5 * 10 = 50

[-23, 4, -5, 99, -27, 329, -2, 7, -921] → produto máximo é -2 * 7 = -14Dada uma matriz (array) de inteiros, encontre o produto máximo obtido da multiplicação de dois números adjacentes na matriz.

O array tem pelo menos 2 elementos.

Os números podem ser positivos, negativos ou zero.

📌 Exemplos:
[1, 2, 3] → produto máximo é 2 * 3 = 6

[9, 5, 10, 2, 24, -1, -48] → produto máximo é 5 * 10 = 50

[-23, 4, -5, 99, -27, 329, -2, 7, -921] → produto máximo é -2 * 7 = -14*/
#endregion

#region Exercicio 5#
public static class Kata5
{
    public static string ReturnEvenOrOdd(int number)
    {
        return number % 2 == 0 ? "Even" : "Odd";
    }
}


/*Crie uma função que receba um inteiro como argumento e retorne "Even" para números pares ou "Odd" para números ímpares.*/
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

//Melhor solução:
// return arr.OrderBy(i => -i).Take(size).Aggregate((x, y) => x * y);

/*
Tarefa
Dado um array/lista [] de inteiros, encontre o produto dos k números máximos.

Observações
O tamanho do array/lista é de pelo menos 3.

Os números do array/lista serão uma mistura de positivos, negativos e zeros.

Pode ocorrer repetição de números no array/lista.

Exemplo 
maxProduct ({4, 3, 5}, 2) ==>  return (20)

Como o tamanho (k) é igual a 2, então a subsequência de tamanho 2 cujo produto dos máximos é 5 * 4 = 20.
 
 */
#endregion

#region Exercicio 7#

public static class Kata7
{ // logica antiga afetou nos indices, logo foi reprovado no teste.
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

//public static int[] ArrayLeaders(int[] n) => n.Where((x, i) => x > n.Skip(i + 1).Sum()).ToArray();


/*
Definição
Um elemento é líder se for maior que a soma de todos os elementos ao seu lado direito.

Tarefa
Dado um array/lista [] de inteiros, encontre todos os LÍDERES no array.

Notas
O tamanho da matriz/lista é de pelo menos 3 .

Os números da matriz/lista serão uma mistura de positivos, negativos e zeros

Pode ocorrer repetição de números na matriz/lista.

Array/list retornado deve armazenar os números iniciais na mesma ordem no array/list original.

 Input >> Output Examples:
arrayLeaders ({1, 2, 3, 4, 0}) ==> return {4}

Explanation:
4 is greater than the sum all the elements to its right side

Note : The last element 0 is equal to right sum of its elements (abstract zero).
 
 */
#endregion#

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

// Outras soluções:/*/*
/*Array.Sort(numbers);
return numbers.Zip(numbers.Skip(1), (a, b) => b - a).Max();**//*/

----

return numbers
.OrderBy(i => i)
.Skip(1)
.Zip(numbers.OrderBy(i => i), (a, b) => Math.Abs(b - a))
.Max();            

---

/*Dada uma matriz/lista [] de inteiros, Encontre a diferença máxima entre os elementos sucessivos em sua forma classificada.

Anotações
O tamanho da matriz/lista é de pelo menos 3 .

Números de array/lista Será uma mistura de positivos e negativos também zeros_

A repetição de números na matriz/lista pode ocorrer.

A lacuna máxima é calculada independentemente do sinal.*/

/*Exemplos de entrada >> saída
maxGap ({13,10,5,2,9}) ==> return (4)

Explicação:
A lacuna máxima após classificar a matriz é , A diferença entre .49 - 5 = 4*/

#endregion