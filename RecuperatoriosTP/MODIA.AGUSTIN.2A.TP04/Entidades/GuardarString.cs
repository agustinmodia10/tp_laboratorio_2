using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardarString
    {
        
        public static bool Guardar(this string txt, string arc)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + arc,true))
                {
                    sw.WriteLine(txt);
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
