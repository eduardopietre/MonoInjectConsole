using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MonoInjectConsole {
	public class TCPReceiver {
		public static void StartListening() {
			IPHostEntry ipHostInfo = Dns.GetHostEntry(TCPDefinitions.IP);
			IPAddress ipAddress = ipHostInfo.AddressList[0];
			IPEndPoint localEndPoint = new IPEndPoint(ipAddress, TCPDefinitions.PORT_DEBUG);

			Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);  // Create a TCP/IP socket.  

			try {
				listener.Bind(localEndPoint);
				listener.Listen(1);

				while (true) {
					Socket handler = listener.Accept();

					TCPStateObject state = new TCPStateObject {
						workSocket = handler
					};
					handler.BeginReceive(state.buffer, 0, TCPStateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
				}
			} catch (Exception e) {
				Console.WriteLine(e);
			}
		}

		public static void ReadCallback(IAsyncResult ar) {
			string content = string.Empty;
			TCPStateObject state = (TCPStateObject) ar.AsyncState;
			Socket handler = state.workSocket;

			int bytesRead = handler.EndReceive(ar);
			if (bytesRead > 0) {
				state.sb.Append(Encoding.UTF8.GetString(state.buffer, 0, bytesRead));  
				content = state.sb.ToString();
				if (content.IndexOf(TCPDefinitions.EOF) > -1) {
					string message = content.Replace(TCPDefinitions.EOF, "");

					Interface.instance.UpdateDebug(message);
				} else {
					handler.BeginReceive(state.buffer, 0, TCPStateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
				}
			}
		}
	}
}
