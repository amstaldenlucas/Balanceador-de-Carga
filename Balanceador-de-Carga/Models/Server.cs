using System;
using System.Collections.Generic;
using System.Text;

namespace Balanceador_de_Carga.Models
{
    class Server
    {
        public Server(int idServidor, List<User> usuariosAlocados, int ticksAtivos)
        {
            IdServidor = idServidor;
            this.usuariosAlocados = usuariosAlocados;
            this.ticksAtivos = ticksAtivos;
        }

        private int IdServidor { get; set; }

        private List<User> usuariosAlocados;

        public List<User> UsuariosAlocados
        {
            get { return usuariosAlocados; }
            set { usuariosAlocados = value; }
        }

        public int ticksAtivos { get; set; }

        public int GetQtdUsuariosAlocados()
        {
            return usuariosAlocados.Count;
        }

        public void adicionarUsuario(User usuario)
        {
            this.usuariosAlocados.Add(usuario);
        }

        public void RemoverUsuario(User usuario)
        {
            this.usuariosAlocados.Remove(usuario);
        }

        public void RemoverUsuarios(User usersParaRemover)
        {
            this.usuariosAlocados.RemoveAll(usuariosAlocados => usuariosAlocados.IdUsuario == usersParaRemover.IdUsuario);
        }
    }
}
