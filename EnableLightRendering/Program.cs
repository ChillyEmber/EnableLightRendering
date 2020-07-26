using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;
using System.Diagnostics;

namespace FixGraphicsEngine
{
    class Program
    {
        static void Main()
        {
            var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SCP Secret Laboratory/registry.txt");
            string text = File.ReadAllText(fileName);
            string Contains = "The Light Rendering line is there. Continuing.";
            string DoesNotContain = "The Light Rendering line is not there. Writing line and continuing.";
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
            if (text.Contains("07gfxsets_hp::-%(|::1"))
            {
                text = text.Replace("07gfxsets_hp::-%(|::1", "07gfxsets_hp::-%(|::0");
                File.WriteAllText(fileName, text);
                Barf();
            }
            if (text.Contains("00gfxsets_hp::-%(|::false"))
            {
                text = text.Replace("07gfxsets_hp::-%(|::0", "07gfxsets_hp::-%(|::1");
                File.WriteAllText(fileName, text);
                NotBarf();
            }
            /*if (text.Contains("07graphics_api::-%(|::1"))
            {
                text = text.Replace("07graphics_api::-%(|::1", "07graphics_api::-%(|::0");
                File.WriteAllText(fileName, text);
                Barf();
            }
            if (text.Contains("07graphics_api::-%(|::2"))
            {
                text = text.Replace("07graphics_api::-%(|::2", "07graphics_api::-%(|::0");
                File.WriteAllText(fileName, text);
                Barf();
            }
            if (text.Contains("07graphics_api::-%(|::3"))
            {
                text = text.Replace("07graphics_api::-%(|::3", "07graphics_api::-%(|::0");
                File.WriteAllText(fileName, text);
                Barf();
            }
            if (text.Contains("07graphics_api::-%(|::4"))
            {
                text = text.Replace("07graphics_api::-%(|::4", "07graphics_api::-%(|::0");
                File.WriteAllText(fileName, text);
                Barf();
            }
            else
            {
                text = text.Replace("07graphics_api::-%(|::", "07graphics_api::-%(|::0");
            }*/
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
            Console.WriteLine($"Something went wrong, please let lXxMangoxXl know about this! Press any key to close the program.");
            Console.ReadKey();
            Process.GetCurrentProcess().Kill();
        }
    }
}
