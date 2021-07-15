using System;
using System.Collections.Generic;
using System.Text;

namespace Balanceador_de_Carga.Models
{
    class User
    {
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

        public List<User> GetUsersParaAlocar(int conteudoLinha, int ttask, int qtdTask)
        {
            List<User> users = new List<User>();
            for (int i = 0; i <conteudoLinha; i++ )
            {
                users.Add(new User(qtdTask, ttask));
            }

            return users;
        }

    }
}
