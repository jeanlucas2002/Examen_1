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
    public partial class frmtipoDocumento : Form
    {
        public frmtipoDocumento()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            datos();
        }
        private void datos()
        {
            
            var adaptador = new ds1TableAdapters.TipoDocumentoTableAdapter();
            
            var tabla = adaptador.GetData();
            
            dgvListado.DataSource = tabla;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var frm = new frmTipoDocumento2();
            frm.ShowDialog();
            datos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int id = getId();
            if (id > 0)
            {
                var frm = new frmTipoDocumento2(id);
                frm.ShowDialog();
                datos();    
            }
            else
            {
                MessageBox.Show("Selecione un ID valido", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private int getId()
        {
            try
            {
                
                DataGridViewRow filaActual = dgvListado.CurrentRow;
                if (filaActual == null)
                {
                    return 0;
                }
                return int.Parse(dgvListado.Rows[filaActual.Index].Cells[0].Value.ToString());
            }
            catch (Exception)
            {
                
                return 0;
                throw;
            }


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = getId();
            if (id > 0)
            {
                var respuesta = MessageBox.Show("¿Realmente desea Eliminar el registro?", "Sistemas",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                if (respuesta == DialogResult.Yes)
                {
                    
                    var adaptador = new ds1TableAdapters.TipoDocumentoTableAdapter();
                    adaptador.Eliminar(id);

                    MessageBox.Show("Registro Eliminado", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    datos();
                }
            }
            else
            {
                MessageBox.Show("Debe selecionar un ID válido", "Sistemas",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
