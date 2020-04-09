using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using Microsoft.LightSwitch.Model;

namespace LightSwitchApplication.Properties
{
    [Export(typeof(IApplicationDefinitionLoaderService))]
    public class ApplicationDefinitionLoader : IApplicationDefinitionLoaderService
    {
        private const string AppDefinition = @"bin\ApplicationDefinition.lsml";
        public IEnumerable<Stream> LoadModelFragments()
        {
            var definitionStreams = new List<Stream>
                {
                    File.OpenRead(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, AppDefinition))
                };
            return definitionStreams;
        }
    }
}
