namespace Shooter_Cave
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
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.PlayerCount = new System.Windows.Forms.Label();
            this.EnemyCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PlayerHealth = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 30;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // PlayerCount
            // 
            this.PlayerCount.AutoSize = true;
            this.PlayerCount.BackColor = System.Drawing.Color.Transparent;
            this.PlayerCount.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerCount.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PlayerCount.Location = new System.Drawing.Point(807, 49);
            this.PlayerCount.Name = "PlayerCount";
            this.PlayerCount.Size = new System.Drawing.Size(120, 21);
            this.PlayerCount.TabIndex = 19;
            this.PlayerCount.Text = "Player Count : ";
            // 
            // EnemyCount
            // 
            this.EnemyCount.AutoSize = true;
            this.EnemyCount.BackColor = System.Drawing.Color.Transparent;
            this.EnemyCount.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnemyCount.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.EnemyCount.Location = new System.Drawing.Point(806, 81);
            this.EnemyCount.Name = "EnemyCount";
            this.EnemyCount.Size = new System.Drawing.Size(124, 21);
            this.EnemyCount.TabIndex = 20;
            this.EnemyCount.Text = "Enemy Count : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(831, 494);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 21);
            this.label1.TabIndex = 21;
            this.label1.Text = "Score :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(820, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 21);
            this.label2.TabIndex = 23;
            this.label2.Text = "Player Health  ";
            // 
            // PlayerHealth
            // 
            this.PlayerHealth.BackColor = System.Drawing.Color.Transparent;
            this.PlayerHealth.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.PlayerHealth.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.PlayerHealth.ForeColor = System.Drawing.Color.Transparent;
            this.PlayerHealth.Location = new System.Drawing.Point(827, 247);
            this.PlayerHealth.Minimum = 0;
            this.PlayerHealth.Name = "PlayerHealth";
            this.PlayerHealth.ProgressColor = System.Drawing.Color.DarkTurquoise;
            this.PlayerHealth.ProgressColor2 = System.Drawing.Color.SteelBlue;
            this.PlayerHealth.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.PlayerHealth.Size = new System.Drawing.Size(105, 105);
            this.PlayerHealth.TabIndex = 25;
            this.PlayerHealth.Text = "guna2CircleProgressBar1";
            this.PlayerHealth.Value = 100;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::Shooter_Cave.Properties.Resources._56c9d4af798727ead21b705acfdde184;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(976, 534);
            this.Controls.Add(this.PlayerHealth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EnemyCount);
            this.Controls.Add(this.PlayerCount);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label PlayerCount;
        private System.Windows.Forms.Label EnemyCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2CircleProgressBar PlayerHealth;
    }
}

