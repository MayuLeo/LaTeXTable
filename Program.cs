using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Paiza
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string pwd = args[0];
			string caption = args[1];
			StreamReader sr = new StreamReader(pwd,System.Text.Encoding.GetEncoding("shift_jis"));
			int FileLength = 0;
			//char[] Delchar = { ',' };
			Queue<string> queue = new Queue<string>();
			while(sr.Peek () >= 0) //行数カウント
			{
				queue.Enqueue(sr.ReadLine());
				//sr.ReadLine ();
				FileLength++;
			}
			string[] CSVdata = new string[FileLength];

			for(int i = 0;i < FileLength;i++) //input にとりあえず格納
			{
				CSVdata[i] = "    ";
				CSVdata[i] += queue.Dequeue();
				//Console.WriteLine(input[i]);
			}

			//string[] CSVdata = new string[FileLength];
			for(int i = 0;i < FileLength;i++) 
			{
				CSVdata[i] = CSVdata[i].Replace(","," & ");
				CSVdata[i] += " \\\\ \\hline";
				//Console.WriteLine(CSVdata[i]);
			}
			
			Print(CSVdata,FileLength,caption);
			sr.Close ();
		}

		public static void Print(string[] CSVdata,int FileLength,string caption)
		{
			int FileWidth = CSVdata[0].Count(c => c == '&');//幅カウント
			string Position = "";
			for(int i = 0;i < FileWidth + 1;i++) 
			{
				Position += "|r";
			}
			Position += "|";
			Console.WriteLine ("\\begin{table}[htbp]\r\n  \\begin{center}\r\n    \\caption{" + caption +"}\r\n    \\begin{tabular}{" + Position + "}\\hline");
			for(int i = 0;i < FileLength;i++) 
			{
				Console.WriteLine(CSVdata[i]);
			}
			Console.WriteLine("    \\end{tabular}\n  \\end{center}\n\\end{table}");
		}
	}

}
