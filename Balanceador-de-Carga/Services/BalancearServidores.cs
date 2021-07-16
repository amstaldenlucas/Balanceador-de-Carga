using Balanceador_de_Carga.Models;
using System.Collections.Generic;

namespace Balanceador_de_Carga.Services
{
    class BalancearServidores
    {
        /// <summary>
        /// Distribuir/Remover os usuários nos servidores. Caso necessário, um server será removido/instanciado.
        /// </summary>
        /// <param name="servidoresOnline">Lista contendo os servidores online.</param>
        /// <param name="usuariosParaAlocar">Lista contendo os novos usuários para alocar.</param>
        /// <param name="umax">Quantidade Máxima de usuários por servidor.</param>
        /// <param name="idUser">Id usuário caso desejar.</param>
        /// <returns></returns>
        public List<Server> DistribuirUsuariosNosServidores(List<Server> servidoresOnline, List<User> usuariosParaAlocar, int umax, int idUser)
        {
            int qtdUsuariosParaAlocar = usuariosParaAlocar.Count;

            // Laço para adicionar os novos usuários enquanto existir.
            while (qtdUsuariosParaAlocar > 0)
            {
                foreach (Server item in servidoresOnline)
                {
                    // Laço para adicionar novos usuário no servidor atual até atingir o limite máximo ou então até acabar os novos usuários
                    while(item.GetQtdUsuariosAlocados() < umax && qtdUsuariosParaAlocar > 0)
                    {
                        User novoUsuario = new User(0, idUser);
                        item.adicionarUsuario(novoUsuario);

                        usuariosParaAlocar.Remove(novoUsuario);
                        qtdUsuariosParaAlocar--;
                    }
                }

                // Criar um novo servidor caso não exista nenhum disponível para alocar novos usuários
                if (qtdUsuariosParaAlocar > 0)
                {
                    List<User> listUsers = new List<User>
                    {
                        new User(0, idUser)
                    };

                    servidoresOnline.Add(new Server(servidoresOnline.Count + 1, listUsers, 1));
                    qtdUsuariosParaAlocar--;
                }
            }

            return servidoresOnline;
        }
        
        /// <summary>
        /// Deletar servidores inativos (sem usuários).
        /// </summary>
        /// <param name="servidoresOnline">Lista contendo os servidores online.</param>
        /// <param name="TTask">Quantidade Máxima de task à ser executada até o fim do ciclo do usuário.</param>
        /// <returns></returns>
        public List<Server> DeletarServidoresInativos(List<Server> servidoresOnline, int TTask = 0)
        {
            List<Server> servidoresParaDeletar = new List<Server>();

            // Percorrer os servidores online para verificar se algum já pode ser inativado.
            foreach (Server item in servidoresOnline)
            {
                DeletarUsuariosInativos(item, TTask);

                if (item.GetQtdUsuariosAlocados() == 0)
                    servidoresParaDeletar.Add(item);
            }

            // Percorrer a lista de servidores para inativar caso exista.
            for (int i = 0; i < servidoresParaDeletar.Count; i++)
            {
                servidoresOnline.Remove(servidoresParaDeletar[i]);
            }
            return servidoresOnline;
        }

        /// <summary>
        /// Deletar usuários inativos (usuários com total de tasks já executadas).
        /// </summary>
        /// <param name="servidor">Servidor para ser verificado</param>
        /// <param name="QtdTasksExecutadas">Quantidade máxima de tasks para completar o ciclo.</param>
        public void DeletarUsuariosInativos(Server servidor, int QtdTasksExecutadas)
        {
            List<User> ususariosParaDeleter = new List<User>();

            // Percorrer cada usuário e verificar se já finalizou as tasks.
            foreach (User item in servidor.UsuariosAlocados)
            {
                item.QtdTask += 1;

                if (item.QtdTask >= QtdTasksExecutadas)
                    ususariosParaDeleter.Add(item);
            }

            // Remover os usuários que já finalizam caso exista.
            for (int i = 0; i < ususariosParaDeleter.Count; i++)
            {
                servidor.RemoverUsuario(ususariosParaDeleter[i]);
            }
        }
    }
}
