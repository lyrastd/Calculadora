using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace CalculadoraApp {
    public partial class Form1 : Form {
        private TextBox display;
        private TableLayoutPanel layout;

        public Form1() {
            InitializeComponent();
            if (System.IO.File.Exists("app.ico")) this.Icon = new Icon("app.ico");
            this.Text = "Calculadora Simples";
            this.MinimumSize = new Size(350, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            SetupLayout();
        }

        private void SetupLayout() {
            display = new TextBox {
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 24F, FontStyle.Bold),
                TextAlign = HorizontalAlignment.Right,
                ReadOnly = true,
                Text = "0",
                Height = 60
            };
            this.Controls.Add(display);

            layout = new TableLayoutPanel {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 5,
                Padding = new Padding(10)
            };
            
            for (int i = 0; i < 4; i++) layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            for (int i = 0; i < 5; i++) layout.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));

            string[] buttons = {
                "C", "/", "*", "DEL",
                "7", "8", "9", "-",
                "4", "5", "6", "+",
                "1", "2", "3", "=",
                "0", ".", "", ""
            };

            foreach (string text in buttons) {
                if (string.IsNullOrEmpty(text)) continue;
                Button btn = new Button {
                    Text = text,
                    Dock = DockStyle.Fill,
                    Font = new Font("Segoe UI", 14F),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.FromArgb(85, 85, 85),
                    ForeColor = Color.White
                };
                
                if (text == "=" ) { btn.BackColor = Color.FromArgb(39, 174, 96); layout.SetRowSpan(btn, 2); }
                else if (text == "C" || text == "DEL") btn.BackColor = Color.FromArgb(231, 76, 60);
                else if ("/*-+".Contains(text)) btn.BackColor = Color.FromArgb(243, 156, 18);

                btn.Click += Button_Click;
                layout.Controls.Add(btn);
            }

            Panel container = new Panel { Dock = DockStyle.Fill };
            container.Controls.Add(layout);
            this.Controls.Add(container);
            layout.BringToFront();
        }

        private void Button_Click(object sender, EventArgs e) {
            string val = ((Button)sender).Text;
            if (val == "C") display.Text = "0";
            else if (val == "DEL") {
                if (display.Text.Length > 1) display.Text = display.Text.Substring(0, display.Text.Length - 1);
                else display.Text = "0";
            }
            else if (val == "=") {
                try { display.Text = new DataTable().Compute(display.Text.Replace(",", "."), null).ToString(); }
                catch { display.Text = "Erro"; }
            }
            else {
                if (display.Text == "0" || display.Text == "Erro") display.Text = val;
                else display.Text += val;
            }
        }
    }
}