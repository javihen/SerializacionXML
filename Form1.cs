using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Xml.Serialization;
using Microsoft.VisualBasic;

namespace SerializacionXML
{
    public partial class Form1 : Form
    {
        ArregloProducto aProductos = new ArregloProducto();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Producto objP = new Producto();
                objP.descripcion = txtDescripcion.Text;
                objP.cantidad = int.Parse(txtCantidad.Text);
                objP.categoria = cboCategoria.Text;
                objP.precio = double.Parse(txtPrecio.Text);
                objP.fechaVenc = DateTime.Parse(txtFecha.Text);

                aProductos.listado.Add(objP);

                listado();

                txtDescripcion.Text = "";
                txtCantidad.Text = "";
                txtFecha.Text = "";
                txtPrecio.Text = "";
                cboCategoria.SelectedItem = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al agregar el producto");
            }
            
        }

        private void listado()
        {
            lvContenido.Items.Clear();

            foreach (Producto P in aProductos.listado)
            {
                ListViewItem fila = new ListViewItem(P.descripcion);
                fila.SubItems.Add(P.categoria);
                fila.SubItems.Add(P.precio.ToString());
                fila.SubItems.Add(P.fechaVenc.ToShortDateString());
                fila.SubItems.Add(P.cantidad.ToString());

                lvContenido.Items.Add(fila);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "Archivo XML|*.xml";
            if(sv.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(sv.FileName, FileMode.Create))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(ArregloProducto));
                    xml.Serialize(fs,aProductos);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string descripcion = txtDescripcion.Text;

            foreach(Producto P in aProductos.listado)
            {
                if(P.descripcion == descripcion)
                {
                    aProductos.listado.Remove(P);
                    break;
                }
            }
            listado();
        }
    }
}
