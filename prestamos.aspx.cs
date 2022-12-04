using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace wed
{
    public partial class prestamos : System.Web.UI.Page
    {
        public string cadena_conexion = "Data Source=Gustavocerna;Initial Catalog=Biblioteca_original;Integrated Security=True";
        SqlConnection conexion = new SqlConnection("Data Source=Gustavocerna;Initial Catalog=Biblioteca_original;Integrated Security=True");
        string usuario_modificar;
        protected void Page_Load(object sender, EventArgs e)
        {
            txtusuario.Enabled = false;
            txtclave.Enabled = false;


            lblmensaje.Enabled = false;
            SqlCommand cmd = new SqlCommand("select * from usuarios", conexion);
            conexion.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            GridView1.DataSource = sdr;
            GridView1.DataBind();
            conexion.Close();
        }

        protected void bnuevo_Click(object sender, EventArgs e)
        {
            txtusuario.Enabled = true;
            txtclave.Enabled = true;
            lstnivel.Enabled = true;
            txtusuario.Text = "";
            txtclave.Text = "";
            //lstnivel.Text = "";
            txtusuario.Focus();
            bnuevo.Visible = false;
            bguardar.Visible = true;
        }

        protected void bmodifiar_Click(object sender, EventArgs e)
        {
            txtusuario.Enabled = true;
            txtclave.Enabled = true;
            lstnivel.Enabled = true;

            txtusuario.Focus();

            bmodifiar.Visible = false;
            bactualizar.Visible = true;

            usuario_modificar = txtusuario.Text.ToString();
        }

        protected void beliminar_Click(object sender, EventArgs e)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("delete from usuarios where idusuario = '" + txtbuscar.Text + "'", conexion);
            comando.ExecuteNonQuery();
            //MessageBox.Show("Registro guardado");

            txtusuario.Text = "";
            txtclave.Text = "";
            lblmensaje.Text = "El usuario fue eliminado";
            // lstnivel.Text = "";

            conexion.Close();
        }

        protected void bguardar_Click(object sender, EventArgs e)
        {
            conexion.Open();
            SqlCommand f = new SqlCommand("insert into usuarios ([nombre] ,[clave],[nivel]) VALUES ('" + txtusuario.Text + "','" + txtclave.Text + "','" + lstnivel.Text + "' ) ", conexion);
            f.ExecuteNonQuery();
            //MessageBox.Show("Registro guardado");

            txtusuario.Text = "";
            txtclave.Text = "";
            // lstnivel.Text = "";
            lblmensaje.Text = "El usuario fue guardado";
            conexion.Close();
        }

        protected void bactualizar_Click(object sender, EventArgs e)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("UPDATE usuarios SET nombre= '" + this.txtusuario.Text + "', clave= '" + this.txtclave.Text + "'WHERE idusuario=" + Convert.ToInt32(this.txtbuscar.Text + ""), conexion);
            cmd.ExecuteNonQuery();
            conexion.Close();

            try
            {
                SqlConnection myConnection = new SqlConnection(cadena_conexion);

                string nom = txtusuario.Text.ToString();
                string cla = txtclave.Text.ToString();
                string niv = lstnivel.Text;
                lblmensaje.Text = "El usuario fue actualizado";
                //Hay dos formas de pasar los valores

                string myInsertQuery = "UPDATE usuarios SET nombre = '" + nom + "', clave = '" + cla + "',nivel = '" + niv + "' WHERE nombre = '" + usuario_modificar + "'";

                SqlCommand myCommand = new SqlCommand(myInsertQuery);

                

                myCommand.Connection = myConnection;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myCommand.Connection.Close();


                string consulta = "select * from usuarios";

                SqlConnection conexion = new SqlConnection(cadena_conexion);
                SqlDataAdapter da = new SqlDataAdapter(consulta, conexion);
                System.Data.DataSet ds = new System.Data.DataSet();
                da.Fill(ds, "sistemapro1");
                //GridView1.DataSource = ds;
                //GridView1.DataMember = "sistemapro1";

            }
            catch (SqlException)
            {
                //MessageBox.Show("Error al modificar el usuario", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            bmodifiar.Visible = true;
            bactualizar.Visible = false;

            //Desabilitar campos, se activan al crear nuevo registro
            txtusuario.Enabled = false;
            txtclave.Enabled = false;
            lstnivel.Enabled = false;
            bmodifiar.Focus();
        }

        protected void bbuscar_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection myConnection = new SqlConnection(cadena_conexion);

                string myInsertQuery = "select * from usuarios Where idusuario = " + txtbuscar.Text + "";
                SqlCommand myCommand = new SqlCommand(myInsertQuery, myConnection);

                myCommand.Connection = myConnection;
                myConnection.Open();

                SqlDataReader myReader;
                myReader = myCommand.ExecuteReader();

                if (myReader.Read())
                {
                    txtusuario.Text = (myReader.GetString(1));
                    txtclave.Text = (myReader.GetString(2));
                    //lstnivel.Text = (myReader.GetString(3));

                }
                else
                {
                    //MessageBox.Show("El usuario no existe", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblmensaje.Text = "El usuario ya existe";
                }
                myReader.Close();
                myConnection.Close();

            }
            catch (SqlException)
            {
                
                //lblmensaje.Text = "Campo de busqueda está vacío";
            }

            bnuevo.Visible = true;
            bguardar.Visible = false;

            //Desabilitar campos, se activan al crear nuevo registro
            txtusuario.Enabled = false;
            txtclave.Enabled = false;
            lstnivel.Enabled = false;
            bmodifiar.Focus();
        }
    }
}