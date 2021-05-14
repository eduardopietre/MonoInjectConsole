using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MonoInjectConsole {
	public class TCPShell {
		public static void StartLoop() {
			while (true) {
				if (!Interface.sendQueue.IsEmpty()) {
					SendReceive(Interface.sendQueue.Dequeue());
				}
			}
		}

		public static void SendReceive(string text) {
			Socket socket = null;
			IPHostEntry hostEntry = Dns.GetHostEntry(TCPDefinitions.IP);

			// Loop through the AddressList to obtain the supported AddressFamily. This is to avoid
			// an exception that occurs when the host IP Address is not compatible with the address family
			// (typical in the IPv6 case).
			foreach (IPAddress address in hostEntry.AddressList) {
				IPEndPoint endPoint = new IPEndPoint(address, TCPDefinitions.PORT_SHELL);
				Socket tempSocket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

				tempSocket.Connect(endPoint);

				if (tempSocket.Connected) {
					socket = tempSocket;
					break;
				}
			}

			byte[] data = Encoding.UTF8.GetBytes(text + TCPDefinitions.EOF); // Data must end with <EOF>
			socket.Send(data, 0, data.Length, 0);

			TCPStateObject state = new TCPStateObject {
				workSocket = socket
			};
			socket.BeginReceive(state.buffer, 0, TCPStateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
		}

		public static void ReceiveCallback(IAsyncResult ar) {
			string content = string.Empty;
			TCPStateObject state = (TCPStateObject) ar.AsyncState;
			Socket handler = state.workSocket;

			int bytesRead = handler.EndReceive(ar);
			if (bytesRead > 0) {
				state.sb.Append(Encoding.UTF8.GetString(state.buffer, 0, bytesRead));
				content = state.sb.ToString();
				if (content.IndexOf(TCPDefinitions.EOF) > -1) {
					string message = content.Replace(TCPDefinitions.EOF, "");
					Interface.instance.UpdateShell(message);

					handler.Close();
				} else {
					handler.BeginReceive(state.buffer, 0, TCPStateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
				}
			}
		}
	}
}
