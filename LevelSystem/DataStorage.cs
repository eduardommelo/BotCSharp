using Habbop.LevelSystem.Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
namespace Habbop.LevelSystem.Dados
{
   public static  class DataStorage
    {

        public static void SaveUserAccount(IEnumerable<UsuarioDados> accounts, string filePath)
        {

            string json = JsonConvert.SerializeObject(accounts, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
   

        public static IEnumerable<UsuarioDados> LoadUserAccounts(string filePath)
        {
            if (!File.Exists(filePath)) return null;
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<UsuarioDados>>(json);

        }
        public static bool SaveExists(string filePath)
        {
            return File.Exists(filePath);
        }
    }
}
