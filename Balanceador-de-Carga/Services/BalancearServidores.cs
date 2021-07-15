using Balanceador_de_Carga.Models;
using System.Collections.Generic;

namespace Balanceador_de_Carga.Services
{
    class BalancearServidores
    {
        const int TTASK = 4;
        public List<Server> DistribuirUsuariosNosServidores(List<Server> servidoresOnline, List<User> usuariosParaAlocar, int umax, int idUser)
        {
            int qtdUsuariosParaAlocar = usuariosParaAlocar.Count;

            while (qtdUsuariosParaAlocar > 0)
            {
                foreach (Server item in servidoresOnline)
                {
                    //if (item.GetQtdUsuariosAlocados() < umax)
                    //{
                    //    User novoUsuario = new User(0, idUser);
                    //    item.adicionarUsuario(novoUsuario);

                    //    usuariosParaAlocar.Remove(novoUsuario);
                    //    qtdUsuariosParaAlocar--;
                    //}

                    while(item.GetQtdUsuariosAlocados() < umax && qtdUsuariosParaAlocar > 0)
                    {
                        User novoUsuario = new User(0, idUser);
                        item.adicionarUsuario(novoUsuario);

                        usuariosParaAlocar.Remove(novoUsuario);
                        qtdUsuariosParaAlocar--;
                    }
                    
                    //if (item.GetQtdUsuariosAlocados() < umax && qtdUsuariosParaAlocar > 0)
                    //{
                    //    User novoUsuario = new User(0, idUser);
                    //    item.adicionarUsuario(novoUsuario);

                    //    usuariosParaAlocar.Remove(novoUsuario);
                    //    qtdUsuariosParaAlocar--;
                    //}
                }

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

        public List<Server> DeletarServidoresInativos(List<Server> servidoresOnline)
        {
            List<Server> servidoresParaDeletar = new List<Server>();
            foreach (Server item in servidoresOnline)
            {
                DeletarUsuariosInativos(item, TTASK);

                if (item.GetQtdUsuariosAlocados() == 0)
                    servidoresParaDeletar.Add(item);
            }

            for (int i = 0; i < servidoresParaDeletar.Count; i++)
            {
                servidoresOnline.Remove(servidoresParaDeletar[i]);
            }
            return servidoresOnline;
        }

        private void DeletarUsuariosInativos(Server servidor, int QtdTasksExecutadas)
        {
            List<User> ususariosParaDeleter = new List<User>();

            foreach (User item in servidor.UsuariosAlocados)
            {
                item.QtdTask += 1;

                if (item.QtdTask >= QtdTasksExecutadas)
                    ususariosParaDeleter.Add(item);
            }

            for (int i = 0; i < ususariosParaDeleter.Count; i++)
            {
                servidor.RemoverUsuario(ususariosParaDeleter[i]);
            }
        }
    }
}
