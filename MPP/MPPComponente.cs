using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Xml.Linq;
using System.IO;
using System.Data;
using System.Xml;
using System.Collections;



namespace MPP
{
    public abstract class MPPComponente
    {
        public abstract IList<BEComponente> CargarRoles();

        public abstract IList<BEComponente> CargarPermisos();

        public abstract void AgregarHijo(BEComponente rol, BEComponente permiso);



    }
}
