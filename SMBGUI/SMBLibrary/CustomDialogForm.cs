using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMBGUI.SMBLibrary
{
    public partial class CustomDialogForm : Form
    {
        public CustomDialogForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.LightGray; // Set a different background color
            this.FormBorderStyle = FormBorderStyle.None;

            // Add a custom border
            Panel borderPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.DarkGray,
                Padding = new Padding(1) // Adjust the padding to create a border effect
            };
            this.Controls.Add(borderPanel);

            // Add the main content panel
            Panel contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.LightGray
            };
            borderPanel.Controls.Add(contentPanel);

            // Add a custom close button
            //Button closeButton = new Button
            //{
            //    Text = "Close",
            //    Dock = DockStyle.Bottom,
            //    Height = 30
            //};
            //closeButton.Click += (s, e) => this.Close();
            //contentPanel.Controls.Add(closeButton);
        }
    }
}
