using System;
using System.Collections.Generic;
using System.IO;

namespace _16._06
{
    internal class Poem
    {
        private List<string> buf_text = new List<string>(); //буфер с текстом (построчно) для перезаписи данных
        private string text; //текст
        private int size; //количество строк
        private string file_path; //путь к файлу
        public Poem(string file_path) //конструктор принимает аргументом путь к файлу со стихотворением
        {
            this.file_path = file_path; //запись пути в переменную для перезаписи файла при необходимости
            using (StreamReader sr = new StreamReader(file_path)) //создание потока на чтение
            {
                while (!sr.EndOfStream) //считвает до конца строки
                {
                    buf_text.Add(sr.ReadLine()); //построчная запись в буфер
                    if (!buf_text[buf_text.Count - 1].Contains("Стих №") &&
                        !(buf_text[buf_text.Count - 1]=="")) //не увеличивается количество строк, если срока не относится к тексту (пустая, нумерация)
                        size++;
                }
                if (!buf_text[0].Contains("Стих №")) //создаётся дополнительный пропуск в буфере для корректной нумерации
                    buf_text.Insert(0, "");
            }
            using(StreamReader sr = new StreamReader(file_path)) //создание нового потока для записи текста в переменную с отображаемым текстом
                text = sr.ReadToEnd(); //считывание до конца
        }
        public void AppendNumbers() //фунция добавления нумерации четверостиший в текст
        {
            using (StreamWriter sw = new StreamWriter(file_path)) //создание потока на запись
            {
                text=String.Empty; //очистка переменной с текстом
                int count = 0; //счётчик четверостиший для нумерации
                for(int i=0; i<buf_text.Count-1; i++)
                {
                    if (buf_text[i] == "") //если строка пустая записывается нумерация
                        buf_text[i] = $"Стих № {++count}";
                    text += buf_text[i]+"\n";
                }
                text += buf_text[buf_text.Count-1]; //запись вне цикла, чтобы в конце текста не было лишнего пропуска
                sw.WriteLine(text); //запись нового текста в файл

                Console.WriteLine("Для повторной перезаписи перезапустите программу\n\nДля продолжения нажмите любую клавишу");
                Console.ReadKey(); //для создания задержки перед очисткой консоли
                Console.Clear(); //очистка консоли
            }
        }
        public void Print() //вывод текста с информацией о количестве строк
        {
            Console.WriteLine($"{text}\n\nВ стихотворении содержится {size} строк");
        }
    }
}
