using SimpleWordProcessor.Library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWordProcessor.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                ProcessFile(args[0]);
            }
            else
            {
                ProcessFile("fileinput.txt");
            }
            Console.WriteLine("Press any key to exit...");
            Console.Read();
        }

        static void ProcessFile(string file)
        {
            Console.WriteLine(string.Format("Processing File: {0}", file));

            try
            {
                string fileContent = File.ReadAllText(file);

                WordsParser parser = new WordsParser();

                IEnumerable<string> words = parser.GetWords(fileContent);

                StandardWordTraverser traverser = new StandardWordTraverser(words);

                // Part 1
                WordsCounter counter = new WordsCounter();
                traverser.AcceptProcessor(counter);
                counter.ReportTo(Console.WriteLine);

                // Part 2
                CompositionMatcher compositonMatcher = new CompositionMatcher(words, 6);
                traverser.AcceptProcessor(compositonMatcher);
                compositonMatcher.ReportTo(Console.WriteLine);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Unable to read the file.");
                Console.WriteLine(string.Format("Message: {0}", ex.Message));
                Console.WriteLine(string.Format("Details: {0}", ex.StackTrace));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops... Unexpected error occurred.");
                Console.WriteLine(string.Format("Message: {0}", ex.Message));
                Console.WriteLine(string.Format("Details: {0}", ex.StackTrace));
            }
        }
    }
}
