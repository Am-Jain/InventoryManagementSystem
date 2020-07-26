using System.Collections.Generic;

namespace BusinessLayer
{
    public interface IFileReader
    {
        List<string> ReadYamlFile(string FilePath);

        List<string> ReadJsonFile(string FilePath);

        //List<string> ReadExcelFile(string FilePath);

        //List<string> ReadCsvFile(string FilePath);
    }
}