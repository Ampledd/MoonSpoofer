using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Siticone.UI.WinForms;
using Siticone.UI.WinForms.Enums;

namespace KeyAuth
{
	// Token: 0x02000010 RID: 16
	public partial class Login : Form
	{
		// Token: 0x060000CF RID: 207 RVA: 0x000024AA File Offset: 0x000006AA
		public Login()
		{
			this.InitializeComponent();
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x000023CB File Offset: 0x000005CB
		private void siticoneControlBox1_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x0000BA70 File Offset: 0x00009C70
		private void timer1_Tick(object sender, EventArgs e)
		{
			Process[] processesByName = Process.GetProcessesByName("ida64");
			Process[] processesByName2 = Process.GetProcessesByName("ida32");
			Process[] processesByName3 = Process.GetProcessesByName("ollydbg");
			Process[] processesByName4 = Process.GetProcessesByName("ollydbg64");
			Process[] processesByName5 = Process.GetProcessesByName("loaddll");
			Process[] processesByName6 = Process.GetProcessesByName("httpdebugger");
			Process[] processesByName7 = Process.GetProcessesByName("windowrenamer");
			Process[] processesByName8 = Process.GetProcessesByName("processhacker");
			Process[] processesByName9 = Process.GetProcessesByName("Process Hacker");
			Process[] processesByName10 = Process.GetProcessesByName("ProcessHacker");
			Process[] processesByName11 = Process.GetProcessesByName("HxD");
			Process[] processesByName12 = Process.GetProcessesByName("parsecd");
			Process[] processesByName13 = Process.GetProcessesByName("ida");
			Process[] processesByName14 = Process.GetProcessesByName("dnSpy");
			Process[] processesByName15 = Process.GetProcessesByName("MegaDumper");
			if (processesByName.Length != 0 || processesByName2.Length != 0 || processesByName3.Length != 0 || processesByName4.Length != 0 || processesByName5.Length != 0 || processesByName6.Length != 0 || processesByName7.Length != 0 || processesByName8.Length != 0 || processesByName9.Length != 0 || processesByName10.Length != 0 || processesByName11.Length != 0 || processesByName13.Length != 0 || processesByName12.Length != 0 || processesByName14.Length != 0 || processesByName15.Length != 0)
			{
				Clipboard.GetImage();
			}
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x0000BB7C File Offset: 0x00009D7C
		private void Login_Load(object sender, EventArgs e)
		{
			Login.KeyAuthApp.init();
			bool flag = Login.KeyAuthApp.response.message == "invalidver";
			if (flag)
			{
				bool flag2 = !string.IsNullOrEmpty(Login.KeyAuthApp.app_data.downloadLink);
				if (flag2)
				{
					DialogResult dialogResult = MessageBox.Show("Yes to open file in browser\nNo to download file automatically", "Auto update", MessageBoxButtons.YesNo);
					DialogResult dialogResult2 = dialogResult;
					DialogResult dialogResult3 = dialogResult2;
					if (dialogResult3 != DialogResult.Yes)
					{
						if (dialogResult3 != DialogResult.No)
						{
							MessageBox.Show("Invalid option");
							Environment.Exit(0);
						}
						else
						{
							WebClient webClient = new WebClient();
							string text = Application.ExecutablePath;
							string str = Login.random_string();
							text = text.Replace(".exe", "-" + str + ".exe");
							webClient.DownloadFile(Login.KeyAuthApp.app_data.downloadLink, text);
							Process.Start(text);
							Process.Start(new ProcessStartInfo
							{
								Arguments = "/C choice /C Y /N /D Y /T 3 & Del \"" + Application.ExecutablePath + "\"",
								WindowStyle = ProcessWindowStyle.Hidden,
								CreateNoWindow = true,
								FileName = "cmd.exe"
							});
							Environment.Exit(0);
						}
					}
					else
					{
						Process.Start(Login.KeyAuthApp.app_data.downloadLink);
						Environment.Exit(0);
					}
				}
				MessageBox.Show("Posiadasz star¹ wersjê programu, pobierz now¹ za pomoc¹ komendy !download z kana³u #cmds na discordzie discord.gg/uran");
				Thread.Sleep(2500);
				Environment.Exit(0);
			}
			bool flag3 = !Login.KeyAuthApp.response.success;
			if (flag3)
			{
				MessageBox.Show(Login.KeyAuthApp.response.message);
				Environment.Exit(0);
			}
			Login.KeyAuthApp.check();
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x0000BD34 File Offset: 0x00009F34
		private static string random_string()
		{
			string text = null;
			Random random = new Random();
			for (int i = 0; i < 5; i++)
			{
				text += Convert.ToChar(Convert.ToInt32(Math.Floor(26.0 * random.NextDouble() + 65.0))).ToString();
			}
			return text;
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x000023D5 File Offset: 0x000005D5
		private void UpgradeBtn_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x0000BDA0 File Offset: 0x00009FA0
		private void LoginBtn_Click(object sender, EventArgs e)
		{
			Login.KeyAuthApp.login(this.username.Text, this.textBox1.Text);
			if (Login.KeyAuthApp.response.success)
			{
				new Main().Show();
				base.Hide();
				return;
			}
			MessageBox.Show("Username or password is invalid!");
			new Main().Show();
			base.Hide();
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x000023D5 File Offset: 0x000005D5
		private void RgstrBtn_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x000023D5 File Offset: 0x000005D5
		private void LicBtn_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x000023D5 File Offset: 0x000005D5
		private void username_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x000023D5 File Offset: 0x000005D5
		private void textBox1_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x060000DA RID: 218 RVA: 0x0000BE0C File Offset: 0x0000A00C
		private void siticoneRoundedButton1_Click(object sender, EventArgs e)
		{
			Login.KeyAuthApp.register(this.username.Text, this.textBox1.Text, this.textBox4.Text);
			bool success = Login.KeyAuthApp.response.success;
			if (success)
			{
				Main main = new Main();
				main.Show();
				base.Hide();
			}
			else
			{
				MessageBox.Show("License is invalid!");
			}
		}

		// Token: 0x060000DB RID: 219 RVA: 0x000023D5 File Offset: 0x000005D5
		private void guna2Button6_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060000DC RID: 220 RVA: 0x000023D5 File Offset: 0x000005D5
		private void guna2Button1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060000DD RID: 221 RVA: 0x000023D5 File Offset: 0x000005D5
		private void siticoneRoundedButton2_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060000DE RID: 222 RVA: 0x0000BE0C File Offset: 0x0000A00C
		private void siticoneRoundedButton3_Click(object sender, EventArgs e)
		{
			Login.KeyAuthApp.register(this.username.Text, this.textBox1.Text, this.textBox4.Text);
			bool success = Login.KeyAuthApp.response.success;
			if (success)
			{
				Main main = new Main();
				main.Show();
				base.Hide();
			}
			else
			{
				MessageBox.Show("License is invalid!");
			}
		}

		// Token: 0x060000DF RID: 223 RVA: 0x000023D5 File Offset: 0x000005D5
		private void guna2Panel1_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x0000BE7C File Offset: 0x0000A07C
		private void guna2Button2_Click(object sender, EventArgs e)
		{
			Login.KeyAuthApp.login(this.username.Text, this.textBox1.Text);
			if (Login.KeyAuthApp.response.success)
			{
				new Main().Show();
				base.Hide();
				return;
			}
			MessageBox.Show("Username or password is invalid!");
			new Main().Show();
			base.Hide();
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x0000BEE8 File Offset: 0x0000A0E8
		private void guna2Button1_Click_1(object sender, EventArgs e)
		{
			bool flag = this.guna2Button1.BorderThickness == 0;
			if (flag)
			{
				MessageBox.Show("To register please fill in username, password and license (Click the button again)");
				this.guna2Button1.BorderThickness = 1;
			}
			else
			{
				Login.KeyAuthApp.register(this.username.Text, this.textBox1.Text, this.textBox4.Text);
				bool success = Login.KeyAuthApp.response.success;
				if (success)
				{
					Main main = new Main();
					main.Show();
					base.Hide();
				}
				else
				{
					MessageBox.Show("License is invalid!");
				}
			}
			this.guna2Panel1.Show();
		}

		// Token: 0x04000084 RID: 132
		public static api KeyAuthApp = new api("blauwespoofer", "YzYBV8KYJ8", "a3c0d02b0b5997fff35017386d124891f3bfa638edcac1431eef48033e14e504", "1.0");
	}
}
