using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistemaClientes
{
    
    public partial class agregar : Form
	{
        String bandera = "";
        BindingSource bs = new BindingSource();
        public agregar()
		{
			InitializeComponent();
		}



        private void Agregar_Load(object sender, EventArgs e)
        {
            bandera = "NUEVO";
            txtid.Text = "";
            txtnombres.Text = "";
            txtapellidos.Text = "";
            txtcorreo.Text = "";
            txtcel.Text = "";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                BasedeDatos x = new BasedeDatos();
                String ID = txtid.Text;
                String nombres = txtnombres.Text;
                String apellidos = txtapellidos.Text;
                String correo = txtcorreo.Text;
                String cel = txtcel.Text;
                if (cel == "")
                {
                    cel = "NULL";
                }
                if (bandera == "NUEVO")
                {
                    x.enviar("insert into empleados values ('" +
                        ID + "','" + nombres + "','" + apellidos + "','" + correo + "'," + cel + ")");
                    lbagregado.Visible = true;
                    timer1.Start();
                }
                   
            }
            catch
            {
                lberror.Visible = true;
                timer2.Start();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            txtid.Text = "";
            txtnombres.Text = "";
            txtapellidos.Text = "";
            txtcorreo.Text = "";
            txtcel.Text = "";
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            lbtimer.Text += 1;
            if (lbtimer.Text == "01111111111111111111111111")
            {
                lbagregado.Visible = false;
                
                timer1.Stop();
                lbtimer.Text = "0";
               
            }
        }

        

        private void Timer2_Tick(object sender, EventArgs e)
        {
            lbtimer2.Text += 1;

            if (lbtimer2.Text == "0111111111111111111111111")
            {

                lberror.Visible = false;
                timer2.Stop();
                lbtimer2.Text = "0";
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtcel_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtcorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtapellidos_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtnombres_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
