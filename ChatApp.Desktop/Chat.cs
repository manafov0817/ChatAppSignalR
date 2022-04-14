using ChatApp.Desktop.Models;
using Microsoft.AspNetCore.SignalR.Client;

namespace ChatApp.Desktop
{
    public partial class Chat : Form
    {
        private int _messageCounter;
        private string _messageTextToSend;
        private HubConnection connection;

        private string _connectionId;
        private bool haveConnectionId = false;

        public Chat()
        {
            InitializeComponent();
            EstablishConnection();
        }


        private async Task EstablishConnection()
        {
            connection = new HubConnectionBuilder().WithUrl("http://localhost:38347/chats/").Build();

            connection.On<string>("UserConnected", (connectionId) =>
            {
                if (!haveConnectionId)
                {
                    _connectionId = connectionId;
                    haveConnectionId= true;
                }
                else
                {
                    cmb_sendTo.Items.Add(connectionId);
                }
            });

            connection.On<string>("UserDisconnected", (connectionId) =>
            {
                cmb_sendTo.Items.Remove(connectionId);
            });

            connection.On<string>("ReceiveMessage", (message) =>
            {
                if (message != _messageTextToSend)
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
            this._messageTextToSend = txt_msg.Text;

            if (cmb_sendTo.SelectedItem == null || txt_msg.Text == "")
            {
                MessageBox.Show("Please, fill the fields correctly");
                return;
            }

            MessageToSend messageToSend = new MessageToSend()
            {
                MessageText = this._messageTextToSend,
                SendTo = cmb_sendTo.SelectedItem.ToString(),
                IsOut = true
            };


            switch (messageToSend.SendTo)
            {
                case "All":
                    await connection.InvokeAsync("SendMessageToAll", messageToSend.MessageText);
                    break;
                default:
                    await connection.InvokeAsync("SendMessageToClient", messageToSend.SendTo, messageToSend.MessageText);
                    break;
            }

            AddMessage(messageToSend);

            txt_msg.Text = "";

        }


        public void AddMessage(MessageToSend message)
        {
            var cssBg = !message.IsOut
                ? "background-color: #40916c; text-align: left; margin-right: 40px; margin-left: 5px;  corner-radius: 5px; "
                : "background-color: #ffffff; text-align: right; margin-right: 5px; margin-left: 40px; corner-radius: 5px; ";


            chat_Panel.Text += $"<div style='font-weight: bold; margin-top: 5px; {cssBg} padding: 5px; border: 1px solid #cccccc;{(!message.IsOut ? "color: #ffffff;" : "color: #00000;")}  font-family: Tahoma; font-size: 10pt;'>"
                + (!message.IsOut
                    ? $"<table border='0' style='width: 100%;'> <tr> <td colspan='2'>Server</td></tr><tr><td style='vertical-align: bottom;'>{DateTime.Now.ToString(@"HH\:mm")}</td><td style='vertical-align: top; text-align: right'>{message.MessageText}</td></tr></table>"
                    : $"<table border='0' style='width: 470px; float: right;'> <tr><td style='width: 40px'></td> <td colspan='2'>You</td></tr><tr><td style='width: 50px'></td><td style='vertical-align: top; text-align: left'>{message.MessageText}</td><td style='vertical-align: bottom;'>{DateTime.Now.ToString(@"HH\:mm")}</td></tr></table>")
                + $"</div><div style='height:0' id='msg_{_messageCounter}'></div>";

            chat_Panel.ScrollToElement($"msg_{_messageCounter}");
            _messageCounter++;
        }


    }
}
