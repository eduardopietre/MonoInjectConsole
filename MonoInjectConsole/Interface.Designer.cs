namespace MonoInjectConsole {
	partial class Interface {
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.tfCommand = new System.Windows.Forms.TextBox();
			this.tbConsole = new System.Windows.Forms.TextBox();
			this.tbDebug = new System.Windows.Forms.TextBox();
			this.tbInject = new System.Windows.Forms.TextBox();
			this.btnInject = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.lblDebug = new System.Windows.Forms.Label();
			this.lblShell = new System.Windows.Forms.Label();
			this.lblInjection = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// tfCommand
			// 
			this.tfCommand.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.tfCommand.Location = new System.Drawing.Point(590, 541);
			this.tfCommand.Name = "tfCommand";
			this.tfCommand.Size = new System.Drawing.Size(575, 26);
			this.tfCommand.TabIndex = 0;
			this.tfCommand.TextChanged += new System.EventHandler(this.TextFieldCommand_TextChanged);
			this.tfCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnTBKeyDownHandler);
			// 
			// tbConsole
			// 
			this.tbConsole.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.tbConsole.Location = new System.Drawing.Point(590, 31);
			this.tbConsole.Multiline = true;
			this.tbConsole.Name = "tbConsole";
			this.tbConsole.ReadOnly = true;
			this.tbConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbConsole.Size = new System.Drawing.Size(575, 491);
			this.tbConsole.TabIndex = 3;
			this.tbConsole.TabStop = false;
			// 
			// tbDebug
			// 
			this.tbDebug.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.tbDebug.Location = new System.Drawing.Point(12, 29);
			this.tbDebug.Multiline = true;
			this.tbDebug.Name = "tbDebug";
			this.tbDebug.ReadOnly = true;
			this.tbDebug.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbDebug.Size = new System.Drawing.Size(560, 237);
			this.tbDebug.TabIndex = 4;
			// 
			// tbInject
			// 
			this.tbInject.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.tbInject.Location = new System.Drawing.Point(12, 305);
			this.tbInject.Multiline = true;
			this.tbInject.Name = "tbInject";
			this.tbInject.ReadOnly = true;
			this.tbInject.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbInject.Size = new System.Drawing.Size(424, 262);
			this.tbInject.TabIndex = 5;
			// 
			// btnInject
			// 
			this.btnInject.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.btnInject.Location = new System.Drawing.Point(458, 361);
			this.btnInject.Name = "btnInject";
			this.btnInject.Size = new System.Drawing.Size(114, 41);
			this.btnInject.TabIndex = 7;
			this.btnInject.Text = "Inject";
			this.btnInject.UseVisualStyleBackColor = true;
			this.btnInject.Click += new System.EventHandler(this.Inject);
			// 
			// btnClear
			// 
			this.btnClear.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.btnClear.Location = new System.Drawing.Point(458, 451);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(114, 41);
			this.btnClear.TabIndex = 7;
			this.btnClear.Text = "Clear";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.Clear);
			// 
			// lblDebug
			// 
			this.lblDebug.AutoSize = true;
			this.lblDebug.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lblDebug.Location = new System.Drawing.Point(12, 9);
			this.lblDebug.Name = "lblDebug";
			this.lblDebug.Size = new System.Drawing.Size(103, 19);
			this.lblDebug.TabIndex = 8;
			this.lblDebug.Text = "Debug Console";
			this.lblDebug.Click += new System.EventHandler(this.label1_Click);
			// 
			// lblShell
			// 
			this.lblShell.AutoSize = true;
			this.lblShell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lblShell.Location = new System.Drawing.Point(590, 9);
			this.lblShell.Name = "lblShell";
			this.lblShell.Size = new System.Drawing.Size(38, 19);
			this.lblShell.TabIndex = 8;
			this.lblShell.Text = "Shell";
			this.lblShell.Click += new System.EventHandler(this.label1_Click);
			// 
			// lblInjection
			// 
			this.lblInjection.AutoSize = true;
			this.lblInjection.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lblInjection.Location = new System.Drawing.Point(12, 283);
			this.lblInjection.Name = "lblInjection";
			this.lblInjection.Size = new System.Drawing.Size(61, 19);
			this.lblInjection.TabIndex = 8;
			this.lblInjection.Text = "Injection";
			this.lblInjection.Click += new System.EventHandler(this.label1_Click);
			// 
			// Interface
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1177, 583);
			this.Controls.Add(this.lblInjection);
			this.Controls.Add(this.lblShell);
			this.Controls.Add(this.lblDebug);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.btnInject);
			this.Controls.Add(this.tbInject);
			this.Controls.Add(this.tbDebug);
			this.Controls.Add(this.tbConsole);
			this.Controls.Add(this.tfCommand);
			this.Name = "Interface";
			this.Text = "MonoInjectConsole";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Interface_Closed);
			this.Load += new System.EventHandler(this.Interface_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tfCommand;
		private System.Windows.Forms.TextBox tbConsole;
		private System.Windows.Forms.TextBox tbDebug;
		private System.Windows.Forms.TextBox tbInject;
		private System.Windows.Forms.Button btnInject;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Label lblDebug;
		private System.Windows.Forms.Label lblShell;
		private System.Windows.Forms.Label lblInjection;
	}
}

