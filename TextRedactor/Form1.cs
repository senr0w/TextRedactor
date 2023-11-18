using System;
using System.Text;
using System.Windows.Forms;

namespace TextRedactor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Clear();
            openFileDialog1.FileName = @"New File.txt";
            openFileDialog1.Filter =
                     "Текстовые файлы (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Filter =
                     "Текстовые файлы (*.txt)|*.txt|All files (*.*)|*.*";
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName == String.Empty) return;
            var reader = new System.IO.StreamReader(
            openFileDialog1.FileName, Encoding.GetEncoding(1251));
            textBox1.Text =reader.ReadToEnd();
            reader.Close();

        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = openFileDialog1.FileName;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                    var editor = new System.IO.StreamWriter(
                    saveFileDialog1.FileName, false,
                    System.Text.Encoding.GetEncoding(1251));
                    editor.Write(textBox1.Text);
                    editor.Close();
                MessageBox.Show("Текстовый файл успешно сохранён", "Сохранение");
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
