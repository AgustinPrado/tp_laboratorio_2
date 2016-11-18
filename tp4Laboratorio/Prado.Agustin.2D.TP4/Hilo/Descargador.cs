using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;

namespace Hilo
{
    public class Descargador
    {
        private string _html;
        private Uri _link;

        public delegate void EventProgress(int status);
        public event EventProgress eventProgress;
        public delegate void EventCompleted(string web);
        public event EventCompleted eventCompleted;

        /// <summary>
        /// Constructor que reciba una Uri.
        /// </summary>
        /// <param name="link">Uri de donde va a buscar la web.</param>
        public Descargador(Uri link)
        {
            this._html = "";
            this._link = link;
        }

        /// <summary>
        /// Inicia la descarga de la web.
        /// </summary>
        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();

                cliente.DownloadProgressChanged += WebClientDownloadProgressChanged;
                cliente.DownloadStringCompleted += WebClientDownloadCompleted;

                // comienza la descarga del contenido de la página.
                cliente.DownloadStringAsync(this._link);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // cada vez que haya progreso, lanza el evento y actualiza la barra de estado con el porcentaje actual.
            this.eventProgress(e.ProgressPercentage);
        }
        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                // pone el contenido de la página en el richTextBox.
                this._html = e.Result;
            }
            catch (Exception exception)
            {
                // en caso de fallar la descarga, muestra el error en el richTextBox.
                // corrije el error del soft funcional al recibir una url errónea.
                this._html = exception.InnerException.Message;
            }
            finally
            {
                // paso el contenido de la página/error para que lance el evento y actualice el richTextBox.
                this.eventCompleted(this._html);
            }
        }
    }
}
