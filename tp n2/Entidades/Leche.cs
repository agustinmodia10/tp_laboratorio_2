using System;
using System.Text;

namespace Entidades_2018
{
     public class Leche : Producto
    {
        public enum ETipo { Entera, Descremada }
        ETipo tipo;

        /// <summary>
        /// Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca">Marca del snack</param>
        /// <param name="patente">El codigo de barra del snack</param>
        /// <param name="color">Color primario del paquete del snack</param>
        public Leche(EMarca marca, string patente, ConsoleColor color)
            : base(patente, marca, color)
        {
            this.tipo = ETipo.Entera;
        }

        /// <summary>
        /// Se instancian los parametros de Leche
        /// </summary>
        /// <param name="marca">Marca del snack</param>
        /// <param name="patente">El codigo de barra del snack</param>
        /// <param name="color">Color primario del paquete del snack</param>
        /// <param name="tipo">Tipo de leche</param>
        public Leche(EMarca marca, string patente, ConsoleColor color, ETipo tipo) :base(patente, marca, color)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }

        /// <summary>
        /// Retorna toda la informacion de el producto Leche
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("CALORIAS : " + this.CantidadCalorias);
            sb.AppendLine("TIPO : " + this.tipo);
            //sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
