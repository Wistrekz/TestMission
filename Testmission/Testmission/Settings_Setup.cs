using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Testmission
{
    internal class Settings_Setup  //Класс для установки настроек
    {
        //Standard params

        public static string PathToGetSets = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings/settings.json");

        public static int SystemNumberOfArchivs;

        public static List<string> SystemSourcePaths = new List<string>();

        public static int CheckMassivPaths()  // Смотр на содержание json файла
        {
            StreamReader r = new StreamReader(PathToGetSets);
            dynamic items = JsonConvert.DeserializeObject(r.ReadToEnd());
            r.Close();
            string check;
            try
            {
                if (items["SourcePaths"] == null)
                {
                    return 0;
                }
            }
            catch(Exception)
            {
                return 0;
            }
            check = items["SourcePaths"].ToString();                 //Если файл пустой, то возвращается 0, если нет то пути записываются в List для передачи в список в окне
            if (check == null || check == "[]")                      //И возвращается 1
            {
                return 0;
            }
            else
            {
                int i = 0;
                foreach (var item in items["SourcePaths"])
                {
                    SystemSourcePaths.Add(item.ToString());
                }
                return 1;
            }
        }


        public static void SetStandardSettings(string Path)
        {
            Settings sets = new Settings();

            string json = System.Text.Json.JsonSerializer.Serialize(sets);
            File.WriteAllText(PathToGetSets, json);
        }

    }

    class Settings  // Класс для настроек записываемых в json
    {

        public List<string> SourcePaths { get; set; }
    }
}
