using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBurnerMerger {
	class Program {
		static long count = 0;
		static int tab = -1;
		static void Main(string[] args) {
			DirectoryInfo root = new DirectoryInfo("V:");
			DirectoryInfo[] folders = root.GetDirectories("NoteBurner iTunes DRM Audio Converter*");
			foreach(DirectoryInfo folder in folders) {
				ReportSize(folder);
			}
		}

		private static long ReportSize(DirectoryInfo folder) {
			Report(folder);
			++tab;
			DirectoryInfo[] folders = folder.GetDirectories();
			foreach(DirectoryInfo dir in folders) {
				count+=ReportSize(dir);
			}
			--tab;
#if false
			FileInfo[] files = folder.GetFiles();
			foreach(FileInfo file in files) {
				count+=file.Length;
			}
			Report(folder);
#endif
			return count;
		}

		private static void Report(DirectoryInfo folder) {
			for(int i = 0;i<tab;++i) {
				Console.Write("    ");
			}
			//Console.WriteLine("{0,20:###,##0.00} GB |{1}",ToGigaByte(count),folder.FullName);
			if(tab>0) {
				Console.WriteLine("{0}",folder.Name);
			} else {
				Console.WriteLine("{0}",folder.FullName);
			}
		}
		private static double ToGigaByte(long countInBytes) {
			double mega = ToMegaByte(countInBytes);
			return mega/1024.0;
		}
		private static double ToMegaByte(long countInBytes) {
			double kilo = ToKiloByte(countInBytes);
			return kilo/1024.0;
		}
		private static double ToKiloByte(long countInBytes) {
			return countInBytes/1024.0;
		}
	}
}
