namespace HelloWorldApp
{
	partial class FormSimpleSample
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
			this.labelNameFirst = new System.Windows.Forms.Label();
			this.textBoxNameFirst = new System.Windows.Forms.TextBox();
			this.textBoxNameLast = new System.Windows.Forms.TextBox();
			this.labelNameLast = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.textBoxAge = new System.Windows.Forms.TextBox();
			this.labelAge = new System.Windows.Forms.Label();
			this.buttonLoad = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.comboBoxFormats = new System.Windows.Forms.ComboBox();
			this.buttonOpen = new System.Windows.Forms.Button();
			this.buttonClear = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// labelNameFirst
			// 
			this.labelNameFirst.AutoSize = true;
			this.labelNameFirst.Location = new System.Drawing.Point(12, 9);
			this.labelNameFirst.Name = "labelNameFirst";
			this.labelNameFirst.Size = new System.Drawing.Size(57, 13);
			this.labelNameFirst.TabIndex = 0;
			this.labelNameFirst.Text = "Name First";
			// 
			// textBoxNameFirst
			// 
			this.textBoxNameFirst.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxNameFirst.Location = new System.Drawing.Point(84, 6);
			this.textBoxNameFirst.Name = "textBoxNameFirst";
			this.textBoxNameFirst.Size = new System.Drawing.Size(580, 20);
			this.textBoxNameFirst.TabIndex = 1;
			this.textBoxNameFirst.Text = "NameFirst";
			// 
			// textBoxNameLast
			// 
			this.textBoxNameLast.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxNameLast.Location = new System.Drawing.Point(84, 34);
			this.textBoxNameLast.Name = "textBoxNameLast";
			this.textBoxNameLast.Size = new System.Drawing.Size(580, 20);
			this.textBoxNameLast.TabIndex = 3;
			this.textBoxNameLast.Text = "NameLast";
			// 
			// labelNameLast
			// 
			this.labelNameLast.AutoSize = true;
			this.labelNameLast.Location = new System.Drawing.Point(12, 37);
			this.labelNameLast.Name = "labelNameLast";
			this.labelNameLast.Size = new System.Drawing.Size(58, 13);
			this.labelNameLast.TabIndex = 2;
			this.labelNameLast.Text = "Name Last";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 69);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(66, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Date of Birth";
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:MM:ss MMMM dddd";
			this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePicker1.Location = new System.Drawing.Point(84, 63);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(580, 20);
			this.dateTimePicker1.TabIndex = 5;
			this.dateTimePicker1.Value = new System.DateTime(1968, 9, 24, 23, 28, 0, 0);
			this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
			// 
			// textBoxAge
			// 
			this.textBoxAge.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxAge.Location = new System.Drawing.Point(84, 91);
			this.textBoxAge.Name = "textBoxAge";
			this.textBoxAge.Size = new System.Drawing.Size(580, 20);
			this.textBoxAge.TabIndex = 7;
			this.textBoxAge.Text = "????";
			// 
			// labelAge
			// 
			this.labelAge.AutoSize = true;
			this.labelAge.Location = new System.Drawing.Point(12, 94);
			this.labelAge.Name = "labelAge";
			this.labelAge.Size = new System.Drawing.Size(26, 13);
			this.labelAge.TabIndex = 6;
			this.labelAge.Text = "Age";
			// 
			// buttonLoad
			// 
			this.buttonLoad.Location = new System.Drawing.Point(84, 117);
			this.buttonLoad.Name = "buttonLoad";
			this.buttonLoad.Size = new System.Drawing.Size(75, 23);
			this.buttonLoad.TabIndex = 8;
			this.buttonLoad.Text = "Load";
			this.buttonLoad.UseVisualStyleBackColor = true;
			this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(165, 117);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 9;
			this.buttonSave.Text = "Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// comboBoxFormats
			// 
			this.comboBoxFormats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxFormats.FormattingEnabled = true;
			this.comboBoxFormats.Items.AddRange(new object[] {
            "Binary Formatter",
            "XmlSerializer",
            "SharpSerializer Binary",
            "SharpSerializer Xml"});
			this.comboBoxFormats.Location = new System.Drawing.Point(405, 117);
			this.comboBoxFormats.Name = "comboBoxFormats";
			this.comboBoxFormats.Size = new System.Drawing.Size(259, 21);
			this.comboBoxFormats.TabIndex = 10;
			// 
			// buttonOpen
			// 
			this.buttonOpen.Location = new System.Drawing.Point(246, 117);
			this.buttonOpen.Name = "buttonOpen";
			this.buttonOpen.Size = new System.Drawing.Size(75, 23);
			this.buttonOpen.TabIndex = 11;
			this.buttonOpen.Text = "Open";
			this.buttonOpen.UseVisualStyleBackColor = true;
			this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
			// 
			// buttonClear
			// 
			this.buttonClear.Location = new System.Drawing.Point(324, 117);
			this.buttonClear.Name = "buttonClear";
			this.buttonClear.Size = new System.Drawing.Size(75, 23);
			this.buttonClear.TabIndex = 12;
			this.buttonClear.Text = "Clear";
			this.buttonClear.UseVisualStyleBackColor = true;
			this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
			// 
			// FormSimpleSample
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(673, 144);
			this.Controls.Add(this.buttonClear);
			this.Controls.Add(this.buttonOpen);
			this.Controls.Add(this.comboBoxFormats);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.buttonLoad);
			this.Controls.Add(this.textBoxAge);
			this.Controls.Add(this.labelAge);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxNameLast);
			this.Controls.Add(this.labelNameLast);
			this.Controls.Add(this.textBoxNameFirst);
			this.Controls.Add(this.labelNameFirst);
			this.Name = "FormSimpleSample";
			this.Text = "FormSimpleSample";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelNameFirst;
		private System.Windows.Forms.TextBox textBoxNameFirst;
		private System.Windows.Forms.TextBox textBoxNameLast;
		private System.Windows.Forms.Label labelNameLast;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.TextBox textBoxAge;
		private System.Windows.Forms.Label labelAge;
		private System.Windows.Forms.Button buttonLoad;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.ComboBox comboBoxFormats;
		private System.Windows.Forms.Button buttonOpen;
		private System.Windows.Forms.Button buttonClear;

	}
}