using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Kompas6API5;
using Kompas6Constants3D;

namespace TablePlugin.Model.Kompas
{
    public class KompasConnector
    {

        public KompasObject KsObject { get; }

        public ksPart Part { get; set; }

        public KompasConnector()
        {
            var progId = "KOMPAS.Application.5";
            try
            {
                KsObject = (KompasObject)Marshal.GetActiveObject(progId);
            }
            catch(COMException)
            {
                KsObject = (KompasObject)Activator.
                    CreateInstance(Type.GetTypeFromProgID(progId));
            }
            KsObject.Visible = true;
            KsObject.ActivateControllerAPI();
        }

        public void GetNewPart()
        {
            var ksDoc = KsObject.Document3D();
            ksDoc.Create(false, true);
            Part = ksDoc.GetPart((short)Part_Type.pTop_Part);
        }
    }

}
