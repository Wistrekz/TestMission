using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Controls = System.Windows.Controls;
using Forms = System.Windows.Forms;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Path = System.IO.Path;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Toolkit.Uwp.Notifications;
using Newtonsoft.Json;

namespace Testmission
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void MainwindowLoaded(object sender, RoutedEventArgs e)
        {
            if(Settings_Setup.SystemSourcePaths != null)
            {
                foreach (var item in Settings_Setup.SystemSourcePaths)
                {
                    PathsBoxes.Items.Add(item);
                }
            }
        }

        private void Archiv_Button_Click(object sender, RoutedEventArgs e) //Метод архивации файлов
        {
            try
            {
                var StartpacketName = new DirectoryInfo(StartPath.Text.ToString()).Name;
                string ArchivWay = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ArchivResults", $"{StartpacketName}_Archiv_{DateTime.Now.ToString("HH_mm")}.zip");
                ZipFile.CreateFromDirectory(StartPath.Text.ToString(), ArchivWay);
                Logging.WriteNewAction("Заархивирована папка " + StartpacketName.ToString());
                App.notifyIcon.ShowBalloonTip(2000, "Файлы заархивированы", "Уведомление", ToolTipIcon.Info);
            }
            catch(UnauthorizedAccessException)
            {
                System.Windows.MessageBox.Show("Нет доступа к папке.", "Access Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(DirectoryNotFoundException)
            {
                System.Windows.MessageBox.Show("Нет такой папки.", "Access Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (IOException)
            {
                System.Windows.MessageBox.Show("Ошибка с папкой архивации", "Access Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ChoosePath_Button_Click(object sender, RoutedEventArgs e)  // Метод выбора папки
        {
            try
            {
                FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                if (folderBrowserDialog1.ShowDialog() == Forms.DialogResult.OK)
                {
                    StartPath.Text = folderBrowserDialog1.SelectedPath;
                }
            }
            catch (IOException)
            {
                System.Windows.MessageBox.Show($"Нет доступа к файлам в папке", "Access Error", MessageBoxButton.OK, MessageBoxImage.Error);
                StartPath.Text = "";
            }
        }

        private void CopyFiles_Button_Click(object sender, RoutedEventArgs e)   //Копирование файлов
        {
            if(StartPath.Text == null || StartPath.Text == "" || Directory.Exists(StartPath.Text) == false)    //Проверка на путь
            {
                System.Windows.MessageBox.Show("Неверный исходный путь", "Folder Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string filename = new DirectoryInfo(StartPath.Text.ToString()).Name;
            string NewDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Time_Current_files", filename + "_" + DateTime.Now.ToString("dd/MM/yyyy"));
            if(Directory.Exists(NewDirectory))
            {
                if (Directory.Exists(NewDirectory))
                {
                    DirectoryInfo GenFolderInfo = new DirectoryInfo(NewDirectory);
                    foreach (var folder in GenFolderInfo.EnumerateDirectories())
                    {
                        DirectoryInfo FoldersInfo = new DirectoryInfo(NewDirectory + "/" + folder.Name);
                        foreach (var file in FoldersInfo.EnumerateFiles())
                        {
                            File.Delete(NewDirectory + "/" + folder.Name + "/" + file.Name);
                        }
                        Directory.Delete(NewDirectory + "/" + folder.Name);
                    }
                    foreach (var file in GenFolderInfo.EnumerateFiles())
                    {
                        File.Delete(NewDirectory + "/" + file.Name);
                    }

                    Directory.Delete(NewDirectory);
                }
            }
            Directory.CreateDirectory(NewDirectory);
            if(TxtFilesFilter_RadioButton.IsChecked == true) // Проверка на выполнение фильтра
            {
                DirectoryInfo direct = new DirectoryInfo(StartPath.Text.ToString());
                foreach (var file in direct.EnumerateFiles())
                {
                    if(file.Name.Contains(".txt"))  //Проверка на фильтр
                    {
                        File.Copy(Path.Combine(StartPath.Text, file.Name), Path.Combine(App.TimeFiles, NewDirectory, file.Name));
                    }
                }
                System.Windows.MessageBox.Show("Текстовые файлы скопированы", "Folder Info", MessageBoxButton.OK, MessageBoxImage.Information);
                Logging.WriteNewAction("Скопированы временные текстовые файлы");
            }
            else
            {
                DirectoryInfo direct = new DirectoryInfo(StartPath.Text.ToString());
                foreach (var file in direct.EnumerateFiles())
                {
                    File.Copy(Path.Combine(StartPath.Text, file.Name), Path.Combine(App.TimeFiles, NewDirectory, file.Name));
                }
                System.Windows.MessageBox.Show("Файлы скопированы", "Folder Info", MessageBoxButton.OK, MessageBoxImage.Information);
                Logging.WriteNewAction("Скопированы временные файлы");
            }
        }

        private void SavePath_Button_Click(object sender, RoutedEventArgs e) //Метод сохранения путей в json
        {
            foreach(var item in PathsBoxes.Items)
            {
                Settings_Setup.SystemSourcePaths.Add(item.ToString());
            }
            StreamReader r = new StreamReader(Settings_Setup.PathToGetSets);
            dynamic items = JsonConvert.DeserializeObject(r.ReadToEnd());
            r.Close();
            Settings sets = new Settings();
            sets.SourcePaths = Settings_Setup.SystemSourcePaths;
            string json = System.Text.Json.JsonSerializer.Serialize(sets);
            File.WriteAllText(Settings_Setup.PathToGetSets, json);
            System.Windows.MessageBox.Show("Пути сохранены", "Paths Info", MessageBoxButton.OK, MessageBoxImage.Information);
            Logging.WriteNewAction("Сохранены настройки");
        }

        private void DeletePath_Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in PathsBoxes.Items)
            {
                PathsBoxes.Items.Remove(item);
            }
            System.Windows.MessageBox.Show("Пути удалены", "Paths Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void AddPaths_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (PathsBoxes.Items != null)   // Проверка на одинаковые записи
                {
                    foreach (string str1 in PathsBoxes.Items)
                    {
                        if (StartPath.Text == str1)
                        {
                            System.Windows.MessageBox.Show("Эта папка есть в списке", "Paths Info", MessageBoxButton.OK, MessageBoxImage.Information);
                            StartPath.Text = "";
                            return;
                        }
                    }
                }

                if (Directory.Exists(StartPath.Text))      //Проверка на существование папки
                    PathsBoxes.Items.Add(StartPath.Text);
                else
                {
                    System.Windows.MessageBox.Show("Этой папки не существует", "Paths Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                DirectoryInfo FilesUnaccessed = new DirectoryInfo(StartPath.Text);
                foreach (var file in FilesUnaccessed.EnumerateFiles())             //Проверка на недоступные файлы
                {
                    StreamReader r = new StreamReader(Path.Combine(StartPath.Text, file.Name));
                    r.Close();
                }
                System.Windows.MessageBox.Show("Добавлена папка в список", "Paths Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(UnauthorizedAccessException)
            {
                System.Windows.MessageBox.Show("В этой папке есть файлы с закрытым доступом");
                PathsBoxes.Items.RemoveAt(PathsBoxes.Items.Count - 1);
            }
        }

        private void TxtFilesFilter_RadioButton_Click(object sender, RoutedEventArgs e)
        {
            TxtFilesFilter_RadioButton.IsChecked = true;        //Смена фильтра на текстовый
            AllFilesFilter_RadioButton.IsChecked = false;
        }

        private void AllFilesFilter_RadioButton_Click(object sender, RoutedEventArgs e)
        {
            AllFilesFilter_RadioButton.IsChecked = true;  //Смена фильтра на всеобщий
            TxtFilesFilter_RadioButton.IsChecked = false;
        }


        //Набор методов ниже способствует выдаче пути из списка

        private bool IsItemSelected = true;
        private void PathsBoxes_DropDownClosed(object sender, EventArgs e)
        {
            if (IsItemSelected) ChangePath();
            IsItemSelected = true;
        }

        private void PathsBoxes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Controls.ComboBox cmb = sender as Controls.ComboBox;
            IsItemSelected = !cmb.IsDropDownOpen;
            ChangePath();
        }

        private void ChangePath()
        {
            string itemthing = PathsBoxes.SelectedItem.ToString();
            if (itemthing != null)
            {
                StartPath.Text = PathsBoxes.SelectedItem.ToString();
            }
        }

    }
}
