using System;
using System.Configuration;
using System.IO;
using System.Threading;
using DtoGenerator.Dto.Description;
using DtoGenerator.DtoClass;
using DtoGenerator.Generator;
using MPP.DtoGenerator.ClassReader;

namespace MPP.DtoGenerator
{
    public class Program
    {
        private static readonly IDtoGenerator _generator = new global::DtoGenerator.Generator.DtoGenerator();
        private static string _dtoClassDirectoryPath;

        public static void Main(string[] args)
        {
            try
            {
                string dtoNamespace = GetDtoNamespace();
                int threadPoolMaxSize = GetThreadPoolMaxSize();
                string jsonDescriptionPath = GetJsonDescriptionPath();
                _dtoClassDirectoryPath = GetResultClassDirectoryPath();
                ThreadPool.SetMaxThreads(threadPoolMaxSize, threadPoolMaxSize);

                DtoDescriptionDocument document = GetDescriptionDocument(jsonDescriptionPath);

                CreateDtoClassDescriptions(document, dtoNamespace);
            }
            catch (ConfigurationErrorsException ex)
            {
                Console.WriteLine($"Cannot load config data: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Cannot generate source files: {ex.Message}");
            }

            Console.ReadLine();
        }

        private static DtoDescriptionDocument GetDescriptionDocument(string descriptionPath)
        {
            IDtoDescriptionFileReader descriptionReader = new JsonClassFileReader();
            return descriptionReader.ReadDtoDescription(descriptionPath);
        }

        private static int GetThreadPoolMaxSize()
        {
            string threadPoolSizeString = GetConfigurationProperty("threadPoolSize");
            return int.Parse(threadPoolSizeString);
        }

        private static string GetDtoNamespace()
        {
            return GetConfigurationProperty("dtoNamespace");
        }

        private static string GetConfigurationProperty(string property)
        {
            string value = ConfigurationManager.AppSettings[property];

            if (value == null)
            {
                throw new ConfigurationErrorsException($"Configuration property `{property}` not found");
            }

            return value;
        }

        private static string GetJsonDescriptionPath()
        {
            Console.WriteLine("Json descritpion path: ");
            return Console.ReadLine();
        }

        private static string GetResultClassDirectoryPath()
        {
            Console.WriteLine("Result class directory: ");
            string path = Console.ReadLine();
            if (!path.EndsWith("\\") || !path.EndsWith("/"))
            {
                return path + "\\";
            }

            return path;
        }

        private static void CreateDtoClassDescriptions(DtoDescriptionDocument document, string classNamespace)
        {
            foreach (DtoClassDescription description in document.ClassDescriptions)
            {
                description.Namespace = classNamespace;
                ThreadPool.QueueUserWorkItem(SaveDtoDescription, description);
            }
        }

        private static void SaveDtoDescription(object description)
        {
            DtoClassDescription classDesciption = (DtoClassDescription) description;

            string classDescriptionText = _generator.GenerateClassDescriptionBody(classDesciption);

            Console.WriteLine(classDescriptionText);

            File.WriteAllText($"{_dtoClassDirectoryPath}{classDesciption.ClassName}.cs", classDescriptionText);
        }
    }
}
