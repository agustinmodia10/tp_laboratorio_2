using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region Atributos
        private List<Thread> _mPaquetes;
        private List<Paquete> _paque;
        #endregion

        #region Propiedades
        public List<Paquete> Paquetes
        {
            get
            {
                return this._paque;
            }
            set
            {
                this._paque = value;
            }
        }
        #endregion

        #region Constructores
        public Correo()
        {
            this._paque = new List<Paquete>();
            this._mPaquetes = new List<Thread>();
        }
        #endregion

        #region Metodos

        public string MostrarDatos(IMostrar<List<Paquete>> em)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Paquete paquete in ((Correo)em)._paque)
            {
                sb.AppendLine(String.Format("{0} ({1})", paquete.MostrarDatos(paquete), paquete.Estado.ToString()));
            }
            return sb.ToString();
        }

   
        public void FinEntregas()
        {
            foreach (Thread _theread in this._mPaquetes)
            {
                if (_theread.IsAlive)
                {
                    _theread.Abort();
                }
            }
        }
        #endregion

        #region Operadores
 
        public static Correo operator +(Correo ko, Paquete pkt)
        {
            Thread _theread;
            try
            {
                foreach (Paquete paquete in ko._paque)
                {
                    if (paquete == pkt)
                    {
                        throw new TrackingIdRepetidoException("El TrackID " + pkt.TrackingID + " ya se encuentra ingresado en el sistema");
                    }
                }
                ko._paque.Add(pkt);
                _theread = new Thread(pkt.MockCicloDeVida);
                _theread.Start();
                ko._mPaquetes.Add(_theread);
                return ko;
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }
        #endregion
    }
}
