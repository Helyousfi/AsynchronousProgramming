   M S B A M L   `   `   `  ����L  HAsyncAwaitProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:AsyncAwaitProjectAsyncAwaitProject  5   	   "    AsyncAwaitProject.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:AsyncAwaitProject     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � $��20q�6    � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0 10 0 5q�5      $��28(�5      $,��&Asynchronous/Parallel Demo Application��5      �� 5   
   -   5         ��Name$ executeNormal��5      $��1��5      $��0 5 0 5q�5      $��20(�5      $��Normal Execute��5      6*   �� 5   
   -   5        $ executeAsync��5      $��2��5      $��0 5 0 5q�5      $��20(�5      $��Async Execute��5      6)   �� 5   
   -   5        $ executeAsyncParallel��5!      $��3��5      $��0 5 0 5q�5       $��20(�5"      $��Async Parallel Execute��5#      62   �� 5%   
   $��4��6   $��0 5 0 10q�6   $��2q�60   
�������._�5&      �� -   5         ��Name$ resultWindow��5(      $��18(�5'      5(      5)      5+      5,      