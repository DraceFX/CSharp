   M S B A M L   `   `   `  ����D  @Module_17, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Module_17	Module_17  5   	       Module_17.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Module_17     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ gridView��5
      $ �� IsSynchronizedWithCurrentItem$
 TrueY�5         SelectionMode$ Single=�5         
IsReadOnly .    AutoGenerateColumns .  ��5      ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        ID��,  &System.Windows.Controls.DataGridColumn   Header$ ID��5   %      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 5   %   �� *id+5   %     5      -   5        
secondName��$ Фамилия��5   %    . 	 5   %   �� *
secondName+5   %     5      -   5        	firstName��$ Имя��5   %    . 	 5   %   �� *	firstName+5   %     5      -   5        lastName��$ Отчество��5!   %    . 	 5    %   �� *
lastName+5"   %     5#      -   5        phoneNumber��$! Номер телефона��5%   %    . 	 5$   %   �� *phoneNumber+5&   %     5'      -   5        	email��$ Email��5)   %    . 	 5(   %   �� *email+5*   %   
 � ContextMenu
 5,      �� 5-      .@�5.      m� -   5        $��Добавить��5.      61   m� 5/      -	   5        $��Удалить��5/      60   m� 50      -
   5        $%��Просмотр заказов��50      69   51      53      55      56      