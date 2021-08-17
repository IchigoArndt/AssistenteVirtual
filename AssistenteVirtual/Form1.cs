using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;

namespace AssistenteVirtual
{
    public partial class Form1 : Form
    {

        private SpeechRecognitionEngine motorReconhecimento;

        public Form1()
        {
            InitializeComponent();

            CarregaFala();
        }
        //LoadSpeech
        private void CarregaFala()
        {
            try
            {
                motorReconhecimento = new SpeechRecognitionEngine();
                motorReconhecimento.SetInputToDefaultAudioDevice();

                string[] palavras = { "a", "Boa noite" };

                //Carregar Gramatica
                motorReconhecimento.LoadGrammar(new Grammar(new GrammarBuilder(new Choices(palavras))));
                motorReconhecimento.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(rec);

                motorReconhecimento.RecognizeAsync(RecognizeMode.Multiple); // Iniciar o Reconhecimento de Fala


            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rec(object s, SpeechRecognizedEventArgs e)
        {
            MessageBox.Show(e.Result.Text);
        }

    }
}
