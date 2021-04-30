using MiBotica.SolPedido.AccesoDatos.Core;
using MiBotica.SolPedido.Entidades.Base;
using MiBotica.SolPedido.Entidades.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBotica.SolPedido.LogicaNegocio.Core
{
    public class UsuarioLN : BaseLN
    {
        public List<Usuario> ListaUsuarios()
        {
            try
            {
                return new UsuarioDA().ListaUsuarios();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InsertarUsuario(Usuario usuario)
        {
            // throw new NotImplementedException();

          
                //usuario.
                //throw new NotImplementedException();
               new UsuarioDA().InsertarUsuario(usuario);
          
        }

        public void EditarUsuario(int id, Usuario usuario)
        {
            new UsuarioDA().EditarUsuario(id,usuario);
        }

        public Usuario DetalleUsuario(int id)
        {
           return new UsuarioDA().DetalleUsuario(id);

        }

        public void DeleteUsuario(int id, Usuario usuario)
        {
            new UsuarioDA().DeleteUsuario(id,usuario);
        }
    }
}
