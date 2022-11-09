using Microsoft.Win32;
using Phobos.DAL;
using Phobos.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phobos.BLL
{
    public class UsuarioBLL
    {
        //objeto global
        UsuarioDAL objBLL = new UsuarioDAL();
        //Create
        public void CadastrarUser(UsuarioDTO objCadUser)
        {
            objBLL.Cadastrar(objCadUser);
        }

        //Read
        public List<UsuarioListDTO> ListaUsuario()
        {
            return objBLL.Listar();
        }
        //Update
        public void EditUser(UsuarioDTO objEdit)
        {
            objBLL.Editar(objEdit);
        }

        //Delete
        public void DeleteUser(int objDelete)
        {
            objBLL.Excluir(objDelete);
        }

        //Autenticar
        public UsuarioAutenticaDTO AutenticaUsuario(string objNome, string objSenha)
        {
            UsuarioAutenticaDTO user = objBLL.Autenticar(objNome, objSenha);
            if (user != null)
            {
                return user;
            }
            else
            {
                throw new Exception("Deu Problema BLL");
            }
        }

        //SelectById
        public UsuarioDTO SelectByDTO(int objModelo)
        {
            return objBLL.BuscarPorId(objModelo);
        }

    }
}
