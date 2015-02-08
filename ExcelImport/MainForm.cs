using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelImport
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			
		}

		private void btnSelectPath_Click(object sender, EventArgs e)
		{
			DialogResult result = dlgSelectFile.ShowDialog();
			if (result == DialogResult.OK)
			{
				this.txtPath.Text = dlgSelectFile.FileName;
			}
		}

		private void btnLoad_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Podaci su uspešno upisani u bazu.");
		}
	}
}
