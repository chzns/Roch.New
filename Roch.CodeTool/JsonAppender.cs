using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

public class JsonAppender
{
    public static void AppendToJson(string filePath, string jsonToAdd)
    {
        // 读取原有的 JSON 文件
        string existingJson = File.ReadAllText(filePath);

        // 将原有的 JSON 字符串转换为 JObject
        JObject jsonObject = JObject.Parse(existingJson);

        // 将要添加的 JSON 字符串转换为 JObject
        JObject newJsonObject = JObject.Parse(jsonToAdd);

        // 将新对象合并到原有对象中
        foreach (var property in newJsonObject)
        {
            jsonObject.Add(property);
        }

        // 将修改后的 JSON 对象序列化为字符串
        string updatedJson = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);

        // 将更新后的 JSON 字符串写入文件
        File.WriteAllText(filePath, updatedJson);
    }
}