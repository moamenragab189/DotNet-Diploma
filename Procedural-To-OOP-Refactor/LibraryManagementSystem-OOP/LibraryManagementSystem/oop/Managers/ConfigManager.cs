using System;

public class ConfigManager
{
    public string SystemName = "Console Library Management System 1.0";
    public bool IsMaintenanceMode = false;
    private static ConfigManager instance;
    Database database = Database.Getinstance();
   private  ConfigManager() { }
    public static ConfigManager GetInstance()
    {
        if (instance==null)
        {
            instance = new ConfigManager();
            return instance;
        }
        return instance;
    }
    public bool UpdateConfiguration(string settingKey, string newValue)
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
                database.DefaultLoanDays = days;
                return true;
            }
            return false;
        }
        return false;
    }

    public void DisplayCurrentConfig()
    {
        Console.WriteLine($"Name: {SystemName}");
        Console.WriteLine($"Maintenance Mode: {IsMaintenanceMode}");
        Console.WriteLine($"Default Loan Days: {database.DefaultLoanDays}");
        Console.WriteLine("-----------------------------------------------------");
    }
}