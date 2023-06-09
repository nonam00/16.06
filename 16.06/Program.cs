//файл с текстом должен быть включён в решение

using System;

namespace _16._06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Poem poem = new Poem($"{Environment.CurrentDirectory}\\Poem.txt");
            poem.Print();
            poem.AppendNumbers();
            poem.Print();
        }
    }
}
