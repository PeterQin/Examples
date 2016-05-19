using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection.Emit;
using SkinEditor;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int exitCodeSuccess = 0;
            int exitCodeWrongArguments = 1;
            int exitCodeCannotLoad = 2;
            int exitCodeFailedCreate = 3;

            if (args == null || args.Length == 0)
                Environment.Exit(exitCodeWrongArguments);

            SkinProject project = SkinProject.LoadProject(Path.GetFullPath(args[0]));

            if (project == null)
                Environment.Exit(exitCodeCannotLoad);

            SkinAssemblyBuilderArgs arguments = new SkinAssemblyBuilderArgs(project.AssemblyName,
                project.ClassName, project.ExtraNamespace, project.Name);
            CustomSkinAssemblyBuilder builder = new CustomSkinAssemblyBuilder(arguments);
            if (args.Length >= 2)
                builder.AssemblyFileVersion = args[1];
            bool created = false;
            try
            {
                created = builder.Generate(project);
            }
            catch { }
            Environment.Exit(created ? exitCodeSuccess : exitCodeFailedCreate);
        }
    }

    public class CustomSkinAssemblyBuilder : SkinAssemblyBuilder
    {
        public CustomSkinAssemblyBuilder() : base() { }
        public CustomSkinAssemblyBuilder(SkinAssemblyBuilderArgs args) : base(args) { }

        public string AssemblyFileVersion { get; set; }

        protected override bool OnGenerate()
        {
            AssemblyBuilder asm = DefineDynamicAssembly(AppDomain.CurrentDomain);
            asm.Save(Args.AsmFileName);
            return true;
        }

        AssemblyBuilder DefineDynamicAssembly(AppDomain domain)
        {
            AssemblyBuilder result = (AssemblyBuilder)typeof(SkinAssemblyBuilder).GetMethod("DefineDynamicAssembly",
                BindingFlags.Instance | BindingFlags.NonPublic).Invoke(this, new object[] { domain });
            if (!string.IsNullOrEmpty(AssemblyFileVersion))
            {
                result.SetCustomAttribute(new CustomAttributeBuilder(typeof(AssemblyFileVersionAttribute).GetConstructor(new Type[] { typeof(string) }),
                    new string[] { AssemblyFileVersion }));
                result.DefineVersionInfoResource();
            }
            return result;
        }
    }
}
