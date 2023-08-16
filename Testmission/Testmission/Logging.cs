using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Testmission
{
    internal static class Logging // Класс для журналирования процесса
    {
        public static string LoggingFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logging");      
        public static string TodayLoggingFilePath = Path.Combine(LoggingFolderPath, DateTime.Now.ToString("dd_MM_yyyy") + ".txt");

        public static void CreateLog()
        {
            Directory.CreateDirectory(LoggingFolderPath);
            if (!File.Exists(TodayLoggingFilePath))
            {
                FileStream f = new FileStream(TodayLoggingFilePath, FileMode.Create, FileAccess.Write); //Добавление файла настроек
                f.Close();
            }
            StreamReader LogRead = new StreamReader(TodayLoggingFilePath);     //Здесь создаётся лог. Чтобы его не переполнять выходами и входами 
            string logtext = LogRead.ReadToEnd();
            LogRead.Close();
            StreamWriter LogWrite = new StreamWriter(TodayLoggingFilePath);    // Программа смотрит на дату. Если сегодня другой день, то и создаётся новый файл для лога
            
            if (logtext == null || logtext == "")
            {
                LogWrite.WriteLine(DateTime.Now.ToString("[dd_MM_yyyy] [hh_mm]" + " - " + "Сессия начата;"));
            }
            LogWrite.Close();
        }
        public static void WriteNewAction(string Actiontext) // Метод записи действий
        {
            StreamReader LogRead = new StreamReader(TodayLoggingFilePath);     //Здесь создаётся лог. Чтобы его не переполнять выходами и входами 
            string logtext = LogRead.ReadToEnd() + Environment.NewLine + Actiontext;
            LogRead.Close();
            StreamWriter LogWrite = new StreamWriter(TodayLoggingFilePath);
            LogWrite.WriteLine(DateTime.Now.ToString("[dd_MM_yyyy] [hh_mm]" + " - " + logtext));
            LogWrite.Close();
        }
    }
}
