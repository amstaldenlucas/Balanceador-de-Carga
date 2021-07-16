using System;
using System.Collections.Generic;
using System.Text;

namespace Balanceador_de_Carga.Models
{
    class User
    {
        /// <summary>
        /// Método construtor para o usuário
        /// </summary>
        /// <param name="qtdTask">Qtd de tasks executadas</param>
        /// <param name="idUsuario">Id Usuário</param>
        public User(int qtdTask, int idUsuario = 0)
        {
            IdUsuario = idUsuario;
            this.qtdTask = qtdTask;
        }

        public int IdUsuario { get; set; }

        private int qtdTask;
        public int QtdTask
        {
            get { return qtdTask; }
            set { qtdTask = value; }
        }
    }
}
