using System;

public static class ConfigManager
{
    public static string SystemName = "Console Library Management System 1.0";
    public static bool IsMaintenanceMode = false;

   
    public static bool UpdateConfiguration(string settingKey, string newValue)
    {
        if (settingKey == "SystemName")
        {
            SystemName = newValue;
            return true;
        }
        else if (settingKey == "IsMaintenanceMode")
        {
            if (bool.TryParse(newValue, out bool mode))
            {
                IsMaintenanceMode = mode;
                return true;
            }
            return false;
        }
        else if (settingKey == "DefaultLoanDays")
        {
            if (int.TryParse(newValue, out int days) && days > 0)
            {
                Database.DefaultLoanDays = days;
                return true;
            }
            return false;
        }
        return false;
    }

    public static void DisplayCurrentConfig()
    {
        Console.WriteLine($"Name: {SystemName}");
        Console.WriteLine($"Maintenance Mode: {IsMaintenanceMode}");
        Console.WriteLine($"Default Loan Days: {Database.DefaultLoanDays}");
        Console.WriteLine("-----------------------------------------------------");
    }
}