using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habbop.LevelSystem.Dados
{
    public static class UsuarioDado
    {


        private static List<UsuarioDados> accounts;

        private static string accountsFile = "arquivos/conta.json";
        static UsuarioDado()
        {
            if(DataStorage.SaveExists(accountsFile))
            {
                accounts = DataStorage.LoadUserAccounts(accountsFile).ToList();
            }
            else
            {
                accounts = new List<UsuarioDados>();
                SaveAccounts();
            }

        }

        public static void SaveAccounts()
        {
            DataStorage.SaveUserAccount(accounts, accountsFile);
        }
        public static UsuarioDados GetUsuarioDados(SocketUser user)
        {
            return GetUsuarios(user.Id);
            
        }

        private static UsuarioDados GetUsuarios(ulong id)
        {
            var resultado = from a in accounts where a.ID == id select a;
            var account = resultado.FirstOrDefault();
            if(account == null) account = CreateUserAccount(id);
            return account;

        }
        private static UsuarioDados CreateUserAccount(ulong id)
        {
            var newAccount = new UsuarioDados()
            {
                ID = id,
                Points = 0,
                XP = 0
            };

            accounts.Add(newAccount);
            SaveAccounts();
            return newAccount;
        }
    }
}
