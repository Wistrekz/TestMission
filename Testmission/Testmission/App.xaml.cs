using System;
using System.Drawing;
using System.Windows;
using Path = System.IO.Path;
using System.IO;
using System.Windows.Forms;

namespace Testmission
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {

        public static readonly NotifyIcon notifyIcon = new NotifyIcon();

        public static string PathToGetSettings = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings"); //Путь к настройкам
        public static string TimeFiles = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Time_Current_files");//Путь к временной папке


        protected override void OnStartup(StartupEventArgs e)
        {
            try//Добавление иконки
            {
                notifyIcon.Icon = new Icon("ico.ico");
            }
            catch(Exception)
            {
                System.Windows.MessageBox.Show("Потеряна иконка для программы. " + Environment.NewLine + "Нужно вставить в папку с программой любой ico файл и назвать его \"ico.ico\"");
                System.Windows.Application.Current.Shutdown();
            }
            notifyIcon.Visible = true;
            notifyIcon.Text = "TestMission";

            Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings"));              //Создание папки настроек и всех использующихся папок при старте

            if (!File.Exists(Path.Combine(PathToGetSettings, "settings.json")))
            {
                FileStream f = new FileStream(Path.Combine(PathToGetSettings, "settings.json"), FileMode.Create, FileAccess.Write); //Добавление файла настроек
                f.Close();
            }

            if (Settings_Setup.CheckMassivPaths() == 0)
            {
                Settings_Setup.SetStandardSettings(Settings_Setup.PathToGetSets);
            }

            Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Time_Current_files"));

            Logging.CreateLog();

            Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ArchivResults"));

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)    // При выходе пользователя уведомляют о том что временные файлы удалятся из временной папки
        {
            if(System.Windows.MessageBox.Show("Вы точно хотите выйти? Все временные файлы будут удалены",
                    "Предупреждение",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                if(Directory.Exists(TimeFiles))
                {
                    DirectoryInfo GenFolderInfo = new DirectoryInfo(TimeFiles);
                    foreach (var folder in GenFolderInfo.EnumerateDirectories())
                    {
                        DirectoryInfo FoldersInfo = new DirectoryInfo(TimeFiles + "/" + folder.Name);
                        foreach (var file in FoldersInfo.EnumerateFiles())
                        {
                            File.Delete(TimeFiles + "/" + folder.Name + "/" + file.Name);
                        }
                        Directory.Delete(TimeFiles + "/" + folder.Name);
                    }
                    foreach (var file in GenFolderInfo.EnumerateFiles())
                    {
                        File.Delete(TimeFiles + "/" + file.Name);
                    }

                    Directory.Delete(TimeFiles);
                }
                
            }
            else
            {
                return;
            }
            notifyIcon.Dispose();
            base.OnExit(e);
        }
    }


}
