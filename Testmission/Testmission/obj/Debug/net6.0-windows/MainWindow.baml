   M S B A M L   `   `   `  ����F  BTestmission, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:TestmissionTestmission  5   	       Testmission.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Testmission     5   	   -   5          � Title$  
MainWindow��5   	   $	��235��6   $	��820��6)    � 
ResizeMode$ NoResize=�65   .��5	      � $��1,6,0,-6q�6    � ColumnDefinitions 5
   
   �� 5      .+�5   
   �� -   5         ��Name$ Archiv_Button��5      $"��Заархивировать��6(   $
��Left=�6A   $��684,138,0,0q�6\   $	��Top=�6q   $��40��6�   $	��100��6�   6�   �� 5   
   $ ��Исходный путь:��6   $
��Left=�6)   $��	10,10,0,0q�6D   $	��Top=�6W   $	��100��6o   �� 5   
   -   5        $ ChoosePath_Button��5      $��Выбор папки��6,   $
��Left=�6B   $��
550,10,0,0q�6]   $	��Top=�6q   $��26��6�   $��80��6�   6�   �� 5   
   -   5         ��Name$ 	StartPath��5      $
��Left=�6%   $��
125,10,0,0q�6@    �� TextWrapping$
 Wrap=�6T   $��TextBox��6h   $	��Top=�6w   $	��420��6�   $��26��6�   ���	#FF8E8E8E6�   �� 5   
   -   5        $ CopyFiles_Button��5      $&�� Копировать 
файлы��6+   $
��Left=�6K   $��550,138,0,0q�6f   $	��Top=�6{   $��40��6�   $��90��6�   6�   �� 5   
   -   5         ��Name$ 
PathsBoxes��5      $
��Left=�6'   $��9,50,0,0q�6B   $	��Top=�6T   $	��240��6l   $��27��6x   6�   �� 5   
   -   5        $ SavePath_Button��5      $��Сохранить��6*   $
��Left=�6>   $��9,91,0,0q�6Y   $	��Top=�6k   $��27��6�   $��65��6�   6�   �� 5   
   -   5        $ AddPaths_Button��5      $��Добавить��6*   $
��Left=�6=   $��	635,9,0,0q�6X   $	��Top=�6k   $��27��6�   $��80��6�   6�   �� 5   
   -	   5        $ DeletePath_Button��5      $��Удалить��6,   $
��Left=�6>   $��
184,91,0,0q�6Y   $	��Top=�6m   $��27��6�   $��65��6�   6�   	� 5   
   -
   5         	�Name$  TxtFilesFilter_RadioButton��5      $!��Только txt файлы��6:   $
��Left=�6U   $��
21,163,0,0q�6p   $	��Top=�6�   6�   	� 5   
   -   5        $  AllFilesFilter_RadioButton��5      $��Все файлы��6:   $
��Left=�6N   $��154,163,0,0q�6i   $	��Top=�6~    �� 	ClickMode$ Release=�6�   	 d� 	IsChecked$
	 TrueY�6�   6�   �� 5   
   $2��,Фильтры для копирования��6   $
��Left=�62   $��
42,123,0,0q�6M   $	��Top=�6a   $��26��6y   $	��160��6�   5      5      