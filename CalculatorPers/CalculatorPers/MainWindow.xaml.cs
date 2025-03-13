using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CalculatorPers
{
    public partial class MainWindow : Window
    {
        private CalculatorModel _calculatorModel;
        private CalculatorSettings _settings;

        public MainWindow()
        {
            InitializeComponent();

            // Încărcăm setările
            _settings = SettingsManager.LoadSettings();

            // Inițializăm modelul calculatorului
            _calculatorModel = new CalculatorModel();

            // Aplicăm setările salvate
            ApplySettings();

            // Actualizăm afișajul
            UpdateDisplay();
        }

        private void ApplySettings()
        {
            // Aplicăm setarea pentru Digit Grouping
            var menuItem = this.FindName("DigitGroupingMenuItem") as MenuItem;
            if (menuItem != null)
                menuItem.IsChecked = _settings.DigitGroupingEnabled;

            // Aplicăm modul calculatorului (Standard/Programmer)
            if (_settings.Mode == CalculatorMode.Standard)
            {
                StandardCalculatorGrid.Visibility = Visibility.Visible;
                ProgrammerGrid.Visibility = Visibility.Collapsed;
            }
            else
            {
                StandardCalculatorGrid.Visibility = Visibility.Collapsed;
                ProgrammerGrid.Visibility = Visibility.Visible;

                // Selectăm baza de numerație salvată
                switch (_settings.Base)
                {
                    case NumberBase.Hex:
                        HexRadioButton.IsChecked = true;
                        break;
                    case NumberBase.Dec:
                        DecRadioButton.IsChecked = true;
                        break;
                    case NumberBase.Oct:
                        OctRadioButton.IsChecked = true;
                        break;
                    case NumberBase.Bin:
                        BinRadioButton.IsChecked = true;
                        break;
                }
            }
        }

        private void UpdateDisplay()
        {
            // Actualizăm afișajul rezultatului conform setărilor active
            ResultDisplay.Text = _calculatorModel.GetDisplayValue(_settings.DigitGroupingEnabled, _settings.Base);
            ExpressionDisplay.Text = _calculatorModel.GetExpressionText();
        }

        #region Event Handlers

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                _calculatorModel.AppendDigit(button.Content.ToString());
                UpdateDisplay();
            }
        }

        private void HexDigit_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                _calculatorModel.AppendDigit(button.Content.ToString());
                UpdateDisplay();
            }
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                _calculatorModel.ProcessOperator(button.Content.ToString());
                UpdateDisplay();
            }
        }

        private void SpecialOperator_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                _calculatorModel.ProcessSpecialOperator(button.Content.ToString());
                UpdateDisplay();
            }
        }

        private void Decimal_Click(object sender, RoutedEventArgs e)
        {
            _calculatorModel.AppendDecimalPoint();
            UpdateDisplay();
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            _calculatorModel.CalculateResult();
            UpdateDisplay();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                if (button.Content.ToString() == "C")
                {
                    _calculatorModel.ClearAll();
                }
                else if (button.Content.ToString() == "CE")
                {
                    _calculatorModel.ClearEntry();
                }
                UpdateDisplay();
            }
        }

        private void Memory_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                switch (button.Content.ToString())
                {
                    case "MC":
                        _calculatorModel.MemoryClear();
                        break;
                    case "MR":
                        _calculatorModel.MemoryRecall();
                        break;
                    case "MS":
                        _calculatorModel.MemoryStore();
                        break;
                    case "M+":
                        _calculatorModel.MemoryAdd();
                        break;
                    case "M-":
                        _calculatorModel.MemorySubtract();
                        break;
                    case "M>":
                        ShowMemoryList();
                        break;
                }
                UpdateDisplay();
            }
        }

        private void ShowMemoryList()
        {
            // Implementarea afișării listei de valori din memorie
            var memoryValues = _calculatorModel.GetMemoryValues();
            if (memoryValues.Count > 0)
            {
                // Aici puteți crea un popup sau o nouă fereastră pentru a afișa valorile
                // Pentru exemplu, vom folosi un MessageBox
                MessageBox.Show(string.Join("\n", memoryValues), "Memory Values");
            }
            else
            {
                MessageBox.Show("No values stored in memory.", "Memory Empty");
            }
        }

        private void BaseRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            /*if (radioButton != null && radioButton.IsChecked == true)
            {
                NumberBase selectedBase = NumberBase.Dec;

                // Determinăm baza selectată
                if (radioButton == HexRadioButton)
                {
                    selectedBase = NumberBase.Hex;
                    HexButtonsPanel.Visibility = Visibility.Visible;
                }
                else if (radioButton == DecRadioButton)
                {
                    selectedBase = NumberBase.Dec;
                    HexButtonsPanel.Visibility = Visibility.Collapsed;
                }
                else if (radioButton == OctRadioButton)
                {
                    selectedBase = NumberBase.Oct;
                    HexButtonsPanel.Visibility = Visibility.Collapsed;
                }
                else if (radioButton == BinRadioButton)
                {
                    selectedBase = NumberBase.Bin;
                    HexButtonsPanel.Visibility = Visibility.Collapsed;
                }

                // Actualizăm setările și afișajul
                _settings.Base = selectedBase;
                SettingsManager.SaveSettings(_settings);
                UpdateDisplay();
            }*/
        }

        private void Standard_Click(object sender, RoutedEventArgs e)
        {
            // Activăm modul Standard
            StandardCalculatorGrid.Visibility = Visibility.Visible;
            ProgrammerGrid.Visibility = Visibility.Collapsed;

            // Actualizăm setările
            _settings.Mode = CalculatorMode.Standard;
            SettingsManager.SaveSettings(_settings);
        }

        private void Programmer_Click(object sender, RoutedEventArgs e)
        {
            // Activăm modul Programmer
            StandardCalculatorGrid.Visibility = Visibility.Collapsed;
            ProgrammerGrid.Visibility = Visibility.Visible;

            // Actualizăm setările
            _settings.Mode = CalculatorMode.Programmer;
            SettingsManager.SaveSettings(_settings);
        }

        private void DigitGrouping_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = sender as MenuItem;
            if (menuItem != null)
            {
                // Actualizăm setarea pentru Digit Grouping
                _settings.DigitGroupingEnabled = menuItem.IsChecked;
                SettingsManager.SaveSettings(_settings);
                UpdateDisplay();
            }
        }

        private void Cut_Click(object sender, RoutedEventArgs e)
        {
            // Implementăm funcția Cut
            Clipboard.SetText(ResultDisplay.Text);
            _calculatorModel.ClearAll();
            UpdateDisplay();
        }

        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            // Implementăm funcția Copy
            Clipboard.SetText(ResultDisplay.Text);
        }

        private void Paste_Click(object sender, RoutedEventArgs e)
        {
            // Implementăm funcția Paste
            try
            {
                string clipboardText = Clipboard.GetText();
                _calculatorModel.PasteValue(clipboardText);
                UpdateDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error pasting value: {ex.Message}", "Paste Error");
            }
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            // Afișăm informații despre aplicație
            MessageBox.Show("Calculator WPF\nCreated by: [Your Name]\nGroup: [Your Group]", "About");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            // Închidem aplicația
            this.Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            // Gestionăm tastele apăsate
            switch (e.Key)
            {
                case Key.Enter:
                    _calculatorModel.CalculateResult();
                    UpdateDisplay();
                    e.Handled = true;
                    break;
                case Key.Escape:
                    _calculatorModel.ClearAll();
                    UpdateDisplay();
                    e.Handled = true;
                    break;
                case Key.Back:
                    _calculatorModel.Backspace();
                    UpdateDisplay();
                    e.Handled = true;
                    break;
                case Key.NumPad0:
                case Key.D0:
                    if (!e.KeyboardDevice.Modifiers.HasFlag(ModifierKeys.Shift))
                    {
                        _calculatorModel.AppendDigit("0");
                        UpdateDisplay();
                        e.Handled = true;
                    }
                    break;
                    // Adaugă aici restul tastelor numerice și operatorilor...
            }
        }

        #endregion
    }
}