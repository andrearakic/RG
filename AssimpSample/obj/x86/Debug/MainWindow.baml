   M S B A M L   `   `   `  ����R  NSharpGL.WPF, Version=2.3.0.1, Culture=neutral, PublicKeyToken=27fc851303210b27>.clr-namespace:SharpGL.WPF;assembly=SharpGL.WPFSharpGL.WPF  5   	    AssimpSample   AssimpSample.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   BsharpGL.clr-namespace:SharpGL.WPF;assembly=SharpGL.WPF     5   	   -   5          � Title$  SharpGL WPF Application��5   	   $	��350��6)   $	��525��66   .��5      �  � RowDefinitions 5   
   �� 5	      $	��30* �6   $��30��6)   5      �� 5      $
��289* �6   5      .+�5   
      SharpGL.WPF.OpenGLControl  -   5        $��openGLControl��5      $��1��5   !      DrawFPS .    RenderContextType$	 FBO=�5         	FrameRate$ 30Q�64   c� 5   
   -   5         c�Name$ toolBar��5      $��Stretch=�6#   $��0��6B   $	��Top=�6O   $��30��6h   $��30��6t   .@�5      �� -   5         ��Name$	 red��5      $��R��6!   $��25��6-   $	��Top=�69   �� 5      -   5         ��Name$ 	sliderRed��5      $��25��6(   $	��Top=�64   $	��100��6L    � Minimum$ 0Q�6q   	 � Maximum$	 1Q�6}   
 � Value$
 1Q�6�    � LargeChange$	 0.1Q�6�   �� 5      -   5        $ green��5      $��G��6#   $��25��6/   $	��Top=�6;   �� 5      -   5        $ sliderGreen��5      $��25��6*   $	��Top=�66   $	��100��6N   $ 0Q�6u   $	 1Q�6�   $
 0Q�6�   $	 0.1Q�6�   �� 5      -   5        $
 blue��5      $��B��6"   $��25��6.   $	��Top=�6:   �� 5      -	   5        $ 
sliderBlue��5      $��25��6)   $	��Top=�65   $	��100��6M   $ 0Q�6s   $	 1Q�6   $
 0Q�6�   $	 0.1Q�6�   �� 5      -
   5        $ label1��5      $��
DOOR SPEED��6$   $��25��69   $	��Top=�6E   �� 5      -   5        $ 
sliderDoor��5      $��25��6)   $	��Top=�65   $	��100��6M   $ 1Q�6s   $	 10Q�6   $
 5Q�6�   $	 0.1Q�6�   �� 5      -   5        $ label2��5      $��HANGAR HIGHT��6$   $��25��6;   $	��Top=�6G   �� 5       -   5        $ sliderHangar��5       $��25��6+   $	��Top=�67   $	��100��6O   $ 0Q�6w   $		 400Q�6�   $
 0Q�6�   $	 0.1Q�6�   5#      5$      5%      