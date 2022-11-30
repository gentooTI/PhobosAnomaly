using MySql.Data.MySqlClient;//
using Phobos.DTO;//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phobos.DAL
{
    public class UsuarioDAL:Conexao
    {
        //Create
        public void Cadastrar(UsuarioDTO objCad)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("INSERT INTO usuario (NomeUsuario, EmailUsuario, SenhaUsuario, DataNascUsuario, UsuarioTp) VALUES (@NomeUsuario, @EmailUsuario, @SenhaUsuario, @DataNascUsuario, @UsuarioTp)", conn);
                cmd.Parameters.AddWithValue("@NomeUsuario", objCad.NomeUsuario);
                cmd.Parameters.AddWithValue("@EmailUsuario",objCad.EmailUsuario);
                cmd.Parameters.AddWithValue("@SenhaUsuario", objCad.SenhaUsuario);
                cmd.Parameters.AddWithValue("@DataNascUsuario", objCad.DataNascUsuario);
                cmd.Parameters.AddWithValue("@UsuarioTp", objCad.UsuarioTp);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception ("Erro ao cadastrar"+ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //read
        public List<UsuarioListDTO> Listar()
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("SELECT NomeUsuario,EmailUsuario,Descricao FROM usuario INNER JOIN TipoUsuario ON usuario.UsuarioTp = TipoUsuario.idTipoUsuario",conn);
                dr = cmd.ExecuteReader();
                //ponteiro - lista vazia
                List<UsuarioListDTO> Lista = new List<UsuarioListDTO> ();
                while (dr.Read())
                {
                    UsuarioListDTO obj = new UsuarioListDTO();
                    obj.NomeUsuario = dr["NomeUsuario"].ToString();
                    obj.EmailUsuario = dr["EmailUsuario"].ToString();
                    obj.Descricao = dr["Descricao"].ToString();

                    //adiciar a lista
                    Lista.Add(obj);
                }
                return Lista;

            }
            catch (Exception ex)
            {

                throw new Exception ("Erro ao listar registros"+ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Update
        public void Editar(UsuarioDTO objEdit)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("UPDATE usuario SET NomeUsuario = @NomeUsuario, EmailUsuario = @EmailUsuario, SenhaUsuario = @SenhaUsuario, DataNascUsuario = @DataNascUsuario, UsuarioTp = @UsuarioTp WHERE idUsuario = @idUsuario", conn);
                cmd.Parameters.AddWithValue("@NomeUsuario",objEdit.NomeUsuario);
                cmd.Parameters.AddWithValue("@EmailUsuario",objEdit.EmailUsuario);
                cmd.Parameters.AddWithValue("@SenhaUsuario",objEdit.SenhaUsuario);
                cmd.Parameters.AddWithValue("@DataNascUsuario",objEdit.DataNascUsuario);
                cmd.Parameters.AddWithValue("@UsuarioTp",objEdit.UsuarioTp);
                cmd.Parameters.AddWithValue("@idUsuario",objEdit.idUsuario);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception ("Erro ao editar o usuario"+ex.Message);
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
                cmd = new MySqlCommand ("DELETE FROM usuario WHERE idUsuario = @idUsuario", conn);
                cmd.Parameters.AddWithValue("@idUsuario", objDel);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception ("Erro ao eliminar registro" +ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Autenticar
        public UsuarioAutenticaDTO Autenticar(string objNome, string objSenha)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("SELECT `NomeUsuario`, `SenhaUsuario`, `UsuarioTp` FROM usuario WHERE NomeUsuario = @NomeUsuario AND SenhaUsuario = @SenhaUsuario", conn);
                cmd.Parameters.AddWithValue("NomeUsuario",objNome);
                cmd.Parameters.AddWithValue("@SenhaUsuario",objSenha);
                dr = cmd.ExecuteReader();
                UsuarioAutenticaDTO obj = null;
                if (dr.Read())
                {
                obj = new UsuarioAutenticaDTO();
                obj.NomeUsuario = dr["NomeUsuario"].ToString();
                obj.SenhaUsuario = dr["SenhaUsuario"].ToString();
                obj.UsuarioTp = Convert.ToInt32 (dr["UsuarioTp"]);

                }
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception ("Usuario não cadastrado"+ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //BuscarporID
        public UsuarioDTO BuscarPorId(int idUsuario)
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("SELECT * FROM `usuario` WHERE idUsuario = @idUsuario", conn);
                cmd.Parameters.AddWithValue("idUsuario", idUsuario);
                dr = cmd.ExecuteReader();
                UsuarioDTO obj = null;
                if (dr.Read())
                {
                    obj = new UsuarioDTO();
                    obj.idUsuario = Convert.ToInt32(dr["idUsuario"]);
                    obj.NomeUsuario = dr["NomeUsuario"].ToString();
                    obj.EmailUsuario = dr["EmailUsuario"].ToString();
                    obj.SenhaUsuario = dr["SenhaUsuario"].ToString();
                    obj.DataNascUsuario = dr["DataNascUsuario"].ToString();
                    obj.UsuarioTp = dr["UsuarioTp"].ToString();
                }
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception ("Erro ao buscar usuario"+ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Litar Admin
        //read
        public List<UsuarioDTO> ListarAdmin()
        {
            try
            {
                Conectar();
                cmd = new MySqlCommand("SELECT idUsuario,NomeUsuario,SenhaUsuario,EmailUsuario,DataNascUsuario,Descricao FROM usuario INNER JOIN TipoUsuario ON usuario.UsuarioTp = TipoUsuario.idTipoUsuario", conn);
                dr = cmd.ExecuteReader();
                //ponteiro - lista vazia
                List<UsuarioDTO> Lista = new List<UsuarioDTO>();
                while (dr.Read())
                {
                    UsuarioDTO obj = new UsuarioDTO();
                    obj.idUsuario = Convert.ToInt32(dr["idUsuario"]);
                    obj.NomeUsuario = dr["NomeUsuario"].ToString();
                    obj.EmailUsuario = dr["EmailUsuario"].ToString();
                    obj.SenhaUsuario = dr["SenhaUsuario"].ToString();
                    obj.DataNascUsuario = Convert.ToDateTime(dr["DataNascUsuario"]).ToString("dd/MM/yyyy");
                    obj.UsuarioTp = dr["Descricao"].ToString();

                    //adiciar a lista
                    Lista.Add(obj);
                }
                return Lista;

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao listar registros" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
    }
}
