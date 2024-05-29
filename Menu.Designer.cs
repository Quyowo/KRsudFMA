namespace WindowsFormsApp1
{
    partial class Предыгровое_меню
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sud = new System.Windows.Forms.Label();
            this.help = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.Records = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sud
            // 
            this.sud.AutoSize = true;
            this.sud.BackColor = System.Drawing.Color.White;
            this.sud.Font = new System.Drawing.Font("Gadugi", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sud.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.sud.Location = new System.Drawing.Point(311, 44);
            this.sud.Name = "sud";
            this.sud.Size = new System.Drawing.Size(120, 35);
            this.sud.TabIndex = 0;
            this.sud.Text = "Судоку";
            this.sud.Click += new System.EventHandler(this.label1_Click);
            // 
            // help
            // 
            this.help.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.help.ForeColor = System.Drawing.SystemColors.ControlText;
            this.help.Location = new System.Drawing.Point(642, 399);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(146, 46);
            this.help.TabIndex = 1;
            this.help.Text = "Справка";
            this.help.UseVisualStyleBackColor = false;
            this.help.Click += new System.EventHandler(this.LoadHelp);
            // 
            // start
            // 
            this.start.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.start.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.start.Location = new System.Drawing.Point(264, 167);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(218, 110);
            this.start.TabIndex = 2;
            this.start.Text = "Играть";
            this.start.UseVisualStyleBackColor = false;
            this.start.Click += new System.EventHandler(this.LoadGame);
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.Red;
            this.Exit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Exit.Location = new System.Drawing.Point(12, 2);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(119, 22);
            this.Exit.TabIndex = 3;
            this.Exit.Text = "Выход";
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.button3_Click);
            // 
            // Records
            // 
            this.Records.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Records.Location = new System.Drawing.Point(12, 411);
            this.Records.Name = "Records";
            this.Records.Size = new System.Drawing.Size(90, 34);
            this.Records.TabIndex = 4;
            this.Records.Text = "Таблица рекордов";
            this.Records.UseVisualStyleBackColor = false;
            this.Records.Click += new System.EventHandler(this.Records_Click);
            // 
            // Предыгровое_меню
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources._51277776;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Records);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.start);
            this.Controls.Add(this.help);
            this.Controls.Add(this.sud);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Предыгровое_меню";
            this.Text = "Предыгровое_меню";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label sud;
        private System.Windows.Forms.Button help;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button Records;
    }
}