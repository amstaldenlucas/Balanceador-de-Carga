using System.Collections.Generic;

namespace Balanceador_de_Carga.Models
{
    class Server
    {
        /// <summary>
        /// Método construtor do obj Servidor
        /// </summary>
        /// <param name="idServidor">Id caso exista</param>
        /// <param name="usuariosAlocados">Lista de usuários alocados</param>
        /// <param name="ticksAtivos">Ticks ativos</param>
        public Server(int id_Servidor, List<User> usuariosAlocados, int ticksAtivos)
        {
            idServidor = id_Servidor;
            this.usuariosAlocados = usuariosAlocados;
            this.ticksAtivos = ticksAtivos;
        }

        private int idServidor { get; set; }

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
    }
}
