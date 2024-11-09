using Microsoft.Win32;
using ServeAll.Core.Helper;
using System;

namespace Inventory.Utilities
{
    public static class RegistryHelper
    {
        private const string PassPhrase = "YourSecurePassPhrase"; // Use a secure passphrase

        /// <summary>
        /// Writes an encrypted value to the Windows Registry.
        /// </summary>
        public static void WriteEncryptedValue(string subKey, string keyName, string keyValue)
        {
            try
            {
                var encryptedValue = StringCipher.Encrypt(keyValue, PassPhrase);
                using (var key = Registry.CurrentUser.CreateSubKey(subKey))
                {
                    key?.SetValue(keyName, encryptedValue, RegistryValueKind.String);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to registry: {ex.Message}");
            }
        }

        /// <summary>
        /// Reads and decrypts a value from the Windows Registry.
        /// </summary>
        public static string ReadDecryptedValue(string subKey, string keyName)
        {
            try
            {
                using (var key = Registry.CurrentUser.OpenSubKey(subKey))
                {
                    if (key != null)
                    {
                        var encryptedValue = key.GetValue(keyName)?.ToString();
                        return encryptedValue != null
                            ? StringCipher.Decrypt(encryptedValue, PassPhrase)
                            : null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading from registry: {ex.Message}");
            }
            return null;
        }

        /// <summary>
        /// Increments the stored integer value in the registry by 1.
        /// </summary>
        public static void IncrementRegistryValue(string subKey, string keyName)
        {
            try
            {
                var currentValue = ReadDecryptedValue(subKey, keyName);
                if (int.TryParse(currentValue, out var number))
                {
                    number++;
                    WriteEncryptedValue(subKey, keyName, number.ToString());
                }
                else
                {
                    // If value does not exist or is not a number, initialize it
                    WriteEncryptedValue(subKey, keyName, "1");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error incrementing registry value: {ex.Message}");
            }
        }
    }
}
