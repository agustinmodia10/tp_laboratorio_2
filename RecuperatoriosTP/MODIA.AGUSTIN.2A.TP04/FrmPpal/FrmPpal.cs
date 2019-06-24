using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmPpal
{
    public partial class FrmPpal : Form
    {
        Correo kreo;

        public FrmPpal()
        {
            this.InitializeComponent();
            this.kreo = new Correo();
        }

        
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete pkts = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);
            pkts.InformarEstado += new Paquete.DelegadoEstado(this.paq_InformaEstado);
            try
            {
                this.kreo += pkts;
            }
            catch (TrackingIdRepetidoException eee)
            {
                MessageBox.Show(eee.Message);
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            this.ActualizarEstados();
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)this.kreo);
        }

     
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (!kreo.Equals(null))
            {
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
                this.rtbMostrar.Text.Guardar("salidasss.txt");
            }
        }

        
        private void ActualizarEstados()
        {
            lstEstadoIngresado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoEntregado.Items.Clear();
            foreach (Paquete pkt in kreo.Paquetes)
            {
                switch (pkt.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        this.lstEstadoIngresado.Items.Add(pkt);
                        break;
                    case Paquete.EEstado.EnViaje:
                        this.lstEstadoEnViaje.Items.Add(pkt);
                        break;
                    case Paquete.EEstado.Entregado:
                        this.lstEstadoEntregado.Items.Add(pkt);
                        break;
                }
            }
        }

        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }


        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            kreo.FinEntregas();
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }
    }
}
