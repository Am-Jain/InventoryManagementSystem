using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.RepresentationModel;

namespace BusinessLayer
{
    public class FileReader : IFileReader
    {
        public List<string> ReadYamlFile(string filepath)
        {
            List<string> list = new List<string>();
            var reader = new StreamReader(filepath);
            var yaml = new YamlStream();
            yaml.Load(reader);
            var mapping = ((YamlSequenceNode)yaml.Documents[0].RootNode);

            foreach (var entry in mapping.Children)
            {
                var children = ((YamlMappingNode)entry).Children;
                foreach (var child in children)
                {
                    list.Add(((YamlScalarNode)child.Value).ToString());
                }

            }
            if (list.Count == 0)
                list.Add("No Data found in the file");
            return list;
        }

        public List<string> ReadJsonFile(string filepath)
        {
            List<string> list = new List<string>();
            using (StreamReader r = new StreamReader(filepath))
            {
                string json = r.ReadToEnd();
                var list1 = (JObject)JsonConvert.DeserializeObject(json);
                foreach (JObject item in list1["products"])
                {
                    if ((item.Count != 0))
                    {
                        if(item["categories"] != null)
                        list.Add(string.Join(",", item["categories"]));
                        if (item["twitter"] != null)
                            list.Add(item["twitter"].ToString());
                        if (item["title"] != null)
                            list.Add(item["title"].ToString());
                    }
                }
            }
            if (list.Count == 0)
                list.Add("No Data found in the file");
            return list;
        }

        //public void ReadExcelFile(string filepath)
        //{

        //}

        //public void ReadCsvFile(string filepath)
        //{
        //}

    }
}

