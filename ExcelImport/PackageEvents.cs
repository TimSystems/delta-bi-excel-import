using Microsoft.SqlServer.Dts.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelImport
{
	public class PackageEvents : IDTSEvents
	{
		public void OnBreakpointHit(IDTSBreakpointSite breakpointSite, BreakpointTarget breakpointTarget)
		{
			throw new NotImplementedException();
		}

		public void OnCustomEvent(TaskHost taskHost, string eventName, string eventText, ref object[] arguments, string subComponent, ref bool fireAgain)
		{
			throw new NotImplementedException();
		}

		public bool OnError(DtsObject source, int errorCode, string subComponent, string description, string helpFile, int helpContext, string idofInterfaceWithError)
		{
			throw new NotImplementedException();
		}

		public void OnExecutionStatusChanged(Executable exec, DTSExecStatus newStatus, ref bool fireAgain)
		{
			throw new NotImplementedException();
		}

		public void OnInformation(DtsObject source, int informationCode, string subComponent, string description, string helpFile, int helpContext, string idofInterfaceWithError, ref bool fireAgain)
		{
			throw new NotImplementedException();
		}

		public void OnPostExecute(Executable exec, ref bool fireAgain)
		{
			throw new NotImplementedException();
		}

		public void OnPostValidate(Executable exec, ref bool fireAgain)
		{
			throw new NotImplementedException();
		}

		public void OnPreExecute(Executable exec, ref bool fireAgain)
		{
			throw new NotImplementedException();
		}

		public void OnPreValidate(Executable exec, ref bool fireAgain)
		{
			throw new NotImplementedException();
		}

		public void OnProgress(TaskHost taskHost, string progressDescription, int percentComplete, int progressCountLow, int progressCountHigh, string subComponent, ref bool fireAgain)
		{
			throw new NotImplementedException();
		}

		public bool OnQueryCancel()
		{
			throw new NotImplementedException();
		}

		public void OnTaskFailed(TaskHost taskHost)
		{
			throw new NotImplementedException();
		}

		public void OnVariableValueChanged(DtsContainer DtsContainer, Variable variable, ref bool fireAgain)
		{
			throw new NotImplementedException();
		}

		public void OnWarning(DtsObject source, int warningCode, string subComponent, string description, string helpFile, int helpContext, string idofInterfaceWithError)
		{
			throw new NotImplementedException();
		}
	}
}
