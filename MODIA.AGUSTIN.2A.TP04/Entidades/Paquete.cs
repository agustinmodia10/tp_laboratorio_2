using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        public delegate void DelegadoEstado(object sender, EventArgs e);
        public event DelegadoEstado InformarEstado;
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }

        #region Atributos
        private string _direccionEntrega;
        private EEstado _estado;
        private string _trackingID;
        #endregion

        #region Propiedades
        public string DireccionEntrega
        {
            get
            {
                return this._direccionEntrega;
            }
            set
            {
                this._direccionEntrega = value;
            }
        }
        public EEstado Estado
        {
            get
            {
                return this._estado;
            }
            set
            {
                this._estado = value;
            }
        }
        public string TrackingID
        {
            get
            {
                return this._trackingID;
            }
            set
            {
                this._trackingID = value;
            }
        }
        #endregion

        #region Constructor
        public Paquete(string direccionEntrega, string trackingID)
        {
            this._direccionEntrega = direccionEntrega;
            this._trackingID = trackingID;
        }
        #endregion

        #region Metodos

        public string MostrarDatos(IMostrar<Paquete> em)
        {
            return String.Format("{0} para {1}", ((Paquete)em)._trackingID, ((Paquete)em)._direccionEntrega);
        }

        public void MockCicloDeVida()
        {
            while (this._estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);
                this._estado++;
                this.InformarEstado.Invoke(this, new EventArgs());
            }
            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Sobrecargas
 
        public override string ToString()
        {
            return this.MostrarDatos((IMostrar<Paquete>)this); 
        }
        #endregion

        #region Operadores
     
        public static bool operator ==(Paquete pkt1, Paquete pkt2)
        {
            bool retorno = false;
            if (pkt1._trackingID == pkt2._trackingID)
            {
                retorno = true;
            }
            return retorno;
        }

        public static bool operator!=(Paquete pkt1, Paquete pkt2)
        {
            return !(pkt1 == pkt2);
        }
        #endregion
    }
}
