namespace Lab10TP
{
    partial class ChildForm2
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
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.StatusStrip2 = new System.Windows.Forms.StatusStrip();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(479, 24);
            this.menuStrip2.TabIndex = 0;
            this.menuStrip2.Text = "menuStrip1";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(12, 56);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(440, 234);
            this.richTextBox2.TabIndex = 1;
            this.richTextBox2.Text = "";
            // 
            // StatusStrip2
            // 
            this.StatusStrip2.Location = new System.Drawing.Point(0, 326);
            this.StatusStrip2.Name = "StatusStrip2";
            this.StatusStrip2.Size = new System.Drawing.Size(479, 22);
            this.StatusStrip2.TabIndex = 2;
            this.StatusStrip2.Text = "statusStrip1";
            // 
            // ChildForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 348);
            this.Controls.Add(this.StatusStrip2);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip2;
            this.Name = "ChildForm2";
            this.Text = "ChildForm2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip2;
        public System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.StatusStrip StatusStrip2;
    }
}