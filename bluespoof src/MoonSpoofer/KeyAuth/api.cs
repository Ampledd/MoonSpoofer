using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;

namespace KeyAuth
{
	// Token: 0x02000004 RID: 4
	public class api
	{
		// Token: 0x06000008 RID: 8 RVA: 0x00002574 File Offset: 0x00000774
		public api(string name, string ownerid, string secret, string version)
		{
			bool flag = string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(ownerid) || string.IsNullOrWhiteSpace(secret) || string.IsNullOrWhiteSpace(version);
			if (flag)
			{
				api.error("Application not setup correctly.");
				Environment.Exit(0);
			}
			this.name = name;
			this.ownerid = ownerid;
			this.secret = secret;
			this.version = version;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002614 File Offset: 0x00000814
		public void init()
		{
			this.enckey = encryption.sha256(encryption.iv_key());
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("init"));
			nameValueCollection["ver"] = encryption.encrypt(this.version, this.secret, text);
			nameValueCollection["hash"] = api.checksum(Process.GetCurrentProcess().MainModule.FileName);
			nameValueCollection["enckey"] = encryption.encrypt(this.enckey, this.secret, text);
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			bool flag = text2 == "KeyAuth_Invalid";
			if (flag)
			{
				api.error("Application not found");
				Environment.Exit(0);
			}
			text2 = encryption.decrypt(text2, this.secret, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			bool success = response_structure.success;
			if (success)
			{
				this.load_app_data(response_structure.appinfo);
				this.sessionid = response_structure.sessionid;
				this.initzalized = true;
			}
			else
			{
				bool flag2 = response_structure.message == "invalidver";
				if (flag2)
				{
					this.app_data.downloadLink = response_structure.download;
				}
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000A RID: 10 RVA: 0x000027B8 File Offset: 0x000009B8
		public static bool IsDebugRelease
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000027CC File Offset: 0x000009CC
		public void Checkinit()
		{
			bool flag = !this.initzalized;
			if (flag)
			{
				bool isDebugRelease = api.IsDebugRelease;
				if (isDebugRelease)
				{
					api.error("Not initialized Check if KeyAuthApp.init() does exist");
				}
				else
				{
					api.error("Please initialize first");
				}
			}
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002810 File Offset: 0x00000A10
		public void register(string username, string pass, string key)
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("register"));
			nameValueCollection["username"] = encryption.encrypt(username, this.enckey, text);
			nameValueCollection["pass"] = encryption.encrypt(pass, this.enckey, text);
			nameValueCollection["key"] = encryption.encrypt(key, this.enckey, text);
			nameValueCollection["hwid"] = encryption.encrypt(value, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			bool success = response_structure.success;
			if (success)
			{
				this.load_user_data(response_structure.info);
			}
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002984 File Offset: 0x00000B84
		public void login(string username, string pass)
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("login"));
			nameValueCollection["username"] = encryption.encrypt(username, this.enckey, text);
			nameValueCollection["pass"] = encryption.encrypt(pass, this.enckey, text);
			nameValueCollection["hwid"] = encryption.encrypt(value, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			bool success = response_structure.success;
			if (success)
			{
				this.load_user_data(response_structure.info);
			}
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002ADC File Offset: 0x00000CDC
		public void upgrade(string username, string key)
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("upgrade"));
			nameValueCollection["username"] = encryption.encrypt(username, this.enckey, text);
			nameValueCollection["key"] = encryption.encrypt(key, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			response_structure.success = false;
			this.load_response_struct(response_structure);
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002C0C File Offset: 0x00000E0C
		public void license(string key)
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("license"));
			nameValueCollection["key"] = encryption.encrypt(key, this.enckey, text);
			nameValueCollection["hwid"] = encryption.encrypt(value, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			bool success = response_structure.success;
			if (success)
			{
				this.load_user_data(response_structure.info);
			}
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002D4C File Offset: 0x00000F4C
		public void check()
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("check"));
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure data = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(data);
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002E2C File Offset: 0x0000102C
		public void setvar(string var, string data)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("setvar"));
			nameValueCollection["var"] = encryption.encrypt(var, this.enckey, text);
			nameValueCollection["data"] = encryption.encrypt(data, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure data2 = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(data2);
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002F40 File Offset: 0x00001140
		public string getvar(string var)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("getvar"));
			nameValueCollection["var"] = encryption.encrypt(var, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			bool success = response_structure.success;
			string result;
			if (success)
			{
				result = response_structure.response;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00003058 File Offset: 0x00001258
		public void ban()
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("ban"));
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure data = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(data);
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00003138 File Offset: 0x00001338
		public string var(string varid)
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("var"));
			nameValueCollection["varid"] = encryption.encrypt(varid, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			bool success = response_structure.success;
			string result;
			if (success)
			{
				result = response_structure.message;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00003264 File Offset: 0x00001464
		public List<api.msg> chatget(string channelname)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("chatget"));
			nameValueCollection["channel"] = encryption.encrypt(channelname, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			bool success = response_structure.success;
			List<api.msg> result;
			if (success)
			{
				result = response_structure.messages;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x0000337C File Offset: 0x0000157C
		public bool chatsend(string msg, string channelname)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("chatsend"));
			nameValueCollection["message"] = encryption.encrypt(msg, this.enckey, text);
			nameValueCollection["channel"] = encryption.encrypt(channelname, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			return response_structure.success;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000034A8 File Offset: 0x000016A8
		public bool checkblack()
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("checkblacklist"));
			nameValueCollection["hwid"] = encryption.encrypt(value, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			return response_structure.success;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000035CC File Offset: 0x000017CC
		public string webhook(string webid, string param, string body = "", string conttype = "")
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("webhook"));
			nameValueCollection["webid"] = encryption.encrypt(webid, this.enckey, text);
			nameValueCollection["params"] = encryption.encrypt(param, this.enckey, text);
			nameValueCollection["body"] = encryption.encrypt(body, this.enckey, text);
			nameValueCollection["conttype"] = encryption.encrypt(conttype, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			bool success = response_structure.success;
			string result;
			if (success)
			{
				result = response_structure.response;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00003730 File Offset: 0x00001930
		public byte[] download(string fileid)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("file"));
			nameValueCollection["fileid"] = encryption.encrypt(fileid, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			bool success = response_structure.success;
			byte[] result;
			if (success)
			{
				result = encryption.str_to_byte_arr(response_structure.contents);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x0000384C File Offset: 0x00001A4C
		public void log(string message)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("log"));
			nameValueCollection["pcuser"] = encryption.encrypt(Environment.UserName, this.enckey, text);
			nameValueCollection["message"] = encryption.encrypt(message, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			api.req(post_data);
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00003940 File Offset: 0x00001B40
		public static string checksum(string filename)
		{
			string result;
			using (MD5 md = MD5.Create())
			{
				using (FileStream fileStream = File.OpenRead(filename))
				{
					byte[] value = md.ComputeHash(fileStream);
					result = BitConverter.ToString(value).Replace("-", "").ToLowerInvariant();
				}
			}
			return result;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000039C0 File Offset: 0x00001BC0
		public static void error(string message)
		{
			Process.Start(new ProcessStartInfo("cmd.exe", "/c start cmd /C \"color b && title Error && echo " + message + " && timeout /t 5\"")
			{
				CreateNoWindow = true,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				UseShellExecute = false
			});
			Environment.Exit(0);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00003A18 File Offset: 0x00001C18
		private static string req(NameValueCollection post_data)
		{
			string result;
			try
			{
				using (WebClient webClient = new WebClient())
				{
					byte[] bytes = webClient.UploadValues("https://keyauth.win/api/1.0/", post_data);
					result = Encoding.Default.GetString(bytes);
				}
			}
			catch (WebException ex)
			{
				HttpWebResponse httpWebResponse = (HttpWebResponse)ex.Response;
				HttpStatusCode statusCode = httpWebResponse.StatusCode;
				HttpStatusCode httpStatusCode = statusCode;
				if (httpStatusCode != (HttpStatusCode)429)
				{
					api.error("Connection failure. Please try again, or contact us for help.");
					Environment.Exit(0);
					result = "";
				}
				else
				{
					api.error("Zbyt szybko podejmujesz akcje, zwolnij troche!");
					Environment.Exit(0);
					result = "";
				}
			}
			return result;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00003ACC File Offset: 0x00001CCC
		private void load_app_data(api.app_data_structure data)
		{
			this.app_data.numUsers = data.numUsers;
			this.app_data.numOnlineUsers = data.numOnlineUsers;
			this.app_data.numKeys = data.numKeys;
			this.app_data.version = data.version;
			this.app_data.customerPanelLink = data.customerPanelLink;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00003B34 File Offset: 0x00001D34
		private void load_user_data(api.user_data_structure data)
		{
			this.user_data.username = data.username;
			this.user_data.ip = data.ip;
			this.user_data.hwid = data.hwid;
			this.user_data.createdate = data.createdate;
			this.user_data.lastlogin = data.lastlogin;
			this.user_data.subscriptions = data.subscriptions;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002082 File Offset: 0x00000282
		private void load_response_struct(api.response_structure data)
		{
			this.response.success = data.success;
			this.response.message = data.message;
		}

		// Token: 0x04000004 RID: 4
		public string name;

		// Token: 0x04000005 RID: 5
		public string ownerid;

		// Token: 0x04000006 RID: 6
		public string secret;

		// Token: 0x04000007 RID: 7
		public string version;

		// Token: 0x04000008 RID: 8
		private string sessionid;

		// Token: 0x04000009 RID: 9
		private string enckey;

		// Token: 0x0400000A RID: 10
		private bool initzalized;

		// Token: 0x0400000B RID: 11
		public api.app_data_class app_data = new api.app_data_class();

		// Token: 0x0400000C RID: 12
		public api.user_data_class user_data = new api.user_data_class();

		// Token: 0x0400000D RID: 13
		public api.response_class response = new api.response_class();

		// Token: 0x0400000E RID: 14
		private json_wrapper response_decoder = new json_wrapper(new api.response_structure());

		// Token: 0x02000005 RID: 5
		[DataContract]
		private class response_structure
		{
			// Token: 0x17000005 RID: 5
			// (get) Token: 0x06000021 RID: 33 RVA: 0x000020A9 File Offset: 0x000002A9
			// (set) Token: 0x06000022 RID: 34 RVA: 0x000020B1 File Offset: 0x000002B1
			[DataMember]
			public bool success { get; set; }

			// Token: 0x17000006 RID: 6
			// (get) Token: 0x06000023 RID: 35 RVA: 0x000020BA File Offset: 0x000002BA
			// (set) Token: 0x06000024 RID: 36 RVA: 0x000020C2 File Offset: 0x000002C2
			[DataMember]
			public string sessionid { get; set; }

			// Token: 0x17000007 RID: 7
			// (get) Token: 0x06000025 RID: 37 RVA: 0x000020CB File Offset: 0x000002CB
			// (set) Token: 0x06000026 RID: 38 RVA: 0x000020D3 File Offset: 0x000002D3
			[DataMember]
			public string contents { get; set; }

			// Token: 0x17000008 RID: 8
			// (get) Token: 0x06000027 RID: 39 RVA: 0x000020DC File Offset: 0x000002DC
			// (set) Token: 0x06000028 RID: 40 RVA: 0x000020E4 File Offset: 0x000002E4
			[DataMember]
			public string response { get; set; }

			// Token: 0x17000009 RID: 9
			// (get) Token: 0x06000029 RID: 41 RVA: 0x000020ED File Offset: 0x000002ED
			// (set) Token: 0x0600002A RID: 42 RVA: 0x000020F5 File Offset: 0x000002F5
			[DataMember]
			public string message { get; set; }

			// Token: 0x1700000A RID: 10
			// (get) Token: 0x0600002B RID: 43 RVA: 0x000020FE File Offset: 0x000002FE
			// (set) Token: 0x0600002C RID: 44 RVA: 0x00002106 File Offset: 0x00000306
			[DataMember]
			public string download { get; set; }

			// Token: 0x1700000B RID: 11
			// (get) Token: 0x0600002D RID: 45 RVA: 0x0000210F File Offset: 0x0000030F
			// (set) Token: 0x0600002E RID: 46 RVA: 0x00002117 File Offset: 0x00000317
			[DataMember(IsRequired = false, EmitDefaultValue = false)]
			public api.user_data_structure info { get; set; }

			// Token: 0x1700000C RID: 12
			// (get) Token: 0x0600002F RID: 47 RVA: 0x00002120 File Offset: 0x00000320
			// (set) Token: 0x06000030 RID: 48 RVA: 0x00002128 File Offset: 0x00000328
			[DataMember(IsRequired = false, EmitDefaultValue = false)]
			public api.app_data_structure appinfo { get; set; }

			// Token: 0x1700000D RID: 13
			// (get) Token: 0x06000031 RID: 49 RVA: 0x00002131 File Offset: 0x00000331
			// (set) Token: 0x06000032 RID: 50 RVA: 0x00002139 File Offset: 0x00000339
			[DataMember]
			public List<api.msg> messages { get; set; }
		}

		// Token: 0x02000006 RID: 6
		public class msg
		{
			// Token: 0x1700000E RID: 14
			// (get) Token: 0x06000034 RID: 52 RVA: 0x0000214B File Offset: 0x0000034B
			// (set) Token: 0x06000035 RID: 53 RVA: 0x00002153 File Offset: 0x00000353
			public string message { get; set; }

			// Token: 0x1700000F RID: 15
			// (get) Token: 0x06000036 RID: 54 RVA: 0x0000215C File Offset: 0x0000035C
			// (set) Token: 0x06000037 RID: 55 RVA: 0x00002164 File Offset: 0x00000364
			public string author { get; set; }

			// Token: 0x17000010 RID: 16
			// (get) Token: 0x06000038 RID: 56 RVA: 0x0000216D File Offset: 0x0000036D
			// (set) Token: 0x06000039 RID: 57 RVA: 0x00002175 File Offset: 0x00000375
			public string timestamp { get; set; }
		}

		// Token: 0x02000007 RID: 7
		[DataContract]
		private class user_data_structure
		{
			// Token: 0x17000011 RID: 17
			// (get) Token: 0x0600003B RID: 59 RVA: 0x0000217E File Offset: 0x0000037E
			// (set) Token: 0x0600003C RID: 60 RVA: 0x00002186 File Offset: 0x00000386
			[DataMember]
			public string username { get; set; }

			// Token: 0x17000012 RID: 18
			// (get) Token: 0x0600003D RID: 61 RVA: 0x0000218F File Offset: 0x0000038F
			// (set) Token: 0x0600003E RID: 62 RVA: 0x00002197 File Offset: 0x00000397
			[DataMember]
			public string ip { get; set; }

			// Token: 0x17000013 RID: 19
			// (get) Token: 0x0600003F RID: 63 RVA: 0x000021A0 File Offset: 0x000003A0
			// (set) Token: 0x06000040 RID: 64 RVA: 0x000021A8 File Offset: 0x000003A8
			[DataMember]
			public string hwid { get; set; }

			// Token: 0x17000014 RID: 20
			// (get) Token: 0x06000041 RID: 65 RVA: 0x000021B1 File Offset: 0x000003B1
			// (set) Token: 0x06000042 RID: 66 RVA: 0x000021B9 File Offset: 0x000003B9
			[DataMember]
			public string createdate { get; set; }

			// Token: 0x17000015 RID: 21
			// (get) Token: 0x06000043 RID: 67 RVA: 0x000021C2 File Offset: 0x000003C2
			// (set) Token: 0x06000044 RID: 68 RVA: 0x000021CA File Offset: 0x000003CA
			[DataMember]
			public string lastlogin { get; set; }

			// Token: 0x17000016 RID: 22
			// (get) Token: 0x06000045 RID: 69 RVA: 0x000021D3 File Offset: 0x000003D3
			// (set) Token: 0x06000046 RID: 70 RVA: 0x000021DB File Offset: 0x000003DB
			[DataMember]
			public List<api.Data> subscriptions { get; set; }
		}

		// Token: 0x02000008 RID: 8
		[DataContract]
		private class app_data_structure
		{
			// Token: 0x17000017 RID: 23
			// (get) Token: 0x06000048 RID: 72 RVA: 0x000021E4 File Offset: 0x000003E4
			// (set) Token: 0x06000049 RID: 73 RVA: 0x000021EC File Offset: 0x000003EC
			[DataMember]
			public string numUsers { get; set; }

			// Token: 0x17000018 RID: 24
			// (get) Token: 0x0600004A RID: 74 RVA: 0x000021F5 File Offset: 0x000003F5
			// (set) Token: 0x0600004B RID: 75 RVA: 0x000021FD File Offset: 0x000003FD
			[DataMember]
			public string numOnlineUsers { get; set; }

			// Token: 0x17000019 RID: 25
			// (get) Token: 0x0600004C RID: 76 RVA: 0x00002206 File Offset: 0x00000406
			// (set) Token: 0x0600004D RID: 77 RVA: 0x0000220E File Offset: 0x0000040E
			[DataMember]
			public string numKeys { get; set; }

			// Token: 0x1700001A RID: 26
			// (get) Token: 0x0600004E RID: 78 RVA: 0x00002217 File Offset: 0x00000417
			// (set) Token: 0x0600004F RID: 79 RVA: 0x0000221F File Offset: 0x0000041F
			[DataMember]
			public string version { get; set; }

			// Token: 0x1700001B RID: 27
			// (get) Token: 0x06000050 RID: 80 RVA: 0x00002228 File Offset: 0x00000428
			// (set) Token: 0x06000051 RID: 81 RVA: 0x00002230 File Offset: 0x00000430
			[DataMember]
			public string customerPanelLink { get; set; }

			// Token: 0x1700001C RID: 28
			// (get) Token: 0x06000052 RID: 82 RVA: 0x00002239 File Offset: 0x00000439
			// (set) Token: 0x06000053 RID: 83 RVA: 0x00002241 File Offset: 0x00000441
			[DataMember]
			public string downloadLink { get; set; }
		}

		// Token: 0x02000009 RID: 9
		public class app_data_class
		{
			// Token: 0x1700001D RID: 29
			// (get) Token: 0x06000055 RID: 85 RVA: 0x0000224A File Offset: 0x0000044A
			// (set) Token: 0x06000056 RID: 86 RVA: 0x00002252 File Offset: 0x00000452
			public string numUsers { get; set; }

			// Token: 0x1700001E RID: 30
			// (get) Token: 0x06000057 RID: 87 RVA: 0x0000225B File Offset: 0x0000045B
			// (set) Token: 0x06000058 RID: 88 RVA: 0x00002263 File Offset: 0x00000463
			public string numOnlineUsers { get; set; }

			// Token: 0x1700001F RID: 31
			// (get) Token: 0x06000059 RID: 89 RVA: 0x0000226C File Offset: 0x0000046C
			// (set) Token: 0x0600005A RID: 90 RVA: 0x00002274 File Offset: 0x00000474
			public string numKeys { get; set; }

			// Token: 0x17000020 RID: 32
			// (get) Token: 0x0600005B RID: 91 RVA: 0x0000227D File Offset: 0x0000047D
			// (set) Token: 0x0600005C RID: 92 RVA: 0x00002285 File Offset: 0x00000485
			public string version { get; set; }

			// Token: 0x17000021 RID: 33
			// (get) Token: 0x0600005D RID: 93 RVA: 0x0000228E File Offset: 0x0000048E
			// (set) Token: 0x0600005E RID: 94 RVA: 0x00002296 File Offset: 0x00000496
			public string customerPanelLink { get; set; }

			// Token: 0x17000022 RID: 34
			// (get) Token: 0x0600005F RID: 95 RVA: 0x0000229F File Offset: 0x0000049F
			// (set) Token: 0x06000060 RID: 96 RVA: 0x000022A7 File Offset: 0x000004A7
			public string downloadLink { get; set; }
		}

		// Token: 0x0200000A RID: 10
		public class user_data_class
		{
			// Token: 0x17000023 RID: 35
			// (get) Token: 0x06000062 RID: 98 RVA: 0x000022B0 File Offset: 0x000004B0
			// (set) Token: 0x06000063 RID: 99 RVA: 0x000022B8 File Offset: 0x000004B8
			public string username { get; set; }

			// Token: 0x17000024 RID: 36
			// (get) Token: 0x06000064 RID: 100 RVA: 0x000022C1 File Offset: 0x000004C1
			// (set) Token: 0x06000065 RID: 101 RVA: 0x000022C9 File Offset: 0x000004C9
			public string ip { get; set; }

			// Token: 0x17000025 RID: 37
			// (get) Token: 0x06000066 RID: 102 RVA: 0x000022D2 File Offset: 0x000004D2
			// (set) Token: 0x06000067 RID: 103 RVA: 0x000022DA File Offset: 0x000004DA
			public string hwid { get; set; }

			// Token: 0x17000026 RID: 38
			// (get) Token: 0x06000068 RID: 104 RVA: 0x000022E3 File Offset: 0x000004E3
			// (set) Token: 0x06000069 RID: 105 RVA: 0x000022EB File Offset: 0x000004EB
			public string createdate { get; set; }

			// Token: 0x17000027 RID: 39
			// (get) Token: 0x0600006A RID: 106 RVA: 0x000022F4 File Offset: 0x000004F4
			// (set) Token: 0x0600006B RID: 107 RVA: 0x000022FC File Offset: 0x000004FC
			public string lastlogin { get; set; }

			// Token: 0x17000028 RID: 40
			// (get) Token: 0x0600006C RID: 108 RVA: 0x00002305 File Offset: 0x00000505
			// (set) Token: 0x0600006D RID: 109 RVA: 0x0000230D File Offset: 0x0000050D
			public List<api.Data> subscriptions { get; set; }
		}

		// Token: 0x0200000B RID: 11
		public class Data
		{
			// Token: 0x17000029 RID: 41
			// (get) Token: 0x0600006F RID: 111 RVA: 0x00002316 File Offset: 0x00000516
			// (set) Token: 0x06000070 RID: 112 RVA: 0x0000231E File Offset: 0x0000051E
			public string subscription { get; set; }

			// Token: 0x1700002A RID: 42
			// (get) Token: 0x06000071 RID: 113 RVA: 0x00002327 File Offset: 0x00000527
			// (set) Token: 0x06000072 RID: 114 RVA: 0x0000232F File Offset: 0x0000052F
			public string expiry { get; set; }

			// Token: 0x1700002B RID: 43
			// (get) Token: 0x06000073 RID: 115 RVA: 0x00002338 File Offset: 0x00000538
			// (set) Token: 0x06000074 RID: 116 RVA: 0x00002340 File Offset: 0x00000540
			public string timeleft { get; set; }
		}

		// Token: 0x0200000C RID: 12
		public class response_class
		{
			// Token: 0x1700002C RID: 44
			// (get) Token: 0x06000076 RID: 118 RVA: 0x00002349 File Offset: 0x00000549
			// (set) Token: 0x06000077 RID: 119 RVA: 0x00002351 File Offset: 0x00000551
			public bool success { get; set; }

			// Token: 0x1700002D RID: 45
			// (get) Token: 0x06000078 RID: 120 RVA: 0x0000235A File Offset: 0x0000055A
			// (set) Token: 0x06000079 RID: 121 RVA: 0x00002362 File Offset: 0x00000562
			public string message { get; set; }
		}
	}
}
