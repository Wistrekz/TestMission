   M S B A M L   `   `   `  ���� F  BTestmission, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:TestmissionTestmission      Testmission.MainWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:Testmission     -     � Title$  
MainWindow��$	��280��$	��800�� � 
ResizeMode$ NoResize=� � SizeToContent$ WidthAndHeight=� � Icon$' !/bin/Debug/net6.0-windows/ico.ico��.��� $��1,6,-15,-16q� � ColumnDefinitions �� .+��� -    ��Name$ Archiv_Button��$"��Заархивировать��$
��Left=�$��690,214,0,0q�$	��Top=�$��40��$	��100���� $ ��Исходный путь:��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��100���� -   $ ChoosePath_Button��$��Выбор папки��$
��Left=�$��
550,10,0,0q�$	��Top=�$��26��$��80���� -    ��Name$ 	StartPath��$
��Left=�$��
125,10,0,0q� �� TextWrapping$
 Wrap=�$��TextBox��$	��Top=�$	��420��$��26�����	#FF8E8E8E�� -   $ CopyFiles_Button��$&�� Копировать 
файлы��$
��Left=�$��575,214,0,0q�$	��Top=�$��40��$��90���� -    ��Name$ 
PathsBoxes��$
��Left=�$��
10,106,0,0q�$	��Top=�$	��240��$��27���� -   $ SavePath_Button��$��Сохранить��$
��Left=�$��
10,147,0,0q�$	��Top=�$��27��$��65���� -   $ AddPaths_Button��$��Добавить��$
��Left=�$��	635,9,0,0q�$	��Top=�$��27��$��80���� -	   $ DeletePath_Button��$��Удалить��$
��Left=�$��185,147,0,0q�$	��Top=�$��27��$��65���� $ ��Конечный путь:��$
��Left=�$��	10,68,0,0q�$	��Top=�$	��100���� -
   $ EndPath��$
��Left=�$��
125,68,0,0q�$
 Wrap=�$��TextBox��$	��Top=�$	��420��$��26�����	#FF8E8E8E�� -   $ ChooseEndPath_Button��$��Выбор папки��$
��Left=�$��
550,68,0,0q�$	��Top=�$��26��$��80��	� -   	 	�Name$ 	 TxtFilesFilter_RadioButton��$!��Только txt файлы��$��Center=�$��	0,227,0,0q�$	��Top=�	� -   $ 	 AllFilesFilter_RadioButton��$��Все файлы��$
��Left=�$��468,227,0,0q�$	��Top=�
 �� 	ClickMode$
 Release=� d� 	IsChecked$
 TrueY��� $2��,Фильтры для копирования��$��Center=�$��	0,169,0,0q�$	��Top=�$��26��$	��160��