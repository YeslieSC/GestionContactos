using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GestionContactos
{
    public partial class Form1 : Form
    {
        // Definición de controles
        private Label lblTitulo, lblNombre, lblTelefono, lblCorreo;
        private TextBox txtNombre, txtTelefono, txtCorreo;
        private Button btnAgregar, btnEliminar, btnLimpiar;
        private ListBox listBoxContactos;
        private MenuStrip menuStrip;
        private ToolStripMenuItem salirMenuItem, acercaDeMenuItem;

        public Form1()
        {

            this.Text = "Gestión de Contactos";
            this.Size = new Size(400, 300);

            // Creación y configuración de controles
            lblTitulo = new Label() { Text = "Gestión de Contactos", Location = new Point(10, 10), AutoSize = true };

            lblNombre = new Label() { Text = "Nombre:", Location = new Point(10, 40), AutoSize = true };
            txtNombre = new TextBox() { Location = new Point(80, 40), Width = 200 };

            lblTelefono = new Label() { Text = "Teléfono:", Location = new Point(10, 70), AutoSize = true };
            txtTelefono = new TextBox() { Location = new Point(80, 70), Width = 200 };

            lblCorreo = new Label() { Text = "Correo Electrónico:", Location = new Point(10, 100), AutoSize = true };
            txtCorreo = new TextBox() { Location = new Point(150, 100), Width = 200 };

            btnAgregar = new Button() { Text = "Agregar", Location = new Point(10, 130) };
            btnEliminar = new Button() { Text = "Eliminar", Location = new Point(100, 130) };
            btnLimpiar = new Button() { Text = "Limpiar", Location = new Point(190, 130) };

            listBoxContactos = new ListBox() { Location = new Point(10, 160), Width = 360, Height = 80 };

            menuStrip = new MenuStrip();
            salirMenuItem = new ToolStripMenuItem() { Text = "Salir" };
            acercaDeMenuItem = new ToolStripMenuItem() { Text = "Acerca de" };

            menuStrip.Items.Add(salirMenuItem);
            menuStrip.Items.Add(acercaDeMenuItem);
            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);

            // Agregar controles al formulario
            this.Controls.Add(lblTitulo);
            this.Controls.Add(lblNombre);
            this.Controls.Add(txtNombre);
            this.Controls.Add(lblTelefono);
            this.Controls.Add(txtTelefono);
            this.Controls.Add(lblCorreo);
            this.Controls.Add(txtCorreo);
            this.Controls.Add(btnAgregar);
            this.Controls.Add(btnEliminar);
            this.Controls.Add(btnLimpiar);
            this.Controls.Add(listBoxContactos);

            // Suscribir eventos
            btnAgregar.Click += new EventHandler(BtnAgregar_Click);
            btnEliminar.Click += new EventHandler(BtnEliminar_Click);
            btnLimpiar.Click += new EventHandler(BtnLimpiar_Click);
            salirMenuItem.Click += new EventHandler(SalirMenuItem_Click);
            acercaDeMenuItem.Click += new EventHandler(AcercaDeMenuItem_Click);

            this.Load += new EventHandler(Form1_Load);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        // Implementación de eventos
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            string contacto = $"{txtNombre.Text} - {txtTelefono.Text} - {txtCorreo.Text}";
            listBoxContactos.Items.Add(contacto);
            MessageBox.Show("Contacto agregado.");
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (listBoxContactos.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un contacto para eliminar.");
                return;
            }

            listBoxContactos.Items.Remove(listBoxContactos.SelectedItem);
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
        }

        private void SalirMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AcercaDeMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aplicación de Gestión de Contactos\nVersión 1.0\nDesarrollado por Yeslie Sanchez");
        }
    }
}
