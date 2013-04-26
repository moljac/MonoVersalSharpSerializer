namespace HelloWorldApp
{
	partial class FormContentPresenter
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
			this.textBoxContent = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// textBoxContent
			// 
			this.textBoxContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxContent.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxContent.Location = new System.Drawing.Point(0, 0);
			this.textBoxContent.Multiline = true;
			this.textBoxContent.Name = "textBoxContent";
			this.textBoxContent.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.textBoxContent.Size = new System.Drawing.Size(532, 555);
			this.textBoxContent.TabIndex = 0;
			// 
			// FormContentPresenter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(532, 555);
			this.Controls.Add(this.textBoxContent);
			this.Name = "FormContentPresenter";
			this.Text = "FormContentPresenter";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxContent;
	}
}