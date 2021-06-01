using DRL.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DRL.Services.Impl
{
	public class VisualMessage : IVisualMessage
	{
		public DialogResult ShowConfirmMessage(string msg)
		{
			return MessageBox.Show(msg, "Confirmation!", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
		}

		public void ShowErrorMessage(string msg)
		{
			MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		public void ShowInformMessage(string msg)
		{
			MessageBox.Show(msg, "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		public DialogResult ShowQuestionMessage(string msg)
		{
			return MessageBox.Show(msg, "Question?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		}

		public void ShowWarningMessage(string msg)
		{
			MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}
	}
}
