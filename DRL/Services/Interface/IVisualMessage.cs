using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DRL.Services.Interface
{
	public interface IVisualMessage
	{
		void ShowErrorMessage(string msg);
		void ShowInformMessage(string msg);
		void ShowWarningMessage(string msg);
		DialogResult ShowConfirmMessage(string msg);
		DialogResult ShowQuestionMessage(string msg);
	}
}
