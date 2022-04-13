using ChatApp.Desktop.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApp.Desktop
{
    public partial class Chat : Form
    {
        private int _messageCounter;

        private HubConnection connection;

        public Chat()
        {
            InitializeComponent();
            EstablishConnection();
        }


        private async Task EstablishConnection()
        {
            connection = new HubConnectionBuilder().WithUrl("http://localhost:38347/chats/").Build();

            connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
            });

            try
            {
                await connection.StartAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while connecting the SignalR Hub. Message: " + ex.Message);
            }
        }

        private async void btn_send_Click(object sender, EventArgs e)
        {
            string message = txt_msg.Text;

            try
            {
                await SendMessageAsync(new MessageToSend()
                {
                    IsOut = true,
                    MessageText = message,
                    SendTo = "All"
                });

                AddMessage(new MessageToSend()
                {
                    IsOut = true,
                    MessageText = message,
                    SendTo = "All"
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        public async Task SendMessageAsync(MessageToSend message)
        {
            try
            {
                await connection.InvokeAsync("SendMessageToAll", message.MessageText);

                txt_msg.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AddMessage(MessageToSend message)
        {
            var cssDir = RightToLeft == RightToLeft.Yes ? "direction: rtl;" : "";

 
            var cssBg = message.IsOut
                ? "background-color: #ccffcc; text-align: left; margin-right: 40px; margin-left: 5px;  corner-radius: 5px; "
                : "background-color: #ffffff; text-align: right; margin-right: 5px; margin-left: 40px; corner-radius: 5px; ";


            chat_Panel.Text += $"<div style='font-weight: bold; margin-top: 5px; {cssBg} padding: 5px; border: 1px solid #cccccc; color: #3b5063; font-family: Tahoma; font-size: 10pt; {cssDir}'>"
                + (message.IsOut
                    ? $"<table border='0' style='width: 100%;'> <tr> <td colspan='2'>You</td></tr><tr><td style='vertical-align: bottom;'>{DateTime.Now.ToString(@"HH\:mm")}</td><td style='vertical-align: top; text-align: right'>{message.MessageText}</td></tr></table>"
                    : $"<table border='0' style='width: 360px; float: right;'> <tr><td style='width: 40px'></td> <td colspan='2'>Server</td></tr><tr><td style='width: 50px'></td><td style='vertical-align: top; text-align: left'>{message.MessageText}</td><td style='vertical-align: bottom;'>{DateTime.Now.ToString(@"HH\:mm")}</td></tr></table>")
                + $"</div><div style='height:0' id='msg_{_messageCounter}'></div>";

            chat_Panel.ScrollToElement($"msg_{_messageCounter}");
            _messageCounter++;
        }

        //private async void txt_msg_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        try
        //        {
        //            await connection.InvokeAsync("SendMessageToAll", message.MessageText);

        //            txt_msg.Text = "";
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }
        //}
    }
}
