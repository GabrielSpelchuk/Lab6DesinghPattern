using System;
using System.IO;

namespace ExecuteAroundPattern
{
    class Program
    {
        delegate void FileOperation(StreamReader reader);

        static void ExecuteWithFile(string filePath, FileOperation operation)
        {
            using (var reader = new StreamReader(filePath))
            {
                operation(reader);
            }
        }

        static void Main()
        {
            string tempFile = "D:\\Study\\2ndCourse\\2ndSemester\\DesignPattern\\Lab6\\example.txt";
            File.WriteAllText(tempFile, "Це тестовий файл з кількома рядками.\nДругий рядок.\nТретій рядок.");

            ExecuteWithFile(tempFile, reader =>
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine("Прочитано рядок: " + line);
                }
            });

            File.Delete(tempFile);
        }
    }
}
