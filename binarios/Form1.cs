using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace binarios
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            persona persona = new persona();
            persona.Age = textBox1.Text;
            persona.name = textBox2.Text;
            persona.subname = textBox3.Text;

            DataGridViewRow load = new DataGridViewRow();
            load.CreateCells(dataGridView1);
            load.Cells[0].Value = textBox1.Text;
            load.Cells[1].Value = textBox2.Text;
            load.Cells[2].Value = textBox3.Text;
            dataGridView1.Rows.Add(load);
            textBox1.Text = textBox2.Text = textBox3.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveDataGridView(dataGridView1, "data.bin");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadDataGridView(dataGridView1, "data.bin");
        }

        private void SaveDataGridView(DataGridView dgv, string filePath)
        {
            List<binario> rows = new List<binario>();

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    binario rowData = new binario();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        rowData.Cells.Add(cell.Value?.ToString() ?? string.Empty);
                    }
                    rows.Add(rowData);
                }
            }

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                binario bf = new binario();
                bf.Serialize(fs, rows);
            }

            MessageBox.Show("Datos guardados exitosamente!");
        }

        private void LoadDataGridView(DataGridView dgv, string filePath)
        {
            if (File.Exists(filePath))
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    binario bf = new binario();
                    List<binario> rows = (List<binario>)bf.Deserialize(fs);

                    dgv.Rows.Clear();
                    foreach (binario rowData in rows)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(dgv, rowData.Cells.ToArray());
                        dgv.Rows.Add(row);
                    }
                }

                MessageBox.Show("Datos cargados exitosamente!");
            }
            else
            {
                MessageBox.Show("Archivo no encontrado!");
            }
        }
    }
}
