using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;   //Acceso a bd SQLServer 
using System.Data.OleDb;       //Acceso a bd Access
using System.Data;

namespace wed
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //Variables globales
        public string cadena_conexion = "Data Source=Gustavocerna;Initial Catalog=Biblioteca_original;Integrated Security=True";

        //Estas variables pueden ir en el boton que corresponde
        //Pero es mas efectivo que sean publicas globales
        public string usuario_modificar;
        public string usuario_eliminar;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Desabilitar campos, se activan al crear nuevo registro
            txtusuario.Enabled = false;
            txtclave.Enabled = false;
            //lstnivel.Enabled = false;

            try
            {

                string consulta = "select * from F_usuario";

                SqlConnection conexion = new SqlConnection(cadena_conexion);
                SqlDataAdapter comando = new SqlDataAdapter(consulta, conexion);

                System.Data.DataSet ds = new System.Data.DataSet();
                comando.Fill(ds, "Biblioteca_original");
                GridView1.DataSource = ds;
                GridView1.DataMember = "Biblioteca_original";

            }
            catch (SqlException)
            {

                // MessageBox.Show("Error de conexion", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        protected void bnuevo_Click(object sender, EventArgs e)
        {
            txtusuario.Enabled = true;
            txtclave.Enabled = true;
            lstnivel.Enabled = true;
            txtusuario.Text = "";
            txtclave.Text = "";
            lstnivel.Text = "Seleccione nivel";
            txtusuario.Focus();
            bnuevo.Visible = false;
            bguardar.Visible = true;
        }

        protected void bguardar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection myConnection = new SqlConnection(cadena_conexion);

                string myInsertQuery = "INSERT INTO F_usuario(nombre,clave,nivel) Values(?nombre,?clave,?nivel)";
                SqlCommand myCommand = new SqlCommand(myInsertQuery);

                myCommand.Parameters.Add("?nombre", SqlDbType.VarChar, 75).Value = txtusuario.Text;
                myCommand.Parameters.Add("?clave", SqlDbType.VarChar, 75).Value = txtclave.Text;
                myCommand.Parameters.Add("?nivel", SqlDbType.Int, 11).Value = lstnivel.Text;

                myCommand.Connection = myConnection;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myCommand.Connection.Close();

                //MessageBox.Show("Usuario agregado con éxito", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string consulta = "select * from F_usuario";

                SqlConnection conexion = new SqlConnection(cadena_conexion);
                SqlDataAdapter da = new SqlDataAdapter(consulta, conexion);
                System.Data.DataSet ds = new System.Data.DataSet();
                da.Fill(ds, "Biblioteca_original");
                GridView1.DataSource = ds;
                GridView1.DataMember = "Biblioteca_original";

            }
            catch (SqlException)
            {
                //MessageBox.Show("Ya existe el usuario", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            bnuevo.Visible = true;
            bguardar.Visible = false;

            //Desabilitar campos, se activan al crear nuevo registro
            txtusuario.Enabled = false;
            txtclave.Enabled = false;
            lstnivel.Enabled = false;
            bnuevo.Focus();

        }

        protected void bmodificar_Click(object sender, EventArgs e)
        {
            txtusuario.Enabled = true;
            txtclave.Enabled = true;
            lstnivel.Enabled = true;

            txtusuario.Focus();

            bmodificar.Visible = false;
            bactualizar.Visible = true;

            usuario_modificar = txtusuario.Text.ToString();
        }

        protected void bactualizar_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection myConnection = new SqlConnection(cadena_conexion);

                string nom = txtusuario.Text.ToString();
                string cla = txtclave.Text.ToString();
                string niv = lstnivel.Text;

                //Hay dos formas de pasar los valores

                //Primera forma de pasar los valores
                //string myInsertQuery = "UPDATE usuarios SET nombre = ?nombre, clave = ?clave, nivel = ?nivel Where nombre = " + usuario_modificar + "";

                //Segunda forma de pasar los valores, usaremos esto
                string myInsertQuery = "UPDATE F_usuario SET nombre = '" + nom + "', clave = '" + cla + "',nivel = '" + niv + "' WHERE nombre = '" + usuario_modificar + "'";

                SqlCommand myCommand = new SqlCommand(myInsertQuery);

                //En caso de usar primera forma, se pasan estos parámetros.
                //myCommand.Parameters.Add("?nombre", MySqlDbType.VarChar, 75).Value = txtusuario.Text;
                //myCommand.Parameters.Add("?clave", MySqlDbType.VarChar, 75).Value = txtclave.Text;
                //myCommand.Parameters.Add("?nivel", MySqlDbType.Int32, 11).Value = lstnivel.Text;

                myCommand.Connection = myConnection;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myCommand.Connection.Close();

                // MessageBox.Show("Usuario modificado con éxito", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string consulta = "select * from F_usuario";

                SqlConnection conexion = new SqlConnection(cadena_conexion);
                SqlDataAdapter da = new SqlDataAdapter(consulta, conexion);
                System.Data.DataSet ds = new System.Data.DataSet();
                da.Fill(ds, "Biblioteca_original");
                GridView1.DataSource = ds;
                GridView1.DataMember = "Biblioteca_original";

            }
            catch (SqlException)
            {
                //MessageBox.Show("Error al modificar el usuario", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            bmodificar.Visible = true;
            bactualizar.Visible = false;

            //Desabilitar campos, se activan al crear nuevo registro
            txtusuario.Enabled = false;
            txtclave.Enabled = false;
            lstnivel.Enabled = false;
            bmodificar.Focus();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {

            try
            {

                SqlConnection myConnection = new SqlConnection(cadena_conexion);

                string myInsertQuery = "select * from F_usuario Where idusuario = " + txtbuscar.Text + "";
                SqlCommand myCommand = new SqlCommand(myInsertQuery, myConnection);

                myCommand.Connection = myConnection;
                myConnection.Open();

                SqlDataReader myReader;
                myReader = myCommand.ExecuteReader();

                if (myReader.Read())
                {
                    txtusuario.Text = (myReader.GetString(1));
                    txtclave.Text = (myReader.GetString(2));
                    lstnivel.Text = (myReader.GetString(3));
                }
                else
                {
                   // MessageBox.Show("El usuario no existe", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                myReader.Close();
                myConnection.Close();

            }
            catch (SqlException)
            {
               // MessageBox.Show("Campo de busqueda está vacío", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            bnuevo.Visible = true;
            bguardar.Visible = false;

            //Desabilitar campos, se activan al crear nuevo registro
            txtusuario.Enabled = false;
            txtclave.Enabled = false;
            lstnivel.Enabled = false;
            bmodificar.Focus();

            //Finalizada la busqueda y llenado de campos
            //guardamos el contenido de txtusuario.Text por si se quiere eliminar por medio del usuario
            //usuario_eliminar = txtusuario.Text;
        }

        protected void beliminar_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection myConnection = new SqlConnection(cadena_conexion);

                string myInsertQuery = "delete from F_usuario Where idusuario = " + txtbuscar.Text + "";
                SqlCommand myCommand = new SqlCommand(myInsertQuery);

                myCommand.Connection = myConnection;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myCommand.Connection.Close();

               // MessageBox.Show("Usuario eliminado con éxito", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);


                string consulta = "select * from F_usuario";

                SqlConnection conexion = new SqlConnection(cadena_conexion);
                SqlDataAdapter da = new SqlDataAdapter(consulta, conexion);
                System.Data.DataSet ds = new System.Data.DataSet();
                da.Fill(ds, "Biblioteca_original");
                GridView1.DataSource = ds;
                GridView1.DataMember = "Biblioteca_original";

            }
            catch (SqlException)
            {
                //MessageBox.Show("Error al eliminar el usuario, primero realice búsqueda del usuario y después puede eliminar.", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            bnuevo.Visible = true;
            bguardar.Visible = false;

            //Desabilitar campos, se activan al crear nuevo registro
            txtusuario.Enabled = false;
            txtclave.Enabled = false;
            lstnivel.Enabled = false;

            txtusuario.Text = "";
            txtclave.Text = "";
            lstnivel.Text = "Seleccione nivel";
            txtbuscar.Focus();
        }
    }
}
