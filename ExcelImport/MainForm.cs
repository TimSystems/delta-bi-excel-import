using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Dts.Runtime;

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
			string packageLocation = @"D:\Temp\Packages\ExcelYouth.dtsx";

			PackageEvents pe = new PackageEvents();

			Microsoft.SqlServer.Dts.Runtime.Application app = new Microsoft.SqlServer.Dts.Runtime.Application();
			Package package = app.LoadPackage(packageLocation, pe);
			//package.PackagePassword = "hitachi";
			package.Variables["User::varExcelFilePath"].Value = this.txtPath.Text;

			DTSExecResult result = package.Execute();

			//MessageBox.Show(result.ToString());
		}
	}
}
