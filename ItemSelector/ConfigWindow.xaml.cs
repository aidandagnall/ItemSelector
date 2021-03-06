﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace ItemSelector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ConfigWindow
    {
        public ConfigWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Title = "Picker Config";
        }

        
        private void PreviewIntegerInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsSecondsInputValid(e.Text);
        }

        private bool IsSecondsInputValid(string text)
        {
            int seconds = 0;
            return int.TryParse(text, out seconds);
        }

        private void StartButton(object sender, RoutedEventArgs e)
        {
            var inputString = InputOptions.Text;
            var inputs = inputString.Split('\n').Select(s => s.Trim()).ToList();
            var seconds = 0;
            var repeats = 0;
            int.TryParse(Seconds.Text, out seconds);
            int.TryParse(Repeats.Text, out repeats);
            var displayWindow = new DisplayWindow(inputs, _random, seconds, repeats, _showTotalTime);
            displayWindow.Closed += ChildWindowClosed;
            displayWindow.Show();
            Hide();
        }

        private void ChildWindowClosed(object sender, EventArgs e)
        {
            Show();
        }

        private bool _random = false;
        private void RandomChecked(object sender, RoutedEventArgs e)
        {
            _random = true;
        }

        private void RandomUnchecked(object sender, RoutedEventArgs e)
        {
            _random = false;
        }

        private bool _showTotalTime = false;
        private void TotalTimeChecked(object sender, RoutedEventArgs e)
        {
            _showTotalTime = true;
        }

        private void TotalTimeUnchecked(object sender, RoutedEventArgs e)
        {
            _showTotalTime = false;
        }
    }
}