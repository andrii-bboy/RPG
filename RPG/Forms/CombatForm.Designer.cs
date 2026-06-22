namespace RPG.Forms
{
    partial class CombatForm
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
            this.btnHit = new System.Windows.Forms.Button();
            this.btnStrongHit = new System.Windows.Forms.Button();
            this.btnHeal = new System.Windows.Forms.Button();
            this.btnBlock = new System.Windows.Forms.Button();
            this.lblPlayerHP = new System.Windows.Forms.Label();
            this.lblPlayerMP = new System.Windows.Forms.Label();
            this.lblEnemyTitle = new System.Windows.Forms.Label();
            this.lblEnemyHP = new System.Windows.Forms.Label();
            this.txtCombatLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnHit
            // 
            this.btnHit.BackColor = System.Drawing.Color.Goldenrod;
            this.btnHit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnHit.Location = new System.Drawing.Point(131, 293);
            this.btnHit.Name = "btnHit";
            this.btnHit.Size = new System.Drawing.Size(192, 45);
            this.btnHit.TabIndex = 0;
            this.btnHit.Text = "Hit";
            this.btnHit.UseVisualStyleBackColor = false;
            this.btnHit.Click += new System.EventHandler(this.btnHit_Click);
            // 
            // btnStrongHit
            // 
            this.btnStrongHit.BackColor = System.Drawing.Color.Gold;
            this.btnStrongHit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStrongHit.Location = new System.Drawing.Point(426, 293);
            this.btnStrongHit.Name = "btnStrongHit";
            this.btnStrongHit.Size = new System.Drawing.Size(185, 45);
            this.btnStrongHit.TabIndex = 1;
            this.btnStrongHit.Text = "Strong Hit";
            this.btnStrongHit.UseVisualStyleBackColor = false;
            this.btnStrongHit.Click += new System.EventHandler(this.btnStrongHit_Click);
            // 
            // btnHeal
            // 
            this.btnHeal.BackColor = System.Drawing.Color.Lime;
            this.btnHeal.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnHeal.Location = new System.Drawing.Point(131, 356);
            this.btnHeal.Name = "btnHeal";
            this.btnHeal.Size = new System.Drawing.Size(192, 49);
            this.btnHeal.TabIndex = 2;
            this.btnHeal.Text = "Heal";
            this.btnHeal.UseVisualStyleBackColor = false;
            this.btnHeal.Click += new System.EventHandler(this.btnHeal_Click);
            // 
            // btnBlock
            // 
            this.btnBlock.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnBlock.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBlock.Location = new System.Drawing.Point(426, 356);
            this.btnBlock.Name = "btnBlock";
            this.btnBlock.Size = new System.Drawing.Size(185, 49);
            this.btnBlock.TabIndex = 3;
            this.btnBlock.Text = "Block";
            this.btnBlock.UseVisualStyleBackColor = false;
            this.btnBlock.Click += new System.EventHandler(this.btnBlock_Click);
            // 
            // lblPlayerHP
            // 
            this.lblPlayerHP.AutoSize = true;
            this.lblPlayerHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPlayerHP.Location = new System.Drawing.Point(12, 20);
            this.lblPlayerHP.Name = "lblPlayerHP";
            this.lblPlayerHP.Size = new System.Drawing.Size(98, 32);
            this.lblPlayerHP.TabIndex = 4;
            this.lblPlayerHP.Text = "label1";
            // 
            // lblPlayerMP
            // 
            this.lblPlayerMP.AutoSize = true;
            this.lblPlayerMP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPlayerMP.Location = new System.Drawing.Point(13, 71);
            this.lblPlayerMP.Name = "lblPlayerMP";
            this.lblPlayerMP.Size = new System.Drawing.Size(70, 25);
            this.lblPlayerMP.TabIndex = 6;
            this.lblPlayerMP.Text = "label2";
            // 
            // lblEnemyTitle
            // 
            this.lblEnemyTitle.AutoSize = true;
            this.lblEnemyTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblEnemyTitle.Location = new System.Drawing.Point(199, 126);
            this.lblEnemyTitle.Name = "lblEnemyTitle";
            this.lblEnemyTitle.Size = new System.Drawing.Size(85, 29);
            this.lblEnemyTitle.TabIndex = 7;
            this.lblEnemyTitle.Text = "label3";
            // 
            // lblEnemyHP
            // 
            this.lblEnemyHP.AutoSize = true;
            this.lblEnemyHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblEnemyHP.Location = new System.Drawing.Point(482, 20);
            this.lblEnemyHP.Name = "lblEnemyHP";
            this.lblEnemyHP.Size = new System.Drawing.Size(98, 32);
            this.lblEnemyHP.TabIndex = 8;
            this.lblEnemyHP.Text = "label1";
            // 
            // txtCombatLog
            // 
            this.txtCombatLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtCombatLog.Location = new System.Drawing.Point(131, 158);
            this.txtCombatLog.Multiline = true;
            this.txtCombatLog.Name = "txtCombatLog";
            this.txtCombatLog.ReadOnly = true;
            this.txtCombatLog.Size = new System.Drawing.Size(480, 120);
            this.txtCombatLog.TabIndex = 9;
            // 
            // CombatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OliveDrab;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtCombatLog);
            this.Controls.Add(this.lblEnemyHP);
            this.Controls.Add(this.lblEnemyTitle);
            this.Controls.Add(this.lblPlayerMP);
            this.Controls.Add(this.lblPlayerHP);
            this.Controls.Add(this.btnBlock);
            this.Controls.Add(this.btnHeal);
            this.Controls.Add(this.btnStrongHit);
            this.Controls.Add(this.btnHit);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "CombatForm";
            this.Text = "CombatForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHit;
        private System.Windows.Forms.Button btnStrongHit;
        private System.Windows.Forms.Button btnHeal;
        private System.Windows.Forms.Button btnBlock;
        private System.Windows.Forms.Label lblPlayerHP;
        private System.Windows.Forms.Label lblPlayerMP;
        private System.Windows.Forms.Label lblEnemyTitle;
        private System.Windows.Forms.Label lblEnemyHP;
        private System.Windows.Forms.TextBox txtCombatLog;
    }
}