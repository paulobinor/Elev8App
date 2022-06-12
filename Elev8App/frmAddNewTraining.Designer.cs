
namespace Elev8App
{
    partial class frmAddNewTraining
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
            System.Windows.Forms.Label durationLabel;
            System.Windows.Forms.Label startdateLabel;
            System.Windows.Forms.Label teaendLabel;
            System.Windows.Forms.Label endateLabel;
            System.Windows.Forms.Label teastartLabel;
            System.Windows.Forms.Label lunchstartLabel;
            System.Windows.Forms.Label lunchendLabel;
            System.Windows.Forms.Label courselinkLabel;
            System.Windows.Forms.Label trainerLabel;
            System.Windows.Forms.Label expmLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label startimeLabel;
            System.Windows.Forms.Label endtimeLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddNewTraining));
            this.durationTextBox = new System.Windows.Forms.TextBox();
            this.courseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.trainingsessionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.startdateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.teaendDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.teastartDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.lunchstartDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.lunchendDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.expmTextBox = new System.Windows.Forms.TextBox();
            this.startimeDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endtimeDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.trainerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBoxTrainer = new System.Windows.Forms.ComboBox();
            this.courselinkTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.courseComboBox = new System.Windows.Forms.ComboBox();
            this.courseBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            coursenameLabel = new System.Windows.Forms.Label();
            durationLabel = new System.Windows.Forms.Label();
            startdateLabel = new System.Windows.Forms.Label();
            teaendLabel = new System.Windows.Forms.Label();
            endateLabel = new System.Windows.Forms.Label();
            teastartLabel = new System.Windows.Forms.Label();
            lunchstartLabel = new System.Windows.Forms.Label();
            lunchendLabel = new System.Windows.Forms.Label();
            courselinkLabel = new System.Windows.Forms.Label();
            trainerLabel = new System.Windows.Forms.Label();
            expmLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            startimeLabel = new System.Windows.Forms.Label();
            endtimeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.courseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trainingsessionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trainerBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.courseBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // coursenameLabel
            // 
            coursenameLabel.AutoSize = true;
            coursenameLabel.Location = new System.Drawing.Point(16, 22);
            coursenameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            coursenameLabel.Name = "coursenameLabel";
            coursenameLabel.Size = new System.Drawing.Size(74, 13);
            coursenameLabel.TabIndex = 1;
            coursenameLabel.Text = "Course Name:";
            // 
            // durationLabel
            // 
            durationLabel.AutoSize = true;
            durationLabel.Location = new System.Drawing.Point(40, 47);
            durationLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            durationLabel.Name = "durationLabel";
            durationLabel.Size = new System.Drawing.Size(50, 13);
            durationLabel.TabIndex = 2;
            durationLabel.Text = "Duration:";
            // 
            // startdateLabel
            // 
            startdateLabel.AutoSize = true;
            startdateLabel.Location = new System.Drawing.Point(40, 179);
            startdateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            startdateLabel.Name = "startdateLabel";
            startdateLabel.Size = new System.Drawing.Size(53, 13);
            startdateLabel.TabIndex = 4;
            startdateLabel.Text = "Startdate:";
            // 
            // teaendLabel
            // 
            teaendLabel.AutoSize = true;
            teaendLabel.Location = new System.Drawing.Point(330, 203);
            teaendLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            teaendLabel.Name = "teaendLabel";
            teaendLabel.Size = new System.Drawing.Size(50, 13);
            teaendLabel.TabIndex = 6;
            teaendLabel.Text = "Tea end:";
            // 
            // endateLabel
            // 
            endateLabel.AutoSize = true;
            endateLabel.Location = new System.Drawing.Point(49, 203);
            endateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            endateLabel.Name = "endateLabel";
            endateLabel.Size = new System.Drawing.Size(44, 13);
            endateLabel.TabIndex = 8;
            endateLabel.Text = "Endate:";
            // 
            // teastartLabel
            // 
            teastartLabel.AutoSize = true;
            teastartLabel.Location = new System.Drawing.Point(328, 179);
            teastartLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            teastartLabel.Name = "teastartLabel";
            teastartLabel.Size = new System.Drawing.Size(52, 13);
            teastartLabel.TabIndex = 10;
            teastartLabel.Text = "Tea start:";
            // 
            // lunchstartLabel
            // 
            lunchstartLabel.AutoSize = true;
            lunchstartLabel.Location = new System.Drawing.Point(317, 234);
            lunchstartLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            lunchstartLabel.Name = "lunchstartLabel";
            lunchstartLabel.Size = new System.Drawing.Size(63, 13);
            lunchstartLabel.TabIndex = 12;
            lunchstartLabel.Text = "Lunch start:";
            // 
            // lunchendLabel
            // 
            lunchendLabel.AutoSize = true;
            lunchendLabel.Location = new System.Drawing.Point(319, 257);
            lunchendLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            lunchendLabel.Name = "lunchendLabel";
            lunchendLabel.Size = new System.Drawing.Size(61, 13);
            lunchendLabel.TabIndex = 14;
            lunchendLabel.Text = "Lunch end:";
            // 
            // courselinkLabel
            // 
            courselinkLabel.AutoSize = true;
            courselinkLabel.Location = new System.Drawing.Point(25, 353);
            courselinkLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            courselinkLabel.Name = "courselinkLabel";
            courselinkLabel.Size = new System.Drawing.Size(66, 13);
            courselinkLabel.TabIndex = 16;
            courselinkLabel.Text = "Course Link:";
            // 
            // trainerLabel
            // 
            trainerLabel.AutoSize = true;
            trainerLabel.Location = new System.Drawing.Point(47, 72);
            trainerLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            trainerLabel.Name = "trainerLabel";
            trainerLabel.Size = new System.Drawing.Size(43, 13);
            trainerLabel.TabIndex = 19;
            trainerLabel.Text = "Trainer:";
            // 
            // expmLabel
            // 
            expmLabel.AutoSize = true;
            expmLabel.Location = new System.Drawing.Point(61, 95);
            expmLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            expmLabel.Name = "expmLabel";
            expmLabel.Size = new System.Drawing.Size(29, 13);
            expmLabel.TabIndex = 21;
            expmLabel.Text = "E.M:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(141, 47);
            label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(31, 13);
            label1.TabIndex = 19;
            label1.Text = "Days";
            // 
            // startimeLabel
            // 
            startimeLabel.AutoSize = true;
            startimeLabel.Location = new System.Drawing.Point(47, 234);
            startimeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            startimeLabel.Name = "startimeLabel";
            startimeLabel.Size = new System.Drawing.Size(46, 13);
            startimeLabel.TabIndex = 24;
            startimeLabel.Text = "startime:";
            // 
            // endtimeLabel
            // 
            endtimeLabel.AutoSize = true;
            endtimeLabel.Location = new System.Drawing.Point(46, 257);
            endtimeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            endtimeLabel.Name = "endtimeLabel";
            endtimeLabel.Size = new System.Drawing.Size(47, 13);
            endtimeLabel.TabIndex = 26;
            endtimeLabel.Text = "endtime:";
            // 
            // durationTextBox
            // 
            this.durationTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.courseBindingSource, "duration", true));
            this.durationTextBox.Location = new System.Drawing.Point(95, 43);
            this.durationTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.durationTextBox.Name = "durationTextBox";
            this.durationTextBox.ReadOnly = true;
            this.durationTextBox.Size = new System.Drawing.Size(41, 20);
            this.durationTextBox.TabIndex = 3;
            // 
            // courseBindingSource
            // 
            this.courseBindingSource.DataSource = typeof(Elev8App.course);
            this.courseBindingSource.CurrentChanged += new System.EventHandler(this.courseBindingSource_CurrentChanged);
            // 
            // trainingsessionBindingSource
            // 
            this.trainingsessionBindingSource.DataSource = typeof(Elev8App.trainingsession);
            // 
            // startdateDateTimePicker
            // 
            this.startdateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.trainingsessionBindingSource, "startdate", true));
            this.startdateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startdateDateTimePicker.Location = new System.Drawing.Point(98, 175);
            this.startdateDateTimePicker.Margin = new System.Windows.Forms.Padding(2);
            this.startdateDateTimePicker.Name = "startdateDateTimePicker";
            this.startdateDateTimePicker.Size = new System.Drawing.Size(86, 20);
            this.startdateDateTimePicker.TabIndex = 5;
            this.startdateDateTimePicker.ValueChanged += new System.EventHandler(this.startdateDateTimePicker_ValueChanged);
            // 
            // teaendDateTimePicker
            // 
            this.teaendDateTimePicker.CustomFormat = "hh:mm tt";
            this.teaendDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.trainingsessionBindingSource, "teaend", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "t"));
            this.teaendDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.teaendDateTimePicker.Location = new System.Drawing.Point(382, 199);
            this.teaendDateTimePicker.Margin = new System.Windows.Forms.Padding(2);
            this.teaendDateTimePicker.Name = "teaendDateTimePicker";
            this.teaendDateTimePicker.ShowUpDown = true;
            this.teaendDateTimePicker.Size = new System.Drawing.Size(76, 20);
            this.teaendDateTimePicker.TabIndex = 7;
            this.teaendDateTimePicker.Value = new System.DateTime(2021, 3, 18, 11, 0, 0, 0);
            // 
            // endateDateTimePicker
            // 
            this.endateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.trainingsessionBindingSource, "endate", true));
            this.endateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endateDateTimePicker.Location = new System.Drawing.Point(98, 199);
            this.endateDateTimePicker.Margin = new System.Windows.Forms.Padding(2);
            this.endateDateTimePicker.Name = "endateDateTimePicker";
            this.endateDateTimePicker.Size = new System.Drawing.Size(86, 20);
            this.endateDateTimePicker.TabIndex = 9;
            // 
            // teastartDateTimePicker
            // 
            this.teastartDateTimePicker.CustomFormat = "hh:mm tt";
            this.teastartDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.trainingsessionBindingSource, "teastart", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "t"));
            this.teastartDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.teastartDateTimePicker.Location = new System.Drawing.Point(382, 175);
            this.teastartDateTimePicker.Margin = new System.Windows.Forms.Padding(2);
            this.teastartDateTimePicker.Name = "teastartDateTimePicker";
            this.teastartDateTimePicker.ShowUpDown = true;
            this.teastartDateTimePicker.Size = new System.Drawing.Size(76, 20);
            this.teastartDateTimePicker.TabIndex = 11;
            this.teastartDateTimePicker.Value = new System.DateTime(2021, 3, 18, 10, 30, 0, 0);
            this.teastartDateTimePicker.ValueChanged += new System.EventHandler(this.teastartDateTimePicker_ValueChanged);
            // 
            // lunchstartDateTimePicker
            // 
            this.lunchstartDateTimePicker.CustomFormat = " hh:mm tt";
            this.lunchstartDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.trainingsessionBindingSource, "lunchstart", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "t"));
            this.lunchstartDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.lunchstartDateTimePicker.Location = new System.Drawing.Point(382, 230);
            this.lunchstartDateTimePicker.Margin = new System.Windows.Forms.Padding(2);
            this.lunchstartDateTimePicker.Name = "lunchstartDateTimePicker";
            this.lunchstartDateTimePicker.ShowUpDown = true;
            this.lunchstartDateTimePicker.Size = new System.Drawing.Size(76, 20);
            this.lunchstartDateTimePicker.TabIndex = 13;
            this.lunchstartDateTimePicker.Value = new System.DateTime(2021, 3, 18, 13, 0, 0, 0);
            // 
            // lunchendDateTimePicker
            // 
            this.lunchendDateTimePicker.CustomFormat = " hh:mm tt";
            this.lunchendDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.trainingsessionBindingSource, "lunchend", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "t"));
            this.lunchendDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.lunchendDateTimePicker.Location = new System.Drawing.Point(382, 253);
            this.lunchendDateTimePicker.Margin = new System.Windows.Forms.Padding(2);
            this.lunchendDateTimePicker.Name = "lunchendDateTimePicker";
            this.lunchendDateTimePicker.ShowUpDown = true;
            this.lunchendDateTimePicker.Size = new System.Drawing.Size(76, 20);
            this.lunchendDateTimePicker.TabIndex = 15;
            this.lunchendDateTimePicker.Value = new System.DateTime(2021, 3, 18, 14, 0, 0, 0);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSave.Location = new System.Drawing.Point(426, 456);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(53, 24);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // expmTextBox
            // 
            this.expmTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.trainingsessionBindingSource, "expm", true));
            this.expmTextBox.Location = new System.Drawing.Point(95, 91);
            this.expmTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.expmTextBox.Name = "expmTextBox";
            this.expmTextBox.Size = new System.Drawing.Size(141, 20);
            this.expmTextBox.TabIndex = 22;
            // 
            // startimeDateTimePicker
            // 
            this.startimeDateTimePicker.CustomFormat = " hh:mm tt";
            this.startimeDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startimeDateTimePicker.Location = new System.Drawing.Point(98, 230);
            this.startimeDateTimePicker.Margin = new System.Windows.Forms.Padding(2);
            this.startimeDateTimePicker.Name = "startimeDateTimePicker";
            this.startimeDateTimePicker.ShowUpDown = true;
            this.startimeDateTimePicker.Size = new System.Drawing.Size(86, 20);
            this.startimeDateTimePicker.TabIndex = 25;
            this.startimeDateTimePicker.Value = new System.DateTime(2021, 3, 18, 9, 0, 0, 0);
            this.startimeDateTimePicker.ValueChanged += new System.EventHandler(this.startimeDateTimePicker_ValueChanged);
            // 
            // endtimeDateTimePicker
            // 
            this.endtimeDateTimePicker.CustomFormat = " hh:mm tt";
            this.endtimeDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endtimeDateTimePicker.Location = new System.Drawing.Point(98, 253);
            this.endtimeDateTimePicker.Margin = new System.Windows.Forms.Padding(2);
            this.endtimeDateTimePicker.Name = "endtimeDateTimePicker";
            this.endtimeDateTimePicker.ShowUpDown = true;
            this.endtimeDateTimePicker.Size = new System.Drawing.Size(86, 20);
            this.endtimeDateTimePicker.TabIndex = 27;
            this.endtimeDateTimePicker.Value = new System.DateTime(2021, 3, 18, 17, 0, 0, 0);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.trainerBindingSource, "signature", true));
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 16);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(210, 104);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // trainerBindingSource
            // 
            this.trainerBindingSource.DataSource = typeof(Elev8App.trainer);
            this.trainerBindingSource.CurrentChanged += new System.EventHandler(this.trainerBindingSource_CurrentChanged);
            // 
            // comboBoxTrainer
            // 
            this.comboBoxTrainer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxTrainer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxTrainer.DataSource = this.trainerBindingSource;
            this.comboBoxTrainer.DisplayMember = "fullname";
            this.comboBoxTrainer.FormattingEnabled = true;
            this.comboBoxTrainer.Location = new System.Drawing.Point(95, 68);
            this.comboBoxTrainer.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxTrainer.Name = "comboBoxTrainer";
            this.comboBoxTrainer.Size = new System.Drawing.Size(141, 21);
            this.comboBoxTrainer.TabIndex = 29;
            this.comboBoxTrainer.ValueMember = "trainerid";
            // 
            // courselinkTextBox
            // 
            this.courselinkTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.courselinkTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.trainingsessionBindingSource, "courselink", true));
            this.courselinkTextBox.Location = new System.Drawing.Point(95, 286);
            this.courselinkTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.courselinkTextBox.Multiline = true;
            this.courselinkTextBox.Name = "courselinkTextBox";
            this.courselinkTextBox.Size = new System.Drawing.Size(375, 154);
            this.courselinkTextBox.TabIndex = 17;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(242, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 123);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Signature";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.courseComboBox);
            this.groupBox2.Controls.Add(startdateLabel);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.startdateDateTimePicker);
            this.groupBox2.Controls.Add(this.comboBoxTrainer);
            this.groupBox2.Controls.Add(this.teaendDateTimePicker);
            this.groupBox2.Controls.Add(expmLabel);
            this.groupBox2.Controls.Add(endtimeLabel);
            this.groupBox2.Controls.Add(this.expmTextBox);
            this.groupBox2.Controls.Add(teaendLabel);
            this.groupBox2.Controls.Add(label1);
            this.groupBox2.Controls.Add(this.endtimeDateTimePicker);
            this.groupBox2.Controls.Add(trainerLabel);
            this.groupBox2.Controls.Add(this.endateDateTimePicker);
            this.groupBox2.Controls.Add(startimeLabel);
            this.groupBox2.Controls.Add(durationLabel);
            this.groupBox2.Controls.Add(endateLabel);
            this.groupBox2.Controls.Add(this.durationTextBox);
            this.groupBox2.Controls.Add(this.courselinkTextBox);
            this.groupBox2.Controls.Add(coursenameLabel);
            this.groupBox2.Controls.Add(courselinkLabel);
            this.groupBox2.Controls.Add(this.startimeDateTimePicker);
            this.groupBox2.Controls.Add(this.teastartDateTimePicker);
            this.groupBox2.Controls.Add(teastartLabel);
            this.groupBox2.Controls.Add(this.lunchstartDateTimePicker);
            this.groupBox2.Controls.Add(lunchstartLabel);
            this.groupBox2.Controls.Add(this.lunchendDateTimePicker);
            this.groupBox2.Controls.Add(lunchendLabel);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(478, 439);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Schedule";
            // 
            // courseComboBox
            // 
            this.courseComboBox.DataSource = this.courseBindingSource;
            this.courseComboBox.DisplayMember = "coursename";
            this.courseComboBox.FormattingEnabled = true;
            this.courseComboBox.Location = new System.Drawing.Point(95, 17);
            this.courseComboBox.Name = "courseComboBox";
            this.courseComboBox.Size = new System.Drawing.Size(360, 21);
            this.courseComboBox.TabIndex = 30;
            this.courseComboBox.ValueMember = "coursecode";
            this.courseComboBox.SelectedIndexChanged += new System.EventHandler(this.courseComboBox_SelectedIndexChanged);
            // 
            // courseBindingSource1
            // 
            this.courseBindingSource1.DataSource = typeof(Elev8App.course);
            // 
            // frmAddNewTraining
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 491);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnSave);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmAddNewTraining";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New Training";
            this.Load += new System.EventHandler(this.frmAddNewTraining_Load);
            ((System.ComponentModel.ISupportInitialize)(this.courseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trainingsessionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trainerBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.courseBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource trainingsessionBindingSource;
        private System.Windows.Forms.TextBox durationTextBox;
        private System.Windows.Forms.DateTimePicker startdateDateTimePicker;
        private System.Windows.Forms.DateTimePicker teaendDateTimePicker;
        private System.Windows.Forms.DateTimePicker endateDateTimePicker;
        private System.Windows.Forms.DateTimePicker teastartDateTimePicker;
        private System.Windows.Forms.DateTimePicker lunchstartDateTimePicker;
        private System.Windows.Forms.DateTimePicker lunchendDateTimePicker;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.TextBox expmTextBox;
        private System.Windows.Forms.BindingSource courseBindingSource;
        private System.Windows.Forms.DateTimePicker startimeDateTimePicker;
        private System.Windows.Forms.DateTimePicker endtimeDateTimePicker;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.BindingSource trainerBindingSource;
        private System.Windows.Forms.ComboBox comboBoxTrainer;
        private System.Windows.Forms.TextBox courselinkTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox courseComboBox;
        private System.Windows.Forms.BindingSource courseBindingSource1;
    }
}