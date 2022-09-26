using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

class Program
{
	static void Main(string[] args)
	{
        List<int> mas = new List<int> { 5, 8, 13, 12, 14, 11, 20, 18, 19, 28, 27, 30};
        IEnumerable<int> rez = Sort(mas, 3, 30);
        foreach (var t in rez)
            Console.WriteLine(t);
	}

	static IEnumerable<int> Sort(IEnumerable<int> inputStream, int sortFactor, int maxValue)
    {
        var mas = new int[maxValue + 1];

        // первое решение
        int current = 0;

        foreach (var value in inputStream) //проходимся по вводной коллекции
        {
            mas[value]++;// записываем в наш массив единичку, если число встретилось
            var min = value - sortFactor;// вычисляем минимальный индекс, до которого можно вывести число
            while (current <= min)
            {
                if (mas[current] > 0) // если элемент не нулевой, то возвращаем его
                    yield return current;
                current++;
            }
        }

        // дополнительный цикл для вывода элементов, которые не вывелись ранее из за ограничения sortFactor
        while (current < mas.Length)
        {
            if (mas[current] > 0)
                yield return current;
            current++;
        }

        // второе решение, но без использования параметра sortFactor
        /*int i = 0;
        foreach (var value in inputStream)
            mas[value]++;

        while (i < mas.Length)
        {
            if (mas[i] > 0)
                yield return i;
            i++;
        }*/
    }
}