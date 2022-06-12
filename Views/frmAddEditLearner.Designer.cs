
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
            System.Windows.Forms.Label label1;
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
            this.textBoxSerialNo = new System.Windows.Forms.TextBox();
            this.btndelete = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            azpassLabel = new System.Windows.Forms.Label();
            emailLabel = new System.Windows.Forms.Label();
            examvoucherLabel = new System.Windows.Forms.Label();
            fullnameLabel = new System.Windows.Forms.Label();
            labLabel = new System.Windows.Forms.Label();
            mocLabel = new System.Windows.Forms.Label();
            organizationLabel = new System.Windows.Forms.Label();
            phoneLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.traningsessionlineitemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // azpassLabel
            // 
            azpassLabel.AutoSize = true;
            azpassLabel.Location = new System.Drawing.Point(16, 162);
            azpassLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            azpassLabel.Name = "azpassLabel";
            azpassLabel.Size = new System.Drawing.Size(63, 13);
            azpassLabel.TabIndex = 1;
            azpassLabel.Text = "Azure Pass:";
            azpassLabel.Click += new System.EventHandler(this.azpassLabel_Click);
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new System.Drawing.Point(41, 35);
            emailLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(37, 13);
            emailLabel.TabIndex = 3;
            emailLabel.Text = "e-mail:";
            // 
            // examvoucherLabel
            // 
            examvoucherLabel.AutoSize = true;
            examvoucherLabel.Location = new System.Drawing.Point(0, 184);
            examvoucherLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            examvoucherLabel.Name = "examvoucherLabel";
            examvoucherLabel.Size = new System.Drawing.Size(79, 13);
            examvoucherLabel.TabIndex = 5;
            examvoucherLabel.Text = "Exam Voucher:";
            // 
            // fullnameLabel
            // 
            fullnameLabel.AutoSize = true;
            fullnameLabel.Location = new System.Drawing.Point(21, 12);
            fullnameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            fullnameLabel.Name = "fullnameLabel";
            fullnameLabel.Size = new System.Drawing.Size(57, 13);
            fullnameLabel.TabIndex = 7;
            fullnameLabel.Text = "Full Name:";
            // 
            // labLabel
            // 
            labLabel.AutoSize = true;
            labLabel.Location = new System.Drawing.Point(30, 118);
            labLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            labLabel.Name = "labLabel";
            labLabel.Size = new System.Drawing.Size(49, 13);
            labLabel.TabIndex = 9;
            labLabel.Text = "Lab-Key:";
            // 
            // mocLabel
            // 
            mocLabel.AutoSize = true;
            mocLabel.Location = new System.Drawing.Point(17, 140);
            mocLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            mocLabel.Name = "mocLabel";
            mocLabel.Size = new System.Drawing.Size(62, 13);
            mocLabel.TabIndex = 13;
            mocLabel.Text = "MOC Code:";
            // 
            // organizationLabel
            // 
            organizationLabel.AutoSize = true;
            organizationLabel.Location = new System.Drawing.Point(9, 58);
            organizationLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            organizationLabel.Name = "organizationLabel";
            organizationLabel.Size = new System.Drawing.Size(69, 13);
            organizationLabel.TabIndex = 15;
            organizationLabel.Text = "Organization:";
            // 
            // phoneLabel
            // 
            phoneLabel.AutoSize = true;
            phoneLabel.Location = new System.Drawing.Point(37, 81);
            phoneLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            phoneLabel.Name = "phoneLabel";
            phoneLabel.Size = new System.Drawing.Size(41, 13);
            phoneLabel.TabIndex = 17;
            phoneLabel.Text = "Phone:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(25, 207);
            label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(53, 13);
            label1.TabIndex = 5;
            label1.Text = "Serial No:";
            // 
            // azpassTextBox
            // 
            this.azpassTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.traningsessionlineitemBindingSource, "azpass", true));
            this.azpassTextBox.Location = new System.Drawing.Point(83, 158);
            this.azpassTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.azpassTextBox.Name = "azpassTextBox";
            this.azpassTextBox.Size = new System.Drawing.Size(185, 20);
            this.azpassTextBox.TabIndex = 6;
            // 
            // traningsessionlineitemBindingSource
            // 
            this.traningsessionlineitemBindingSource.DataSource = typeof(Elev8App.traningsessionlineitem);
            // 
            // emailTextBox
            // 
            this.emailTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.traningsessionlineitemBindingSource, "email", true));
            this.emailTextBox.Location = new System.Drawing.Point(83, 31);
            this.emailTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(185, 20);
            this.emailTextBox.TabIndex = 1;
            // 
            // examvoucherTextBox
            // 
            this.examvoucherTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.traningsessionlineitemBindingSource, "examvoucher", true));
            this.examvoucherTextBox.Location = new System.Drawing.Point(83, 180);
            this.examvoucherTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.examvoucherTextBox.Name = "examvoucherTextBox";
            this.examvoucherTextBox.Size = new System.Drawing.Size(185, 20);
            this.examvoucherTextBox.TabIndex = 7;
            // 
            // fullnameTextBox
            // 
            this.fullnameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fullnameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.traningsessionlineitemBindingSource, "fullname", true));
            this.fullnameTextBox.Location = new System.Drawing.Point(83, 8);
            this.fullnameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.fullnameTextBox.Name = "fullnameTextBox";
            this.fullnameTextBox.Size = new System.Drawing.Size(286, 20);
            this.fullnameTextBox.TabIndex = 0;
            // 
            // labTextBox
            // 
            this.labTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.traningsessionlineitemBindingSource, "lab", true));
            this.labTextBox.Location = new System.Drawing.Point(83, 114);
            this.labTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.labTextBox.Name = "labTextBox";
            this.labTextBox.Size = new System.Drawing.Size(185, 20);
            this.labTextBox.TabIndex = 4;
            // 
            // mocTextBox
            // 
            this.mocTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.traningsessionlineitemBindingSource, "moc", true));
            this.mocTextBox.Location = new System.Drawing.Point(83, 136);
            this.mocTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.mocTextBox.Name = "mocTextBox";
            this.mocTextBox.Size = new System.Drawing.Size(185, 20);
            this.mocTextBox.TabIndex = 5;
            // 
            // organizationTextBox
            // 
            this.organizationTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.traningsessionlineitemBindingSource, "organization", true));
            this.organizationTextBox.Location = new System.Drawing.Point(83, 54);
            this.organizationTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.organizationTextBox.Name = "organizationTextBox";
            this.organizationTextBox.Size = new System.Drawing.Size(185, 20);
            this.organizationTextBox.TabIndex = 2;
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.traningsessionlineitemBindingSource, "phone", true));
            this.phoneTextBox.Location = new System.Drawing.Point(83, 77);
            this.phoneTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(185, 20);
            this.phoneTextBox.TabIndex = 3;
            // 
            // textBoxSerialNo
            // 
            this.textBoxSerialNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.traningsessionlineitemBindingSource, "certno", true));
            this.textBoxSerialNo.Location = new System.Drawing.Point(83, 203);
            this.textBoxSerialNo.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSerialNo.Name = "textBoxSerialNo";
            this.textBoxSerialNo.Size = new System.Drawing.Size(185, 20);
            this.textBoxSerialNo.TabIndex = 7;
            // 
            // btndelete
            // 
            this.btndelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btndelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btndelete.ImageOptions.Image")));
            this.btndelete.Location = new System.Drawing.Point(11, 230);
            this.btndelete.Margin = new System.Windows.Forms.Padding(2);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(66, 24);
            this.btndelete.TabIndex = 8;
            this.btndelete.Text = "Delete";
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(299, 230);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(2);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(69, 24);
            this.simpleButton1.TabIndex = 9;
            this.simpleButton1.Text = "Save";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmAddEditLearner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 264);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(azpassLabel);
            this.Controls.Add(this.azpassTextBox);
            this.Controls.Add(emailLabel);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(label1);
            this.Controls.Add(examvoucherLabel);
            this.Controls.Add(this.textBoxSerialNo);
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
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.TextBox textBoxSerialNo;
    }
}