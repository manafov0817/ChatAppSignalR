namespace ChatApp.Desktop
{
    partial class Chat
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
            this.txt_msg = new System.Windows.Forms.TextBox();
            this.cmb_sendTo = new System.Windows.Forms.ComboBox();
            this.lbl_sendTo = new System.Windows.Forms.Label();
            this.lbl_msg = new System.Windows.Forms.Label();
            this.btn_send = new System.Windows.Forms.Button();
            this.chat_Panel = new TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel();
            this.SuspendLayout();
            this.cmb_sendTo.Items.AddRange(new string[] { "All", "All Clients", "All Administrators" });
            this.cmb_sendTo.SelectedItem = "All";

            // 
            // txt_msg
            // 
            this.txt_msg.Font = new System.Drawing.Font("Hack", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_msg.Location = new System.Drawing.Point(10, 399);
            this.txt_msg.Name = "txt_msg";
            this.txt_msg.Size = new System.Drawing.Size(308, 31);
            this.txt_msg.TabIndex = 2;

            this.txt_msg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_msg_KeyDown);
            // 
            // cmb_sendTo
            // 
            this.cmb_sendTo.FormattingEnabled = true;
            this.cmb_sendTo.Location = new System.Drawing.Point(12, 32);
            this.cmb_sendTo.Name = "cmb_sendTo";
            this.cmb_sendTo.Size = new System.Drawing.Size(506, 28);
            this.cmb_sendTo.TabIndex = 1;
            // 
            // lbl_sendTo
            // 
            this.lbl_sendTo.AutoSize = true;
            this.lbl_sendTo.Location = new System.Drawing.Point(12, 9);
            this.lbl_sendTo.Name = "lbl_sendTo";
            this.lbl_sendTo.Size = new System.Drawing.Size(124, 20);
            this.lbl_sendTo.TabIndex = 2;
            this.lbl_sendTo.Text = "Send Message To";
            // 
            // lbl_msg
            // 
            this.lbl_msg.AutoSize = true;
            this.lbl_msg.Location = new System.Drawing.Point(10, 376);
            this.lbl_msg.Name = "lbl_msg";
            this.lbl_msg.Size = new System.Drawing.Size(67, 20);
            this.lbl_msg.TabIndex = 3;
            this.lbl_msg.Text = "Message";
            // 
            // btn_send
            // 
            this.btn_send.Font = new System.Drawing.Font("Hack", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_send.Location = new System.Drawing.Point(325, 376);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(193, 57);
            this.btn_send.TabIndex = 3;
            this.btn_send.Text = "Send Message";
            this.btn_send.UseMnemonic = false;
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // chat_Panel
            // 
            this.chat_Panel.AutoScroll = true;
            this.chat_Panel.BackColor = System.Drawing.SystemColors.Window;
            this.chat_Panel.BaseStylesheet = null;
            this.chat_Panel.Location = new System.Drawing.Point(10, 66);
            this.chat_Panel.Name = "chat_Panel";
            this.chat_Panel.Size = new System.Drawing.Size(508, 304);
            this.chat_Panel.TabIndex = 5;
            this.chat_Panel.Text = null;
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 445);
            this.Controls.Add(this.chat_Panel);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.lbl_msg);
            this.Controls.Add(this.lbl_sendTo);
            this.Controls.Add(this.cmb_sendTo);
            this.Controls.Add(this.txt_msg);
            this.Name = "Chat";
            this.Text = "Chat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txt_msg;
        private ComboBox cmb_sendTo;
        private Label lbl_sendTo;
        private Label lbl_msg;
        private Button btn_send;
        private TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel chat_Panel;
    }
}