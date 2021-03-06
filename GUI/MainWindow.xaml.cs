﻿using Engine;
using System;
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

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private GameSession _gameSession;
        public MainWindow()
        {
            InitializeComponent();

            _gameSession = new GameSession();

            DataContext = _gameSession;
        }

        private void IncrementAttribrute_Click(object sender, RoutedEventArgs e)
        {
            string initials = ((Button)sender).Tag.ToString();
            _gameSession.CurrentCharacter.AdjustAttribute(initials, +1);

        }
        private void DecrementAttribrute_Click(object sender, RoutedEventArgs e)
        {
            string initials = ((Button)sender).Tag.ToString();
            _gameSession.CurrentCharacter.AdjustAttribute(initials, -1);

        }

        private void AddTrait_Click(object sender, RoutedEventArgs e)
        {
            _gameSession.CurrentCharacter.AddTrait();
        }
    }
}
