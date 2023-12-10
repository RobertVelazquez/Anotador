using System;
using System.Drawing;
using System.IO;
using System.Runtime.Remoting.Channels;
using System.Windows.Forms;

namespace Anotador
{
    public partial class Form1 : Form

    {


        public Form1()
        {
            InitializeComponent();



            panel_izquierdo = new Panel();
            boton = new Button();
            richTextBox1.SuspendLayout();
            btn = new Button();
            btn2 = new Button();

            panel_izquierdo.SuspendLayout();
            this.btn2 = new Button();
            img = new PictureBox();
            //creamos un boton
            this.btn2.Name = "btn2";
            this.btn2.Text = "Hide";
            this.btn2.Location = new System.Drawing.Point(10, 60);
            this.btn2.Visible = true;
            this.btn2.Enabled = true;
            this.btn2.Click += new EventHandler(btn2_Click);
            //Creamos el picturebox
            this.img.Name = "img";
            this.img.Location = new Point(200, 200);
            this.img.Size = new Size(300, 300);
            this.img.TabIndex = 0;
            this.img.Visible = true;
            this.richTextBox1.Controls.Add(img);




        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Focus();



        }


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

            switch (richTextBox1.TextLength)
            {
                case 0:
                    editarToolStripMenuItem.Enabled = false;
                    break;
                default:
                    editarToolStripMenuItem.Enabled = true;
                    break;
            }

            string[] elementos = { "html", "head", "body", "div", "title", "h1", "h2", "h3", "h4", "h5", "h6" };

            richTextBox1.PerformLayout();


        }

