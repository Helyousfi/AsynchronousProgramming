   M S B A M L   `   `   `  ����M  IAdvancedAsyncAwait, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:AdvancedAsyncAwaitAdvancedAsyncAwait  5   	   #    AdvancedAsyncAwait.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:AdvancedAsyncAwait     5   	     � Title$  
MainWindow��5   	   $	��770��6   $	��764��6)   .��5	      � $��20q�6    � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $	��20* �6   .+�5   
   �� $��0 10 0 5q�6   $��0��6&   $��28(�63   $#��Advanced Async Await Demo App��6A   �� 5   
   -   5         ��Name$ executeNormal��5      $��0 5 0 5q�6(   $��1��69   $��Normal execute��6F   $��18(�6_   6m   �� 5   
   -   5        $ executeAsync��5      $��0 5 0 5q�6(   $��2��69   $��Async execute��6F   $��18(�6^   6l   �� 5   
   -   5        $ executeAsyncParallel��5      $��0 5 0 5q�6/   $��3��6@   $��Parallel Async execute��6M   $��18(�6n   6|   �� 5   
   -   5        $ 	cancelBtn��5      $��0 5 0 5q�6$   $��4��65   $��Cancel execution��6B   $��18(�6]   � 5   
   -   5         �Name$ progressBar��5   4   $��0 5 0 5q�6   $��5��6'    � Minimum$ 0Q�6I    � Maximum$	 100Q�6U    � Value$ 0Q�6c   �� 5   
   
�������$��2q�6$   $��6��68   ._�5      �� -   5         ��Name$ resultsWindow��5      5      5      5      