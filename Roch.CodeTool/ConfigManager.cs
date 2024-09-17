using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class ConfigManager
{
    private readonly string _configFilePath;
    private Dictionary<string, object> _configData;

    // 构造函数，初始化配置文件路径和数据
    public ConfigManager(string fileName = "config.json")
    {
        _configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
        _configData = new Dictionary<string, object>();

        if (File.Exists(_configFilePath))
        {
            LoadConfig();
        }
        else
        {
            SaveConfig();
        }
    }

    // 加载配置文件
    private void LoadConfig()
    {
        try
        {
            string json = File.ReadAllText(_configFilePath);
            _configData = JsonConvert.DeserializeObject<Dictionary<string, object>>(json) ?? new Dictionary<string, object>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"加载配置文件时出错: {ex.Message}");
        }
    }

    // 保存配置文件
    private void SaveConfig()
    {
        try
        {
            string json = JsonConvert.SerializeObject(_configData, Formatting.Indented);
            File.WriteAllText(_configFilePath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"保存配置文件时出错: {ex.Message}");
        }
    }

    // 添加或更新配置项
    public void SetConfig(string key, object value)
    {
        _configData[key] = value;
        SaveConfig();
    }

    // 获取配置项
    public T GetConfig<T>(string key, T defaultValue = default)
    {
        if (_configData.ContainsKey(key))
        {
            try
            {
                return (T)Convert.ChangeType(_configData[key], typeof(T));
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("类型转换失败");
            }
        }
        return defaultValue;
    }

    // 打印所有配置项
    public void PrintAllConfigs()
    {
        foreach (var item in _configData)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }
}
