﻿namespace Spawn_PickUp_Objects
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            cantidadMovimientos = new Label();
            cantidadObjetos = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // cantidadMovimientos
            // 
            cantidadMovimientos.AutoSize = true;
            cantidadMovimientos.BackColor = Color.Transparent;
            cantidadMovimientos.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            cantidadMovimientos.ForeColor = Color.Red;
            cantidadMovimientos.Location = new Point(5, 500);
            cantidadMovimientos.Name = "cantidadMovimientos";
            cantidadMovimientos.Size = new Size(198, 38);
            cantidadMovimientos.TabIndex = 0;
            cantidadMovimientos.Text = "Movimientos:";
            // 
            // cantidadObjetos
            // 
            cantidadObjetos.AutoSize = true;
            cantidadObjetos.BackColor = Color.Transparent;
            cantidadObjetos.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            cantidadObjetos.ForeColor = Color.FromArgb(255, 128, 0);
            cantidadObjetos.Location = new Point(500, 500);
            cantidadObjetos.Name = "cantidadObjetos";
            cantidadObjetos.Size = new Size(324, 38);
            cantidadObjetos.TabIndex = 1;
            cantidadObjetos.Text = "Objetos coleccionados: ";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 20;
            timer1.Tick += TiempoEjecucion;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(878, 544);
            Controls.Add(cantidadObjetos);
            Controls.Add(cantidadMovimientos);
            Name = "Form1";
            Text = "Detectar y recoger objetos";
            Paint += EventoDiseñoFormulario;
            KeyDown += EventoPresionarTeclas;
            KeyUp += EventoSoltarTeclas;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label cantidadMovimientos;
        private Label cantidadObjetos;
        private System.Windows.Forms.Timer timer1;
    }
}