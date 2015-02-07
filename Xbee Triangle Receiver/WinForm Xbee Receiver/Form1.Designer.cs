namespace WinForm_Xbee_Receiver
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
            this.pbIR = new System.Windows.Forms.PictureBox();
            this.txtPoint = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFrequency = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMessageCount = new System.Windows.Forms.TextBox();
            this.txtTimeStamp = new System.Windows.Forms.TextBox();
            this.txtLastMessage = new System.Windows.Forms.TextBox();
            this.lbReadings = new System.Windows.Forms.ListBox();
            this.lblPoint = new System.Windows.Forms.Label();
            this.btnShowReadings = new System.Windows.Forms.Button();
            this.btnClearReadings = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pbIR)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbIR
            // 
            this.pbIR.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbIR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbIR.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbIR.Location = new System.Drawing.Point(12, 4);
            this.pbIR.Name = "pbIR";
            this.pbIR.Size = new System.Drawing.Size(688, 391);
            this.pbIR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbIR.TabIndex = 29;
            this.pbIR.TabStop = false;
            // 
            // txtPoint
            // 
            this.txtPoint.Location = new System.Drawing.Point(183, 79);
            this.txtPoint.Name = "txtPoint";
            this.txtPoint.Size = new System.Drawing.Size(48, 20);
            this.txtPoint.TabIndex = 41;
            this.txtPoint.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(98, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "ms";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(26, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "freq";
            // 
            // txtFrequency
            // 
            this.txtFrequency.Location = new System.Drawing.Point(60, 104);
            this.txtFrequency.Name = "txtFrequency";
            this.txtFrequency.Size = new System.Drawing.Size(35, 20);
            this.txtFrequency.TabIndex = 38;
            this.txtFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(16, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "count";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "timestamp";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "message";
            // 
            // txtMessageCount
            // 
            this.txtMessageCount.Location = new System.Drawing.Point(60, 78);
            this.txtMessageCount.Name = "txtMessageCount";
            this.txtMessageCount.Size = new System.Drawing.Size(48, 20);
            this.txtMessageCount.TabIndex = 34;
            // 
            // txtTimeStamp
            // 
            this.txtTimeStamp.Location = new System.Drawing.Point(60, 53);
            this.txtTimeStamp.Name = "txtTimeStamp";
            this.txtTimeStamp.Size = new System.Drawing.Size(204, 20);
            this.txtTimeStamp.TabIndex = 33;
            // 
            // txtLastMessage
            // 
            this.txtLastMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastMessage.Location = new System.Drawing.Point(60, 9);
            this.txtLastMessage.Multiline = true;
            this.txtLastMessage.Name = "txtLastMessage";
            this.txtLastMessage.Size = new System.Drawing.Size(204, 38);
            this.txtLastMessage.TabIndex = 32;
            // 
            // lbReadings
            // 
            this.lbReadings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lbReadings.FormattingEnabled = true;
            this.lbReadings.Location = new System.Drawing.Point(6, 130);
            this.lbReadings.Name = "lbReadings";
            this.lbReadings.Size = new System.Drawing.Size(258, 264);
            this.lbReadings.TabIndex = 31;
            this.lbReadings.Visible = false;
            // 
            // lblPoint
            // 
            this.lblPoint.AutoSize = true;
            this.lblPoint.BackColor = System.Drawing.Color.Black;
            this.lblPoint.ForeColor = System.Drawing.Color.White;
            this.lblPoint.Location = new System.Drawing.Point(346, 139);
            this.lblPoint.Name = "lblPoint";
            this.lblPoint.Size = new System.Drawing.Size(20, 13);
            this.lblPoint.TabIndex = 42;
            this.lblPoint.Text = "x,y";
            this.lblPoint.Visible = false;
            // 
            // btnShowReadings
            // 
            this.btnShowReadings.Location = new System.Drawing.Point(222, 104);
            this.btnShowReadings.Name = "btnShowReadings";
            this.btnShowReadings.Size = new System.Drawing.Size(42, 23);
            this.btnShowReadings.TabIndex = 43;
            this.btnShowReadings.Text = "show";
            this.btnShowReadings.UseVisualStyleBackColor = true;
            this.btnShowReadings.Click += new System.EventHandler(this.btnShowReadings_Click);
            // 
            // btnClearReadings
            // 
            this.btnClearReadings.Location = new System.Drawing.Point(181, 104);
            this.btnClearReadings.Name = "btnClearReadings";
            this.btnClearReadings.Size = new System.Drawing.Size(42, 23);
            this.btnClearReadings.TabIndex = 44;
            this.btnClearReadings.Text = "clear";
            this.btnClearReadings.UseVisualStyleBackColor = true;
            this.btnClearReadings.Click += new System.EventHandler(this.btnClearReadings_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 385);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(712, 22);
            this.statusStrip1.TabIndex = 45;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.Black;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(52, 17);
            this.toolStripStatusLabel1.Text = "progress";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(712, 407);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnClearReadings);
            this.Controls.Add(this.btnShowReadings);
            this.Controls.Add(this.lblPoint);
            this.Controls.Add(this.txtPoint);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFrequency);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMessageCount);
            this.Controls.Add(this.txtTimeStamp);
            this.Controls.Add(this.txtLastMessage);
            this.Controls.Add(this.lbReadings);
            this.Controls.Add(this.pbIR);
            this.Name = "Form1";
            this.Text = "Triangle Visualizer";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbIR)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox pbIR;
        private System.Windows.Forms.TextBox txtPoint;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFrequency;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMessageCount;
        private System.Windows.Forms.TextBox txtTimeStamp;
        private System.Windows.Forms.TextBox txtLastMessage;
        private System.Windows.Forms.ListBox lbReadings;
        private System.Windows.Forms.Label lblPoint;
        private System.Windows.Forms.Button btnShowReadings;
        private System.Windows.Forms.Button btnClearReadings;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

