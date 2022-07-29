using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_Practica1
{
    public partial class frmTipoDocumento2 : Form
    {
        private int? Id;
        public frmTipoDocumento2(int? id = null)
        {
            InitializeComponent();
            this.Id = id;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            int estado = chkestado.Checked ? 1 : 0;
            string nombre = txtnombre.Text;

            var adaptador = new ds1TableAdapters.TipoDocumentoTableAdapter();
            if (this.Id == null)
            {
                adaptador.Insertar(nombre, (byte)estado);
            }
            else
            {

                adaptador.Actualizar(nombre, (byte)estado, (int)this.Id);

            }
            this.Close();
        }

        private void frmTipoDocumento2_Load(object sender, EventArgs e)
        {
            if (this.Id != null)
            {
                this.Text = "Editar";
                var adaptador = new ds1TableAdapters.TipoDocumentoTableAdapter();
                var tabla = adaptador.GetDataById((int)this.Id);
                var fila = (ds1.TipoDocumentoRow)tabla.Rows[0];
                txtnombre.Text = fila.Nombre;
                chkestado.Checked = fila.Estado == 1 ? true : false;
            }
            else
            {
                this.Text = "Nuevo";
            }

            }
        }
    }

