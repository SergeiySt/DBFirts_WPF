   M S B A M L   `   `   `  ����D  @LsitPhone, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:LsitPhone	LsitPhone  5   	       LsitPhone.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:LsitPhone     5   	   -   5          � 
ResizeMode$  NoResize=�5   	    � Title$) #Телефоний довідник��5	   	   $	��518��6$   $	��777��61    � WindowStartupLocation$ CenterScreen=�6V    � Icon$ /icon_210815.ico��6{   .��5
      � $��	0,0,-29,0q�6   $	��539��6   $	��Top=�6+    � RowDefinitions 5   
   �� 5      $
��382* �6   �� 5      $	��46* �6   �� 5      $	��29* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
phonesGrid��5       $��0��6      AutoGenerateColumns .  $��10,4,38,227q�6�   ��64   �� *Phones+ �� SelectedItem 6S   �� *SelectedPhone+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 ID��6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 61   �� *id_listphone+  5      $	 Прізвище��6%   
 67   �� *
LSurname+  5      $	 Ім'я��6%   
 63   �� *LName+  5      $	 По-батькові��6%   
 6:   �� *
LPobatkovi+  5      $	 Email��6%   
 64   �� *LEmail+  5      $	 Країна��6%   
 65   �� *Country.CName+  5      $	 Телефон��6%   
 66   �� *LPhone+  5      $#	 Дата народження��6%   
 6>   �� *
LDateBrith+  5      $#	 Дата реєстрації��6%   
 6>   �� *
LAddDate+5      �� 5   
   -   5        $��Добавити��5      $
��Left=�6$   $��323,441,0,0q�6?   $	��Top=�6T   $��30��6�   $	��132��6�   $��16(�6�   $��2��6�   ��6l   �� *AddPhoneCommand+{�6�   �� *AddPhoneEnabled+6�   �� 5   
   -   5        $��Видалити��5      $
��Left=�6$   $��Bottom=�6?    J� RenderTransformOrigin$ -2.531,-1.503&�6�   $��30��6�   $	��134��6�   $��
470,0,0,34q�6�   $��16(�6�   $��2��6�   ��6Z   �� *DeletePhoneCommand+6�   �� 5    
   -   5        $!��Зберегти зміни��5       $
��Left=�6*   $��
619,0,0,34q�6E   $��16(�6�   $	��133��6�   $ 0.263,0.337&�6�   $��30��6�   $��Bottom=�6�   $��2��6�   ��6Y   �� *SaveChangesCommand+6�   �� 5!   
   $��По-батькові:��6   $
��Left=�6'   $��
45,303,0,0q�6B   $	��Top=�6V   �� 5"   
   $��Email:��6   $
��Left=�6!   $��
83,326,0,0q�6<   $	��Top=�6P   $ 0.114,-0.142&�6h   �� 5#   
   $��Країна:��6   $
��Left=�6"   $��
75,351,0,0q�6=   $	��Top=�6Q   $ 0.432,0.836&�6i   �� 5$   
   $��Телефон:��6   $
��Left=�6#   $��
64,376,0,0q�6>   $	��Top=�6R   $��2��6j   �� 5%   
   $$��Дата народження:��6   $
��Left=�6+   $��
14,401,0,0q�6F   $	��Top=�6Z   �� 5&   
   $	��ID:��6   $
��Left=�6   $��100,234,0,0q�69   $	��Top=�6N   �� 5'   
   $��Прізвище:��6   $
��Left=�6$   $��
58,257,0,0q�6?   $	��Top=�6S   �� 5(   
   $��Ім'я:��6   $
��Left=�6    $��
91,280,0,0q�6;   $	��Top=�6O   $ 0.192,-0.371&�6g   �� 5)   
   -   5         ��Name$ id��5)   �   $
��Left=�6   $��129,238,0,0q�6-    �� TextWrapping$
 Wrap=�6B   $�� ��6V   $	��Top=�6_   $	��623��6w   {�.  6�   �� 5*   
   -   5        $ LSurName��5*   {   $
��Left=�6   $��129,261,0,0q�6-   $
 Wrap=�6B   $	��Top=�6W   $	��623��6o   $�� ��6�   �� 5+   
   -   5        $ LName��5+   |   $
��Left=�6   $��129,284,0,0q�6-   $
 Wrap=�6B   $	��Top=�6W   $	��623��6o   $�� ��6�   �� 5,   
   -	   5        $ 
LPobatkovi��5,   z   $
��Left=�6   $��129,307,0,0q�6-   $
 Wrap=�6B   $	��Top=�6V   $	��623��6n   $�� ��6�   �� 5-   
   -
   5        $ LEmail��5-   {   $
��Left=�6   $��129,330,0,0q�6-   $
 Wrap=�6B   $	��Top=�6W   $	��623��6o   $�� ��6�   �� 5.   
   -   5         ��Name$ comboBoxCountry��5.   g   $
��Left=�6   $��129,353,0,0q�6.   $	��Top=�6C   $	��623��6[    �� DisplayMemberPath$ CName��6�    �� SelectedValuePath$ 
id_country��6�   ��6�   �� *	Countries+ �� SelectedValue 6�   �� *SelectedCountry+�� 5/   
   -   5        $ LPhone��5/   {   $
��Left=�6   $��129,380,0,0q�6-   $
 Wrap=�6B   $	��Top=�6W   $	��623��6o   $�� ��6�   (  "System.Windows.Controls.DatePicker  50   
   -   5          Name$ 
LDateBrith��50   i   $
��Left=�6   $��129,403,0,0q�60   $	��Top=�6E   $	��623��6]   6i   �� 51   
   -   5         ��Name$ Clear��51      $��Очистити поля��6    $
��Left=�68   $��
176,0,0,34q�6S   $��Bottom=�6g   $	��132��6�   $ 0.333,2.277&�6�   $��30��6�   $��16(�6�   $��2��6�   �� 52   
   $��Label��6   $
��Left=�6    $��-232,377,0,0q�6;   $	��Top=�6Q   �� 53   
   -   5        $ About��53      $��?��6    $
��Left=�6,   $��129,441,0,0q�6G   $	��Top=�6\   $��2��6t   $��30��6�   $��34��6�   $��16(�6�   6�   54      55      