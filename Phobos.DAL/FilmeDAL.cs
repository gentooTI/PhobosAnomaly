using MySql.Data.MySqlClient;
using Phobos.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Phobos.DAL
{
    public class FilmeDAL : Conexao
    {
        //Create
        public void Cadastrar(FilmeDTO objCad)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("INSERT INTO filme(titulo, genero, produtora, urlImagem, idClassificacao) VALUES (@titulo, @genero, @produtora, @urlImagem, @idClassificacao)", conn);
                cmd.Parameters.AddWithValue("@titulo", objCad.Titulo);
                cmd.Parameters.AddWithValue("@genero", objCad.Genero);
                cmd.Parameters.AddWithValue("@produtora", objCad.Produtora);
                cmd.Parameters.AddWithValue("@urlImagem", objCad.UrlImagem);
                cmd.Parameters.AddWithValue("@idClassificacao", objCad.idClassificacao);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao cadastrar filme" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Read
        public List<FilmeListDTO> Listar()
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("SELECT `titulo`, `genero`, `produtora`, `urlImagem`, `descricao` FROM `filme` INNER JOIN `classificacao` ON filme.idClassificacao = classificacao.idClassificacao", conn);
                dr = cmd.ExecuteReader();
                //ponteiro - Lista vazia
                List<FilmeListDTO> Lista = new List<FilmeListDTO>();
                while (dr.Read())
                {
                    FilmeListDTO obj = new FilmeListDTO();
                    obj.Titulo = dr["titulo"].ToString();
                    obj.Genero = dr["genero"].ToString();
                    obj.Produtora = dr["produtora"].ToString();
                    obj.UrlImagem = dr["urlImagem"].ToString();
                    obj.Descricao = dr["descricao"].ToString();

                    //Adiciar a lista
                    Lista.Add(obj);
                }
                return Lista;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao listar os filmes" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Update
        public void Editar(FilmeDTO objEdit)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("UPDATE filme SET titulo = @titulo,genero = @genero,produtora = @produtora,@urlImagem = @urlImagem,idClassificacao = @idClassificacao WHERE idFilme = @idFilme", conn);
                cmd.Parameters.AddWithValue("@titulo", objEdit.Titulo);
                cmd.Parameters.AddWithValue("@genero", objEdit.Genero);
                cmd.Parameters.AddWithValue("@produtora", objEdit.Produtora);
                cmd.Parameters.AddWithValue("@urlImagem", objEdit.UrlImagem);
                cmd.Parameters.AddWithValue("@idClassificacao", objEdit.idClassificacao);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao editar o filme" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Delete
        public void Excluir(int objDel)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("DELETE FROM filme WHERE idFilme = @idFilme", conn);
                cmd.Parameters.AddWithValue("@idUsuario", objDel);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao eliminar registro" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //BscarporID
        public FilmeDTO BuscarporId(int idFilme)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("SELECT * FROM filme WHERE idFilme = @idFilme", conn);
                cmd.Parameters.AddWithValue("idFilme", idFilme);
                dr = cmd.ExecuteReader();
                FilmeDTO obj = null;
                if (dr.Read())
                {
                    obj = new FilmeDTO();
                    obj.idFilme = Convert.ToInt32(dr["idUsuario"]);
                    obj.Titulo = dr["titulo"].ToString();
                    obj.Genero = dr["genero"].ToString();
                    obj.Produtora = dr["produtora"].ToString();
                    obj.UrlImagem = dr["urlImagem"].ToString();
                    obj.idClassificacao = dr["idClassificacao"].ToString();
                }
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao buscar filme" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        //Listar Admin
        public List<FilmeDTO> ListarFilmeAdmin()
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("SELECT idFilme,titulo, genero, produtora, urlImagem, descricao FROM Filme INNER JOIN Classificacao ON filme.idClassificacao = classificacao.idClassificacao", conn);
                dr = cmd.ExecuteReader();
                //ponteiro - lista vazia
                List<FilmeDTO> Lista = new List<FilmeDTO>();
                while (dr.Read())
                {
                    FilmeDTO obj = new FilmeDTO();
                    obj.idFilme = Convert.ToInt32(dr["idFilme"]);
                    obj.Titulo = dr["titulo"].ToString();
                    obj.Genero = dr["genero"].ToString();
                    obj.Produtora = dr["produtora"].ToString();
                    obj.UrlImagem = dr["urlImagem"].ToString();
                    obj.idClassificacao = dr["descricao"].ToString();

                    //adiciar a lista
                    Lista.Add(obj);
                }
                return Lista;

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao listar registros !!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

    }
}
