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
            _settings = SettingsManager.LoadSettings();
            _calculatorModel = new CalculatorModel();
            ApplySettings();
            UpdateDisplay();
        }

        private void ApplySettings()
        {
            var menuItem = this.FindName("DigitGroupingMenuItem") as MenuItem;
            if (menuItem != null)
                menuItem.IsChecked = _settings.DigitGroupingEnabled;

            if (_settings.Mode == CalculatorMode.Standard)
            {
                StandardCalculatorGrid.Visibility = Visibility.Visible;
                ProgrammerGrid.Visibility = Visibility.Collapsed;
            }
            else
            {
                StandardCalculatorGrid.Visibility = Visibility.Collapsed;
                ProgrammerGrid.Visibility = Visibility.Visible;

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
            var memoryValues = _calculatorModel.GetMemoryValues();
            if (memoryValues.Count > 0)
            {
                // Creăm o fereastră nouă pentru afișarea valorilor
                Window memoryWindow = new Window
                {
                    Title = "Memory Values",
                    Width = 200,
                    Height = 300,
                    WindowStartupLocation = WindowStartupLocation.CenterOwner,
                    Owner = this,
                    ResizeMode = ResizeMode.NoResize
                };

                // Creăm un ListView pentru a afișa valorile
                ListView listView = new ListView();
                foreach (var value in memoryValues)
                {
                    listView.Items.Add(value.ToString(CultureInfo.CurrentCulture));
                }

                // Adăugăm un handler pentru dublu-click pe element
                listView.MouseDoubleClick += (s, e) =>
                {
                    if (listView.SelectedItem != null)
                    {
                        // Folosim valoarea selectată
                        _calculatorModel.PasteValue(listView.SelectedItem.ToString());
                        UpdateDisplay();
                        memoryWindow.Close();
                    }
                };

                memoryWindow.Content = listView;
                memoryWindow.Show();
            }
            else
            {
                MessageBox.Show("No values stored in memory.", "Memory Empty");
            }

        }

        private void BaseRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton != null && radioButton.IsChecked == true)
            {
                NumberBase selectedBase = NumberBase.Dec;

                // Determinăm baza selectată
                if (radioButton == HexRadioButton)
                {
                    selectedBase = NumberBase.Hex;
                    if (HexButtonsPanel != null)
                    {
                        HexButtonsPanel.Visibility = Visibility.Visible;
                    }
                }
                else if (radioButton == DecRadioButton)
                {
                    selectedBase = NumberBase.Dec;
                    if (HexButtonsPanel != null)
                    {
                        HexButtonsPanel.Visibility = Visibility.Collapsed;
                    }
                }
                else if (radioButton == OctRadioButton)
                {
                    selectedBase = NumberBase.Oct;
                    if (HexButtonsPanel != null)
                    {
                        HexButtonsPanel.Visibility = Visibility.Collapsed;
                    }
                }
                else if (radioButton == BinRadioButton)
                {
                    selectedBase = NumberBase.Bin;
                    if (HexButtonsPanel != null)
                    {
                        HexButtonsPanel.Visibility = Visibility.Collapsed;
                    }

                }
                if (_settings != null)
                {
                    _settings.Base = selectedBase;
                    SettingsManager.SaveSettings(_settings);
                    UpdateDisplay();
                }
                else
                {
                    // Handle the null case, possibly by initializing _settings or logging an error
                }
            }
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
        private void Backspace_Click(object sender, RoutedEventArgs e)
        {
            _calculatorModel.Backspace();
            UpdateDisplay();
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
            
            MessageBox.Show("Calculator Personal\nCreated by: Ilie Paul Gabriel\nGroup: 10LF331", "About");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            // Închidem aplicația
            this.Close();
        }
        private bool IsValidKeyForBase(Key key)
        {
            switch (_settings.Base)
            {
                case NumberBase.Bin:
                    return key == Key.D0 || key == Key.D1 ||
                           key == Key.NumPad0 || key == Key.NumPad1;
                case NumberBase.Oct:
                    return (key >= Key.D0 && key <= Key.D7) ||
                           (key >= Key.NumPad0 && key <= Key.NumPad7);
                case NumberBase.Dec:
                    return (key >= Key.D0 && key <= Key.D9) ||
                           (key >= Key.NumPad0 && key <= Key.NumPad9);
                case NumberBase.Hex:
                    return (key >= Key.D0 && key <= Key.D9) ||
                           (key >= Key.NumPad0 && key <= Key.NumPad9) ||
                           (key >= Key.A && key <= Key.F);
                default:
                    return false;
            }
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (_settings.Mode == CalculatorMode.Programmer && !IsValidKeyForBase(e.Key) && !(e.Key == Key.Back || e.Key == Key.Delete || e.Key == Key.Escape || e.Key == Key.Enter || e.Key == Key.Add || e.Key == Key.Subtract || e.Key == Key.Multiply || e.Key == Key.Divide))
            {
                e.Handled = true;
                return;
            }
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
                case Key.NumPad1:
                case Key.D1:
                    if (!e.KeyboardDevice.Modifiers.HasFlag(ModifierKeys.Shift))
                    {
                        _calculatorModel.AppendDigit("1");
                        UpdateDisplay();
                        e.Handled = true;
                    }
                    break;
                case Key.NumPad2:
                case Key.D2:
                    if (!e.KeyboardDevice.Modifiers.HasFlag(ModifierKeys.Shift))
                    {
                        _calculatorModel.AppendDigit("2");
                        UpdateDisplay();
                        e.Handled = true;
                    }
                    break;
                case Key.NumPad3:
                case Key.D3:
                    if (!e.KeyboardDevice.Modifiers.HasFlag(ModifierKeys.Shift))
                    {
                        _calculatorModel.AppendDigit("3");
                        UpdateDisplay();
                        e.Handled = true;
                    }
                    break;
                case Key.NumPad4:
                case Key.D4:
                    if (!e.KeyboardDevice.Modifiers.HasFlag(ModifierKeys.Shift))
                    {
                        _calculatorModel.AppendDigit("4");
                        UpdateDisplay();
                        e.Handled = true;
                    }
                    break;
                case Key.NumPad5:
                case Key.D5:
                    if (!e.KeyboardDevice.Modifiers.HasFlag(ModifierKeys.Shift))
                    {
                        _calculatorModel.AppendDigit("5");
                        UpdateDisplay();
                        e.Handled = true;
                    }
                    break;
                case Key.NumPad6:
                case Key.D6:
                    if (!e.KeyboardDevice.Modifiers.HasFlag(ModifierKeys.Shift))
                    {
                        _calculatorModel.AppendDigit("6");
                        UpdateDisplay();
                        e.Handled = true;
                    }
                    break;
                case Key.NumPad7:
                case Key.D7:
                    if (!e.KeyboardDevice.Modifiers.HasFlag(ModifierKeys.Shift))
                    {
                        _calculatorModel.AppendDigit("7");
                        UpdateDisplay();
                        e.Handled = true;
                    }
                    break;
                case Key.NumPad8:
                case Key.D8:
                    if (!e.KeyboardDevice.Modifiers.HasFlag(ModifierKeys.Shift))
                    {
                        _calculatorModel.AppendDigit("8");
                        UpdateDisplay();
                        e.Handled = true;
                    }
                    break;
                case Key.NumPad9:
                case Key.D9:
                    if (!e.KeyboardDevice.Modifiers.HasFlag(ModifierKeys.Shift))
                    {
                        _calculatorModel.AppendDigit("9");
                        UpdateDisplay();
                        e.Handled = true;
                    }
                    break;
                case Key.Add:
                case Key.OemPlus:
                    _calculatorModel.ProcessOperator("+");
                    UpdateDisplay();
                    e.Handled = true;
                    break;
                case Key.Subtract:
                case Key.OemMinus:
                    _calculatorModel.ProcessOperator("-");
                    UpdateDisplay();
                    e.Handled = true;
                    break;
                case Key.Multiply:
                    _calculatorModel.ProcessOperator("*");
                    UpdateDisplay();
                    e.Handled = true;
                    break;
                case Key.Divide:
                case Key.OemQuestion:
                    if (e.KeyboardDevice.Modifiers.HasFlag(ModifierKeys.Shift))
                    {
                        _calculatorModel.ProcessOperator("/");
                        UpdateDisplay();
                        e.Handled = true;
                    }
                    break;
                case Key.Decimal:
                case Key.OemPeriod:
                    _calculatorModel.AppendDecimalPoint();
                    UpdateDisplay();
                    e.Handled = true;
                    break;
                // Pentru Backspace (deși am deja o tratare mai sus)
                case Key.Delete:
                    _calculatorModel.ClearEntry();
                    UpdateDisplay();
                    e.Handled = true;
                    break;
            }
            if (e.KeyboardDevice.Modifiers.HasFlag(ModifierKeys.Control))
            {
                switch (e.Key)
                {
                    case Key.C:
                        Copy_Click(null, null);
                        e.Handled = true;
                        break;
                    case Key.X:
                        Cut_Click(null, null);
                        e.Handled = true;
                        break;
                    case Key.V:
                        Paste_Click(null, null);
                        e.Handled = true;
                        break;
                }
            }
        }
        #endregion
    }
}