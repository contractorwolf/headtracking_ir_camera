namespace StreetViewer
{
    partial class BrowserViewerForm
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
            this.wbMainBrowser = new System.Windows.Forms.WebBrowser();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.btnRequest = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHeading = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnChangeHeading = new System.Windows.Forms.Button();
            this.txtLastMessage = new System.Windows.Forms.TextBox();
            this.btnIncreaseHeading = new System.Windows.Forms.Button();
            this.btnDecreaseHeading = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // wbMainBrowser
            // 
            this.wbMainBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wbMainBrowser.Location = new System.Drawing.Point(-1, 1);
            this.wbMainBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbMainBrowser.Name = "wbMainBrowser";
            this.wbMainBrowser.ScrollBarsEnabled = false;
            this.wbMainBrowser.Size = new System.Drawing.Size(987, 606);
            this.wbMainBrowser.TabIndex = 0;
            // 
            // txtLocation
            // 
            this.txtLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocation.Location = new System.Drawing.Point(485, 1);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(173, 26);
            this.txtLocation.TabIndex = 1;
            // 
            // btnRequest
            // 
            this.btnRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRequest.Location = new System.Drawing.Point(662, 0);
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Size = new System.Drawing.Size(36, 23);
            this.btnRequest.TabIndex = 2;
            this.btnRequest.Text = "go";
            this.btnRequest.UseVisualStyleBackColor = true;
            this.btnRequest.Click += new System.EventHandler(this.btnRequest_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(435, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "location";
            // 
            // txtHeading
            // 
            this.txtHeading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHeading.Location = new System.Drawing.Point(789, 1);
            this.txtHeading.Name = "txtHeading";
            this.txtHeading.Size = new System.Drawing.Size(57, 26);
            this.txtHeading.TabIndex = 5;
            this.txtHeading.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHeading_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(718, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "heading";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 610);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(988, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // btnChangeHeading
            // 
            this.btnChangeHeading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeHeading.Location = new System.Drawing.Point(879, 1);
            this.btnChangeHeading.Name = "btnChangeHeading";
            this.btnChangeHeading.Size = new System.Drawing.Size(102, 23);
            this.btnChangeHeading.TabIndex = 8;
            this.btnChangeHeading.Text = "change heading";
            this.btnChangeHeading.UseVisualStyleBackColor = true;
            this.btnChangeHeading.Click += new System.EventHandler(this.btnChangeHeading_Click);
            // 
            // txtLastMessage
            // 
            this.txtLastMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastMessage.Location = new System.Drawing.Point(818, 31);
            this.txtLastMessage.Name = "txtLastMessage";
            this.txtLastMessage.Size = new System.Drawing.Size(162, 26);
            this.txtLastMessage.TabIndex = 11;
            // 
            // btnIncreaseHeading
            // 
            this.btnIncreaseHeading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIncreaseHeading.Location = new System.Drawing.Point(847, 1);
            this.btnIncreaseHeading.Name = "btnIncreaseHeading";
            this.btnIncreaseHeading.Size = new System.Drawing.Size(22, 23);
            this.btnIncreaseHeading.TabIndex = 12;
            this.btnIncreaseHeading.Text = "+";
            this.btnIncreaseHeading.UseVisualStyleBackColor = true;
            this.btnIncreaseHeading.Click += new System.EventHandler(this.btnIncreaseHeading_Click);
            // 
            // btnDecreaseHeading
            // 
            this.btnDecreaseHeading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDecreaseHeading.Location = new System.Drawing.Point(766, 1);
            this.btnDecreaseHeading.Name = "btnDecreaseHeading";
            this.btnDecreaseHeading.Size = new System.Drawing.Size(22, 23);
            this.btnDecreaseHeading.TabIndex = 13;
            this.btnDecreaseHeading.Text = "-";
            this.btnDecreaseHeading.UseVisualStyleBackColor = true;
            this.btnDecreaseHeading.Click += new System.EventHandler(this.btnDecreaseHeading_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(880, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(101, 101);
            this.panel1.TabIndex = 14;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Location = new System.Drawing.Point(879, 170);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(101, 101);
            this.panel2.TabIndex = 15;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // BrowserViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 632);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDecreaseHeading);
            this.Controls.Add(this.btnIncreaseHeading);
            this.Controls.Add(this.txtLastMessage);
            this.Controls.Add(this.btnChangeHeading);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtHeading);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRequest);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.wbMainBrowser);
            this.Name = "BrowserViewerForm";
            this.Text = "Headtracking Google Street Viewer";
            this.Load += new System.EventHandler(this.BrowserViewerForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BrowserViewerForm_KeyDown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbMainBrowser;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Button btnRequest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHeading;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btnChangeHeading;
        private System.Windows.Forms.TextBox txtLastMessage;
        private System.Windows.Forms.Button btnIncreaseHeading;
        private System.Windows.Forms.Button btnDecreaseHeading;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}