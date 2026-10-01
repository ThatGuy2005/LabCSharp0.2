using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LabCSharp0._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.label1.MouseEnter += MoveLabelOnHover;
        }
        private void MoveLabelOnHover(object sender, EventArgs e)
        {
            // 1. Get mouse position relative to the form
            Point mousePos = this.PointToClient(Cursor.Position);

            // 2. Calculate the center point of the label
            Point labelCenter = new Point(
                label1.Left + label1.Width / 2,
                label1.Top + label1.Height / 2
            );

            // 3. Compute vector components from cursor to label center
            int deltaX = labelCenter.X - mousePos.X;
            int deltaY = labelCenter.Y - mousePos.Y;

            // 4. Calculate distance between mouse and label center
            double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
            int triggerRadius = 80; // Distance at which label starts moving

            if (distance < triggerRadius && distance > 0)
            {
                int moveStep = 20; // Distance to push the label away

                // Normalize vector and scale by moveStep
                int newX = label1.Left + (int)((deltaX / distance) * moveStep);
                int newY = label1.Top + (int)((deltaY / distance) * moveStep);

                // 5. Clamp coordinates to stay within form boundaries (Math.Clamp is unavailable in .NET 3.5)
                newX = Math.Max(0, Math.Min(newX, this.ClientSize.Width - label1.Width));
                newY = Math.Max(0, Math.Min(newY, this.ClientSize.Height - label1.Height));

                label1.Location = new Point(newX, newY);
            }
        }
    }
}
