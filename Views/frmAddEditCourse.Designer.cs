
namespace Elev8App
{
    partial class frmAddEditCourse
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
            System.Windows.Forms.Label coursenameLabel;
            System.Windows.Forms.Label coursecodeLabel;
            System.Windows.Forms.Label durationLabel;
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddEditCourse));
            this.coursenameTextBox = new System.Windows.Forms.TextBox();
            this.courseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.coursecodeTextBox = new System.Windows.Forms.TextBox();
            this.durationTextBox = new System.Windows.Forms.TextBox();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            coursenameLabel = new System.Windows.Forms.Label();
            coursecodeLabel = new System.Windows.Forms.Label();
            durationLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.courseBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // coursenameLabel
            // 
            coursenameLabel.AutoSize = true;
            coursenameLabel.Location = new System.Drawing.Point(14, 34);
            coursenameLabel.Name = "coursenameLabel";
            coursenameLabel.Size = new System.Drawing.Size(94, 17);
            coursenameLabel.TabIndex = 1;
            coursenameLabel.Text = "course name:";
            // 
            // coursenameTextBox
            // 
            this.coursenameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.courseBindingSource, "coursename", true));
            this.coursenameTextBox.Location = new System.Drawing.Point(110, 31);
            this.coursenameTextBox.Name = "coursenameTextBox";
            this.coursenameTextBox.Size = new System.Drawing.Size(403, 22);
            this.coursenameTextBox.TabIndex = 2;
            // 
            // courseBindingSource
            // 
            this.courseBindingSource.DataSource = typeof(course);
            // 
            // coursecodeLabel
            // 
            coursecodeLabel.AutoSize = true;
            coursecodeLabel.Location = new System.Drawing.Point(18, 73);
            coursecodeLabel.Name = "coursecodeLabel";
            coursecodeLabel.Size = new System.Drawing.Size(86, 17);
            coursecodeLabel.TabIndex = 2;
            coursecodeLabel.Text = "coursecode:";
            // 
            // coursecodeTextBox
            // 
            this.coursecodeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.courseBindingSource, "coursecode", true));
            this.coursecodeTextBox.Location = new System.Drawing.Point(110, 70);
            this.coursecodeTextBox.Name = "coursecodeTextBox";
            this.coursecodeTextBox.Size = new System.Drawing.Size(146, 22);
            this.coursecodeTextBox.TabIndex = 3;
            // 
            // durationLabel
            // 
            durationLabel.AutoSize = true;
            durationLabel.Location = new System.Drawing.Point(40, 115);
            durationLabel.Name = "durationLabel";
            durationLabel.Size = new System.Drawing.Size(64, 17);
            durationLabel.TabIndex = 4;
            durationLabel.Text = "duration:";
            // 
            // durationTextBox
            // 
            this.durationTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.courseBindingSource, "duration", true));
            this.durationTextBox.Location = new System.Drawing.Point(110, 112);
            this.durationTextBox.Name = "durationTextBox";
            this.durationTextBox.Size = new System.Drawing.Size(100, 22);
            this.durationTextBox.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(216, 115);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(50, 17);
            label1.TabIndex = 4;
            label1.Text = "Day(s)";
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(419, 217);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(94, 29);
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "Save";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmAddEditCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 258);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(label1);
            this.Controls.Add(durationLabel);
            this.Controls.Add(this.durationTextBox);
            this.Controls.Add(coursecodeLabel);
            this.Controls.Add(this.coursecodeTextBox);
            this.Controls.Add(coursenameLabel);
            this.Controls.Add(this.coursenameTextBox);
            this.Name = "frmAddEditCourse";
            this.Load += new System.EventHandler(this.frmAddEditCourse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.courseBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource courseBindingSource;
        private System.Windows.Forms.TextBox coursenameTextBox;
        private System.Windows.Forms.TextBox coursecodeTextBox;
        private System.Windows.Forms.TextBox durationTextBox;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}