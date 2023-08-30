using System;
using System.IO;


namespace RecursividadConsola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool continueProgram = true;

            while (continueProgram)
            {
                Console.WriteLine("Select a storage unit (e.g., D:):");
                string selectedDrive = Console.ReadLine();

                if (!IsDriveC(selectedDrive) && Directory.Exists(selectedDrive))
                {
                    Console.WriteLine($"Files in {selectedDrive}:");

                    // Call the recursive method to list files in the selected drive
                    ListFiles(selectedDrive);
                }
                else
                {
                    Console.WriteLine("The selected drive is not valid or it's the C: drive.");
                }

                Console.WriteLine("Do you want to restart the program? (Y/N)");
                string restart = Console.ReadLine();
                if (restart.ToUpper() != "Y")
                {
                    continueProgram = false;
                }
                Console.Clear();
            }
            Console.ReadKey();
        }

        static bool IsDriveC(string drive)
        {
            return drive.ToUpper() == "C:";
        }

        static void ListFiles(string directory)
        {
            try
            {
                // List all files in the current directory
                string[] files = Directory.GetFiles(directory);

                // Print the name of each file
                foreach (string file in files)
                {
                    Console.WriteLine(Path.GetFileName(file));
                }

                // List all subdirectories in the current directory
                string[] subdirectories = Directory.GetDirectories(directory);

                // Call the method recursively for each subdirectory
                foreach (string subdirectory in subdirectories)
                {
                    ListFiles(subdirectory);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error listing files in {directory}: {ex.Message}");
            }
        }
    }
}
