namespace RPG.Forms
{
    partial class CharacterSelectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CharacterSelectionForm));
            this.btnWarrior = new System.Windows.Forms.Button();
            this.btnArcher = new System.Windows.Forms.Button();
            this.btnMage = new System.Windows.Forms.Button();
            this.Archer = new System.Windows.Forms.PictureBox();
            this.Mage = new System.Windows.Forms.PictureBox();
            this.Warrior = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Archer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Warrior)).BeginInit();
            this.SuspendLayout();
            // 
            // btnWarrior
            // 
            this.btnWarrior.BackColor = System.Drawing.Color.Yellow;
            this.btnWarrior.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnWarrior.Location = new System.Drawing.Point(551, 681);
            this.btnWarrior.Name = "btnWarrior";
            this.btnWarrior.Size = new System.Drawing.Size(265, 131);
            this.btnWarrior.TabIndex = 0;
            this.btnWarrior.Text = "Warrior";
            this.btnWarrior.UseVisualStyleBackColor = false;
            this.btnWarrior.Click += new System.EventHandler(this.btnWarrior_Click);
            // 
            // btnArcher
            // 
            this.btnArcher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnArcher.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnArcher.Location = new System.Drawing.Point(1083, 681);
            this.btnArcher.Name = "btnArcher";
            this.btnArcher.Size = new System.Drawing.Size(265, 131);
            this.btnArcher.TabIndex = 1;
            this.btnArcher.Text = "Archer";
            this.btnArcher.UseVisualStyleBackColor = false;
            this.btnArcher.Click += new System.EventHandler(this.btnArcher_Click);
            // 
            // btnMage
            // 
            this.btnMage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnMage.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMage.Location = new System.Drawing.Point(41, 681);
            this.btnMage.Name = "btnMage";
            this.btnMage.Size = new System.Drawing.Size(265, 131);
            this.btnMage.TabIndex = 2;
            this.btnMage.Text = "Mage";
            this.btnMage.UseVisualStyleBackColor = false;
            this.btnMage.Click += new System.EventHandler(this.btnMage_Click);
            // 
            // Archer
            // 
            this.Archer.Image = ((System.Drawing.Image)(resources.GetObject("Archer.Image")));
            this.Archer.Location = new System.Drawing.Point(1020, 60);
            this.Archer.Name = "Archer";
            this.Archer.Size = new System.Drawing.Size(395, 583);
            this.Archer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Archer.TabIndex = 7;
            this.Archer.TabStop = false;
            // 
            // Mage
            // 
            this.Mage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Mage.Image = global::RPG.Properties.Resources.Dumbledore;
            this.Mage.Location = new System.Drawing.Point(-13, 60);
            this.Mage.Name = "Mage";
            this.Mage.Size = new System.Drawing.Size(446, 583);
            this.Mage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Mage.TabIndex = 6;
            this.Mage.TabStop = false;
            // 
            // Warrior
            // 
            this.Warrior.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Warrior.Image = global::RPG.Properties.Resources.Pikachu;
            this.Warrior.Location = new System.Drawing.Point(496, 60);
            this.Warrior.Name = "Warrior";
            this.Warrior.Size = new System.Drawing.Size(448, 557);
            this.Warrior.TabIndex = 4;
            this.Warrior.TabStop = false;
            // 
            // CharacterSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1410, 824);
            this.Controls.Add(this.Archer);
            this.Controls.Add(this.Mage);
            this.Controls.Add(this.Warrior);
            this.Controls.Add(this.btnMage);
            this.Controls.Add(this.btnArcher);
            this.Controls.Add(this.btnWarrior);
            this.Name = "CharacterSelectionForm";
            this.Text = "CharacterSelectionForm";
            ((System.ComponentModel.ISupportInitialize)(this.Archer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Warrior)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnWarrior;
        private System.Windows.Forms.Button btnArcher;
        private System.Windows.Forms.Button btnMage;
        private System.Windows.Forms.PictureBox Warrior;
        private System.Windows.Forms.PictureBox Mage;
        private System.Windows.Forms.PictureBox Archer;
    }
}