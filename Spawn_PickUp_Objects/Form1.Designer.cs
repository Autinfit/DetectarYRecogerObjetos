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
            cantidadMovimientos = new Label();
            SuspendLayout();
            // 
            // cantidadMovimientos
            // 
            cantidadMovimientos.AutoSize = true;
            cantidadMovimientos.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            cantidadMovimientos.ForeColor = Color.Red;
            cantidadMovimientos.Location = new Point(5, 500);
            cantidadMovimientos.Name = "cantidadMovimientos";
            cantidadMovimientos.Size = new Size(198, 38);
            cantidadMovimientos.TabIndex = 0;
            cantidadMovimientos.Text = "Movimientos:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(878, 544);
            Controls.Add(cantidadMovimientos);
            Name = "Form1";
            Text = "Detectar y recoger objetos";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label cantidadMovimientos;
    }
}