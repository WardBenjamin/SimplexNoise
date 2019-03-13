// Simplex Noise for C#
// Copyright © Benjamin Ward 2019
// See LICENSE
// Simplex Noise implementation offering 1D, 2D, and 3D forms w/ values in the range of 0 to 255.
// Based on work by Heikki Törmälä (2012) and Stefan Gustavson (2006).

namespace NoiseTest
{
    partial class Form1
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
            this.ControlPanel = new System.Windows.Forms.Panel();
            this.OverrideSeed = new System.Windows.Forms.CheckBox();
            this.NewSeedLabel = new System.Windows.Forms.Label();
            this.NewSeed = new System.Windows.Forms.TextBox();
            this.GridSizeLabel = new System.Windows.Forms.Label();
            this.GridSize = new System.Windows.Forms.HScrollBar();
            this.GridMaximumLabel = new System.Windows.Forms.Label();
            this.GridMinimumLabel = new System.Windows.Forms.Label();
            this.TimeTakenLabel = new System.Windows.Forms.Label();
            this.ControlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ControlPanel
            // 
            this.ControlPanel.Controls.Add(this.TimeTakenLabel);
            this.ControlPanel.Controls.Add(this.GridMinimumLabel);
            this.ControlPanel.Controls.Add(this.GridMaximumLabel);
            this.ControlPanel.Controls.Add(this.GridSize);
            this.ControlPanel.Controls.Add(this.GridSizeLabel);
            this.ControlPanel.Controls.Add(this.NewSeed);
            this.ControlPanel.Controls.Add(this.NewSeedLabel);
            this.ControlPanel.Controls.Add(this.OverrideSeed);
            this.ControlPanel.Location = new System.Drawing.Point(12, 12);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Size = new System.Drawing.Size(538, 122);
            this.ControlPanel.TabIndex = 0;
            // 
            // OverrideSeed
            // 
            this.OverrideSeed.AutoSize = true;
            this.OverrideSeed.Location = new System.Drawing.Point(4, 4);
            this.OverrideSeed.Name = "OverrideSeed";
            this.OverrideSeed.Size = new System.Drawing.Size(130, 21);
            this.OverrideSeed.TabIndex = 0;
            this.OverrideSeed.Text = "Override Seed?";
            this.OverrideSeed.UseVisualStyleBackColor = true;
            this.OverrideSeed.CheckStateChanged += new System.EventHandler(this.RecalculateNoise);
            // 
            // NewSeedLabel
            // 
            this.NewSeedLabel.AutoSize = true;
            this.NewSeedLabel.Location = new System.Drawing.Point(35, 32);
            this.NewSeedLabel.Name = "NewSeedLabel";
            this.NewSeedLabel.Size = new System.Drawing.Size(80, 17);
            this.NewSeedLabel.TabIndex = 1;
            this.NewSeedLabel.Text = "New Seed?";
            // 
            // NewSeed
            // 
            this.NewSeed.Enabled = false;
            this.NewSeed.Location = new System.Drawing.Point(137, 29);
            this.NewSeed.Name = "NewSeed";
            this.NewSeed.Size = new System.Drawing.Size(100, 22);
            this.NewSeed.TabIndex = 2;
            this.NewSeed.Text = "12345";
            this.NewSeed.TextChanged += new System.EventHandler(this.RecalculateNoise);
            // 
            // GridSizeLabel
            // 
            this.GridSizeLabel.AutoSize = true;
            this.GridSizeLabel.Location = new System.Drawing.Point(4, 66);
            this.GridSizeLabel.Name = "GridSizeLabel";
            this.GridSizeLabel.Size = new System.Drawing.Size(92, 17);
            this.GridSizeLabel.TabIndex = 3;
            this.GridSizeLabel.Text = "Grid Size (1):";
            // 
            // GridSize
            // 
            this.GridSize.Location = new System.Drawing.Point(137, 66);
            this.GridSize.Minimum = 1;
            this.GridSize.Name = "GridSize";
            this.GridSize.Size = new System.Drawing.Size(320, 21);
            this.GridSize.TabIndex = 4;
            this.GridSize.Value = 1;
            this.GridSize.Scroll += new System.Windows.Forms.ScrollEventHandler(this.RecalculateNoise);
            // 
            // GridMaximumLabel
            // 
            this.GridMaximumLabel.AutoSize = true;
            this.GridMaximumLabel.Location = new System.Drawing.Point(472, 66);
            this.GridMaximumLabel.Name = "GridMaximumLabel";
            this.GridMaximumLabel.Size = new System.Drawing.Size(32, 17);
            this.GridMaximumLabel.TabIndex = 5;
            this.GridMaximumLabel.Text = "100";
            // 
            // GridMinimumLabel
            // 
            this.GridMinimumLabel.AutoSize = true;
            this.GridMinimumLabel.Location = new System.Drawing.Point(109, 66);
            this.GridMinimumLabel.Name = "GridMinimumLabel";
            this.GridMinimumLabel.Size = new System.Drawing.Size(16, 17);
            this.GridMinimumLabel.TabIndex = 6;
            this.GridMinimumLabel.Text = "1";
            // 
            // TimeTakenLabel
            // 
            this.TimeTakenLabel.AutoSize = true;
            this.TimeTakenLabel.Location = new System.Drawing.Point(7, 102);
            this.TimeTakenLabel.Name = "TimeTakenLabel";
            this.TimeTakenLabel.Size = new System.Drawing.Size(0, 17);
            this.TimeTakenLabel.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 634);
            this.Controls.Add(this.ControlPanel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Noise Example";
            this.Resize += new System.EventHandler(this.RecalculateNoise);
            this.ControlPanel.ResumeLayout(false);
            this.ControlPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ControlPanel;
        private System.Windows.Forms.Label GridMinimumLabel;
        private System.Windows.Forms.Label GridMaximumLabel;
        private System.Windows.Forms.HScrollBar GridSize;
        private System.Windows.Forms.Label GridSizeLabel;
        private System.Windows.Forms.TextBox NewSeed;
        private System.Windows.Forms.Label NewSeedLabel;
        private System.Windows.Forms.CheckBox OverrideSeed;
        private System.Windows.Forms.Label TimeTakenLabel;

    }
}

