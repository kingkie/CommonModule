﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Expression.Media.Effects;

namespace WpfDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    RippleEffect effect = new RippleEffect();
        //    //effect.TwistAmount = 36;
        //    effect.Phase = 0.5;
        //    button1.Effect = effect;
        //}
    }
}
