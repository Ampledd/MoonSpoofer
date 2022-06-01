using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using Microsoft.Win32;
using Siticone.UI.WinForms;
using Siticone.UI.WinForms.Enums;

namespace KeyAuth
{
	// Token: 0x0200000F RID: 15
	public partial class Main : Form
	{
		// Token: 0x06000087 RID: 135 RVA: 0x000023B3 File Offset: 0x000005B3
		public Main()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000088 RID: 136 RVA: 0x000023CB File Offset: 0x000005CB
		private void siticoneControlBox1_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00003F90 File Offset: 0x00002190
		private void Main_Load(object sender, EventArgs e)
		{
			Login.KeyAuthApp.check();
			this.nazwa.Text = "";
			this.dokiedy.Text = "";
			this.createDate.Text = "29-4-2022";
			this.version.Text = "3.0";
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00003FF0 File Offset: 0x000021F0
		public DateTime UnixTimeToDateTime(long unixtime)
		{
			DateTime result = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
			result = result.AddSeconds((double)unixtime).ToLocalTime();
			return result;
		}

		// Token: 0x0600008B RID: 139 RVA: 0x000023D5 File Offset: 0x000005D5
		private void subscriptionDaysLabel_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600008C RID: 140 RVA: 0x000023D5 File Offset: 0x000005D5
		private void expiry_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600008D RID: 141 RVA: 0x000023D8 File Offset: 0x000005D8
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			MessageBox.Show("This will be introduced in 3.0");
		}

