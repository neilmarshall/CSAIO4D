using System;
using System.IO;

// LoopThroughFiles -- Loop through all files contained in a directory;
//     this time perform a hex dump, though it could be anything
namespace LoopThroughFiles {

    public class Program {

        public static void Main(string[] args) {

            // if no directory name provided
            string directoryName;
            if (args.Length == 0) {
                // get the name of the current directory
                directoryName = Directory.GetCurrentDirectory();
            } else {
                // otherwise assume that the first argument is the directory
                // to use (and ignore all other command line arguments)
                directoryName = args[0];
            }
            Console.WriteLine(directoryName);

            // get a list of all files in that directory
            FileInfo[] files = GetFileList(directoryName);

            // now iterate through the files in that list, performing a hex
            // dump of each file
            foreach (FileInfo file in files) {
                // write the name of the file
                Console.WriteLine("\n\nhex dump of file {0}:", file.FullName);

                // now "dump" the file to the console
                DumpHex(file);

                // wait before outputting the next file
                Console.WriteLine("\nenter return to continue to the next file");
                Console.ReadLine();
            }

            // that's it!
            Console.WriteLine("\nno files left");
        }

        // GetFileList -- Get a list of all files in a specified directory
        public static FileInfo[] GetFileList(string directoryName) {

            // start with an empty list
            FileInfo[] files = new FileInfo[0];
            try {
                // get directory information
                DirectoryInfo di = new DirectoryInfo(directoryName);

                // that information object has a list of the contents
                files = di.GetFiles();
            } catch (Exception e) {
                Console.Error.WriteLine("Directory \"{0}\" invalid", directoryName);
                Console.Error.WriteLine(e.Message);
            }

            return files;
        }


        // DumpHex -- Given a file dump the contents to the console
        public static void DumpHex(FileInfo file) {

            // open the file
            FileStream fs;
            BinaryReader reader;            
            try {
                fs = file.OpenRead();
                // wrap the file in a BinaryReader
                reader = new BinaryReader(fs);
            } catch (Exception e) {
                Console.Error.WriteLine("\ncan't read from \"{0}\"", file.FullName);
                Console.Error.WriteLine(e.Message);
                return;
            }

            // iterate through the contents of the file one line at a time
            for (int line = 1; true; line++) {
                // read another 10 bytes across (all that will fit on a single
                // line) -- return when no data remains
                byte[] buffer = new byte[10];
                // use the BinaryReader to read bytes
                int numBytes = reader.Read(buffer, 0, buffer.Length);
                if (numBytes == 0) return;

                // write the data in a single line preceded by the line number
                Console.Write("{0:D3} - ", line);
                DumpBuffer(buffer, numBytes);
    
                // stop every 20 lines so that the data doesn't scroll off the screen
                if (line % 20 == 0) {
                    Console.WriteLine("Enter return to continue another 20 lines");
                    Console.ReadLine();
                }
            }
        }

        // DumpBuffer -- write a buffer of characters as a single line in hex format
        public static void DumpBuffer(byte[] buffer, int numBytes) {
            for (int index = 0; index < numBytes; index++) {
                byte b = buffer[index];
                Console.Write("{0:X2}, ", b);
            }
            Console.WriteLine();
        }
    }
}

