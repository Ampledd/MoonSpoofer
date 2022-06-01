namespace KeyAuth
{
	// Token: 0x02000010 RID: 16
	public partial class Login : global::System.Windows.Forms.Form
	{
		// Token: 0x060000E2 RID: 226 RVA: 0x0000BF94 File Offset: 0x0000A194
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			bool flag2 = flag;
			if (flag2)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x0000BFD0 File Offset: 0x0000A1D0
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::KeyAuth.Login));
			this.siticoneControlBox1 = new global::Siticone.UI.WinForms.SiticoneControlBox();
			this.siticoneControlBox2 = new global::Siticone.UI.WinForms.SiticoneControlBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.guna2BorderlessForm1 = new global::Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
			this.username = new global::System.Windows.Forms.TextBox();
			this.textBox1 = new global::System.Windows.Forms.TextBox();
			this.textBox4 = new global::System.Windows.Forms.TextBox();
			this.guna2Button1 = new global::Guna.UI2.WinForms.Guna2Button();
			this.guna2Button2 = new global::Guna.UI2.WinForms.Guna2Button();
			this.guna2Panel1 = new global::Guna.UI2.WinForms.Guna2Panel();
			this.timer1 = new global::System.Windows.Forms.Timer(this.components);
			this.guna2Panel1.SuspendLayout();
			base.SuspendLayout();
			this.siticoneControlBox1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.siticoneControlBox1.BackColor = global::System.Drawing.Color.Transparent;
			this.siticoneControlBox1.BorderRadius = 5;
			this.siticoneControlBox1.FillColor = global::System.Drawing.Color.Transparent;
			this.siticoneControlBox1.HoveredState.FillColor = global::System.Drawing.Color.FromArgb(232, 17, 35);
			this.siticoneControlBox1.HoveredState.IconColor = global::System.Drawing.Color.White;
			this.siticoneControlBox1.HoveredState.Parent = this.siticoneControlBox1;
			this.siticoneControlBox1.IconColor = global::System.Drawing.Color.White;
			this.siticoneControlBox1.Location = new global::System.Drawing.Point(717, 5);
			this.siticoneControlBox1.Name = "siticoneControlBox1";
			this.siticoneControlBox1.ShadowDecoration.Parent = this.siticoneControlBox1;
			this.siticoneControlBox1.Size = new global::System.Drawing.Size(45, 29);
			this.siticoneControlBox1.TabIndex = 1;
			this.siticoneControlBox1.Click += new global::System.EventHandler(this.siticoneControlBox1_Click);
			this.siticoneControlBox2.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.siticoneControlBox2.BackColor = global::System.Drawing.Color.Transparent;
			this.siticoneControlBox2.BorderColor = global::System.Drawing.Color.Transparent;
			this.siticoneControlBox2.BorderRadius = 10;
			this.siticoneControlBox2.ControlBoxType = global::Siticone.UI.WinForms.Enums.ControlBoxType.MinimizeBox;
			this.siticoneControlBox2.FillColor = global::System.Drawing.Color.Transparent;
			this.siticoneControlBox2.HoveredState.FillColor = global::System.Drawing.Color.FromArgb(255, 255, 255);
			this.siticoneControlBox2.HoveredState.IconColor = global::System.Drawing.Color.FromArgb(0, 0, 0);
			this.siticoneControlBox2.HoveredState.Parent = this.siticoneControlBox2;
			this.siticoneControlBox2.IconColor = global::System.Drawing.Color.White;
			this.siticoneControlBox2.Location = new global::System.Drawing.Point(666, 5);
			this.siticoneControlBox2.Name = "siticoneControlBox2";
			this.siticoneControlBox2.ShadowDecoration.Parent = this.siticoneControlBox2;
			this.siticoneControlBox2.Size = new global::System.Drawing.Size(45, 29);
			this.siticoneControlBox2.TabIndex = 2;
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Segoe UI Light", 10f);
			this.label1.ForeColor = global::System.Drawing.Color.White;
			this.label1.Location = new global::System.Drawing.Point(-5, 136);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(0, 19);
			this.label1.TabIndex = 22;
			this.label2.AutoSize = true;
			this.label2.BackColor = global::System.Drawing.Color.FromArgb(9, 9, 9);
			this.label2.Font = new global::System.Drawing.Font("Segoe UI Semibold", 10.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.SystemColors.ButtonFace;
			this.label2.Location = new global::System.Drawing.Point(8, 11);
			this.label2.Margin = new global::System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(125, 19);
			this.label2.TabIndex = 27;
			this.label2.Text = "Blue Spoofer login";
			this.guna2BorderlessForm1.AnimationType = global::Guna.UI2.WinForms.Guna2BorderlessForm.AnimateWindowType.AW_CENTER;
			this.guna2BorderlessForm1.BorderRadius = 30;
			this.guna2BorderlessForm1.ContainerControl = this;
			this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6;
			this.guna2BorderlessForm1.DragStartTransparencyValue = 0.3;
			this.guna2BorderlessForm1.ResizeForm = false;
			this.guna2BorderlessForm1.TransparentWhileDrag = true;
			this.username.BackColor = global::System.Drawing.Color.FromArgb(16, 16, 19);
			this.username.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.username.Font = new global::System.Drawing.Font("Arial", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 238);
			this.username.ForeColor = global::System.Drawing.Color.FromArgb(116, 73, 255);
			this.username.Location = new global::System.Drawing.Point(99, 206);
			this.username.Multiline = true;
			this.username.Name = "username";
			this.username.Size = new global::System.Drawing.Size(190, 20);
			this.username.TabIndex = 35;
			this.username.TextChanged += new global::System.EventHandler(this.textBox1_TextChanged);
			this.textBox1.BackColor = global::System.Drawing.Color.FromArgb(16, 16, 19);
			this.textBox1.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.textBox1.Font = new global::System.Drawing.Font("Arial", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 238);
			this.textBox1.ForeColor = global::System.Drawing.Color.FromArgb(116, 73, 255);
			this.textBox1.Location = new global::System.Drawing.Point(103, 255);
			this.textBox1.Name = "textBox1";
			this.textBox1.PasswordChar = '*';
			this.textBox1.Size = new global::System.Drawing.Size(187, 18);
			this.textBox1.TabIndex = 36;
			this.textBox1.UseSystemPasswordChar = true;
			this.textBox4.BackColor = global::System.Drawing.Color.FromArgb(16, 16, 19);
			this.textBox4.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.textBox4.Font = new global::System.Drawing.Font("Arial", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 238);
			this.textBox4.ForeColor = global::System.Drawing.Color.FromArgb(151, 99, 255);
			this.textBox4.Location = new global::System.Drawing.Point(56, 46);
			this.textBox4.Name = "textBox4";
			this.textBox4.PasswordChar = '*';
			this.textBox4.Size = new global::System.Drawing.Size(203, 18);
			this.textBox4.TabIndex = 42;
			this.textBox4.UseSystemPasswordChar = true;
			this.guna2Button1.Animated = true;
			this.guna2Button1.BackColor = global::System.Drawing.Color.Transparent;
			this.guna2Button1.BorderColor = global::System.Drawing.Color.Transparent;
			this.guna2Button1.BorderRadius = 9;
			this.guna2Button1.DisabledState.BorderColor = global::System.Drawing.Color.DarkGray;
			this.guna2Button1.DisabledState.CustomBorderColor = global::System.Drawing.Color.DarkGray;
			this.guna2Button1.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(169, 169, 169);
			this.guna2Button1.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(141, 141, 141);
			this.guna2Button1.FillColor = global::System.Drawing.Color.Transparent;
			this.guna2Button1.Font = new global::System.Drawing.Font("Arial", 9.75f);
			this.guna2Button1.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button1.Location = new global::System.Drawing.Point(67, 379);
			this.guna2Button1.Name = "guna2Button1";
			this.guna2Button1.Size = new global::System.Drawing.Size(290, 36);
			this.guna2Button1.TabIndex = 43;
			this.guna2Button1.Click += new global::System.EventHandler(this.guna2Button1_Click_1);
			this.guna2Button2.Animated = true;
			this.guna2Button2.BackColor = global::System.Drawing.Color.Transparent;
			this.guna2Button2.BorderColor = global::System.Drawing.Color.Transparent;
			this.guna2Button2.BorderRadius = 9;
			this.guna2Button2.DisabledState.BorderColor = global::System.Drawing.Color.DarkGray;
			this.guna2Button2.DisabledState.CustomBorderColor = global::System.Drawing.Color.DarkGray;
			this.guna2Button2.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(169, 169, 169);
			this.guna2Button2.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(141, 141, 141);
			this.guna2Button2.FillColor = global::System.Drawing.Color.Transparent;
			this.guna2Button2.Font = new global::System.Drawing.Font("Arial", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 238);
			this.guna2Button2.ForeColor = global::System.Drawing.Color.White;
			this.guna2Button2.Location = new global::System.Drawing.Point(67, 334);
			this.guna2Button2.Name = "guna2Button2";
			this.guna2Button2.Size = new global::System.Drawing.Size(290, 36);
			this.guna2Button2.TabIndex = 44;
			this.guna2Button2.Click += new global::System.EventHandler(this.guna2Button2_Click);
			this.guna2Panel1.BackColor = global::System.Drawing.Color.Transparent;
			this.guna2Panel1.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("guna2Panel1.BackgroundImage");
			this.guna2Panel1.Controls.Add(this.textBox4);
			this.guna2Panel1.Location = new global::System.Drawing.Point(440, 191);
			this.guna2Panel1.Name = "guna2Panel1";
			this.guna2Panel1.Size = new global::System.Drawing.Size(300, 94);
			this.guna2Panel1.TabIndex = 45;
			this.guna2Panel1.Visible = false;
			this.timer1.Enabled = true;
			this.timer1.Interval = 1000;
			this.timer1.Tick += new global::System.EventHandler(this.timer1_Tick);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.AutoValidate = global::System.Windows.Forms.AutoValidate.Disable;
			this.BackColor = global::System.Drawing.Color.FromArgb(35, 39, 42);
			this.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("$this.BackgroundImage");
			this.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			base.ClientSize = new global::System.Drawing.Size(769, 479);
			base.Controls.Add(this.guna2Panel1);
			base.Controls.Add(this.guna2Button2);
			base.Controls.Add(this.guna2Button1);
			base.Controls.Add(this.textBox1);
			base.Controls.Add(this.username);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.siticoneControlBox2);
			base.Controls.Add(this.siticoneControlBox1);
			this.DoubleBuffered = true;
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "Login";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Loader";
			base.TransparencyKey = global::System.Drawing.Color.Maroon;
			base.Load += new global::System.EventHandler(this.Login_Load);
			this.guna2Panel1.ResumeLayout(false);
			this.guna2Panel1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000085 RID: 133
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000086 RID: 134
		private global::Siticone.UI.WinForms.SiticoneControlBox siticoneControlBox1;

		// Token: 0x04000087 RID: 135
		private global::Siticone.UI.WinForms.SiticoneControlBox siticoneControlBox2;

		// Token: 0x04000088 RID: 136
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000089 RID: 137
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400008A RID: 138
		private global::Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;

		// Token: 0x0400008B RID: 139
		private global::System.Windows.Forms.TextBox username;

		// Token: 0x0400008C RID: 140
		private global::System.Windows.Forms.TextBox textBox1;

		// Token: 0x0400008D RID: 141
		private global::System.Windows.Forms.TextBox textBox4;

		// Token: 0x0400008E RID: 142
		private global::Guna.UI2.WinForms.Guna2Button guna2Button2;

		// Token: 0x0400008F RID: 143
		private global::Guna.UI2.WinForms.Guna2Button guna2Button1;

		// Token: 0x04000090 RID: 144
		private global::Guna.UI2.WinForms.Guna2Panel guna2Panel1;

		// Token: 0x04000091 RID: 145
		private global::System.Windows.Forms.Timer timer1;
	}
}