		// Token: 0x0600008E RID: 142 RVA: 0x000023D5 File Offset: 0x000005D5
		private void siticoneControlBox2_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600008F RID: 143 RVA: 0x000023D5 File Offset: 0x000005D5
		private void label1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000090 RID: 144 RVA: 0x000023D5 File Offset: 0x000005D5
		private void key_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000091 RID: 145 RVA: 0x000023D5 File Offset: 0x000005D5
		private void guna2Button5_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000092 RID: 146 RVA: 0x000023D5 File Offset: 0x000005D5
		private void guna2Button7_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000093 RID: 147 RVA: 0x000023D5 File Offset: 0x000005D5
		private void guna2Button3_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000094 RID: 148 RVA: 0x000023D5 File Offset: 0x000005D5
		private void guna2Button3_Click_2(object sender, EventArgs e)
		{
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00004028 File Offset: 0x00002228
		private void guna2Button4_Click(object sender, EventArgs e)
		{
			string text = Path.ChangeExtension(Path.GetTempFileName(), ".bat");
			using (StreamWriter streamWriter = new StreamWriter(text))
			{
				streamWriter.WriteLine("echo off");
				streamWriter.WriteLine("taskkill / f / im Steam.exe / t");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("rmdir / s / q % LocalAppData%\\DigitalEntitlements");
				streamWriter.WriteLine("taskkill / f / im Steam.exe / t");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("rmdir / s / q % userprofile %\\AppData\\Roaming\\CitizenFX");
				streamWriter.WriteLine("taskkill / f / im Steam.exe / t");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("set hostspath =% windir %\\System32\\drivers\\etc\\hosts");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("echo 127.0.0.1 xboxlive.com >> % hostspath %");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("echo 127.0.0.1 user.auth.xboxlive.com >> % hostspath %");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("echo 127.0.0.1 presence - heartbeat.xboxlive.com >> % hostspath %");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\MSLicensing\\HardwareID / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\MSLicensing\\Store / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("DELETE HKEY_CURRENT_USER\\Software\\WinRAR\\ArcHistory / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\bam\\State\\UserSettings\\S - 1 - 5 - 21 - 1282084573 - 1681065996 - 3115981261 - 1001 / va / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETEH KEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETEH KEY_CURRENT_USER\\Software\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CURRENT_USER\\Software\\WinRAR\\ArcHistory / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CLASSES_ROOT\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\bam\\State\\UserSettings\\S - 1 - 5 - 21 - 332004695 - 2829936588 - 140372829 - 1002 / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CLASSES_ROOT\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CURRENT_USER\\Software\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CURRENT_USER\\Software\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\bam\\State\\UserSettings\\S - 1 - 5 - 21 - 1282084573 - 1681065996 - 3115981261 - 1001 / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenFX_SubProcess_chrome.bin");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenFX_SubProcess_game.bin");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenFX_SubProcess_game_372.bin");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenFX_SubProcess_game_1604.bin");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenFX_SubProcess_game_1868.bin");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenFX_SubProcess_game_2060.bin");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenFX_SubProcess_game_2189.bin");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\botan.dll");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\asi - five.dll");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\steam.dll");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\steam_api64.dll");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenGame.dll");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\profiles.dll");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\cfx_curl_x86_64.dll");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenFX.ini");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\caches.XML");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\adhesive.dll");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("taskkill / f / im Steam.exe / t");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\discord.dll");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("RENAME % userprofile %\\AppData\\Roaming\\discord\\0.0.309\\modules\\discord_rpc STARCHARMS_SPOOFER");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\Browser");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\db");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\dunno");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\priv");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\servers");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\subprocess");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\unconfirmed");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\authbrowser");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\cache\\crashometry");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\cache\\launcher_skip");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\cache\\launcher_skip_mtl2");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\crashes\\*.* ");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\logs\\*.* ");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\mods\\*.* ");
				streamWriter.WriteLine(":folderclean");
				streamWriter.WriteLine("call :getDiscordVersion");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("goto :xboxclean");
				streamWriter.WriteLine(": getDiscordVersion");
				streamWriter.WriteLine("for / d %% a in (' % appdata%\\Discord\\*') do (");
				streamWriter.WriteLine("     set 'varLoc =%%a'");
				streamWriter.WriteLine("   goto :d1");
				streamWriter.WriteLine(")");
				streamWriter.WriteLine(":d1");
				streamWriter.WriteLine("for / f 'delims =\\ tokens=7' %% z in ('echo %varLoc%') do (");
				streamWriter.WriteLine("     set 'discordVersion =%%z'");
				streamWriter.WriteLine(")");
				streamWriter.WriteLine("goto :EOF");
				streamWriter.WriteLine(": xboxclean");
				streamWriter.WriteLine(" cls");
				streamWriter.WriteLine("powershell - Command ' & {Get-AppxPackage -AllUsers xbox | Remove-AppxPackage}'");
				streamWriter.WriteLine("sc stop XblAuthManager");
				streamWriter.WriteLine("sc stop XblGameSave");
				streamWriter.WriteLine("sc stop XboxNetApiSvc");
				streamWriter.WriteLine("sc stop XboxGipSvc");
				streamWriter.WriteLine("sc delete XblAuthManager");
				streamWriter.WriteLine("sc delete XblGameSave");
				streamWriter.WriteLine("sc delete XboxNetApiSvc");
				streamWriter.WriteLine("sc delete XboxGipSvc");
				streamWriter.WriteLine("reg delete 'HKLM\\SYSTEM\\CurrentControlSet\\Services\\xbgm' / f");
				streamWriter.WriteLine("schtasks / Change / TN 'Microsoft\\XblGameSave\\XblGameSaveTask' / disable");
				streamWriter.WriteLine("schtasks / Change / TN 'Microsoft\\XblGameSave\\XblGameSaveTaskLogon' / disableL");
				streamWriter.WriteLine("reg add 'HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\GameDVR' / v AllowGameDVR / t REG_DWORD / d 0 / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("set hostspath =% windir %\\System32\\drivers\\etc\\hosts");
				streamWriter.WriteLine("   echo 127.0.0.1 xboxlive.com >> % hostspath %");
				streamWriter.WriteLine("   echo 127.0.0.1 user.auth.xboxlive.com >> % hostspath % ");
				streamWriter.WriteLine("   echo 127.0.0.1 presence - heartbeat.xboxlive.com >> % hostspath %");
				streamWriter.WriteLine("   rd % userprofile %\\AppData\\Local\\DigitalEntitlements / q / s");
				streamWriter.WriteLine("exit");
				streamWriter.WriteLine("goto :eof");
			}
			Process process = Process.Start(text);
			process.WaitForExit();
			File.Delete(text);
			MessageBox.Show("Unlinked successfully");
		}

		// Token: 0x06000096 RID: 150 RVA: 0x000023D5 File Offset: 0x000005D5
		private void guna2Button4_Click_1(object sender, EventArgs e)
		{
		}

		// Token: 0x06000097 RID: 151 RVA: 0x000023D8 File Offset: 0x000005D8
		private void guna2Button2_Click(object sender, EventArgs e)
		{
			MessageBox.Show("This will be introduced in 3.0");
		}

		// Token: 0x06000098 RID: 152 RVA: 0x000047DC File Offset: 0x000029DC
		private void guna2Button3_Click_1(object sender, EventArgs e)
		{
			string text = Path.ChangeExtension(Path.GetTempFileName(), ".bat");
			using (StreamWriter streamWriter = new StreamWriter(text))
			{
				streamWriter.WriteLine("echo off");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("taskkill /f /im Steam.exe /t");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("set hostspath=%windir%\\System32\\drivers\\etc\\hosts");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\MSLicensing\\HardwareID / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\MSLicensing\\Store / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CURRENT_USER\\Software\\WinRAR\\ArcHistory / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\bam\\State\\UserSettings\\S - 1 - 5 - 21 - 1282084573 - 1681065996 - 3115981261 - 1001 / va / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETEH KEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETEH KEY_CURRENT_USER\\Software\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CURRENT_USER\\Software\\WinRAR\\ArcHistory / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CLASSES_ROOT\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\bam\\State\\UserSettings\\S - 1 - 5 - 21 - 332004695 - 2829936588 - 140372829 - 1002 / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CLASSES_ROOT\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CURRENT_USER\\Software\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CURRENT_USER\\Software\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\bam\\State\\UserSettings\\S - 1 - 5 - 21 - 1282084573 - 1681065996 - 3115981261 - 1001 / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("REG DELETE HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\AppSwitched / f");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\cfx_curl_x86_64.dll");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\Browser");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\db");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\dunno");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\priv");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\servers");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\subprocess");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\unconfirmed");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\steam_api64.dll");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\authbrowser");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\cache\\crashometry");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\cache\\launcher_skip");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\cache\\launcher_skip_mtl2");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\DigitalEntitlements");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\profiles.dll");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenFX_SubProcess_chrome.bin");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenFX_SubProcess_game.bin");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenFX_SubProcess_game_372.bin");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenFX_SubProcess_game_1604.bin");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenFX_SubProcess_game_1868.bin");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenFX_SubProcess_game_2060.bin");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenFX_SubProcess_game_2189.bin");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\logs\\*.* ");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenGame.dll");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\cfx_curl_x86_64.dll");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\steam.dll");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("rmdir / s / q % userprofile %\\AppData\\Roaming\\CitizenFX");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\asi - five.dll");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\CitizenFX.ini");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\caches.XML");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\adhesive.dll");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f % LocalAppData %\\FiveM\\FiveM.app\\discord.dll");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\crashes\\*.* ");
				streamWriter.WriteLine("cls");
				streamWriter.WriteLine("RENAME % userprofile %\\AppData\\Roaming\\discord\\0.0.309\\modules\\discord_rpc BlueSpoofer");
				streamWriter.WriteLine("cls");
			}
			Process process = Process.Start(text);
			process.WaitForExit();
			File.Delete(text);
			MessageBox.Show("Spoofed successfully");
		}

		// Token: 0x06000099 RID: 153 RVA: 0x000023D5 File Offset: 0x000005D5
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x0600009A RID: 154 RVA: 0x000023D5 File Offset: 0x000005D5
		private void hwidlabel_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600009B RID: 155 RVA: 0x000023D5 File Offset: 0x000005D5
		private void createDate_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600009C RID: 156 RVA: 0x000023D5 File Offset: 0x000005D5
		private void guna2Button2_Click_1(object sender, EventArgs e)
		{
		}

		// Token: 0x0600009D RID: 157 RVA: 0x000023D5 File Offset: 0x000005D5
		private void guna2Panel3_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00004D5C File Offset: 0x00002F5C
		private void settingsBTN_Click(object sender, EventArgs e)
		{
			this.homeBTN.Checked = false;
			this.settingsBTN.Checked = true;
			this.SPOOFPANEL.Show();
			this.cleanPANEL.Hide();
			this.cleanBTN.Checked = false;
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00004DAC File Offset: 0x00002FAC
		private void homeBTN_Click(object sender, EventArgs e)
		{
			this.settingsBTN.Checked = false;
			this.homeBTN.Checked = true;
			this.PANELhome.Show();
			this.SPOOFPANEL.Hide();
			this.cleanBTN.Checked = false;
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00004DFC File Offset: 0x00002FFC
		private void guna2Button7_Click_1(object sender, EventArgs e)
		{
			Login login = new Login();
			login.Show();
			base.Hide();
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x000023D5 File Offset: 0x000005D5
		private void guna2Button2_Click_2(object sender, EventArgs e)
		{
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x000023D5 File Offset: 0x000005D5
		private void guna2Button2_Click_3(object sender, EventArgs e)
		{
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00004E20 File Offset: 0x00003020
		private void guna2Button6_Click(object sender, EventArgs e)
		{
			Font font = new Font("Arial", 12f);
			Font font2 = new Font("Arial", 12f, FontStyle.Bold);
			bool flag = this.guna2Button6.Text == "SHOW";
			if (flag)
			{
				this.guna2Button6.Text = "HIDE";
				this.hwidlabel.Text = Login.KeyAuthApp.user_data.hwid;
				this.hwidlabel.Font = font;
			}
			else
			{
				this.hwidlabel.Text = "HIDDEN";
				this.guna2Button6.Text = "SHOW";
				this.hwidlabel.Font = font2;
			}
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x000023E6 File Offset: 0x000005E6
		private void guna2Button1_Click_1(object sender, EventArgs e)
		{
			Process.Start("discord.gg/BmbrCjfqZJ");
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00004ED8 File Offset: 0x000030D8
		private void checkbox_Click_1(object sender, EventArgs e)
		{
			bool flag = this.checkbox.FillColor == Color.FromArgb(147, 94, 255);
			if (flag)
			{
				this.checkbox.FillColor = Color.FromArgb(9, 9, 10);
			}
			else
			{
				this.checkbox.FillColor = Color.FromArgb(147, 94, 255);
			}
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00004F48 File Offset: 0x00003148
		private void guna2Button2_Click_4(object sender, EventArgs e)
		{
			bool flag = this.guna2Button2.FillColor == Color.FromArgb(147, 94, 255);
			if (flag)
			{
				this.guna2Button2.FillColor = Color.FromArgb(9, 9, 10);
			}
			else
			{
				this.guna2Button2.FillColor = Color.FromArgb(147, 94, 255);
			}
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00004FB8 File Offset: 0x000031B8
		private void guna2Button5_Click_1(object sender, EventArgs e)
		{
			bool flag = this.guna2Button5.FillColor == Color.FromArgb(9, 9, 10);
			if (flag)
			{
				this.guna2Button5.FillColor = Color.FromArgb(147, 94, 255);
				this.guna2Button9.FillColor = Color.FromArgb(147, 94, 255);
				this.guna2Button8.FillColor = Color.FromArgb(147, 94, 255);
				this.guna2Button2.FillColor = Color.FromArgb(147, 94, 255);
				this.checkbox.FillColor = Color.FromArgb(147, 94, 255);
			}
			else
			{
				this.guna2Button5.FillColor = Color.FromArgb(9, 9, 10);
				this.guna2Button9.FillColor = Color.FromArgb(9, 9, 10);
				this.guna2Button8.FillColor = Color.FromArgb(9, 9, 10);
				this.guna2Button2.FillColor = Color.FromArgb(9, 9, 10);
				this.checkbox.FillColor = Color.FromArgb(9, 9, 10);
			}
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x000050F4 File Offset: 0x000032F4
		private void guna2Button9_Click(object sender, EventArgs e)
		{
			bool flag = this.guna2Button9.FillColor == Color.FromArgb(147, 94, 255);
			if (flag)
			{
				this.guna2Button9.FillColor = Color.FromArgb(9, 9, 10);
			}
			else
			{
				this.guna2Button9.FillColor = Color.FromArgb(147, 94, 255);
			}
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00005164 File Offset: 0x00003364
		private void guna2Button8_Click(object sender, EventArgs e)
		{
			bool flag = this.guna2Button8.FillColor == Color.FromArgb(147, 94, 255);
			if (flag)
			{
				this.guna2Button8.FillColor = Color.FromArgb(9, 9, 10);
			}
			else
			{
				this.guna2Button8.FillColor = Color.FromArgb(147, 94, 255);
			}
		}

		// Token: 0x060000AA RID: 170 RVA: 0x000051D4 File Offset: 0x000033D4
		private void guna2Button12_Click(object sender, EventArgs e)
		{
			bool flag = this.guna2Button12.FillColor == Color.FromArgb(9, 9, 10);
			if (flag)
			{
				this.guna2Button10.FillColor = Color.FromArgb(147, 94, 255);
				this.guna2Button11.FillColor = Color.FromArgb(147, 94, 255);
				this.guna2Button14.FillColor = Color.FromArgb(147, 94, 255);
				this.guna2Button13.FillColor = Color.FromArgb(147, 94, 255);
				this.guna2Button12.FillColor = Color.FromArgb(147, 94, 255);
			}
			else
			{
				this.guna2Button10.FillColor = Color.FromArgb(9, 9, 10);
				this.guna2Button11.FillColor = Color.FromArgb(9, 9, 10);
				this.guna2Button14.FillColor = Color.FromArgb(9, 9, 10);
				this.guna2Button13.FillColor = Color.FromArgb(9, 9, 10);
				this.guna2Button12.FillColor = Color.FromArgb(9, 9, 10);
			}
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00005310 File Offset: 0x00003510
		private void guna2Button10_Click(object sender, EventArgs e)
		{
			bool flag = this.guna2Button10.FillColor == Color.FromArgb(147, 94, 255);
			if (flag)
			{
				this.guna2Button10.FillColor = Color.FromArgb(9, 9, 10);
			}
			else
			{
				this.guna2Button10.FillColor = Color.FromArgb(147, 94, 255);
			}
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00005380 File Offset: 0x00003580
		private void guna2Button11_Click(object sender, EventArgs e)
		{
			bool flag = this.guna2Button11.FillColor == Color.FromArgb(147, 94, 255);
			if (flag)
			{
				this.guna2Button11.FillColor = Color.FromArgb(9, 9, 10);
			}
			else
			{
				this.guna2Button11.FillColor = Color.FromArgb(147, 94, 255);
			}
		}

		// Token: 0x060000AD RID: 173 RVA: 0x000053F0 File Offset: 0x000035F0
		private void guna2Button14_Click(object sender, EventArgs e)
		{
			bool flag = this.guna2Button14.FillColor == Color.FromArgb(147, 94, 255);
			if (flag)
			{
				this.guna2Button14.FillColor = Color.FromArgb(9, 9, 10);
			}
			else
			{
				this.guna2Button14.FillColor = Color.FromArgb(147, 94, 255);
			}
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00005460 File Offset: 0x00003660
		private void guna2Button13_Click(object sender, EventArgs e)
		{
			bool flag = this.guna2Button13.FillColor == Color.FromArgb(147, 94, 255);
			if (flag)
			{
				this.guna2Button13.FillColor = Color.FromArgb(9, 9, 10);
			}
			else
			{
				this.guna2Button13.FillColor = Color.FromArgb(147, 94, 255);
			}
		}

		// Token: 0x060000AF RID: 175 RVA: 0x000023D5 File Offset: 0x000005D5
		private void guna2Panel2_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x000023F4 File Offset: 0x000005F4
		private void guna2Button15_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Soon | discord.gg/BmbrCjfqZJ");
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x000023F4 File Offset: 0x000005F4
		private void guna2Button16_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Soon | discord.gg/BmbrCjfqZJ");
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00002402 File Offset: 0x00000602
		private void guna2Button17_Click(object sender, EventArgs e)
		{
			this.settingsBTN.Checked = false;
			this.homeBTN.Checked = false;
			this.SPOOFPANEL.Show();
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x000054D0 File Offset: 0x000036D0
		private void guna2Button17_Click_1(object sender, EventArgs e)
		{
			string text = Path.ChangeExtension(Path.GetTempFileName(), ".bat");
			using (StreamWriter streamWriter = new StreamWriter(text))
			{
				streamWriter.WriteLine("@echo off");
				streamWriter.WriteLine("echo Wait...");
				streamWriter.WriteLine("echo Wait...");
				streamWriter.WriteLine("echo Wait...");
				streamWriter.WriteLine("echo Wait...");
				streamWriter.WriteLine("echo Wait...");
				streamWriter.WriteLine("echo Wait...");
				streamWriter.WriteLine("echo Wait...");
				streamWriter.WriteLine("rmdir /s /q %LocalAppData%\\FiveM\\FiveM.app\\data");
			}
			Process process = Process.Start(text);
			process.WaitForExit();
			File.Delete(text);
			MessageBox.Show("Cache has been cleared");
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x000055A0 File Offset: 0x000037A0
		private void guna2Button18_Click(object sender, EventArgs e)
		{
			string text = Path.ChangeExtension(Path.GetTempFileName(), ".bat");
			using (StreamWriter streamWriter = new StreamWriter(text))
			{
				streamWriter.WriteLine("@echo off");
				streamWriter.WriteLine("echo Wait...");
				streamWriter.WriteLine("echo Wait...");
				streamWriter.WriteLine("echo Wait...");
				streamWriter.WriteLine("echo Wait...");
				streamWriter.WriteLine("echo Wait...");
				streamWriter.WriteLine("echo Wait...");
				streamWriter.WriteLine("echo Wait...");
				streamWriter.WriteLine("rmdir /s /q %LocalAppData%\\FiveM\\FiveM.app\\citizen");
			}
			Process process = Process.Start(text);
			process.WaitForExit();
			File.Delete(text);
			MessageBox.Show("Citizen has been cleared");
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00005670 File Offset: 0x00003870
		private void guna2Button19_Click(object sender, EventArgs e)
		{
			string text = Path.ChangeExtension(Path.GetTempFileName(), ".bat");
			using (StreamWriter streamWriter = new StreamWriter(text))
			{
				streamWriter.WriteLine("@echo off");
				streamWriter.WriteLine("rmdir / s / q C:\\Program Files\\Epic Games\\GTAV\\reshade-shaders");
				streamWriter.WriteLine("del / s / q / f C:\\Program Files\\Epic Games\\GTAV\\Dxgi.dll");
				streamWriter.WriteLine("del / s / q / f C:\\Program Files\\Epic Games\\GTAV\\D3d10.dll");
				streamWriter.WriteLine("del / s / q / f C:\\Program Files\\Epic Games\\GTAV\\d3d9.dll");
				streamWriter.WriteLine("del / s / q / f C:\\Program Files\\Epic Games\\GTAV\\d3d8.dll");
				streamWriter.WriteLine("del / s / q / f C:\\Program Files\\Epic Games\\GTAV\\Dxgi.txt");
				streamWriter.WriteLine("rmdir / s / q D:\\Program Files\\Epic Games\\GTAV\\reshade-shaders");
				streamWriter.WriteLine("del / s / q / f D:\\Program Files\\Epic Games\\GTAV\\Dxgi.dll");
				streamWriter.WriteLine("del / s / q / f D:\\Program Files\\Epic Games\\GTAV\\D3d10.dll");
				streamWriter.WriteLine("del / s / q / f D:\\Program Files\\Epic Games\\GTAV\\d3d9.dll");
				streamWriter.WriteLine("del / s / q / f D:\\Program Files\\Epic Games\\GTAV\\d3d8.dll");
				streamWriter.WriteLine("del / s / q / f D:\\Program Files\\Epic Games\\GTAV\\dxgi.log");
				streamWriter.WriteLine("rmdir / s / q C:\\Program Files (x86)\\Steam\\steamapps\\common\\Grand Theft Auto V\\reshade-shaders");
				streamWriter.WriteLine("del / s / q / f C:\\Program Files (x86)\\Steam\\steamapps\\common\\Grand Theft Auto V\\Dxgi.dll");
				streamWriter.WriteLine("del / s / q / f C:\\Program Files (x86)\\Steam\\steamapps\\common\\Grand Theft Auto V\\D3d10.dll");
				streamWriter.WriteLine("del / s / q / f C:\\Program Files (x86)\\Steam\\steamapps\\common\\Grand Theft Auto V\\d3d9.dll");
				streamWriter.WriteLine("del / s / q / f C:\\Program Files (x86)\\Steam\\steamapps\\common\\Grand Theft Auto V\\d3d8.dll");
				streamWriter.WriteLine("del / s / q / f C:\\Program Files (x86)\\Steam\\steamapps\\common\\Grand Theft Auto V\\Dxgi.txt");
				streamWriter.WriteLine("del / s / q / f D:\\Program Files (x86)\\Steam\\steamapps\\common\\Grand Theft Auto V\\Dxgi.dll");
				streamWriter.WriteLine("del / s / q / f D:\\Program Files (x86)\\Steam\\steamapps\\common\\Grand Theft Auto V\\D3d10.dll");
				streamWriter.WriteLine("del / s / q / f D:\\Program Files (x86)\\Steam\\steamapps\\common\\Grand Theft Auto V\\d3d9.dll");
				streamWriter.WriteLine("del / s / q / f D:\\Program Files (x86)\\Steam\\steamapps\\common\\Grand Theft Auto V\\d3d8.dll");
				streamWriter.WriteLine("del / s / q / f D:\\Program Files (x86)\\Steam\\steamapps\\common\\Grand Theft Auto V\\Dxgi.txt");
				streamWriter.WriteLine("rmdir / s / q C:\\Program Files\\Rockstar Games\\Grand Theft Auto V\\reshade-shaders");
				streamWriter.WriteLine("del / s / q / f C:\\Program Files\\Rockstar Games\\Grand Theft Auto V\\Dxgi.dll");
				streamWriter.WriteLine("del / s / q / f C:\\Program Files\\Rockstar Games\\Grand Theft Auto V\\D3d10.dll");
				streamWriter.WriteLine("del / s / q / f C:\\Program Files\\Rockstar Games\\Grand Theft Auto V\\d3d9.dll");
				streamWriter.WriteLine("del / s / q / f C:\\Program Files\\Rockstar Games\\Grand Theft Auto V\\d3d8.dll");
				streamWriter.WriteLine("del / s / q / f C:\\Program Files\\Rockstar Games\\Grand Theft Auto V\\Dxgi.txt");
				streamWriter.WriteLine("rmdir / s / q D:\\Program Files\\Rockstar Games\\Grand Theft Auto V\\reshade-shaders");
				streamWriter.WriteLine("del / s / q / f D:\\Program Files\\Rockstar Games\\Grand Theft Auto V\\Dxgi.dll");
				streamWriter.WriteLine("del / s / q / f D:\\Program Files\\Rockstar Games\\Grand Theft Auto V\\D3d10.dll");
				streamWriter.WriteLine("del / s / q / f D:\\Program Files\\Rockstar Games\\Grand Theft Auto V\\d3d9.dll");
				streamWriter.WriteLine("del / s / q / f D:\\Program Files\\Rockstar Games\\Grand Theft Auto V\\d3d8.dll");
				streamWriter.WriteLine("del / s / q / f D:\\Program Files\\Rockstar Games\\Grand Theft Auto V\\Dxgi.txt");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\reshade-shaders");
				streamWriter.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\Dxgi.dll");
				streamWriter.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\D3d10.dll");
				streamWriter.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\d3d9.dll");
				streamWriter.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\d3d8.dll");
				streamWriter.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\Dxgi.txt");
			}
			Process process = Process.Start(text);
			process.WaitForExit();
			File.Delete(text);
			MessageBox.Show("Reshade has been cleared");
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x000058D8 File Offset: 0x00003AD8
		private void guna2Button22_Click(object sender, EventArgs e)
		{
			string text = Path.ChangeExtension(Path.GetTempFileName(), ".bat");
			using (StreamWriter streamWriter = new StreamWriter(text))
			{
				streamWriter.WriteLine("@echo off");
				streamWriter.WriteLine("del /s /q %systemdrive%\\Windows\\Temp\\*.*");
				streamWriter.WriteLine("del / s / q % userprofile %\\AppData\\Local\\Temp\\*.* ");
			}
			Process process = Process.Start(text);
			process.WaitForExit();
			File.Delete(text);
			MessageBox.Show("Temp has been cleared");
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00005960 File Offset: 0x00003B60
		private void guna2Button20_Click(object sender, EventArgs e)
		{
			string text = Path.ChangeExtension(Path.GetTempFileName(), ".bat");
			using (StreamWriter streamWriter = new StreamWriter(text))
			{
				streamWriter.WriteLine("@echo off");
				streamWriter.WriteLine("ipconfig /flushdns");
			}
			Process process = Process.Start(text);
			process.WaitForExit();
			File.Delete(text);
			MessageBox.Show("Dns cache has been cleared");
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x000059DC File Offset: 0x00003BDC
		private void guna2Button21_Click(object sender, EventArgs e)
		{
			string text = Path.ChangeExtension(Path.GetTempFileName(), ".bat");
			using (StreamWriter streamWriter = new StreamWriter(text))
			{
				streamWriter.WriteLine("@echo off");
				streamWriter.WriteLine("del /s /q %systemdrive%\\$Recycle.bin\\*.*");
			}
			Process process = Process.Start(text);
			process.WaitForExit();
			File.Delete(text);
			MessageBox.Show("Recycle bin has been cleared");
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00005A58 File Offset: 0x00003C58
		private void guna2Button24_Click(object sender, EventArgs e)
		{
			string text = Path.ChangeExtension(Path.GetTempFileName(), ".bat");
			using (StreamWriter streamWriter = new StreamWriter(text))
			{
				streamWriter.WriteLine("@echo off");
				streamWriter.WriteLine("set tmp2 = C:\\Windows\\Temp\\moonhelper.bat");
				streamWriter.WriteLine("echo @echo off > % tmp2 % ");
				streamWriter.WriteLine("echo title Zyorby Cleaner V2 \\ Background Apps Help >> % tmp2 %");
				streamWriter.WriteLine("echo color 03 >> % tmp2 % ");
				streamWriter.WriteLine("echo mode con:cols = 100 lines = 20 >> % tmp2 %");
				streamWriter.WriteLine("echo echo Hello if you dont know what to do in the backgound apps setting then read this: >> % tmp2 % ");
				streamWriter.WriteLine("echo echo If you want MAX Performance switch the Let apps run in the background settings to OFF >> % tmp2 %");
				streamWriter.WriteLine("echo echo. >> % tmp2 % ");
				streamWriter.WriteLine("echo echo If you want some of the apps running that you see you like leave those On and turn the rest OFF >> % tmp2 %");
				streamWriter.WriteLine("echo echo. >> % tmp2 % ");
				streamWriter.WriteLine("echo echo. >> % tmp2 %");
				streamWriter.WriteLine("echo echo. >> % tmp2 % ");
				streamWriter.WriteLine("echo echo. >> % tmp2 %");
				streamWriter.WriteLine("echo echo Please Close This Window Once You Are Done >> % tmp2 % ");
				streamWriter.WriteLine("echo set / p read = \" >> % tmp2 %");
				streamWriter.WriteLine("start C:\\Windows\\Temp\\zyorbybghelper.bat");
				streamWriter.WriteLine("start ms - settings:privacy - backgroundapps");
			}
			Process process = Process.Start(text);
			process.WaitForExit();
			File.Delete(text);
			MessageBox.Show("Bg Apps has been disabled");
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00005B94 File Offset: 0x00003D94
		private void guna2Button23_Click(object sender, EventArgs e)
		{
			string text = Path.ChangeExtension(Path.GetTempFileName(), ".bat");
			using (StreamWriter streamWriter = new StreamWriter(text))
			{
				streamWriter.WriteLine("@echo off");
				streamWriter.WriteLine("set tmp3 = C:\\Windows\\Temp\\moon2helper.bat");
				streamWriter.WriteLine("echo @echo off > % tmp3 % ");
				streamWriter.WriteLine("echo title Zyorby Cleaner V2 \\ Startup Apps Help >> % tmp3 %");
				streamWriter.WriteLine("echo color 03 >> % tmp3 % ");
				streamWriter.WriteLine("echo mode con:cols = 100 lines = 20 >> % tmp3 %");
				streamWriter.WriteLine("echo echo Hello if you dont know what to do in the startup apps setting then read this: >> % tmp3 % ");
				streamWriter.WriteLine("echo echo. >> % tmp3 %");
				streamWriter.WriteLine("echo echo What most do here is switch all uneccesary apps off on startup >> % tmp3 % ");
				streamWriter.WriteLine("echo echo Like i turn off discord, steam, and all my peripheral apps >> % tmp3 %");
				streamWriter.WriteLine(" echo echo. >> % tmp3 % ");
				streamWriter.WriteLine("echo echo. >> % tmp3 %");
				streamWriter.WriteLine("echo echo. >> % tmp3 %");
				streamWriter.WriteLine("echo echo. >> % tmp3 %");
				streamWriter.WriteLine("echo echo Please Close This Window Once You Are Done >> % tmp3 % ");
				streamWriter.WriteLine("echo set / p read = \" >> % tmp3 %");
				streamWriter.WriteLine("start C:\\Windows\\Temp\\zyorbystartupappshelper.bat");
				streamWriter.WriteLine("start ms - settings:startupapps");
			}
			Process process = Process.Start(text);
			process.WaitForExit();
			File.Delete(text);
			MessageBox.Show("Bg Apps has been disabled");
		}

		// Token: 0x060000BB RID: 187 RVA: 0x0000242B File Offset: 0x0000062B
		private void guna2Button17_Click_2(object sender, EventArgs e)
		{
			this.SPOOFPANEL.Show();
			this.homeBTN.Checked = false;
			this.settingsBTN.Checked = false;
		}

		// Token: 0x060000BC RID: 188 RVA: 0x000023D5 File Offset: 0x000005D5
		private void guna2Button17_Click_3(object sender, EventArgs e)
		{
		}

		// Token: 0x060000BD RID: 189 RVA: 0x000023D5 File Offset: 0x000005D5
		private void guna2Panel4_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x060000BE RID: 190 RVA: 0x000023D5 File Offset: 0x000005D5
		private void guna2Button17_Click_4(object sender, EventArgs e)
		{
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00002454 File Offset: 0x00000654
		private void hotandcoldBTN_Click(object sender, EventArgs e)
		{
			Process.Start("https://mega.nz/file/OJgBFSSR#-I7eZ-QLiSyGtM_x4nzMJunJkKME9xqitV4DVL7EL9c");
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00002462 File Offset: 0x00000662
		private void redcloudsBTN_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.mediafire.com/file/73bawwffq98bp35/SuperCottonCandy-Cheeco#1111.rar/file");
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00002470 File Offset: 0x00000670
		private void blueskyBTN_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.mediafire.com/file/7kmhpz6bar3e4br/feaR+V3+Visual+Pack.rar/file");
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x0000247E File Offset: 0x0000067E
		private void bluelightBTN_Click(object sender, EventArgs e)
		{
			Process.Start("https://megawrzuta.pl/download/7f4178eb578dbfb19218a9800e020b01.html");
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x000023D5 File Offset: 0x000005D5
		private void nazwa_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x000023D5 File Offset: 0x000005D5
		private void dokiedy_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x000023D5 File Offset: 0x000005D5
		private void SPOOFPANEL_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x000023D5 File Offset: 0x000005D5
		private void siticoneControlBox3_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x000023D5 File Offset: 0x000005D5
		private void siticoneControlBox4_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00005CD0 File Offset: 0x00003ED0
		private void guna2Button16_Click_1(object sender, EventArgs e)
		{
			this.SPOOFPANEL.Show();
			this.cleanPANEL.Show();
			this.settingsBTN.Checked = false;
			this.homeBTN.Checked = false;
			this.cleanBTN.Checked = true;
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00005D20 File Offset: 0x00003F20
		private void guna2Button16_Click_2(object sender, EventArgs e)
		{
			string text = Path.ChangeExtension(Path.GetTempFileName(), ".bat");
			using (StreamWriter streamWriter = new StreamWriter(text))
			{
				streamWriter.WriteLine("@echo off");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\browser");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\db");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\priv");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\servers");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\subprocess");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\cache\\unconfirmed");
				streamWriter.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\crashometry");
				streamWriter.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\launcher_skip_mtl2");
				streamWriter.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\session");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\plugins");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\mods");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\logs");
				streamWriter.WriteLine("rmdir / s / q %LocalAppData%\\FiveM\\FiveM.app\\crashes");
				streamWriter.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\caches.XML");
				streamWriter.WriteLine("del / s / q / f %LocalAppData%\\FiveM\\FiveM.app\\adhesive.dll");
			}
			Process process = Process.Start(text);
			process.WaitForExit();
			File.Delete(text);
			MessageBox.Show("Fivem Cache has been cleared");
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00005E44 File Offset: 0x00004044
		private void guna2Button18_Click_1(object sender, EventArgs e)
		{
			string text = Path.ChangeExtension(Path.GetTempFileName(), ".bat");
			using (StreamWriter streamWriter = new StreamWriter(text))
			{
				streamWriter.WriteLine("@echo off");
				streamWriter.WriteLine("powercfg - s 8c5e7fda - e8bf - 4a96 - 9a85 - a6e23a8c635c");
				streamWriter.WriteLine("taskkill / f / im GTAVLauncher.exe");
				streamWriter.WriteLine("wmic process where name = FiveM_b2189_GTAProcess.exe CALL setpriority 128");
				streamWriter.WriteLine("taskkill / f / im wmpnetwk.exe.exe");
				streamWriter.WriteLine("taskkill / f / im OneDrive.exe");
				streamWriter.WriteLine("taskkill / f / im speedfan.exe");
				streamWriter.WriteLine("taskkill / f / im TeamWiever_Service.exe");
				streamWriter.WriteLine("taskkill / f / im opera.exe");
				streamWriter.WriteLine("taskkill / f / im java.exed");
			}
			Process process = Process.Start(text);
			process.WaitForExit();
			File.Delete(text);
			MessageBox.Show("Windows for fivem has been optimized");
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00005F20 File Offset: 0x00004120
		private void guna2Button19_Click_1(object sender, EventArgs e)
		{
			Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\AutoComplete", "Append Completion", "yes", RegistryValueKind.String);
			Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\AutoComplete", "AutoSuggest", "yes", RegistryValueKind.String);
			Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer", "EnableAutoTray", "0", RegistryValueKind.DWord);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\System\\CurrentControlSet\\Control\\Remote Assistance", "fAllowToGetHelp", "0", RegistryValueKind.DWord);
			Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "DisallowShaking", "1", RegistryValueKind.DWord);
			Registry.SetValue("HKEY_CLASSES_ROOT\\AllFilesystemObjects\\shellex\\ContextMenuHandlers\\Copy To", "", "{C2FBB630-2971-11D1-A18C-00C04FD75D13}");
			Registry.SetValue("HKEY_CLASSES_ROOT\\AllFilesystemObjects\\shellex\\ContextMenuHandlers\\Move To", "", "{C2FBB631-2971-11D1-A18C-00C04FD75D13}");
			Registry.SetValue("HKEY_CURRENT_USER\\Control Panel\\Desktop", "AutoEndTasks", "1");
			Registry.SetValue("HKEY_CURRENT_USER\\Control Panel\\Desktop", "HungAppTimeout", "1000");
			Registry.SetValue("HKEY_CURRENT_USER\\Control Panel\\Desktop", "MenuShowDelay", "0");
			Registry.SetValue("HKEY_CURRENT_USER\\Control Panel\\Desktop", "WaitToKillAppTimeout", "2000");
			Registry.SetValue("HKEY_CURRENT_USER\\Control Panel\\Desktop", "LowLevelHooksTimeout", "1000");
			Registry.SetValue("HKEY_CURRENT_USER\\Control Panel\\Mouse", "MouseHoverTime", "0");
			Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", "NoLowDiskSpaceChecks", "00000001", RegistryValueKind.DWord);
			Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", "LinkResolveIgnoreLinkInfo", "00000001", RegistryValueKind.DWord);
			Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", "NoResolveSearch", "00000001", RegistryValueKind.DWord);
			Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", "NoResolveTrack", "00000001", RegistryValueKind.DWord);
			Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", "NoInternetOpenWith", "00000001", RegistryValueKind.DWord);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control", "WaitToKillServiceTimeout", "2000");
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\DiagTrack", "Start", "4", RegistryValueKind.DWord);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\diagsvc", "Start", "4", RegistryValueKind.DWord);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\diagnosticshub.standardcollector.service", "Start", "4", RegistryValueKind.DWord);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\dmwappushservice", "Start", "4", RegistryValueKind.DWord);
			Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "HideFileExt", "0", RegistryValueKind.DWord);
			Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "Hidden", "1", RegistryValueKind.DWord);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile", "SystemResponsiveness", 1, RegistryValueKind.DWord);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile\\Tasks\\Games", "GPU Priority", 8, RegistryValueKind.DWord);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile\\Tasks\\Games", "Priority", 6, RegistryValueKind.DWord);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile\\Tasks\\Games", "Scheduling Category", "High", RegistryValueKind.String);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile\\Tasks\\Games", "SFIO Priority", "High", RegistryValueKind.String);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile\\Tasks\\Low Latency", "GPU Priority", 0, RegistryValueKind.DWord);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile\\Tasks\\Low Latency", "Priority", 8, RegistryValueKind.DWord);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile\\Tasks\\Low Latency", "Scheduling Category", "Medium", RegistryValueKind.String);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile\\Tasks\\Low Latency", "SFIO Priority", "High", RegistryValueKind.String);
			Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\AutoComplete", true).DeleteValue("Append Completion", false);
			Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\AutoComplete", true).DeleteValue("AutoSuggest", false);
			Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer", true).DeleteValue("EnableAutoTray", false);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\System\\CurrentControlSet\\Control\\Remote Assistance", "fAllowToGetHelp", "1", RegistryValueKind.DWord);
			Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "DisallowShaking", "0", RegistryValueKind.DWord);
			Registry.ClassesRoot.DeleteSubKeyTree("AllFilesystemObjects\\\\shellex\\\\ContextMenuHandlers\\\\Copy To", false);
			Registry.ClassesRoot.DeleteSubKeyTree("AllFilesystemObjects\\\\shellex\\\\ContextMenuHandlers\\\\Move To", false);
			Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop", true).DeleteValue("AutoEndTasks", false);
			Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop", true).DeleteValue("HungAppTimeout", false);
			Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop", true).DeleteValue("WaitToKillAppTimeout", false);
			Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop", true).DeleteValue("LowLevelHooksTimeout", false);
			Registry.SetValue("HKEY_CURRENT_USER\\Control Panel\\Desktop", "MenuShowDelay", "400");
			Registry.SetValue("HKEY_CURRENT_USER\\Control Panel\\Mouse", "MouseHoverTime", "400");
			Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true).DeleteValue("NoLowDiskSpaceChecks", false);
			Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true).DeleteValue("LinkResolveIgnoreLinkInfo", false);
			Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true).DeleteValue("NoResolveSearch", false);
			Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true).DeleteValue("NoResolveTrack", false);
			Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true).DeleteValue("NoInternetOpenWith", false);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control", "WaitToKillServiceTimeout", "5000");
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\DiagTrack", "Start", "2", RegistryValueKind.DWord);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\diagnosticshub.standardcollector.service", "Start", "2", RegistryValueKind.DWord);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\dmwappushservice", "Start", "2", RegistryValueKind.DWord);
			Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "HideFileExt", "1", RegistryValueKind.DWord);
			Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "Hidden", "0", RegistryValueKind.DWord);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile", "SystemResponsiveness", 14, RegistryValueKind.DWord);
			Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile\\Tasks\\Games", true).DeleteValue("GPU Priority", false);
			Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile\\Tasks\\Games", true).DeleteValue("Priority", false);
			Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile\\Tasks\\Games", true).DeleteValue("Scheduling Category", false);
			Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile\\Tasks\\Games", true).DeleteValue("SFIO Priority", false);
			Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile\\Tasks\\Low Latency", true).DeleteValue("GPU Priority", false);
			Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile\\Tasks\\Low Latency", true).DeleteValue("Priority", false);
			Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile\\Tasks\\Low Latency", true).DeleteValue("Scheduling Category", false);
			Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile\\Tasks\\Low Latency", true).DeleteValue("SFIO Priority", false);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows\\System", "PublishUserActivities", "0", RegistryValueKind.DWord);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\SQMClient\\Windows", "CEIPEnable", "0", RegistryValueKind.DWord);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows\\AppCompat", "AITEnable", "0", RegistryValueKind.DWord);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows\\AppCompat", "DisableInventory", "1", RegistryValueKind.DWord);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows\\AppCompat", "DisablePCA", "1", RegistryValueKind.DWord);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows\\AppCompat", "DisableUAR", "1", RegistryValueKind.DWord);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Device Metadata", "PreventDeviceMetadataFromNetwork", "1", RegistryValueKind.DWord);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\MRT", "DontOfferThroughWUAU", "1", RegistryValueKind.DWord);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\WMI\\AutoLogger\\SQMLogger", "Start", "0", RegistryValueKind.DWord);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\PolicyManager\\current\\device\\System", "AllowExperimentation", 0);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows Defender", "DisableAntiVirus", "1", RegistryValueKind.DWord);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows Defender", "DisableSpecialRunningModes", "1", RegistryValueKind.DWord);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows Defender", "DisableRoutinelyTakingAction", "1", RegistryValueKind.DWord);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows Defender", "ServiceKeepAlive", "0", RegistryValueKind.DWord);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows Defender\\Real-Time Protection", "DisableRealtimeMonitoring", "1", RegistryValueKind.DWord);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows Defender\\Signature Updates", "ForceUpdateFromMU", 0);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows Defender\\Spynet", "DisableBlockAtFirstSeen", 1);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows Defender\\MpEngine", "MpEnablePus", "0", RegistryValueKind.DWord);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows Defender", "PUAProtection", "0", RegistryValueKind.DWord);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows Defender\\Policy Manager", "DisableScanningNetworkFiles", "1", RegistryValueKind.DWord);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows Defender", "DisableAntiSpyware", "1", RegistryValueKind.DWord);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows Defender", "DisableRealtimeMonitoring", "1", RegistryValueKind.DWord);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\Software\\Policies\\Microsoft\\Windows Defender\\Spynet", "SpyNetReporting", "0", RegistryValueKind.DWord);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\Software\\Policies\\Microsoft\\Windows Defender\\Spynet", "SubmitSamplesConsent", "0", RegistryValueKind.DWord);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\Software\\Policies\\Microsoft\\MRT", "DontReportInfectionInformation", "1", RegistryValueKind.DWord);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\Software\\Policies\\Microsoft\\MRT", "DontOfferThroughWUAU", "1", RegistryValueKind.DWord);
			Registry.ClassesRoot.DeleteSubKeyTree("\\CLSID\\{09A47860-11B0-4DA5-AFA5-26D86198A780}", false);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows Defender\\Real-Time Protection", "DisableBehaviorMonitoring", "1", RegistryValueKind.DWord);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows Defender\\Real-Time Protection", "DisableOnAccessProtection", "1", RegistryValueKind.DWord);
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Policies\\Microsoft\\Windows Defender\\Real-Time Protection", "DisableScanOnRealtimeEnable", "1", RegistryValueKind.DWord);
			MessageBox.Show("Windows has been optimized!");
		}

		// Token: 0x060000CC RID: 204 RVA: 0x0000248C File Offset: 0x0000068C
		private void guna2Button20_Click_1(object sender, EventArgs e)
		{
			Process.Start("fivem://connect/" + this.textBox1.Text);
		}
	}
}
