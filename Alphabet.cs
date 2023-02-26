using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JapanRandomHiraganaKatakana
{
    public partial class Alphabet : Form
    {
        private Label _label;
        private Button _button;
        private TextBox _textBox;
        private CheckBox _checkIncludePreviousRowsBox;
        private CheckedListBox _checkUseAlphabetBox;
        public Alphabet()
        {
            _label = new Label()
            {
                Text = "Random HIRAGANA",
                Font = new Font("Arial", 17),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            _textBox = new TextBox()
            {
                Text = "0",
                Dock = DockStyle.Fill,
            };
            _checkIncludePreviousRowsBox = new CheckBox()
            {
                Text = "Include previous rows",
                Dock = DockStyle.Fill,
            };
            _checkUseAlphabetBox = new CheckedListBox();
            _checkUseAlphabetBox.Items.Add("Hiragana", true);
            _checkUseAlphabetBox.Items.Add("Katakana", false);
            _checkUseAlphabetBox.ItemCheck += OnItemCheck;
            _button = new Button()
            {
                Text = "Randomer",
                Dock = DockStyle.Fill,
            };
            _button.Click += OnButtonClick;
            var table = new TableLayoutPanel();
            CreateRawStyles(table);
        }
        private void OnItemCheck(object? sender, ItemCheckEventArgs e)
        {
            if (e.Index == 0 && e.NewValue == CheckState.Checked)
            {
                _checkUseAlphabetBox.SetItemChecked(1, false);
                _label.Text = "Random HIRAGANA";
            }
            else if (e.Index == 1 && e.NewValue == CheckState.Checked)
            {
                _checkUseAlphabetBox.SetItemChecked(0, false);
                _label.Text = "Random KATAKANA";
            }
        }
        private void OnButtonClick(object? sender, EventArgs e)
        {
            int rowNumber;
            if(!int.TryParse(_textBox.Text, out rowNumber))
            {
                MessageBox.Show("Invalid row number");
                return;
            }
            string alphabet = "";
            if (_checkUseAlphabetBox.GetItemChecked(0))
                alphabet = JapanAlphobet.RandomAlphabet(rowNumber, JapanAlphobet.AlphabetType.Hiragana, _checkIncludePreviousRowsBox.Checked);
            else
                alphabet = JapanAlphobet.RandomAlphabet(rowNumber, JapanAlphobet.AlphabetType.Katakana, _checkIncludePreviousRowsBox.Checked);
            _label.Text = alphabet;
        }
        private void CreateRawStyles(TableLayoutPanel table)
        {
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            table.Controls.Add(new Panel(), 0, 0);
            table.Controls.Add(_checkUseAlphabetBox, 0, 0);
            table.Controls.Add(_label, 0, 1);
            table.Controls.Add(_button, 0, 2);
            table.Controls.Add(_textBox, 0, 3);
            table.Controls.Add(_checkIncludePreviousRowsBox, 0, 4);
            table.Controls.Add(new Panel(), 0, 5);

            table.Dock = DockStyle.Fill;
            Controls.Add(table);
        }
    }
}
