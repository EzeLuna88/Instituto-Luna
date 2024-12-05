using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

namespace DAL
{
    public class Acceso
    {
        private SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionSQL"].ToString());
        private SqlCommand conexionCommand = new SqlCommand();
        private SqlTransaction transaction;

        public DataTable Leer (string consulta, Hashtable datos)
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter;
            conexionCommand = new SqlCommand(consulta, conexion);
            conexionCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                dataAdapter = new SqlDataAdapter(conexionCommand);
                if (datos != null)
                {
                    foreach (string dato in datos.Keys)
                        conexionCommand.Parameters.AddWithValue(dato, datos[dato]);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally 
            {
                conexion.Close();
            }
            dataAdapter.Fill(dataTable);
            return dataTable;

        }

        public bool Escribir (string consultaSQL, Hashtable datos)
        {
            if(conexion.State==ConnectionState.Closed)
            {
                conexion.Open();
            }
            try
            {
                
                transaction = conexion.BeginTransaction();
                SqlCommand command = new SqlCommand(consultaSQL, conexion, transaction);
                command.CommandType = CommandType.StoredProcedure;

                if (datos != null)
                {
                    foreach (string dato in datos.Keys)
                        command.Parameters.AddWithValue(dato, datos[dato]);
                }


                int respuesta = command.ExecuteNonQuery();
                transaction.Commit();
                return true;
            }
            catch (SqlException ex)
            {
                transaction.Rollback();   
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            { conexion.Close(); }
        }

        public int DevolverConteoAsistencia(string consultaSQL, Hashtable datos)
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }
            try
            {
                transaction = conexion.BeginTransaction();
                SqlCommand command = new SqlCommand(consultaSQL, conexion, transaction);
                command.CommandType = CommandType.StoredProcedure;

                if (datos != null)
                {
                    foreach (string dato in datos.Keys)
                        command.Parameters.AddWithValue(dato, datos[dato]);
                }

                int respuesta = Convert.ToInt32(command.ExecuteScalar());
                transaction.Commit();
                return respuesta;
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }


        public bool EscribirYDevolverCodigo(string consultaSQL, Hashtable datos, out int nuevoCodigo)
        {
            nuevoCodigo = 0;

            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }
            try
            {

                transaction = conexion.BeginTransaction();
                SqlCommand command = new SqlCommand(consultaSQL, conexion, transaction);
                command.CommandType = CommandType.StoredProcedure;

                // Agregar parámetro de salida para el nuevo Codigo
                SqlParameter parametroNuevoCodigo = new SqlParameter("@NuevoCodigo", SqlDbType.Int);
                parametroNuevoCodigo.Direction = ParameterDirection.Output;
                command.Parameters.Add(parametroNuevoCodigo);
                
                if (datos != null)
                {
                    foreach (string dato in datos.Keys)
                        command.Parameters.AddWithValue(dato, datos[dato]);
                }


                int respuesta = command.ExecuteNonQuery();
                nuevoCodigo = (int)parametroNuevoCodigo.Value;

                transaction.Commit();
                return true;
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            { conexion.Close(); }
        }

        public bool LeerScalar(string consulta)
        {
            conexion.Open();
            //uso el constructor del objeto Command
            SqlCommand cmd = new SqlCommand(consulta, conexion);
            cmd.CommandType = CommandType.Text;
            try
            {
                int Respuesta = Convert.ToInt32(cmd.ExecuteScalar());
                conexion.Close();
                if (Respuesta > 0)
                { return true; }
                else
                { return false; }
            }
            catch (SqlException ex)
            { throw ex; }
        }

       

        public DataSet LeerPruebaUsuarioDespuesBorrar(string consulta)
        {
            DataSet dataSet = new DataSet();
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(consulta, conexion);
                dataAdapter.Fill(dataSet);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return dataSet;

        }

       
    }
}