        private void fuentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fuentes = new FontDialog();
            if (fuentes.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fuentes.Font;
            }
        }

        private void colorDelPrimerPlanoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            if (color.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = color.Color;
            }
        }

        private void nUevosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (richTextBox1.Text.Length > 1)
            {
                MessageBox.Show("Guarde su trabajo primero");

            }
            else
            {
                richTextBox1.Text = "";


            }
        }

        private void insigniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Insignia insignia = new Insignia();
            insignia.Show();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {


            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (richTextBox1.Text.Length > 1)
                    {
                        MessageBox.Show("Guarde todo antes de empezar");
                    }
                    StreamReader reader = new StreamReader(openFileDialog1.FileName);
                    reader.Peek();
                    richTextBox1.Text = reader.ReadToEnd();
                    reader.Close();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("algo salio mal\nSeleccione un Arcivo de texto para abrir");
            }



        }







        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 1)
            {

                MessageBox.Show("Desas gurdar tu trabajo", "Anotador", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                this.Close();
            }


            else
            {
                Environment.Exit(0);
            }

        }

        private void deshacerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void rehacerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pegarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void cortarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void seleccionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Select();
        }

        private void seleccionarTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void borrarTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void izqierdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
            radioButton1.Checked = true;
            richTextBox1.Focus();
        }

        private void derechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
            richTextBox1.Focus();
            radioButton3.Checked = true;
        }

        private void centroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox1.Focus();
            radioButton2.Checked = true;
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.ShowDialog();
                StreamWriter writer = new StreamWriter(saveFileDialog1.FileName);
                writer.Flush();
                writer.WriteLine(richTextBox1.Text);
                writer.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Algo salio mal");
            }
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog2.ShowDialog();
                StreamWriter guardar = new StreamWriter(saveFileDialog2.FileName);
                guardar.Flush();
                guardar.WriteLine(richTextBox1.Text);
                guardar.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Algo salio mal");
            }
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
            richTextBox1.Focus();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox1.Focus();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
            richTextBox1.Focus();
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font("Sans serif", 24);
        }

        private void lblSubtitulos_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font("Sans serif", 16);
        }

        private void lblTexto_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font("Sans serif", 10);
        }

        private void colorDeFondoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog fondo = new ColorDialog();
            if (fondo.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionBackColor = fondo.Color;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Find(richTextBox2.Text, 0, richTextBox1.TextLength, RichTextBoxFinds.MatchCase);
            richTextBox1.Select();





        }

        private void richTextBox1_MouseHover(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength < 1)
            {
                toolTip1.SetToolTip(richTextBox1, "escriba el texto");
            }
            else
            {
                toolTip1.SetToolTip(richTextBox1, "");
            }



        }

        private void richTextBox2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(richTextBox2, "Busca una palabra o un texto");
        }

        private void groupBox2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(groupBox2, "Seleccione el texto y cambie entre Titulo, Subtitulo o texto");
        }

        private void mostrarPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {







            if (richTextBox1.Text.Length < 1)

            {



                richTextBox1.SelectedText = "<DOCtype html>\n<html>\n<title></title>\n<head>\n\n\n\n\n\n</head>\n<body>\nContenido\n\n</body>\n</html>";

                richTextBox1.Find("contenido");


            }
        }



        private void motrarControlComunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 ventana = new Form2();
            AddOwnedForm(ventana);
            ventana.Show();

        }

        private void groupBox1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(groupBox1, "Alinear el texto entre izquierda, centro, derecha");
        }

        private void listaOrdenadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lista list = new Lista();
            AddOwnedForm(list);
            list.Show();




            richTextBox1.SelectedText = "<ol>" + "aquiLista" + "</ol>";
            richTextBox1.Find("AquiLIsta");

        }

        private void listaDesordenadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lista listaDesordenada = new Lista();
            AddOwnedForm(listaDesordenada);
            listaDesordenada.Show();

            richTextBox1.SelectedText = "<ul>" + "aquiLista" + "</ul>";
            richTextBox1.Find("aquiLista");
        }

        private void h1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            richTextBox1.SelectedText = "<h1>" + "Escriba Aqui" + "</h1>";
            richTextBox1.Find("escriba Aqui");

        }

        private void h2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "<h2></h2>";
        }

        private void h3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "<h3></h3>";
        }

        private void h4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "<h4></h4>";
        }

        private void h5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "<h5></h5>";
        }

        private void h6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "<h6></h6>";
        }

        private void parrafoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "<p></p>";
        }

        private void cajaDeTextoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "<input type = \"text" + "\"" + " id = \"text\" " + " value = \"texto\">";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)

        {
            richTextBox1.Dock = DockStyle.None;

            richTextBox1.Size = new Size(500, 700);


            richTextBox1.Location = new Point(400, 100);
            this.AutoScroll = true;
            if (richTextBox1.Dock == DockStyle.None)
            {
                richTextBox1.BorderStyle = BorderStyle.None;
            }
            else
            {
                richTextBox1.BorderStyle = BorderStyle.Fixed3D;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Dock = DockStyle.Fill;
            radioButton4.Checked = false;
            if (richTextBox1.Dock == DockStyle.None)
            {
                richTextBox1.BorderStyle = BorderStyle.None;
            }
            else
            {
                richTextBox1.BorderStyle = BorderStyle.Fixed3D;
            }
        }

        private void textareaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "<textarea></textarea>";
        }

        private void checkboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "<input type = \"checkbox" + "\"" + " id = \"checkbox\" " + " value = \"check\">";
        }

        private void radioButtonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "<input type = \"radio" + "\"" + " id = \"readio\" " + " value = \"radio\">";
        }

        private void botonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "<input type = \"button" + "\"" + " id = \"button\" " + " value = \"button\">";
        }

        private void saltoDeLineaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "<br>";
        }

        private void spanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "<span>" + "escriva Aqui" + "</span>";
            richTextBox1.Find("Escriva Aqui");
            richTextBox1.Select();
        }

        private void headerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "<header>" + "contenido" + "</header>";
            richTextBox1.Find("contenido");
            richTextBox1.Select();
        }

        private void enlaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Enlace enlace = new Enlace();
            AddOwnedForm(enlace);
            enlace.Show();
        }

        private void imagenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //OpenFileDialog abrir = new OpenFileDialog();
            //abrir.Filter = "JPG(*.jpg)|*.jpg|PNG(*.png)|*.png";
            //if(abrir.ShowDialog() == DialogResult.OK)
            //{

            //    img.Load(abrir.FileName);
            //    img.SizeMode = PictureBoxSizeMode.StretchImage;


            //}
           
            Pen lapiz = new Pen(Color.Red, 5);
            Graphics g;
            g = richTextBox1.CreateGraphics();
            g.DrawRectangle(lapiz, 20, 20, 20, 20);

            g.Dispose();

           

        }

        private void Img_MouseHover(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.Cross;



        }
        private void Img_MouseEnter(object sender, EventArgs e)
        {
            img.Cursor = Cursors.Cross;


        }
        private void Img_Click(object sender, EventArgs e)
        {



        }
       



        private void btn2_Click(object sender, EventArgs e)
        {
            img.Location = new Point(300, 300);



        }


        private System.Windows.Forms.PictureBox img;
        private Panel panel_izquierdo;
        private Button boton;
        private Button btn;
        private Button btn2;

        private void vistaPreviaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VistaPrevia vista = new VistaPrevia();
            AddOwnedForm(vista);
            vista.Show();
        }
    }

}
