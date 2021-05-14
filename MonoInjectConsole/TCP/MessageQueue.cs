using System.Collections.Generic;

namespace MonoInjectConsole {
	public class MessageQueue<T> {
		private Queue<T> _queue = new Queue<T>();

		public T Dequeue() {
			if (IsEmpty()) {
				return default;
			}
			lock (_queue) {
				return _queue.Dequeue();
			}
		}

		public void Enqueue(T item) {
			lock (_queue) {
				_queue.Enqueue(item);
			}
		}

		public bool IsEmpty() {
			lock (_queue) {
				return _queue.Count == 0;
			}
		}
	}
}
