
namespace firefox
{
    partial class Form1
    {

        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            panel1 = new System.Windows.Forms.Panel();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            eventLog1 = new System.Diagnostics.EventLog();
            button1 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            richTextBox1 = new System.Windows.Forms.RichTextBox();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            button4 = new System.Windows.Forms.Button();
            bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(eventLog1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new System.Drawing.Point(256, 12);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(107, 103);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new System.Drawing.Point(0, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(107, 100);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // eventLog1
            // 
            eventLog1.SynchronizingObject = this;
            // 
            // button1
            // 
            button1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            button1.Location = new System.Drawing.Point(12, 158);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Start";
            button1.UseVisualStyleBackColor = false;
            button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            button2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            button2.Location = new System.Drawing.Point(94, 158);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(75, 23);
            button2.TabIndex = 3;
            button2.Text = "On top";
            button2.UseVisualStyleBackColor = false;
            button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            button3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            button3.Location = new System.Drawing.Point(175, 158);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(75, 23);
            button3.TabIndex = 4;
            button3.Text = "Options";
            button3.UseVisualStyleBackColor = false;
            button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            richTextBox1.Cursor = System.Windows.Forms.Cursors.Default;
            richTextBox1.DetectUrls = false;
            richTextBox1.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            richTextBox1.ForeColor = System.Drawing.Color.Purple;
            richTextBox1.ImeMode = System.Windows.Forms.ImeMode.Disable;
            richTextBox1.Location = new System.Drawing.Point(12, 12);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            richTextBox1.Size = new System.Drawing.Size(238, 139);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // chart1
            // 
            chart1.BackColor = System.Drawing.Color.DarkGray;
            chart1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            chart1.BackImageTransparentColor = System.Drawing.Color.White;
            chart1.BackSecondaryColor = System.Drawing.Color.White;
            chart1.BorderlineColor = System.Drawing.Color.Transparent;
            chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea4.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            chart1.Legends.Add(legend4);
            chart1.Location = new System.Drawing.Point(369, 15);
            chart1.Name = "chart1";
            chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            chart1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            chart1.Series.Add(series4);
            chart1.Size = new System.Drawing.Size(227, 166);
            chart1.TabIndex = 5;
            chart1.Text = "chart1";
            chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // button4
            // 
            button4.Location = new System.Drawing.Point(271, 158);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(75, 23);
            button4.TabIndex = 6;
            button4.Text = "button4";
            button4.UseVisualStyleBackColor = true;
            button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = System.Drawing.Color.Thistle;
            label1.Location = new System.Drawing.Point(271, 137);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(43, 13);
            label1.TabIndex = 7;
            label1.Text = "Bobbel:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            label2.Location = new System.Drawing.Point(320, 137);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(22, 13);
            label2.TabIndex = 8;
            label2.Text = "0.0";
            label2.TextChanged += new System.EventHandler(this.label2_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(608, 192);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Controls.Add(button4);
            this.Controls.Add(chart1);
            this.Controls.Add(button3);
            this.Controls.Add(button2);
            this.Controls.Add(button1);
            this.Controls.Add(richTextBox1);
            this.Controls.Add(panel1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::firefox.Properties.Settings.Default, "lexa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Name = "Form1";
            this.Text = global::firefox.Properties.Settings.Default.lexa;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(eventLog1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        static internal System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        static private System.Windows.Forms.Panel panel1;
        static private System.Diagnostics.EventLog eventLog1;
        static private System.Windows.Forms.Button button3;
        static private System.Windows.Forms.Button button2;
        static private System.Windows.Forms.Button button1;
        static public System.Windows.Forms.RichTextBox richTextBox1;
        static public System.Windows.Forms.PictureBox pictureBox1;
        static private System.Windows.Forms.Button button4;
        static private System.Windows.Forms.BindingSource bindingSource1;
        static private System.Windows.Forms.Label label1;
        static public System.Windows.Forms.Label label2;
    }
}

