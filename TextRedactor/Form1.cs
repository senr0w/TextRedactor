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
            //диалог с предложенным именем файла и текстовым форматом файла
            openFileDialog1.FileName = @"New File.txt";
            openFileDialog1.Filter ="Текстовые файлы (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Filter ="Текстовые файлы (*.txt)|*.txt|All files (*.*)|*.*";
        }

        //функция открыть во вкладке "Файл", открывает готовый текстовый файл с компьютера 
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Открывается диалог,где можно выбрать нужный текстовый файл
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName == String.Empty) return;
            //Считывает содержимое и записывает его в textbox приложения
            var reader = new System.IO.StreamReader(
            openFileDialog1.FileName, Encoding.GetEncoding(1251));
            textBox1.Text =reader.ReadToEnd();
            reader.Close();

        }

        //функция сохранить во вкладке "Файл", сохраняет текстовый файл приложения
        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Открывается диалог,где можно назвать наш файл любым именем и сохранить его
            saveFileDialog1.FileName = openFileDialog1.FileName;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {        //Записывает данные из textbox и сохраняет txt файл
                    var editor = new System.IO.StreamWriter(
                    saveFileDialog1.FileName, false,
                    System.Text.Encoding.GetEncoding(1251));
                    editor.Write(textBox1.Text);
                    editor.Close();
                MessageBox.Show("Текстовый файл успешно сохранён", "Сохранение");
            }
        }

        //функция выход во вкладке "Файл", выключает приложение
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //функция отменить в правке
        private void отменитьCtrlZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0)
            {
                textBox1.Undo();
            }
        }

        //функция вставить в правке
        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0)
            {
                textBox1.Paste();
            }
        }

        //функция копировать в правке
        private void копироватьCtrlVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(textBox1.TextLength > 0)
            {
                textBox1.Copy();
            }
        }

        //функция вырезать в правке
        private void вырезатьCtrlСToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0)
            {
              
                textBox1.Cut();
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Клон блокнота на WinForms, сделанный на Учебной Практике", "Упссс");
        }
    }
}
