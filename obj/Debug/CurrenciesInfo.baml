   M S B A M L   `   `   `  ????I  ETestAssignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TestAssignmentTestAssignment  5      #    TestAssignment.CurrenciesInfo   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:TestAssignment     5      -   5          N? Title$  CurrenciesInfo??5	       ? 	Resources 5       ?? MergedDictionaries ?? Source?? 5   
    5      ?? 5      $$ Resources/ThemeDictionary.xaml??6%   ?? 5      $- 'Resources/CurrenciesInfoDictionary.xaml??6%   ?? 5      $ Resources/lang.xaml??6%   %    5      .??5      ?    LinearPanelBrush#???   6    ? ColumnDefinitions 5   
   ?? 5      $??2* ?6   6,   ?? 5      $??* ?6   6+   .+?5   
   ? $??0??6    ? RowDefinitions 5      ?? 5      $
??Auto ?6    60   ?? 5       6"   .+?5#      ]? $??0??6   ??.  .+?5$      ??   Curr#???  6   6;   ?? 5%      -   5        $??	SearchBox??5%      $??Right=?6+   $	??250??6B   $??20??6N   $??10q?6Z   6?   5&      ?? 5(      -   5        $??CurrenciesListAll??5(   #   $??1??6    ?? DisplayMemberPath$
 Name??6T   $
??Auto=?6m   $??14(?6?   $??10q?6?   ??6<   ?? 6?   5)      ? 5+   
   $??1??6    ? DataContext 6   ??  ?? ElementName$ CurrenciesListAll??	 ?? Path$	 SelectedItem? 5,      ?? 5-      $
??Auto ?6    60   ?? 5.      6"   .+?51      ?? $??0??6     SoloCurrInfo#???  6!   6L   ? 53      $??1??6    54      ?? 55      $
??Auto ?6$   64   ?? 56      6&   .+?59      ?? $??0??6   .+?5:      ?? $??14(?6     	 Price#???  6.   6O   ?? 5;      $??14(?6   |?.  ??6,   ?? *CurrentPrice+
 ?? Mode$
 OneWay=? ?? StringFormat$
 ${0}??6?   ?? 5<      $??14(?6      Vol#???  6.   6M   ?? 5=      $??14(?6   |?.  ??6,   ?? *TotalVolume+$
 OneWay=?$
 ${0}??6?   ?? 5>      $??14(?6      PriceChange#???  6.   6U   ?? 5?      $??14(?6   |?.  ??6,   ?? *PriceChangePercentage24H+$
 OneWay=?$
 {0}%??6?   ?? 5@      $??14(?6      Markets#???  6.   6Q   5A      ?? 5C      -   5        $??Markets??5C   5   $??1??6   $??14(?6'   $
??Auto=?6\   ??6D   ?? 6?   5D      5E      5F      5G      