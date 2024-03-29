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
            this.cB_Items = new System.Windows.Forms.ComboBox();
            this.l_itemsInWorld = new System.Windows.Forms.Label();
            this.l_selectedItemNumber = new System.Windows.Forms.Label();
            this.b_selectItemPrevioaus = new System.Windows.Forms.Button();
            this.b_selectItemNext = new System.Windows.Forms.Button();
            this.tB_selectedItemInfos = new System.Windows.Forms.TextBox();
            this.tB_contains = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
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
            this.dGV_Terraformation.AllowUserToResizeColumns = false;
            this.dGV_Terraformation.AllowUserToResizeRows = false;
            this.dGV_Terraformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_Terraformation.Location = new System.Drawing.Point(12, 41);
            this.dGV_Terraformation.Name = "dGV_Terraformation";
            this.dGV_Terraformation.ReadOnly = true;
            this.dGV_Terraformation.RowHeadersVisible = false;
            this.dGV_Terraformation.RowTemplate.Height = 25;
            this.dGV_Terraformation.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dGV_Terraformation.Size = new System.Drawing.Size(503, 175);
            this.dGV_Terraformation.TabIndex = 5;
            // 
            // cB_Items
            // 
            this.cB_Items.Enabled = false;
            this.cB_Items.FormattingEnabled = true;
            this.cB_Items.Location = new System.Drawing.Point(12, 237);
            this.cB_Items.Name = "cB_Items";
            this.cB_Items.Size = new System.Drawing.Size(179, 23);
            this.cB_Items.TabIndex = 6;
            this.cB_Items.SelectedIndexChanged += new System.EventHandler(this.cB_Items_DropDownClosed);
            this.cB_Items.SelectionChangeCommitted += new System.EventHandler(this.cB_Items_DropDownClosed);
            // 
            // l_itemsInWorld
            // 
            this.l_itemsInWorld.AutoSize = true;
            this.l_itemsInWorld.Enabled = false;
            this.l_itemsInWorld.Location = new System.Drawing.Point(12, 219);
            this.l_itemsInWorld.Name = "l_itemsInWorld";
            this.l_itemsInWorld.Size = new System.Drawing.Size(151, 15);
            this.l_itemsInWorld.TabIndex = 7;
            this.l_itemsInWorld.Text = "Amount of Items in World: ";
            // 
            // l_selectedItemNumber
            // 
            this.l_selectedItemNumber.AutoSize = true;
            this.l_selectedItemNumber.Enabled = false;
            this.l_selectedItemNumber.Location = new System.Drawing.Point(12, 263);
            this.l_selectedItemNumber.Name = "l_selectedItemNumber";
            this.l_selectedItemNumber.Size = new System.Drawing.Size(106, 15);
            this.l_selectedItemNumber.TabIndex = 7;
            this.l_selectedItemNumber.Text = "Selected Item No.: ";
            // 
            // b_selectItemPrevioaus
            // 
            this.b_selectItemPrevioaus.Enabled = false;
            this.b_selectItemPrevioaus.Location = new System.Drawing.Point(12, 281);
            this.b_selectItemPrevioaus.Name = "b_selectItemPrevioaus";
            this.b_selectItemPrevioaus.Size = new System.Drawing.Size(86, 23);
            this.b_selectItemPrevioaus.TabIndex = 8;
            this.b_selectItemPrevioaus.Text = "previous";
            this.b_selectItemPrevioaus.UseVisualStyleBackColor = true;
            this.b_selectItemPrevioaus.Click += new System.EventHandler(this.b_selectItemPrevioaus_Click);
            // 
            // b_selectItemNext
            // 
            this.b_selectItemNext.Enabled = false;
            this.b_selectItemNext.Location = new System.Drawing.Point(105, 281);
            this.b_selectItemNext.Name = "b_selectItemNext";
            this.b_selectItemNext.Size = new System.Drawing.Size(86, 23);
            this.b_selectItemNext.TabIndex = 8;
            this.b_selectItemNext.Text = "next";
            this.b_selectItemNext.UseVisualStyleBackColor = true;
            this.b_selectItemNext.Click += new System.EventHandler(this.b_selectItemNext_Click);
            // 
            // tB_selectedItemInfos
            // 
            this.tB_selectedItemInfos.BackColor = System.Drawing.SystemColors.Control;
            this.tB_selectedItemInfos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tB_selectedItemInfos.Location = new System.Drawing.Point(12, 310);
            this.tB_selectedItemInfos.Multiline = true;
            this.tB_selectedItemInfos.Name = "tB_selectedItemInfos";
            this.tB_selectedItemInfos.Size = new System.Drawing.Size(179, 143);
            this.tB_selectedItemInfos.TabIndex = 9;
            // 
            // tB_contains
            // 
            this.tB_contains.BackColor = System.Drawing.SystemColors.Control;
            this.tB_contains.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tB_contains.Location = new System.Drawing.Point(197, 310);
            this.tB_contains.Multiline = true;
            this.tB_contains.Name = "tB_contains";
            this.tB_contains.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tB_contains.Size = new System.Drawing.Size(179, 143);
            this.tB_contains.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(440, 237);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SafefileAnalyzer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 465);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tB_contains);
            this.Controls.Add(this.tB_selectedItemInfos);
            this.Controls.Add(this.b_selectItemNext);
            this.Controls.Add(this.b_selectItemPrevioaus);
            this.Controls.Add(this.l_selectedItemNumber);
            this.Controls.Add(this.l_itemsInWorld);
            this.Controls.Add(this.cB_Items);
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
        private ComboBox cB_Items;
        private Label l_itemsInWorld;
        private Label l_selectedItemNumber;
        private Button b_selectItemPrevioaus;
        private Button b_selectItemNext;
        private TextBox tB_selectedItemInfos;
        private TextBox tB_contains;
        private Button button1;
    }
}