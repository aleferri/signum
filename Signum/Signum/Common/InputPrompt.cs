using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Signum.Common
{
    public class InputPrompt
    {
        private static Form BuildForm(string title, int width, int height)
        {
            Form form = new Form()
            {
                Text = title,
                FormBorderStyle = FormBorderStyle.FixedSingle,
                StartPosition = FormStartPosition.CenterParent,
                MinimizeBox = false,
                MaximizeBox = false,
                Width = width,
                Height = height
            };
            return form;
        }

        private static Control BuildUpperPanel(string message, TextBox inputField)
        {
            FlowLayoutPanel upPanel = new FlowLayoutPanel();
            upPanel.FlowDirection = FlowDirection.TopDown;
            upPanel.Dock = DockStyle.Fill;

            Label messageLabel = new Label();
            if (null != message)
            {
                messageLabel.Text = message;
                upPanel.Controls.Add(messageLabel);
            }
            upPanel.Controls.Add(inputField);

            return upPanel;
        }

        public static string ShowInputDialog(string message, string title, string ok, string cancel, string content)
        {
            using (InputDialog form = new InputDialog())
            {
                form.OK.Text = ok;
                form.Cancel.Text = cancel;
                form.MessageLabel.Text = message;
                form.Text = title;
                form.InputField.Text = content;
                DialogResult result = form.ShowDialog();
                if (result != DialogResult.OK || result == DialogResult.OK && form.InputField.Text == "")
                {
                    return null;
                }

                return form.InputField.Text;
            }
        }
        public static string ShowInputDialog(string message, string title, string ok, string cancel)
        {
            return ShowInputDialog(message, title, ok, cancel, "");
        }

        public static string ShowInputDialog(string message, string title)
        {
            return ShowInputDialog(message, title, "OK", "Cancel", "");
        }

        public static string ShowInputDialog(string message)
        {
            return ShowInputDialog(message, "Input", "OK", "Cancel", "");
        }
    }
}
