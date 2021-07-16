using System;
using System.Collections.Generic;
using System.Text;

namespace Balanceador_de_Carga.Models
{
    class Tick
    {
        /// <summary>
        /// Construtor base para o obj Tick
        /// </summary>
        /// <param name="idTick"></param>
        /// <param name="usuarios"></param>
        /// <param name="fimTarefa"></param>
        public Tick(int idTick, int usuarios, int fimTarefa)
        {
            IdTick = idTick;
            Usuarios = usuarios;
            FimTarefa = fimTarefa;
        }

        private int IdTick { get; set; }

        private int Usuarios { get; set; }

        private int FimTarefa { get; set; }
    }
}
