using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace wed
{
    public partial class prestamoss : System.Web.UI.Page
    {

        public string cadena_conexion = "Data Source=Gustavocerna;Initial Catalog=Libros;Integrated Security=True";
        SqlConnection conexion = new SqlConnection("Data Source=Gustavocerna;Initial Catalog=Libros;Integrated Security=True");
         string usuario_modificar;
        protected void Page_Load(object sender, EventArgs e)
        {
            txtautor.Enabled = false;
            txtcategoria.Enabled = false;
            txteditorial.Enabled = false;
            txtstan.Enabled = false;
            txtisbm.Enabled = false;
            txtlibro.Enabled = false;
            txtobservaciones.Enabled = false;

            lblmensaje.Enabled = false;
            SqlCommand cmd = new SqlCommand("select * from libros", conexion);
            conexion.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            GridView1.DataSource = sdr;
            GridView1.DataBind();
            conexion.Close();

        }

        protected void bnuevo_Click(object sender, EventArgs e)
        {
            txtautor.Enabled = true;
            txtcategoria.Enabled = true;
            txteditorial.Enabled = true;
            txtisbm.Enabled = true;
            txtlibro.Enabled = true;
            txtstan.Enabled = true;
            txtobservaciones.Enabled = true;
            txtlibro.Text="";
            txtautor.Text = "";
            txtcategoria.Text = "";
            txteditorial.Text = "";
            txtisbm.Text = "";
            txtobservaciones.Text = "";
            txtlibro.Focus();
            bnuevo.Visible = false;
            bguardar.Visible = true;
        }

        protected void bmodificar_Click(object sender, EventArgs e)
        {
            txtautor.Enabled = true;
            txtcategoria.Enabled = true;
            txteditorial.Enabled = true;
            txtisbm.Enabled = true;
            txtlibro.Enabled = true;
            txtstan.Enabled = true;
            txtobservaciones.Enabled = true;
            
            txtlibro.Focus();

            bmodificar.Visible = false;
            bactualizar.Visible = true;

            usuario_modificar = txtlibro.Text.ToString();
        }

        protected void beliminar_Click(object sender, EventArgs e)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("delete from libros where idlibros= '" + txtbuscar.Text + "'", conexion);
            comando.ExecuteNonQuery();


            txtlibro.Text = "";
            txtautor.Text = "";
            txtcategoria.Text = "";
            txteditorial.Text = "";
            txtstan.Text = "";
            txtisbm.Text = "";
            txtobservaciones.Text = "";
            lblmensaje.Text = "El usuario fue eliminado";
            

            conexion.Close();
        }

        protected void bguardar_Click(object sender, EventArgs e)
        {

            conexion.Open();
            SqlCommand f = new SqlCommand("insert into libros ([libro] ,[autor],[categoria],[editorial],[isbm],[observaciones],[estante]) VALUES ('" + txtlibro.Text + "','" + txtautor.Text + "','" + txtcategoria.Text + "','" + txteditorial.Text + "','" + txtisbm.Text + "','" + txtobservaciones.Text + "','" + txtstan.Text + "' ) ", conexion);
            f.ExecuteNonQuery();


            txtlibro.Text = "";
            txtautor.Text = "";
            txtcategoria.Text = "";
            txteditorial.Text = "";
            txtisbm.Text = "";
            txtobservaciones.Text = "";
            lblmensaje.Text = "El usuario fue guardado";
            conexion.Close();
        }

        protected void bactualizar_Click(object sender, EventArgs e)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("UPDATE libros SET libro = '" + this.txtlibro.Text + "', categoria= '" + this.txtcategoria.Text + "', editorial= '" + this.txteditorial.Text + "', isbm= '" + this.txtisbm.Text + "', autor= '" + this.txtautor.Text + "', observaciones= '" + this.txtobservaciones.Text + "', estante= '" + this.txtstan.Text + "'WHERE idlibros=" + Convert.ToInt32(this.txtbuscar.Text + ""), conexion);
            cmd.ExecuteNonQuery();
            conexion.Close();

            try
            {
                SqlConnection myConnection = new SqlConnection(cadena_conexion);

                string lbo = txtlibro.Text.ToString();
                string ctg = txtcategoria.Text.ToString();
                string etl = txteditorial.Text.ToString();
                string bm = txtisbm.Text.ToString();
                string cla = txtautor.Text.ToString();
                string tan = txtstan.Text.ToString();
                string obs = txtobservaciones.Text.ToString();

                lblmensaje.Text = "El usuario fue actualizado";
               

                string myInsertQuery = "UPDATE libros SET libro= '" + lbo + "', categoria = '" + ctg + "',editorial = '" + etl + "',isbm = '" + etl + "',estante = '" + tan + "',autor = '" + cla + "',observaciones = '" + obs + "' WHERE libro= '" + usuario_modificar + "'";

                SqlCommand myCommand = new SqlCommand(myInsertQuery);

                
                myCommand.Connection = myConnection;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myCommand.Connection.Close();

                // MessageBox.Show("Usuario modificado con éxito", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string consulta = "select * from usuarios";

                SqlConnection conexion = new SqlConnection(cadena_conexion);
                SqlDataAdapter da = new SqlDataAdapter(consulta, conexion);
                System.Data.DataSet ds = new System.Data.DataSet();
                da.Fill(ds, "sistemapro1");
              

            }
            catch (SqlException)
            {
                
            }

            bmodificar.Visible = true;
            bactualizar.Visible = false;

            //Desabilitar campos, se activan al crear nuevo registro
            txtautor.Enabled = false;
            txtcategoria.Enabled = false;
            txteditorial.Enabled = false;
            txtstan.Enabled = false;
            txtisbm.Enabled = false;
            txtlibro.Enabled = false;
            txtobservaciones.Enabled = false;

        }

        protected void bbuscar_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection myConnection = new SqlConnection(cadena_conexion);

                string myInsertQuery = "select * from libros Where idlibros = " + txtbuscar.Text + "";
                SqlCommand myCommand = new SqlCommand(myInsertQuery, myConnection);

                myCommand.Connection = myConnection;
                myConnection.Open();

                SqlDataReader myReader;
                myReader = myCommand.ExecuteReader();

                if (myReader.Read())
                {
                    txtlibro.Text = (myReader.GetString(1));
                    txtcategoria.Text = (myReader.GetString(2));
                    txteditorial.Text = (myReader.GetString(3));
                    txtisbm.Text = (myReader.GetString(4));
                    txtautor.Text = (myReader.GetString(5));
                    txtobservaciones.Text = (myReader.GetString(6));
                    txtstan.Text = (myReader.GetString(7));


                }
                else
                {
                    
                    lblmensaje.Text = "El usuario ya existe";
                }
                myReader.Close();
                myConnection.Close();

            }
            catch (SqlException)
            {
                
                lblmensaje.Text = "Campo de busqueda está vacío";
            }

            bnuevo.Visible = true;
            bguardar.Visible = false;

            //Desabilitar campos, se activan al crear nuevo registro
            txtautor.Enabled = false;
            txtcategoria.Enabled = false;
            txteditorial.Enabled = false;
            txtstan.Enabled = false;
            txtisbm.Enabled = false;
            txtlibro.Enabled = false;
            txtobservaciones.Enabled = false;
            bmodificar.Focus();
        }
    }
    }
    
