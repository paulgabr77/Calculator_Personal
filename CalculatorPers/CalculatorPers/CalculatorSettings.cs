using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace CalculatorPers
{
    [Serializable]
    public class CalculatorSettings
    {
        public bool DigitGroupingEnabled { get; set; } = false;
        public CalculatorMode Mode { get; set; } = CalculatorMode.Standard;
        public NumberBase Base { get; set; } = NumberBase.Dec;
    }

    public static class SettingsManager
    {
        private const string SettingsFileName = "calculator_settings.xml";
        private static readonly string SettingsFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Calculator", SettingsFileName);

        public static CalculatorSettings LoadSettings()
        {
            try
            {
                string directoryPath = Path.GetDirectoryName(SettingsFilePath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                if (File.Exists(SettingsFilePath))
                {
                    using (FileStream fs = new FileStream(SettingsFilePath, FileMode.Open))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(CalculatorSettings));
                        return (CalculatorSettings)serializer.Deserialize(fs);
                    }
                }
            }
            catch (Exception)
            {
                // În caz de eroare, returnăm setări implicite
                // Putem adăuga logging aici dacă dorim
            }

            // Returnăm setări implicite dacă nu există fișierul sau a apărut o eroare
            return new CalculatorSettings();
        }

        public static void SaveSettings(CalculatorSettings settings)
        {
            try
            {
                // Asigurăm-ne că directorul există
                string directoryPath = Path.GetDirectoryName(SettingsFilePath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                // Salvăm setările în fișier
                using (FileStream fs = new FileStream(SettingsFilePath, FileMode.Create))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(CalculatorSettings));
                    serializer.Serialize(fs, settings);
                }
            }
            catch (Exception)
            {
                // Gestionăm eroarea - putem adăuga logging aici
            }
        }
    }
}