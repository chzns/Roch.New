using System;
using System.Windows.Forms;
using System.Threading.Tasks;


namespace Roch.CodeTool
{


    public static class MessageBoxHelper
    {
        public static async void ShowTimedMessage(string message, string title, int duration)
        {
            var messageBox = new Form()
            {
                Size = new System.Drawing.Size(0, 0),
                StartPosition = FormStartPosition.CenterScreen,
                ShowInTaskbar = false,
                FormBorderStyle = FormBorderStyle.None,
                Opacity = 0
            };

            messageBox.Load += async (sender, e) =>
            {
                await Task.Delay(duration);
                messageBox.Close();
            };

            messageBox.Shown += (sender, e) =>
            {
                Task.Run(async () =>
                {
                    await Task.Delay(duration);
                    messageBox.Invoke(new Action(() => messageBox.Close()));
                });
                MessageBox.Show(messageBox, message, title);
            };

            messageBox.ShowDialog();
        }
    }
}
