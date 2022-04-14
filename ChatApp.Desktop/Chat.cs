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
        private string messageTextToSend;
        private HubConnection connection;

        public Chat()
        {
            InitializeComponent();
            EstablishConnection();
        }


        private async Task EstablishConnection()
        {
            connection = new HubConnectionBuilder().WithUrl("http://localhost:38347/chats/").Build();

            connection.On<string>("ReceiveMessage", (message) =>
            {
                if (message != messageTextToSend)
                {
                    AddMessage(new MessageToSend()
                    {
                        IsOut = false,
                        MessageText = message,
                    });
                }
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
            await CreateAndSendMessage();
        }

        private async void txt_msg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await CreateAndSendMessage();
            }
        }

        public async Task CreateAndSendMessage()
        {
            this.messageTextToSend = txt_msg.Text;

            MessageToSend messageToSend = new MessageToSend()
            {
                MessageText = this.messageTextToSend,
                SendTo = cmb_sendTo.SelectedItem.ToString(),
                IsOut = true
            };

            txt_msg.Text = "";

            switch (messageToSend.SendTo)
            {
                case "All":
                    await connection.InvokeAsync("SendMessageToAll", messageToSend.MessageText);
                    break;
                case "All Clients":
                    await connection.InvokeAsync("SendMessageToServer", messageToSend.MessageText);
                    break;
                case "All Administrators":
                    await connection.InvokeAsync("SendMessageToServer", messageToSend.MessageText);
                    break;
                default:
                    break;
            }



            AddMessage(messageToSend);

        }


        public void AddMessage(MessageToSend message)
        {   
 
            var cssBg = !message.IsOut
                ? "background-color: #ccffcc; text-align: left; margin-right: 40px; margin-left: 5px;  corner-radius: 5px; "
                : "background-color: #ffffff; text-align: right; margin-right: 5px; margin-left: 40px; corner-radius: 5px; ";


            chat_Panel.Text += $"<div style='font-weight: bold; margin-top: 5px; {cssBg} padding: 5px; border: 1px solid #cccccc; color: #3b5063; font-family: Tahoma; font-size: 10pt;'>"
                + (!message.IsOut
                    ? $"<table border='0' style='width: 100%;'> <tr> <td colspan='2'>Server</td></tr><tr><td style='vertical-align: bottom;'>{DateTime.Now.ToString(@"HH\:mm")}</td><td style='vertical-align: top; text-align: right'>{message.MessageText}</td></tr></table>"
                    : $"<table border='0' style='width: 480px; float: right;'> <tr><td style='width: 40px'></td> <td colspan='2'>You</td></tr><tr><td style='width: 50px'></td><td style='vertical-align: top; text-align: left'>{message.MessageText}</td><td style='vertical-align: bottom;'>{DateTime.Now.ToString(@"HH\:mm")}</td></tr></table>")
                + $"</div><div style='height:0' id='msg_{_messageCounter}'></div>";

            chat_Panel.ScrollToElement($"msg_{_messageCounter}");
            _messageCounter++;
        }
    }
}
