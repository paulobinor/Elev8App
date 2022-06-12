
namespace Elev8App
{
    partial class frmAddEditLearner
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
            System.Windows.Forms.Label azpassLabel;
            System.Windows.Forms.Label emailLabel;
            System.Windows.Forms.Label examvoucherLabel;
            System.Windows.Forms.Label fullnameLabel;
            System.Windows.Forms.Label labLabel;
            System.Windows.Forms.Label mocLabel;
            System.Windows.Forms.Label organizationLabel;
            System.Windows.Forms.Label phoneLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddEditLearner));
            this.azpassTextBox = new System.Windows.Forms.TextBox();
            this.traningsessionlineitemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.examvoucherTextBox = new System.Windows.Forms.TextBox();
            this.fullnameTextBox = new System.Windows.Forms.TextBox();
            this.labTextBox = new System.Windows.Forms.TextBox();
            this.mocTextBox = new System.Windows.Forms.TextBox();
            this.organizationTextBox = new System.Windows.Forms.TextBox();
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btndelete = new DevExpress.XtraEditors.SimpleButton();
            azpassLabel = new System.Windows.Forms.Label();
            emailLabel = new System.Windows.Forms.Label();
            examvoucherLabel = new System.Windows.Forms.Label();
            fullnameLabel = new System.Windows.Forms.Label();
            labLabel = new System.Windows.Forms.Label();
            mocLabel = new System.Windows.Forms.Label();
            organizationLabel = new System.Windows.Forms.Label();
            phoneLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.traningsessionlineitemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // azpassLabel
            // 
            azpassLabel.AutoSize = true;
            azpassLabel.Location = new System.Drawing.Point(21, 199);
            azpassLabel.Name = "azpassLabel";
            azpassLabel.Size = new System.Drawing.Size(84, 17);
            azpassLabel.TabIndex = 1;
            azpassLabel.Text = "Azure Pass:";
            azpassLabel.Click += new System.EventHandler(this.azpassLabel_Click);
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new System.Drawing.Point(55, 43);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(50, 17);
            emailLabel.TabIndex = 3;
            emailLabel.Text = "e-mail:";
            // 
            // examvoucherLabel
            // 
            examvoucherLabel.AutoSize = true;
            examvoucherLabel.Location = new System.Drawing.Point(2, 227);
            examvoucherLabel.Name = "examvoucherLabel";
            examvoucherLabel.Size = new System.Drawing.Size(103, 17);
            examvoucherLabel.TabIndex = 5;
            examvoucherLabel.Text = "Exam Voucher:";
            // 
            // fullnameLabel
            // 
            fullnameLabel.AutoSize = true;
            fullnameLabel.Location = new System.Drawing.Point(30, 15);
            fullnameLabel.Name = "fullnameLabel";
            fullnameLabel.Size = new System.Drawing.Size(75, 17);
            fullnameLabel.TabIndex = 7;
            fullnameLabel.Text = "Full Name:";
            // 
            // labLabel
            // 
            labLabel.AutoSize = true;
            labLabel.Location = new System.Drawing.Point(40, 143);
            labLabel.Name = "labLabel";
            labLabel.Size = new System.Drawing.Size(65, 17);
            labLabel.TabIndex = 9;
            labLabel.Text = "Lab-Key:";
            // 
            // mocLabel
            // 
            mocLabel.AutoSize = true;
            mocLabel.Location = new System.Drawing.Point(25, 171);
            mocLabel.Name = "mocLabel";
            mocLabel.Size = new System.Drawing.Size(80, 17);
            mocLabel.TabIndex = 13;
            mocLabel.Text = "MOC Code:";
            // 
            // organizationLabel
            // 
            organizationLabel.AutoSize = true;
            organizationLabel.Location = new System.Drawing.Point(12, 71);
            organizationLabel.Name = "organizationLabel";
            organizationLabel.Size = new System.Drawing.Size(93, 17);
            organizationLabel.TabIndex = 15;
            organizationLabel.Text = "Organization:";
            // 
            // phoneLabel
            // 
            phoneLabel.AutoSize = true;
            phoneLabel.Location = new System.Drawing.Point(52, 101);
            phoneLabel.Name = "phoneLabel";
            phoneLabel.Size = new System.Drawing.Size(53, 17);
            phoneLabel.TabIndex = 17;
            phoneLabel.Text = "Phone:";
            // 
            // azpassTextBox
            // 
            this.azpassTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.traningsessionlineitemBindingSource, "azpass", true));
            this.azpassTextBox.Location = new System.Drawing.Point(111, 196);
            this.azpassTextBox.Name = "azpassTextBox";
            this.azpassTextBox.Size = new System.Drawing.Size(245, 22);
            this.azpassTextBox.TabIndex = 2;
            // 
            // traningsessionlineitemBindingSource
            // 
            this.traningsessionlineitemBindingSource.DataSource = typeof(Elev8App.traningsessionlineitem);
            // 
            // emailTextBox
            // 
            this.emailTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.traningsessionlineitemBindingSource, "email", true));
            this.emailTextBox.Location = new System.Drawing.Point(111, 40);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(245, 22);
            this.emailTextBox.TabIndex = 4;
            // 
            // examvoucherTextBox
            // 
            this.examvoucherTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.traningsessionlineitemBindingSource, "examvoucher", true));
            this.examvoucherTextBox.Location = new System.Drawing.Point(111, 224);
            this.examvoucherTextBox.Name = "examvoucherTextBox";
            this.examvoucherTextBox.Size = new System.Drawing.Size(245, 22);
            this.examvoucherTextBox.TabIndex = 6;
            // 
            // fullnameTextBox
            // 
            this.fullnameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fullnameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.traningsessionlineitemBindingSource, "fullname", true));
            this.fullnameTextBox.Location = new System.Drawing.Point(111, 12);
            this.fullnameTextBox.Name = "fullnameTextBox";
            this.fullnameTextBox.Size = new System.Drawing.Size(451, 22);
            this.fullnameTextBox.TabIndex = 8;
            // 
            // labTextBox
            // 
            this.labTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.traningsessionlineitemBindingSource, "lab", true));
            this.labTextBox.Location = new System.Drawing.Point(111, 140);
            this.labTextBox.Name = "labTextBox";
            this.labTextBox.Size = new System.Drawing.Size(245, 22);
            this.labTextBox.TabIndex = 10;
            // 
            // mocTextBox
            // 
            this.mocTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.traningsessionlineitemBindingSource, "moc", true));
            this.mocTextBox.Location = new System.Drawing.Point(111, 168);
            this.mocTextBox.Name = "mocTextBox";
            this.mocTextBox.Size = new System.Drawing.Size(245, 22);
            this.mocTextBox.TabIndex = 14;
            // 
            // organizationTextBox
            // 
            this.organizationTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.traningsessionlineitemBindingSource, "organization", true));
            this.organizationTextBox.Location = new System.Drawing.Point(111, 68);
            this.organizationTextBox.Name = "organizationTextBox";
            this.organizationTextBox.Size = new System.Drawing.Size(245, 22);
            this.organizationTextBox.TabIndex = 16;
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.traningsessionlineitemBindingSource, "phone", true));
            this.phoneTextBox.Location = new System.Drawing.Point(111, 96);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(245, 22);
            this.phoneTextBox.TabIndex = 18;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(470, 254);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(92, 29);
            this.simpleButton1.TabIndex = 19;
            this.simpleButton1.Text = "Save";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btndelete
            // 
            this.btndelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btndelete.ImageOptions.Image")));
            this.btndelete.Location = new System.Drawing.Point(5, 260);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(88, 29);
            this.btndelete.TabIndex = 19;
            this.btndelete.Text = "Delete";
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // frmAddEditLearner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 295);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(azpassLabel);
            this.Controls.Add(this.azpassTextBox);
            this.Controls.Add(emailLabel);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(examvoucherLabel);
            this.Controls.Add(this.examvoucherTextBox);
            this.Controls.Add(fullnameLabel);
            this.Controls.Add(this.fullnameTextBox);
            this.Controls.Add(labLabel);
            this.Controls.Add(this.labTextBox);
            this.Controls.Add(mocLabel);
            this.Controls.Add(this.mocTextBox);
            this.Controls.Add(organizationLabel);
            this.Controls.Add(this.organizationTextBox);
            this.Controls.Add(phoneLabel);
            this.Controls.Add(this.phoneTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddEditLearner";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmAddEditLearner_Load);
            ((System.ComponentModel.ISupportInitialize)(this.traningsessionlineitemBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource traningsessionlineitemBindingSource;
        private System.Windows.Forms.TextBox azpassTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox examvoucherTextBox;
        private System.Windows.Forms.TextBox fullnameTextBox;
        private System.Windows.Forms.TextBox labTextBox;
        private System.Windows.Forms.TextBox mocTextBox;
        private System.Windows.Forms.TextBox organizationTextBox;
        private System.Windows.Forms.TextBox phoneTextBox;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton btndelete;
    }
}