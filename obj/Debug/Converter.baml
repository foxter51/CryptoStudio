   M S B A M L   `   `   `  ????I  ETestAssignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TestAssignmentTestAssignment  5          TestAssignment.Converter   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:TestAssignment     5      -   5          N? Title$  	Converter??5	       ? 	Resources 5       ?? MergedDictionaries ?? Source?? 5   
    5      ?? 5      $( "Resources/ConverterDictionary.xaml??6%   ?? 5      $$ Resources/ThemeDictionary.xaml??6%   ?? 5      $ Resources/lang.xaml??6%   %    5      .??5      ?    LinearPanelBrush#???   6    ? RowDefinitions 5   
   ?? 5      $
??Auto ?6   6,   ?? 5      $
??Auto ?6   6,   ?? 5      $
??Auto ?6   6,   .+?5   
   A?  A? Rows$ 1??6    A? Columns$ 3??6   $??0??6+   .+?5      ??  ?? Orientation$ 
Horizontal=?6   .+?5      ??   From#???  6<    ?? Target 6   ?? 	 ?? ElementName$
	 From??6_   ?? 5       -   5        $
??From??5    L   
 ?? DisplayMemberPath$

 Name??63   $??80??6X   $??20, 5, 0, 5q?6c   ??6   ?? 6?   5!      ?? 5"      -   5        
??????  ? ToolTip$ Switch??5"   /   .??5#      ?? $??20??6   $_??YC:\Users\ihor\source\repos\TestAssignment\TestAssignment\arrow-right-arrow-left-solid.png??6$   6?   5$      ?? 5%      $ 
Horizontal=?6   $??Right=?62   .+?5&      ??   To#???  6:    6   ?? $	 To??6[   ?? 5'      -   5        $??To??5'   L   $

 Name??63   $??80??6V   $??20, 5, 10, 5q?6a   ??6   ?? 6?   5(      5)      A? 5+   
   $ 2??6   $ 2??6   $??1??6+   .+?5,      ??   Inp#???  6@    6   ?? $	 inputTextBox??6b   ? 5-       ? ColumnDefinitions 5.      ?? 5/      $??4* ?6'   64   ?? 50      $??* ?6'   63   .+?52      ?? -   5        $??inputTextBox??52   *   $??0??6   6g   ?? 53      -   5        $??	fromLabel??53      $??1??6)   $??Bitcoin??6e    69   ?? $	 inputTextBox??6y   54      ?? 55        Out#???  6A    6   ?? $	 outputTextBox??6c   ? 56       57      ?? 58      $??4* ?6'   64   ?? 59      $??* ?6'   63   .+?5;      ?? -   5        $??outputTextBox??5;   *   $??0??6    ?? 
IsReadOnly . 6S   ?? 5<      -   5        $??toLabel??5<      $??1??6(   $??Ethereum??6e    68   ?? $	 outputTextBox??6z   5=      5>      ?? 5@   
   -	   5        $??20q?5@   '   $??2??63   $??16(?6@   $
??Bold"?6N   $	??200??6`     Convert#???  6?   ??6o   Z? 6?   ?? 5B   
   $??0??6   ???	#FFCBBEBE$??2q?66    ?? CornerRadius$ 10??6J   6^   ?? 5C   
   $??1??6   ???	#FFCBBEBE$??2q?66   $ 10??6J   6^   ?? 5D   
   $??2??6   ???	#FFCBBEBE$??2q?66   $ 10??6J   6^   5E      5F      