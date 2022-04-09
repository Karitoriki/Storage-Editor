﻿namespace Storage_Editor
{
    partial class SafefileAnalyzer
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
            this.b_clipboard = new System.Windows.Forms.Button();
            this.l_player_pos = new System.Windows.Forms.Label();
            this.dGV_Terraformation = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Terraformation)).BeginInit();
            this.SuspendLayout();
            // 
            // b_clipboard
            // 
            this.b_clipboard.Location = new System.Drawing.Point(12, 12);
            this.b_clipboard.Name = "b_clipboard";
            this.b_clipboard.Size = new System.Drawing.Size(193, 23);
            this.b_clipboard.TabIndex = 0;
            this.b_clipboard.Text = "Clipboard";
            this.b_clipboard.UseVisualStyleBackColor = true;
            this.b_clipboard.Click += new System.EventHandler(this.b_clipboard_Click);
            // 
            // l_player_pos
            // 
            this.l_player_pos.AutoSize = true;
            this.l_player_pos.Location = new System.Drawing.Point(211, 16);
            this.l_player_pos.Name = "l_player_pos";
            this.l_player_pos.Size = new System.Drawing.Size(80, 15);
            this.l_player_pos.TabIndex = 2;
            this.l_player_pos.Text = "Your Position:";
            // 
            // dGV_Terraformation
            // 
            this.dGV_Terraformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_Terraformation.Location = new System.Drawing.Point(12, 41);
            this.dGV_Terraformation.Name = "dGV_Terraformation";
            this.dGV_Terraformation.ReadOnly = true;
            this.dGV_Terraformation.RowHeadersVisible = false;
            this.dGV_Terraformation.RowTemplate.Height = 25;
            this.dGV_Terraformation.Size = new System.Drawing.Size(403, 367);
            this.dGV_Terraformation.TabIndex = 5;
            // 
            // SafefileAnalyzer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dGV_Terraformation);
            this.Controls.Add(this.l_player_pos);
            this.Controls.Add(this.b_clipboard);
            this.Name = "SafefileAnalyzer";
            this.Text = "Planet Crafter Safefile Editor";
            this.Load += new System.EventHandler(this.SafefileAnalyzer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Terraformation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button b_clipboard;
        private Label l_player_pos;
        private DataGridView dGV_Terraformation;
    }
}