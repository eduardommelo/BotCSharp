using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habbop.LevelSystem.Dados
{
    public class UsuarioDados
    {



        public ulong ID { get; set; }
        public uint Points { get; set; }

        public uint XP { get; set; }

        public string missao { get; set; }

        public string cargos { get; set; }
        public uint levelNumero
        {
            get
            {
                return (uint)Math.Sqrt(XP / 500);
            }


        }

        public bool IsMuted { get; set; }

        public uint NumberOfWarning { get; set; }
    }
}
