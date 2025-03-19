using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime;
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
        private CalculatorSettings _settings;

        public CalculatorModel()
        {
            _settings = new CalculatorSettings();
        }
        public void AppendDigit(string digit)
        {
            if (_settings.Base == NumberBase.Hex)
            {
                if (!"0123456789ABCDEFabcdef".Contains(digit))
                {
                    return;
                }
            }
            else
            {
                if (!"0123456789".Contains(digit))
                {
                    return;
                }
            }
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
            if (!_isNewInput && !_hasCalculated && _currentInput.Length > 0)
            {
                _currentInput = _currentInput.Length > 1 ? _currentInput.Substring(0, _currentInput.Length - 1): "0";

                if (_currentInput == "0")
                {
                    _isNewInput = true;
                }
            }
        }

        public void ClearEntry()
        {
            _currentInput = "0";
            _isNewInput = true;
        }

        public void ClearAll()
        {
            _currentInput = "0";
            _currentValue = 0;
            _lastOperator = "";
            _isNewInput = true;
            _hasCalculated = false;
            _expressionBuilder.Clear();
        }

        public void ProcessOperator(string op)
        {
            if (!_isNewInput || _hasCalculated)
            {
                CalculateIntermediateResult();
            }

            _lastOperator = op;
            _isNewInput = true;

            _expressionBuilder.Append($" {_currentValue} {op}");
        }

        public void ProcessSpecialOperator(string op)
        {
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
                        value = 0;
                    }
                    break;
                case "%":
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
            double inputValue;

            if (_settings.Base == NumberBase.Hex)
            {
                if (long.TryParse(_currentInput, System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture, out long hexValue))
                {
                    inputValue = hexValue;
                }
                else
                {
                    inputValue = 0; 
                }
            }
            else
            {
                if (!double.TryParse(_currentInput, out inputValue))
                {
                    inputValue = 0; 
                }
            }
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
            if (!string.IsNullOrEmpty(_lastOperator) && !_isNewInput)
            {
                CalculateIntermediateResult();
                _lastOperator = "";
                _isNewInput = true;
                _hasCalculated = true;
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
            if (numberBase == NumberBase.Dec)
            {
                if (useDigitGrouping)
                {
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
                double value;
                if (double.TryParse(_currentInput, out value))
                {
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