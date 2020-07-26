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
            
            string text = File.ReadAllText(fileName);

            string Contains = "The Light Rendering line is there. Continuing.";
            string DoesNotContain = "The Light Rendering line is not there. Writing line and continuing.";


            //Checks to see if the line is actually there in configs.
            if (text.Contains("07gfxsets_hp::-%(|::"))
            {
                Console.WriteLine(Contains);
            }
            else
            {
                Console.WriteLine(DoesNotContain);
                string billybob = Environment.NewLine + "07gfxsets_hp::-%(|::1";
                System.IO.File.AppendAllText(fileName, billybob);
                NotBarf();
            }

            //Toggles the config.
            if (text.Contains("07gfxsets_hp::-%(|::1"))
            {
                text = text.Replace("07gfxsets_hp::-%(|::1", "07gfxsets_hp::-%(|::0");
                File.WriteAllText(fileName, text);
                Barf();
            }
            if (text.Contains("07gfxsets_hp::-%(|::0"))
            {
                text = text.Replace("07gfxsets_hp::-%(|::0", "07gfxsets_hp::-%(|::1");
                File.WriteAllText(fileName, text);
                NotBarf();
            }
            File.WriteAllText(fileName, text);
            Barf();
        }
        
        static void Barf()
        {
            Console.WriteLine("Done! Set Light Rendering to false! Hit any key to quit!");
            Console.ReadKey();
            Process.GetCurrentProcess().Kill();
        }

        static void NotBarf()
        {
            Console.WriteLine("Done! Set Light Rendering to true! Hit any key to quit!");
            Console.ReadKey();
            Process.GetCurrentProcess().Kill();
        }
        static void UhOh()
        {
            // Yes I know it has no references, shhhhh
            Console.WriteLine($"Something went wrong, please let lXxMangoxXl know about this! Press any key to close the program.");
            Console.ReadKey();
            Process.GetCurrentProcess().Kill();
        }
    }
}
//Shoot me a message on Discord lXxMangoxXl#8878 if theres any issues.