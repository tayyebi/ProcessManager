namespace ProcessManager
{
    partial class MainForm
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
            this.List = new System.Windows.Forms.ListView();
            this.ControlPanel = new System.Windows.Forms.Panel();
            this.TerminateButton = new System.Windows.Forms.Button();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.ListButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.ProtectionPanel = new System.Windows.Forms.Panel();
            this.DisableButton = new System.Windows.Forms.Button();
            this.EnableButton = new System.Windows.Forms.Button();
            this.PathTextBox = new System.Windows.Forms.TextBox();
            this.ChooseButton = new System.Windows.Forms.Button();
            this.ControlPanel.SuspendLayout();
            this.ProtectionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // List
            // 
            this.List.Dock = System.Windows.Forms.DockStyle.Fill;
            this.List.FullRowSelect = true;
            this.List.Location = new System.Drawing.Point(0, 0);
            this.List.MultiSelect = false;
            this.List.Name = "List";
            this.List.Size = new System.Drawing.Size(253, 350);
            this.List.TabIndex = 0;
            this.List.UseCompatibleStateImageBehavior = false;
            this.List.SelectedIndexChanged += new System.EventHandler(this.ProcessList_SelectedIndexChanged);
            // 
            // ControlPanel
            // 
            this.ControlPanel.BackColor = System.Drawing.Color.Transparent;
            this.ControlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ControlPanel.Controls.Add(this.TerminateButton);
            this.ControlPanel.Controls.Add(this.ApplyButton);
            this.ControlPanel.Controls.Add(this.RefreshButton);
            this.ControlPanel.Controls.Add(this.ListButton);
            this.ControlPanel.Controls.Add(this.RemoveButton);
            this.ControlPanel.Controls.Add(this.AddButton);
            this.ControlPanel.Controls.Add(this.ProtectionPanel);
            this.ControlPanel.Controls.Add(this.PathTextBox);
            this.ControlPanel.Controls.Add(this.ChooseButton);
            this.ControlPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ControlPanel.Location = new System.Drawing.Point(0, 350);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Size = new System.Drawing.Size(253, 138);
            this.ControlPanel.TabIndex = 1;
            // 
            // TerminateButton
            // 
            this.TerminateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TerminateButton.Location = new System.Drawing.Point(129, 110);
            this.TerminateButton.Name = "TerminateButton";
            this.TerminateButton.Size = new System.Drawing.Size(118, 23);
            this.TerminateButton.TabIndex = 9;
            this.TerminateButton.Text = "Terminate";
            this.TerminateButton.UseVisualStyleBackColor = true;
            this.TerminateButton.Click += new System.EventHandler(this.TerminateButton_Click);
            // 
            // ApplyButton
            // 
            this.ApplyButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ApplyButton.Location = new System.Drawing.Point(3, 110);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(118, 23);
            this.ApplyButton.TabIndex = 8;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(129, 85);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(118, 23);
            this.RefreshButton.TabIndex = 7;
            this.RefreshButton.Text = "Process List";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // ListButton
            // 
            this.ListButton.Location = new System.Drawing.Point(129, 59);
            this.ListButton.Name = "ListButton";
            this.ListButton.Size = new System.Drawing.Size(118, 23);
            this.ListButton.TabIndex = 6;
            this.ListButton.Text = "Allowed list";
            this.ListButton.UseVisualStyleBackColor = true;
            this.ListButton.Click += new System.EventHandler(this.ListButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(129, 33);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(118, 23);
            this.RemoveButton.TabIndex = 5;
            this.RemoveButton.Text = "Remove from allowed list";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(3, 33);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(118, 23);
            this.AddButton.TabIndex = 4;
            this.AddButton.Text = "Add to allowed list";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // ProtectionPanel
            // 
            this.ProtectionPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ProtectionPanel.Controls.Add(this.DisableButton);
            this.ProtectionPanel.Controls.Add(this.EnableButton);
            this.ProtectionPanel.Location = new System.Drawing.Point(3, 59);
            this.ProtectionPanel.Name = "ProtectionPanel";
            this.ProtectionPanel.Size = new System.Drawing.Size(120, 49);
            this.ProtectionPanel.TabIndex = 10;
            this.ProtectionPanel.Tag = "";
            // 
            // DisableButton
            // 
            this.DisableButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DisableButton.Location = new System.Drawing.Point(0, 22);
            this.DisableButton.Name = "DisableButton";
            this.DisableButton.Size = new System.Drawing.Size(116, 23);
            this.DisableButton.TabIndex = 1;
            this.DisableButton.Text = "Disable Protection";
            this.DisableButton.UseVisualStyleBackColor = true;
            this.DisableButton.Click += new System.EventHandler(this.DisableButton_Click);
            // 
            // EnableButton
            // 
            this.EnableButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.EnableButton.Location = new System.Drawing.Point(0, 0);
            this.EnableButton.Name = "EnableButton";
            this.EnableButton.Size = new System.Drawing.Size(116, 23);
            this.EnableButton.TabIndex = 0;
            this.EnableButton.Text = "Enable Protection";
            this.EnableButton.UseVisualStyleBackColor = true;
            this.EnableButton.Click += new System.EventHandler(this.EnableButton_Click);
            // 
            // PathTextBox
            // 
            this.PathTextBox.Location = new System.Drawing.Point(3, 4);
            this.PathTextBox.Name = "PathTextBox";
            this.PathTextBox.Size = new System.Drawing.Size(163, 20);
            this.PathTextBox.TabIndex = 2;
            // 
            // ChooseButton
            // 
            this.ChooseButton.Location = new System.Drawing.Point(172, 4);
            this.ChooseButton.Name = "ChooseButton";
            this.ChooseButton.Size = new System.Drawing.Size(75, 23);
            this.ChooseButton.TabIndex = 3;
            this.ChooseButton.Text = "Choose Executable";
            this.ChooseButton.UseVisualStyleBackColor = true;
            this.ChooseButton.Click += new System.EventHandler(this.ChooseButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 488);
            this.Controls.Add(this.List);
            this.Controls.Add(this.ControlPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Opacity = 0.9D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tayyebi - Process Manager";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ControlPanel.ResumeLayout(false);
            this.ControlPanel.PerformLayout();
            this.ProtectionPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView List;
        private System.Windows.Forms.Panel ControlPanel;
        private System.Windows.Forms.Button ChooseButton;
        private System.Windows.Forms.TextBox PathTextBox;
        private System.Windows.Forms.Panel ProtectionPanel;
        private System.Windows.Forms.Button DisableButton;
        private System.Windows.Forms.Button EnableButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button ListButton;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button TerminateButton;
        private System.Windows.Forms.Button ApplyButton;
    }
}

