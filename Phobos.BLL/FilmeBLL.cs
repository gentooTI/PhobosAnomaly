using Phobos.DTO;
using Phobos.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phobos.BLL
{
    public class FilmeBLL
    {
        //objeto global
        FilmeDAL objBLL = new FilmeDAL();
        //Create
        public void CadastrarFilme(FilmeDTO objCadFilme)
        {
            objBLL.Cadastrar(objCadFilme);
        }
        //Read
        public List<FilmeListDTO> ListaFilme()
        {
            return objBLL.Listar();
        }
        //Update
        public void EditFilme(FilmeDTO objEdit)
        {
            objBLL.Editar(objEdit);
        }
        //Delete
        public void DeleteFilme(int objDelete)
        {
            objBLL.Excluir(objDelete);
        }
        //SelectById
        public FilmeDTO SelectByDTO(int objModelo)
        {
            return objBLL.BuscarporId(objModelo);
        }
    }
}
