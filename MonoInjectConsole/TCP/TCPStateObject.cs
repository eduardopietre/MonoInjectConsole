using System.Net.Sockets;
using System.Text;

namespace MonoInjectConsole {
	public class TCPStateObject {
		public const int BufferSize = 4096;
		public byte[] buffer = new byte[BufferSize];
		public StringBuilder sb = new StringBuilder();
		public Socket workSocket = null;
	}
}
