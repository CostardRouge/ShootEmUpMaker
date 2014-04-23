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

namespace ShootEmUpMaker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MakerWindow : Window
    {
        public MakerWindow()
        {
            InitializeComponent();

            // Init events
            this.CreateNewLevelButton.MouseDown += CreateNewLevel;
        }

        void CreateNewLevel(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("lol");
        }
    }
}
