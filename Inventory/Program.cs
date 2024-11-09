using System;
using System.Windows.Forms;
using Inventory.MainForm;
using Inventory.Utilities;

namespace Inventory
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            InitializeRegistryLimit();

            Application.Run(new FirmLogin());
        }
        private static void InitializeRegistryLimit()
        {
            const string subKey = @"Software\com\pos\wizard\limit";
            const string keyName = "regWizard";

            // Check if the value is already set in the registry
            var currentLimit = RegistryHelper.ReadDecryptedValue(subKey, keyName);

            // If the value is not set, initialize it
            if (string.IsNullOrEmpty(currentLimit))
            {
                RegistryHelper.WriteEncryptedValue(subKey, keyName, "20");
                Console.WriteLine("Registry limit initialized to 20.");
            }
            else
            {
                Console.WriteLine($"Registry limit is already set to {currentLimit}.");
            }
        }
    }
}