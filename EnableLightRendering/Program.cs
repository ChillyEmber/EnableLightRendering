using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;
using System.Diagnostics;
using System.Data;

namespace FixGraphicsEngine
{
    class Program
    {
        static void Main()
        {
            //Checks to see if SCP:SL is running
            Process[] pname = Process.GetProcessesByName("scpsl");
            if (pname.Length > 0)
            {
                SLRunning();
            }
            else
            {
                Console.WriteLine("SCP:SL is not running, continuing.");
            }

            //Finds the config paths and sets them as a variable/string.
            var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SCP Secret Laboratory/registry.txt");

            //Registry.txt check
            if (File.Exists(fileName))
            {
                Console.WriteLine($"The Registry file is there. Continuing.");
            }
            else
            {
                Console.WriteLine($"The Registry file is not there. Making the file and continuing.");
                File.Create(fileName).Close();
            }
            
            //Reads all the text
            string text = File.ReadAllText(fileName);

            //Checks to see if the line is actually there in configs.
            if (text.Contains("07gfxsets_hp::-%(|::"))
            {
                string Contains = "The Light Rendering line is there. Continuing.";
                Console.WriteLine(Contains);
            }
            else
            {
                string DoesNotContain = "The Light Rendering line is not there. Writing line and continuing.";
                Console.WriteLine(DoesNotContain);
                string WriteLine = Environment.NewLine + "07gfxsets_hp::-%(|::1";
                System.IO.File.AppendAllText(fileName, WriteLine);
                SetToTrue();
            }

            //Toggles the config.
            if (text.Contains("07gfxsets_hp::-%(|::1"))
            {
                text = text.Replace("07gfxsets_hp::-%(|::1", "07gfxsets_hp::-%(|::0");
                File.WriteAllText(fileName, text);
                SetToFalse();
            }
            if (text.Contains("07gfxsets_hp::-%(|::0"))
            {
                text = text.Replace("07gfxsets_hp::-%(|::0", "07gfxsets_hp::-%(|::1");
                File.WriteAllText(fileName, text);
                SetToTrue();
            }
            File.WriteAllText(fileName, text);
            SetToFalse();
        }
        
        //Used for writing the line and ending the program.
        static void SetToFalse()
        {
            Console.WriteLine("Done! Set Light Rendering to false! Hit any key to quit!");
            Console.ReadKey();
            Process.GetCurrentProcess().Kill();
        }
        static void SetToTrue()
        {
            Console.WriteLine("Done! Set Light Rendering to true! Hit any key to quit!");
            Console.ReadKey();
            Process.GetCurrentProcess().Kill();
        }
        static void SLRunning()
        {
            Console.WriteLine("SCP:SL is currently running, close it before running the program! Hit any key to close.");
            Console.ReadKey();
            Process.GetCurrentProcess().Kill();
        }
    }
}