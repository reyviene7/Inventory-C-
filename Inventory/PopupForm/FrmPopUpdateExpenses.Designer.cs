using System.Drawing;

namespace Inventory.PopupForm
{
    partial class FrmPopUpdateExpenses
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
            this.Icon = new Icon("wizard.ico");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPopUpdateExpenses));
            this.splashScreen = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::Inventory.MainForm.FrmWait), true, true);
            this.groupLauncher = new DevExpress.XtraEditors.GroupControl();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbRelatedEntity = new System.Windows.Forms.ComboBox();
            this.cmbExpensesType = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dkpExpensesDate = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bntExit = new DevExpress.XtraEditors.SimpleButton();
            this.lblMainTitle = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.bntAccept = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupLauncher)).BeginInit();
            this.groupLauncher.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupLauncher
            // 
            this.groupLauncher.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupLauncher.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.groupLauncher.Appearance.Options.UseBackColor = true;
            this.groupLauncher.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.groupLauncher.Controls.Add(this.cmbEmployee);
            this.groupLauncher.Controls.Add(this.label1);
            this.groupLauncher.Controls.Add(this.cmbRelatedEntity);
            this.groupLauncher.Controls.Add(this.cmbExpensesType);
            this.groupLauncher.Controls.Add(this.label10);
            this.groupLauncher.Controls.Add(this.dkpExpensesDate);
            this.groupLauncher.Controls.Add(this.pictureBox1);
            this.groupLauncher.Controls.Add(this.bntExit);
            this.groupLauncher.Controls.Add(this.lblMainTitle);
            this.groupLauncher.Controls.Add(this.txtDescription);
            this.groupLauncher.Controls.Add(this.label6);
            this.groupLauncher.Controls.Add(this.label2);
            this.groupLauncher.Controls.Add(this.txtAmount);
            this.groupLauncher.Controls.Add(this.label3);
            this.groupLauncher.Controls.Add(this.label7);
            this.groupLauncher.Controls.Add(this.bntAccept);
            this.groupLauncher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupLauncher.Location = new System.Drawing.Point(0, 0);
            this.groupLauncher.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.groupLauncher.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupLauncher.Name = "groupLauncher";
            this.groupLauncher.Size = new System.Drawing.Size(931, 522);
            this.groupLauncher.TabIndex = 10;
            this.groupLauncher.Text = "Stock Update Expenses From Daily Expenses";
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbEmployee.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbEmployee.BackColor = System.Drawing.Color.White;
            this.cmbEmployee.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.cmbEmployee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cmbEmployee.FormattingEnabled = true;
            this.cmbEmployee.Location = new System.Drawing.Point(259, 196);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(397, 43);
            this.cmbEmployee.TabIndex = 5;
            this.cmbEmployee.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbEmployee_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(37, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 28);
            this.label1.TabIndex = 285;
            this.label1.Text = "Employee :";
            // 
            // cmbRelatedEntity
            // 
            this.cmbRelatedEntity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRelatedEntity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRelatedEntity.BackColor = System.Drawing.Color.White;
            this.cmbRelatedEntity.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.cmbRelatedEntity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cmbRelatedEntity.FormattingEnabled = true;
            this.cmbRelatedEntity.Location = new System.Drawing.Point(259, 112);
            this.cmbRelatedEntity.Name = "cmbRelatedEntity";
            this.cmbRelatedEntity.Size = new System.Drawing.Size(397, 43);
            this.cmbRelatedEntity.TabIndex = 3;
            this.cmbRelatedEntity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbRelatedEntity_KeyDown);
            // 
            // cmbExpensesType
            // 
            this.cmbExpensesType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbExpensesType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbExpensesType.BackColor = System.Drawing.Color.White;
            this.cmbExpensesType.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.cmbExpensesType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cmbExpensesType.FormattingEnabled = true;
            this.cmbExpensesType.Location = new System.Drawing.Point(259, 28);
            this.cmbExpensesType.Name = "cmbExpensesType";
            this.cmbExpensesType.Size = new System.Drawing.Size(397, 43);
            this.cmbExpensesType.TabIndex = 1;
            this.cmbExpensesType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbExpensesType_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(38, 246);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 28);
            this.label10.TabIndex = 273;
            this.label10.Text = "Date:";
            // 
            // dkpExpensesDate
            // 
            this.dkpExpensesDate.CustomFormat = "dd-MM-yyyy";
            this.dkpExpensesDate.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.dkpExpensesDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dkpExpensesDate.Location = new System.Drawing.Point(259, 240);
            this.dkpExpensesDate.Name = "dkpExpensesDate";
            this.dkpExpensesDate.Size = new System.Drawing.Size(396, 41);
            this.dkpExpensesDate.TabIndex = 6;
            this.dkpExpensesDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dkpExpensesDate_KeyDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(704, 185);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(173, 229);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 271;
            this.pictureBox1.TabStop = false;
            // 
            // bntExit
            // 
            this.bntExit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bntExit.ImageOptions.Image")));
            this.bntExit.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.bntExit.Location = new System.Drawing.Point(267, 460);
            this.bntExit.Name = "bntExit";
            this.bntExit.Size = new System.Drawing.Size(371, 62);
            this.bntExit.TabIndex = 8;
            this.bntExit.ToolTip = "Close Item Delivery";
            this.bntExit.Click += new System.EventHandler(this.bntExit_Click);
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.AutoSize = true;
            this.lblMainTitle.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblMainTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblMainTitle.Location = new System.Drawing.Point(324, 309);
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Size = new System.Drawing.Size(227, 62);
            this.lblMainTitle.TabIndex = 270;
            this.lblMainTitle.Text = "Expenses";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold);
            this.txtDescription.Location = new System.Drawing.Point(259, 157);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(396, 38);
            this.txtDescription.TabIndex = 4;
            this.txtDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescription_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(36, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 28);
            this.label6.TabIndex = 264;
            this.label6.Text = "Description:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(37, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 28);
            this.label2.TabIndex = 258;
            this.label2.Text = "Related Entity:";
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.Color.White;
            this.txtAmount.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold);
            this.txtAmount.Location = new System.Drawing.Point(259, 73);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(396, 38);
            this.txtAmount.TabIndex = 2;
            this.txtAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyDown);
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(37, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 28);
            this.label3.TabIndex = 256;
            this.label3.Text = "Amount:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(37, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(154, 28);
            this.label7.TabIndex = 251;
            this.label7.Text = "Expenses Type:";
            // 
            // bntAccept
            // 
            this.bntAccept.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntAccept.Appearance.Options.UseFont = true;
            this.bntAccept.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bntAccept.ImageOptions.Image")));
            this.bntAccept.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.bntAccept.Location = new System.Drawing.Point(267, 390);
            this.bntAccept.Name = "bntAccept";
            this.bntAccept.Size = new System.Drawing.Size(371, 62);
            this.bntAccept.TabIndex = 7;
            this.bntAccept.ToolTip = "Accept Delivery";
            this.bntAccept.Click += new System.EventHandler(this.bntAccept_Click);
            // 
            // FrmPopUpdateExpenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 522);
            this.Controls.Add(this.groupLauncher);
            this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmPopUpdateExpenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update Expenses";
            this.Load += new System.EventHandler(this.FrmPopUpdateExpenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupLauncher)).EndInit();
            this.groupLauncher.ResumeLayout(false);
            this.groupLauncher.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupLauncher;
        private DevExpress.XtraEditors.SimpleButton bntAccept;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton bntExit;
        private System.Windows.Forms.Label lblMainTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dkpExpensesDate;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreen;
        private System.Windows.Forms.ComboBox cmbExpensesType;
        private System.Windows.Forms.ComboBox cmbRelatedEntity;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.Label label1;
    }
}