using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace SerializacionXML
{
    [XmlRoot("Producto")]
    public class ArregloProducto
    {
        [XmlArrayItem(typeof(Producto))]
        public List<Producto> listado = new List<Producto>();
    }
}
