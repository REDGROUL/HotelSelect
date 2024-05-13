using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace HotelSelect.Views
{
    public partial class CreatHotel : Form
    {
        public CreatHotel()
        {
            InitializeComponent();
        }

        private void CreatHotel_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) ||
                string.IsNullOrEmpty(textBox2.Text) ||
                string.IsNullOrEmpty(textBox3.Text) ||
                string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Отель успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
        }

        private void ClearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string hint = textBox.Tag.ToString();
            label2.Visible = textBox == textBox1 && string.IsNullOrEmpty(textBox.Text);
            label3.Visible = textBox == textBox2 && string.IsNullOrEmpty(textBox.Text);
            label4.Visible = textBox == textBox3 && string.IsNullOrEmpty(textBox.Text);
            label5.Visible = textBox == textBox4 && string.IsNullOrEmpty(textBox.Text);
            label6.Visible = textBox == textBox5 && string.IsNullOrEmpty(textBox.Text);
            label7.Visible = textBox == textBox6 && string.IsNullOrEmpty(textBox.Text);

            if (!string.IsNullOrEmpty(hint))
            {
                textBox.ForeColor = SystemColors.WindowText;
                if (textBox.Text == hint)
                {
                    textBox.Text = string.Empty;
                }
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string hint = textBox.Tag.ToString();

            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = hint;
                textBox.ForeColor = SystemColors.GrayText;
                label2.Visible = textBox == textBox1 && string.IsNullOrEmpty(textBox.Text);
                label3.Visible = textBox == textBox2 && string.IsNullOrEmpty(textBox.Text);
                label4.Visible = textBox == textBox3 && string.IsNullOrEmpty(textBox.Text);
                label5.Visible = textBox == textBox4 && string.IsNullOrEmpty(textBox.Text);
                label6.Visible = textBox == textBox5 && string.IsNullOrEmpty(textBox.Text);
                label7.Visible = textBox == textBox6 && string.IsNullOrEmpty(textBox.Text);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(label2.Text))
            {
                label2.Visible = true;
            }
            else
            {
                label2.Visible = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(label3.Text))
            {
                label3.Visible = true;
            }
            else
            {
                label3.Visible = false;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(label4.Text))
            {
                label4.Visible = true;
            }
            else
            {
                label4.Visible = false;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(label5.Text))
            {
                label5.Visible = true;
            }
            else
            {
                label5.Visible = false;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(label6.Text))
            {
                label6.Visible = true;
            }
            else
            {
                label6.Visible = false;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(label7.Text))
            {
                label7.Visible = true;
            }
            else
            {
                label7.Visible = false;
            }
        }
    }
}
