using System;
using System.IO;
using System.Text.Json;
using System.Xml;
using Newtonsoft.Json;
using YamlDotNet.Serialization;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Usage: dotnet run <yamlFilePath> <jsonFilePath>");
            return;
        }

        string yamlFilePath = args[0];
        string jsonFilePath = args[1];

        try
        {
            using (var yamlInput = new FileStream(yamlFilePath, FileMode.Open, FileAccess.Read))
            using (var jsonOutput = new FileStream(jsonFilePath, FileMode.Create, FileAccess.Write))
            {
                var yamlObject = new Deserializer().Deserialize(new StreamReader(yamlInput));

                var jsonSerializer = new Newtonsoft.Json.JsonSerializer();
                jsonSerializer.Formatting = Newtonsoft.Json.Formatting.Indented;
                using (var jsonOutputStream = new StreamWriter(jsonOutput))
                {
                    jsonSerializer.Serialize(jsonOutputStream, yamlObject);
                }
            }

            Console.WriteLine($"Successfully converted {yamlFilePath} to {jsonFilePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
