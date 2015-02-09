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
//using Microsoft.SqlServer.Dts.Runtime;
using Microsoft.SqlServer.Management.IntegrationServices;

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
			// get Integration Services connection string from config file
			string connStr = ConfigurationManager.ConnectionStrings["IntegrationServicesConnectionString"].ToString();

			var connection = new SqlConnection(connStr);
			var integrationServices = new IntegrationServices(connection);

			if (integrationServices != null)
			{
				var package = integrationServices.Catalogs["SSISDB"].Folders["DeltaBI-Excel"].Projects["DeltaBI.ExcelFiles"].Packages["ExcelYouth.dtsx"];

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
