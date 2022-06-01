using System;
using System.Windows.Forms;

namespace KeyAuth
{
	// Token: 0x02000011 RID: 17
	internal static class Program
	{
		// Token: 0x060000E5 RID: 229 RVA: 0x000024E2 File Offset: 0x000006E2
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Login());
		}
	}
}
