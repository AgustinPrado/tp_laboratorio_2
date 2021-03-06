﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using Hilo;

namespace Navegador
{
    public partial class frmWebBrowser : Form
    {
        private const string ESCRIBA_AQUI = "Escriba aquí...";
        Archivos.Texto archivos;

        public frmWebBrowser()
        {
            InitializeComponent();
        }

        private void frmWebBrowser_Load(object sender, EventArgs e)
        {
            this.txtUrl.SelectionStart = 0;  //This keeps the text
            this.txtUrl.SelectionLength = 0; //from being highlighted
            this.txtUrl.ForeColor = Color.Gray;
            this.txtUrl.Text = frmWebBrowser.ESCRIBA_AQUI;

            archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);
        }

        #region "Escriba aquí..."
        private void txtUrl_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.IBeam; //Without this the mouse pointer shows busy
        }

        private void txtUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.txtUrl.Text.Equals(frmWebBrowser.ESCRIBA_AQUI) == true)
            {
                this.txtUrl.Text = "";
                this.txtUrl.ForeColor = Color.Black;
            }
        }

        private void txtUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.txtUrl.Text.Equals(null) == true || this.txtUrl.Text.Equals("") == true)
            {
                this.txtUrl.Text = frmWebBrowser.ESCRIBA_AQUI;
                this.txtUrl.ForeColor = Color.Gray;
            }
        }

        private void txtUrl_MouseDown(object sender, MouseEventArgs e)
        {
            this.txtUrl.SelectAll();
        }
        #endregion

        delegate void ProgresoDescargaCallback(int progreso);
        private void ProgresoDescarga(int progreso)
        {
            if (statusStrip.InvokeRequired)
            {
                ProgresoDescargaCallback d = new ProgresoDescargaCallback(ProgresoDescarga);
                this.Invoke(d, new object[] { progreso });
            }
            else
            {
                tspbProgreso.Value = progreso;
            }
        }
        delegate void FinDescargaCallback(string html);
        private void FinDescarga(string html)
        {
            if (rtxtHtmlCode.InvokeRequired)
            {
                FinDescargaCallback d = new FinDescargaCallback(FinDescarga);
                this.Invoke(d, new object[] { html });
            }
            else
            {
                rtxtHtmlCode.Text = html;
            }
        }

        private void mostrarTodoElHistorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHistorial historial = new Navegador.frmHistorial();

            // lanzo el form del historial de manera que no se pueda acceder al form inicial sin cerrar el nuevo form.
            historial.ShowDialog();
        }

        private void btnIr_Click(object sender, EventArgs e)
        {
            // hago que la barra de progreso vuelva a 0.
            this.tspbProgreso.Value = 0;

            // en caso de que la url no contenga http://, se lo agrego al principio de la cadena.
            if (!this.txtUrl.Text.Contains("http://"))
            {
                this.txtUrl.Text = this.txtUrl.Text.Insert(0, "http://");
            }

            try
            {
                // url absoluta, protocolo://dominio/ . Por eso previamente le agrego http:// si no lo tiene.
                Uri link = new Uri(this.txtUrl.Text, UriKind.Absolute);

                Descargador downloader = new Descargador(link);
                downloader.eventProgress += new Descargador.EventProgress(this.ProgresoDescarga);
                downloader.eventCompleted += new Descargador.EventCompleted(this.FinDescarga);

                // hilo que va a iniciar la descarga de la página.
                Thread hilo = new Thread(new ThreadStart(downloader.IniciarDescarga));

                hilo.Start();
            }
            catch (Exception exc)
            {
                // en caso de fallar, lanza un mensaje.
                MessageBox.Show(exc.Message, "ERROR");
            }
            finally
            {
                // al terminar, haya fallado o no, guarda la url que se buscó en el historial.
                this.archivos.guardar(this.txtUrl.Text);
            }
        }
    }
}
