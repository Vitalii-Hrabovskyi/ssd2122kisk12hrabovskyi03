using org.mariuszgromada.math.mxparser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DPPS.CommandsResolvers
{
    public class SequenceFileResolver
    {
        public SequenceFileResolver()
        {
            SequenceResult = new List<double>();
        }

        public int NumberOfSequence { get; set; } // число елементів в послідовності

        public string Expression { get; set; } // вхідниц вираз

        List<double> SequenceResult { get; set; } // вихідна послідовність

        public bool isGenerateFile { get; set; }

        /// <summary>
        /// Метод для заватаження вхідної послідовності з файла .ini
        /// </summary>
        /// <param name="path"></param>
        public void LoadFile(string path)
        {
            string file = File.ReadAllText(path); // читання файлу 
            Console.WriteLine("Input: " + file); // вивід вмістимого файлу на консоль
            Expression = file;
        }

        /// <summary>
        /// Метод для обчисленння послідовності згідно вхідної формули 
        /// </summary>
        public void CalculateSequence()
        {
            for (int i = 1; i <= NumberOfSequence; i++)
            {
                string argument = "x = " + i; // створення змінної
                Argument x = new Argument(argument); // створення змінної для передачі в парсер
                Expression expression = new Expression(Expression, x); 
                double result = expression.calculate(); // обрахунок виразу 
                SequenceResult.Add(result); // збереження результату в послідовність
            }
            ShowResults();
        }

        public void CalculateSequenceByMyParser()
        {
            for (int i = 1; i <= NumberOfSequence; i++)
            {
                var context = new ContextForParser(i); // клас для передачі  зміної в парсер
                var result = Parser.Parse(Expression).Eval(context); // обрахунок виразу
                SequenceResult.Add(result); // збереження результату в послідовність
            }
            ShowResults();
        }

        /// <summary>
        /// Метод для виводу вихідної послідовності в консоль.
        /// </summary>
        private void ShowResults()
        {
            string result = string.Empty;
            foreach (var item in SequenceResult)
            {
                result += item.ToString() + ", "; // додавання до стрінги кожного значення з масиву послідовності
            }
            Console.WriteLine("Result: " + result);         
        }

        public void GenerateFile(string path)
        {
            if (isGenerateFile)
            {
                //створюємо файл або перезаписуємо якщо він вже існує
                using (FileStream fs = File.Create(path))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(string.Join(Environment.NewLine, SequenceResult)); // перетворення послідовності в байти для запису в файл
                    // запис байтів у файл
                    fs.Write(info, 0, info.Length);
                }
                Console.WriteLine("File successfuly generated!");
            }
        }
    }
}
