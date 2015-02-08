namespace ExcelImport
{
	partial class MainForm
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
			this.txtPath = new System.Windows.Forms.TextBox();
			this.btnSelectPath = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rbAdditionalData = new System.Windows.Forms.RadioButton();
			this.rbAdecco = new System.Windows.Forms.RadioButton();
			this.rbFedra = new System.Windows.Forms.RadioButton();
			this.rbYouth = new System.Windows.Forms.RadioButton();
			this.btnLoad = new System.Windows.Forms.Button();
			this.dlgSelectFile = new System.Windows.Forms.OpenFileDialog();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtPath
			// 
			this.txtPath.Location = new System.Drawing.Point(13, 13);
			this.txtPath.Name = "txtPath";
			this.txtPath.Size = new System.Drawing.Size(665, 20);
			this.txtPath.TabIndex = 0;
			// 
			// btnSelectPath
			// 
			this.btnSelectPath.Location = new System.Drawing.Point(684, 12);
			this.btnSelectPath.Name = "btnSelectPath";
			this.btnSelectPath.Size = new System.Drawing.Size(75, 21);
			this.btnSelectPath.TabIndex = 1;
			this.btnSelectPath.Text = "...";
			this.btnSelectPath.UseVisualStyleBackColor = true;
			this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPath_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rbAdditionalData);
			this.groupBox1.Controls.Add(this.rbAdecco);
			this.groupBox1.Controls.Add(this.rbFedra);
			this.groupBox1.Controls.Add(this.rbYouth);
			this.groupBox1.Location = new System.Drawing.Point(13, 59);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(665, 72);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Vrsta Excel fajla";
			// 
			// rbAdditionalData
			// 
			this.rbAdditionalData.AutoSize = true;
			this.rbAdditionalData.Location = new System.Drawing.Point(213, 31);
			this.rbAdditionalData.Name = "rbAdditionalData";
			this.rbAdditionalData.Size = new System.Drawing.Size(97, 17);
			this.rbAdditionalData.TabIndex = 3;
			this.rbAdditionalData.TabStop = true;
			this.rbAdditionalData.Text = "Dodatni podaci";
			this.rbAdditionalData.UseVisualStyleBackColor = true;
			// 
			// rbAdecco
			// 
			this.rbAdecco.AutoSize = true;
			this.rbAdecco.Location = new System.Drawing.Point(144, 31);
			this.rbAdecco.Name = "rbAdecco";
			this.rbAdecco.Size = new System.Drawing.Size(62, 17);
			this.rbAdecco.TabIndex = 2;
			this.rbAdecco.TabStop = true;
			this.rbAdecco.Text = "Adecco";
			this.rbAdecco.UseVisualStyleBackColor = true;
			// 
			// rbFedra
			// 
			this.rbFedra.AutoSize = true;
			this.rbFedra.Location = new System.Drawing.Point(85, 31);
			this.rbFedra.Name = "rbFedra";
			this.rbFedra.Size = new System.Drawing.Size(52, 17);
			this.rbFedra.TabIndex = 1;
			this.rbFedra.TabStop = true;
			this.rbFedra.Text = "Fedra";
			this.rbFedra.UseVisualStyleBackColor = true;
			// 
			// rbYouth
			// 
			this.rbYouth.AutoSize = true;
			this.rbYouth.Location = new System.Drawing.Point(7, 31);
			this.rbYouth.Name = "rbYouth";
			this.rbYouth.Size = new System.Drawing.Size(71, 17);
			this.rbYouth.TabIndex = 0;
			this.rbYouth.TabStop = true;
			this.rbYouth.Text = "Omladinci";
			this.rbYouth.UseVisualStyleBackColor = true;
			// 
			// btnLoad
			// 
			this.btnLoad.Location = new System.Drawing.Point(13, 156);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new System.Drawing.Size(75, 23);
			this.btnLoad.TabIndex = 3;
			this.btnLoad.Text = "Učitaj fajl";
			this.btnLoad.UseVisualStyleBackColor = true;
			this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(775, 204);
			this.Controls.Add(this.btnLoad);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnSelectPath);
			this.Controls.Add(this.txtPath);
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "DeltaBI Excel Import";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtPath;
		private System.Windows.Forms.Button btnSelectPath;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rbAdditionalData;
		private System.Windows.Forms.RadioButton rbAdecco;
		private System.Windows.Forms.RadioButton rbFedra;
		private System.Windows.Forms.RadioButton rbYouth;
		private System.Windows.Forms.Button btnLoad;
		private System.Windows.Forms.OpenFileDialog dlgSelectFile;
	}
}

