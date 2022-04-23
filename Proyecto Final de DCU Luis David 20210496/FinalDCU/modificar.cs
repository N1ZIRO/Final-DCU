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
    public partial class modificar : Form
    {
        
        BindingSource bs = new BindingSource();
        public modificar()
        {
            InitializeComponent();
        }
        public void buscardatos()
        {
            BasedeDatos bus = new BasedeDatos();
            DataSet ds = bus.recibir("select * from empleados where " + "ID" + "='" + txtBuscar.Text + "'");
            bs.DataSource = ds.Tables[0];
            dataGridView1.DataSource = bs;
        }
        
        public void cargardatos()
        {

            BasedeDatos con = new BasedeDatos();
            DataSet ds = con.recibir("select * from empleados");
            bs.DataSource = ds.Tables[0];
            dataGridView1.DataSource = bs;

        }
        
        private void Modificar_Load(object sender, EventArgs e)
        {
            

            cargardatos();
            txtid.DataBindings.Add("Text", bs, "ID");
            txtnombres.DataBindings.Add("Text", bs, "NOMBRES");
            txtapellidos.DataBindings.Add("Text", bs, "APELLIDOS");
            txtacorreo.DataBindings.Add("Text", bs, "CORREO");
            txtcel.DataBindings.Add("Text", bs, "CELULAR");

            
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            
            buscardatos();
                
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                BasedeDatos x = new BasedeDatos();
                String id = txtid.Text;
                String nombres = txtnombres.Text;
                String apellidos = txtapellidos.Text;
                String correo = txtacorreo.Text;
                String cel = txtcel.Text;

                x.enviar("update empleados set NOMBRES='" + nombres + "',APELLIDOS='" + apellidos + "', CORREO='" + correo + "', CELULAR='" + cel + "' where ID='" + id + "'");
                cargardatos();
                lbagregado.Visible = true;
                timer1.Start();
            }
            catch
            {
                lberror.Visible = true;
                timer2.Start();
            }
            
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

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
