using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace MonoInjectConsole {
	public partial class Interface : Form {

		public static Interface instance;
		private Thread thDebug;
		private Thread thConsole;

		public static MessageQueue<string> sendQueue = new MessageQueue<string>();
		private List<string> commandHistory = new List<string>();
		private int historyIndex = 0;  // Index from the end. 1 = commandHistory.count - 1

		public Interface() {
			InitializeComponent();
			instance = this;

			thDebug = new Thread(TCPReceiver.StartListening) {
				IsBackground = true
			};
			thConsole = new Thread(TCPShell.StartLoop) {
				IsBackground = true
			};

			thDebug.Start();
			thConsole.Start();
		}

		private void TextFieldCommand_TextChanged(object sender, EventArgs e) {
			// pass
		}

		private void label1_Click(object sender, EventArgs e) {
			// pass
		}

		private void Interface_Load(object sender, EventArgs e) {
			// Before it apears
		}

		private void OnTBKeyDownHandler(object sender, KeyEventArgs eventArgs) {
			Keys key = eventArgs.KeyCode;

			switch (key) {
				case Keys.Return:
					SendCommand();
					break;
				case Keys.Up:
					HistoryUp();
					break;
				case Keys.Down:
					HistoryDown();
					break;
				default:
					break;
			}

			switch (key) {
				case Keys.Return:
				case Keys.Up:
				case Keys.Down:
					eventArgs.Handled = true;
					eventArgs.SuppressKeyPress = true;
					break;
				default:
					break;
			}
		}

		private void CommandFieldFocus() {
			tfCommand.Enabled = true;
			tfCommand.Focus();
			tfCommand.Select(tfCommand.Text.Length, 0);
		}

		private void SendCommand() {
			string command = tfCommand.Text.Trim();
			tfCommand.Text = "";
			if (!string.IsNullOrEmpty(command)) {
				sendQueue.Enqueue(command);
				tbConsole.AppendText("\r\n" + CurrentTime() + " $ " + command);

				commandHistory.Add(command);
				historyIndex = 0;
				tfCommand.Enabled = false;
			}
		}

		private void HistoryUp() {
			int count = commandHistory.Count;
			if (count > 0) {
				if (historyIndex < count) {
					historyIndex += 1;
				}
				string history = commandHistory[count - historyIndex];
				tfCommand.Text = history;
				CommandFieldFocus();
			}
		}

		private void HistoryDown() {
			int count = commandHistory.Count;
			if (count > 0) {
				if (historyIndex > 1) {  // Not at the end
					historyIndex -= 1;
					string history = commandHistory[count - historyIndex];
					tfCommand.Text = history;
					CommandFieldFocus();
				}
			}
		}


		private void Clear(object sender, EventArgs e) {
			tfCommand.Text = "";
			tbConsole.Text = "";
			tbDebug.Text = "";
			// tbInject.Text = "";
			tfCommand.Enabled = true;
			tfCommand.Focus();
		}

		private void Inject(object sender, EventArgs e) {
			try {
				ProcessStartInfo processInfo = new ProcessStartInfo {
					UseShellExecute = false,
					RedirectStandardOutput = true,
					RedirectStandardError = true,
					CreateNoWindow = true,
					FileName = "inject.bat"
				};

				Process process = new Process {
					StartInfo = processInfo
				};

				process.OutputDataReceived += (sender, args) => {
					if (args != null && args.Data != null && args.Data.Trim().Length > 0) {
						UpdateInject(args.Data);
					}
				};

				process.ErrorDataReceived += (sender, args) => {
					if (args != null && args.Data != null && args.Data.Trim().Length > 0) {
						UpdateInject("[ERROR]: " + args.Data);
					}
				};

				process.Start();
				process.BeginOutputReadLine();
				process.BeginErrorReadLine();
				// process.WaitForExit();
				btnInject.Enabled = false;
			} catch (Exception exc) {
				UpdateInject("[EXCEPTION]: " + exc.ToString());
			}
		}

		public void UpdateDebug(string newText) {
			Invoke(new Action(() => 
				tbDebug.AppendText("\r\n" + CurrentTime() + " > " + newText)
			));
		}

		public void UpdateInject(string newText) {
			Invoke(new Action(() =>
				tbInject.AppendText("\r\n" + CurrentTime() + " > " + newText)
			));
		}

		public void UpdateShell(string newText) {
			Invoke(new Action(() => {
				tbConsole.AppendText("\r\n" + CurrentTime() + " > " + newText);
				CommandFieldFocus();
			}));
		}

		public static string CurrentTime() {
			return "(" + DateTime.Now.ToString("HH:mm:ss") + "s)";
		}

		private void Interface_Closed(object sender, FormClosedEventArgs e) {
			Application.Exit();
		}
	}
}
