namespace ServeAll.Core.Helper
{
    using Microsoft.Win32;
    using System;

    public class RegistryHelper
    {
        public static bool WriteToRegistry(string subKeyPath, string keyName, object value)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(subKeyPath))
                {
                    if (key != null)
                    {
                        key.SetValue(keyName, value);
                        Console.WriteLine("Value written successfully.");
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing to the registry: " + ex.Message);
            }
            return false;
        }


        // Method to read from the registry
        public static string ReadFromRegistry(string subKeyPath, string keyName)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(subKeyPath))
                {
                    if (key != null)
                    {
                        object value = key.GetValue(keyName);
                        return value.ToString() ?? "";
                    }
                    else
                    {
                        return "";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading from the registry: " + ex.Message);
                return "";
            }
        }
    }
}
