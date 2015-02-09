using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.SqlServer.Management.IntegrationServices;

namespace ExcelImport
{
	public partial class MainForm : Form
	{
		public enum ExcelFileType
		{
			Fedra,
			Adecco,
			Youth,
			ManualEntry,
			Unspecified
		}

		private ExcelFileType excelFileType;

		public MainForm()
		{
			InitializeComponent();
		}

		private void btnSelectPath_Click(object sender, EventArgs e)
		{
			DialogResult result = dlgSelectFile.ShowDialog();
			if (result == DialogResult.OK)
			{
				this.txtPath.Text = dlgSelectFile.FileName;

				string fileName = Path.GetFileNameWithoutExtension(this.txtPath.Text).ToLower();
				string fileExt = Path.GetExtension(this.txtPath.Text).ToLower();

				if (fileName.Contains("fedra"))
				{
					this.excelFileType = ExcelFileType.Fedra;
					this.rbFedra.Checked = true;
				}
				else if (fileName.Contains("adecco"))
				{
					this.excelFileType = ExcelFileType.Adecco;
					this.rbAdecco.Checked = true;
				}
				else if (fileName.Contains("omladinci"))
				{
					this.excelFileType = ExcelFileType.Youth;
					this.rbYouth.Checked = true;
				}
				else if (fileName.Contains("unos") || fileName.Contains("rucni"))
				{
					this.excelFileType = ExcelFileType.ManualEntry;
					this.rbAdditionalData.Checked = true;
				}
				else
				{
					this.excelFileType = ExcelFileType.Unspecified;
				}

				if (this.excelFileType == ExcelFileType.Unspecified)
				{
					MessageBox.Show("Excel fajl nije ispravan!\nExcel fajl u nazivu mora imati oznaku za tip unosa (npr. 'fedra', 'adecco', 'omladinci' ili 'rucni unos')");
					ClearAll();
					return;
				}

				if (fileExt != ".xlsx")
				{
					MessageBox.Show("Morate izabrati Excel fajl (nastavak '.xlsx')!");
					ClearAll();
					return;
				}
			}
		}

		private void ClearAll()
		{
			this.rbAdditionalData.Checked = false;
			this.rbAdecco.Checked = false;
			this.rbFedra.Checked = false;
			this.rbYouth.Checked = false;
			this.txtPath.Text = string.Empty;
		}

		private void btnLoad_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(this.txtPath.Text))
			{
				MessageBox.Show("Morate izabrati Excel fajl!");
				return;
			}

			// get Integration Services connection string from config file
			string connStr = ConfigurationManager.ConnectionStrings["IntegrationServicesConnectionString"].ToString();

			var connection = new SqlConnection(connStr);
			var integrationServices = new IntegrationServices(connection);

			if (integrationServices != null)
			{
				string packageName = string.Empty;
				
				switch(this.excelFileType)
				{
					case ExcelFileType.Adecco:
						packageName = "ExcelAdecco.dtsx";
						break;

					case ExcelFileType.Fedra:
						packageName = "ExcelFedra.dtsx";
						break;

					case ExcelFileType.Youth:
						packageName = "ExcelYouth.dtsx";
						break;

					case ExcelFileType.ManualEntry:
						packageName = "ExcelManualEntry.dtsx";
						break;
				}

				var package = integrationServices.Catalogs["SSISDB"].Folders["DeltaBI-Excel"].Projects["DeltaBI.ExcelFiles"].Packages[packageName];

				// update Excel file connection string accordingly
				// { Provider=Microsoft.ACE.OLEDB.12.0;Data Source=[ Excel_file_path ];Extended Properties="EXCEL 12.0 XML;HDR=NO"; }
				string excelFileConnStr = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"EXCEL 12.0 XML;HDR=NO\";", this.txtPath.Text);

				package.Parameters["CM.Excel Connection - header.ConnectionString"].Set(ParameterInfo.ParameterValueType.Literal, excelFileConnStr);
				package.Parameters["CM.Excel Connection - rows.ConnectionString"].Set(ParameterInfo.ParameterValueType.Literal, excelFileConnStr);

				// this makes the package execution synchronous (otherwise, it would be asynchronous)
				var setValueParameters = new Collection<PackageInfo.ExecutionValueParameterSet>();
				setValueParameters.Add(new PackageInfo.ExecutionValueParameterSet
				{
					ObjectType = 50,
					ParameterName = "SYNCHRONIZED",
					ParameterValue = 1
				});

				long executionIdentifier = package.Execute(false, null, setValueParameters);

				var execution = integrationServices.Catalogs.Single(x => x.Name.Equals("SSISDB")).Executions.Single(x => x.Id.Equals(executionIdentifier));
				
				var errors = execution.Messages.Where(m => m.MessageType == 120).Select(m => m.Message);
				var warnings = execution.Messages.Where(m => m.MessageType == 110).Select(m => m.Message);

				if (errors.Count() > 0)
				{
					MessageBox.Show("Došlo je do greške prilikom upisa podataka. Podaci nisu upisani!");
				}
				else
				{
					MessageBox.Show("Podaci su uspešno upisani.");
				}
			}
			else
			{
				MessageBox.Show("Servis 'SQL Server Integration Services' nije dostupan!");
			}
		}
	}
}
