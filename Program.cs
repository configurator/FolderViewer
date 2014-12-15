using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderViewer {
	class Program {
		static void Main(string[] args) {
			var watcher = new FileSystemWatcher(Environment.CurrentDirectory) {
				IncludeSubdirectories = true,
				EnableRaisingEvents = true
			};
			watcher.Changed += WatcherEvent;
			watcher.Created += WatcherEvent;
			watcher.Deleted += WatcherEvent;
			watcher.Renamed += WatcherEvent;

			watcher.Error += (s, e) => Console.WriteLine("Error: {0}", e.GetException());

			Console.WriteLine("Hello. Watching " + Environment.CurrentDirectory);
			Console.CancelKeyPress += (s, e) => Console.WriteLine("Goodbye.");
			Application.Run();
		}

		static void WatcherEvent(object sender, FileSystemEventArgs e) {
			Console.WriteLine("{1} {0}", e.FullPath, e.ChangeType, e.Name);
		}
	}
}
