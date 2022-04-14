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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chat));
            this.cmb_sendTo = new System.Windows.Forms.ComboBox();
            this.lbl_sendTo = new System.Windows.Forms.Label();
            this.btn_send = new System.Windows.Forms.Button();
            this.chat_Panel = new TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel();
            this.txt_msg = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmb_sendTo
            // 
            this.cmb_sendTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_sendTo.FormattingEnabled = true;
            this.cmb_sendTo.SelectedItem = "All";
            this.cmb_sendTo.SelectedText = "All";

            this.cmb_sendTo.Items.AddRange(new object[] {
            "All"});
            this.cmb_sendTo.Location = new System.Drawing.Point(142, 6);
            this.cmb_sendTo.Name = "cmb_sendTo";
            this.cmb_sendTo.Size = new System.Drawing.Size(371, 28);
            this.cmb_sendTo.TabIndex = 0;
            this.cmb_sendTo.TabStop = false;
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
            // btn_send
            // 
            this.btn_send.BackColor = System.Drawing.Color.White;
            this.btn_send.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_send.BackgroundImage")));
            this.btn_send.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_send.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_send.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btn_send.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btn_send.Font = new System.Drawing.Font("Hack", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_send.ForeColor = System.Drawing.Color.Black;
            this.btn_send.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btn_send.Location = new System.Drawing.Point(352, 643);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(161, 34);
            this.btn_send.TabIndex = 3;
            this.btn_send.Text = "Send";
            this.btn_send.UseMnemonic = false;
            this.btn_send.UseVisualStyleBackColor = false;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // chat_Panel
            // 
            this.chat_Panel.AutoScroll = true;
            this.chat_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(228)))), ((int)(((byte)(199)))));
            this.chat_Panel.BaseStylesheet = null;
            this.chat_Panel.Location = new System.Drawing.Point(12, 40);
            this.chat_Panel.Name = "chat_Panel";
            this.chat_Panel.Size = new System.Drawing.Size(501, 597);
            this.chat_Panel.TabIndex = 5;
            this.chat_Panel.Text = null;
            // 
            // txt_msg
            // 
            this.txt_msg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_msg.BackColor = System.Drawing.Color.White;
            this.txt_msg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_msg.Font = new System.Drawing.Font("Hack", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_msg.Location = new System.Drawing.Point(12, 643);
            this.txt_msg.Name = "txt_msg";
            this.txt_msg.Size = new System.Drawing.Size(334, 34);
            this.txt_msg.TabIndex = 2;
            this.txt_msg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_msg_KeyDown);
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(522, 688);
            this.Controls.Add(this.txt_msg);
            this.Controls.Add(this.lbl_sendTo);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.cmb_sendTo);
            this.Controls.Add(this.chat_Panel);
            this.MaximizeBox = false;
            this.Name = "Chat";
            this.Text = "Chat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cmb_sendTo;
        private Label lbl_sendTo;
        private Button btn_send;
        private TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel chat_Panel;
        private TextBox txt_msg;
    }
}