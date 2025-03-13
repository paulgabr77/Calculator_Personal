using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CalculatorPers
{
    public class CalculatorModel
    {
        private string _currentInput = "0";
        private double _currentValue = 0;
        private double _memoryValue = 0;
        private string _lastOperator = "";
        private bool _isNewInput = true;
        private bool _hasCalculated = false;
        private List<double> _memoryValues = new List<double>();
        private StringBuilder _expressionBuilder = new StringBuilder();

        public void AppendDigit(string digit)
        {
            // Verificăm dacă trebuie să începem o nouă intrare
            if (_isNewInput || _currentInput == "0" || _hasCalculated)
            {
                _currentInput = digit;
                _isNewInput = false;
                _hasCalculated = false;
            }
            else
            {
                _currentInput += digit;
            }
        }

        public void AppendDecimalPoint()
        {
            // Verificăm dacă putem adăuga punct zecimal
            if (_isNewInput || _hasCalculated)
            {
                _currentInput = "0.";
                _isNewInput = false;
                _hasCalculated = false;
            }
            else if (!_currentInput.Contains("."))
            {
                _currentInput += ".";
            }
        }

        public void Backspace()
        {
            // Ștergem ultimul caracter
            if (!_isNewInput && !_hasCalculated && _currentInput.Length > 0)
            {
                _currentInput = _currentInput.Length > 1
                    ? _currentInput.Substring(0, _currentInput.Length - 1)
                    : "0";

                if (_currentInput == "0")
                {
                    _isNewInput = true;
                }
            }
        }

        public void ClearEntry()
        {
            // Resetăm intrarea curentă
            _currentInput = "0";
            _isNewInput = true;
        }

        public void ClearAll()
        {
            // Resetăm totul
            _currentInput = "0";
            _currentValue = 0;
            _lastOperator = "";
            _isNewInput = true;
            _hasCalculated = false;
            _expressionBuilder.Clear();
        }

        public void ProcessOperator(string op)
        {
            // Calculăm rezultatul curent înainte de a procesa noul operator
            if (!_isNewInput || _hasCalculated)
            {
                CalculateIntermediateResult();
            }

            // Salvăm operatorul pentru următorul calcul
            _lastOperator = op;
            _isNewInput = true;

            // Adăugăm la expresie
            _expressionBuilder.Append($" {_currentValue} {op}");
        }

        public void ProcessSpecialOperator(string op)
        {
            // Procesăm operatorul special (sqrt, square, etc)
            double value = double.Parse(_currentInput);

            switch (op)
            {
                case "√":
                    if (value >= 0)
                    {
                        value = Math.Sqrt(value);
                    }
                    else
                    {
                        // Eroare - radical din număr negativ
                        value = 0;
                    }
                    break;
                case "x²":
                    value = value * value;
                    break;
                case "1/x":
                    if (value != 0)
                    {
                        value = 1 / value;
                    }
                    else
                    {
                        // Eroare - împărțire la zero
                        value = 0;
                    }
                    break;
                case "%":
                    // Procentaj din valoarea curentă
                    value = _currentValue * (value / 100);
                    break;
                case "+/-":
                    value = -value;
                    break;
            }

            _currentInput = value.ToString(CultureInfo.InvariantCulture);
            _isNewInput = false;
            _hasCalculated = true;
        }

        private void CalculateIntermediateResult()
        {
            double inputValue = double.Parse(_currentInput);

            // Aplicăm operatorul anterior
            switch (_lastOperator)
            {
                case "+":
                    _currentValue += inputValue;
                    break;
                case "-":
                    _currentValue -= inputValue;
                    break;
                case "*":
                    _currentValue *= inputValue;
                    break;
                case "/":
                    if (inputValue != 0)
                    {
                        _currentValue /= inputValue;
                    }
                    else
                    {
                        // Eroare - împărțire la zero
                        _currentValue = 0;
                    }
                    break;
                default:
                    _currentValue = inputValue;
                    break;
            }

            _currentInput = _currentValue.ToString(CultureInfo.InvariantCulture);
        }

        public void CalculateResult()
        {
            // Calculăm rezultatul final
            if (!string.IsNullOrEmpty(_lastOperator) && !_isNewInput)
            {
                CalculateIntermediateResult();

                // Resetăm pentru următoarea operație
                _lastOperator = "";
                _isNewInput = true;
                _hasCalculated = true;

                // Adăugăm la expresie
                _expressionBuilder.Append($" {_currentInput} =");
            }
        }

        #region Memory Operations

        public void MemoryClear()
        {
            _memoryValue = 0;
            _memoryValues.Clear();
        }

        public void MemoryRecall()
        {
            _currentInput = _memoryValue.ToString(CultureInfo.InvariantCulture);
            _isNewInput = false;
        }

        public void MemoryStore()
        {
            _memoryValue = double.Parse(_currentInput);
            _memoryValues.Add(_memoryValue);
        }

        public void MemoryAdd()
        {
            _memoryValue += double.Parse(_currentInput);
            _memoryValues.Add(_memoryValue);
        }

        public void MemorySubtract()
        {
            _memoryValue -= double.Parse(_currentInput);
            _memoryValues.Add(_memoryValue);
        }

        public List<double> GetMemoryValues()
        {
            return _memoryValues;
        }

        #endregion

        #region Display Methods

        public string GetDisplayValue(bool useDigitGrouping, NumberBase numberBase = NumberBase.Dec)
        {
            // Obținem valoarea pentru afișaj în funcție de setări
            if (numberBase == NumberBase.Dec)
            {
                // În baza 10, folosim formatarea cultură
                if (useDigitGrouping)
                {
                    // Determinăm cultura sistemului pentru separatorul corect
                    double value;
                    if (double.TryParse(_currentInput, out value))
                    {
                        return value.ToString("N", CultureInfo.CurrentCulture);
                    }
                }

                return _currentInput;
            }
            else
            {
                // Pentru alte baze, convertim valoarea
                double value;
                if (double.TryParse(_currentInput, out value))
                {
                    // Rotunjim pentru a evita probleme cu numere zecimale
                    long intValue = (long)Math.Round(value);

                    switch (numberBase)
                    {
                        case NumberBase.Hex:
                            return Convert.ToString(intValue, 16).ToUpper();
                        case NumberBase.Oct:
                            return Convert.ToString(intValue, 8);
                        case NumberBase.Bin:
                            return Convert.ToString(intValue, 2);
                        default:
                            return _currentInput;
                    }
                }

                return "0";
            }
        }

        public string GetExpressionText()
        {
            return _expressionBuilder.ToString();
        }

        #endregion

        #region Clipboard Operations

        public void PasteValue(string value)
        {
            // Verificăm dacă valoarea este un număr valid
            double parsedValue;
            if (double.TryParse(value, out parsedValue))
            {
                _currentInput = parsedValue.ToString(CultureInfo.InvariantCulture);
                _isNewInput = false;
                _hasCalculated = false;
            }
            else
            {
                throw new ArgumentException("Invalid numeric format");
            }
        }

        #endregion
    }

    // Enumerări pentru setări
    public enum CalculatorMode
    {
        Standard,
        Programmer
    }

    public enum NumberBase
    {
        Hex,
        Dec,
        Oct,
        Bin
    }
}