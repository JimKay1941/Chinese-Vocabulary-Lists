using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Xml.Linq;
using Microsoft.LightSwitch.Model;

namespace LightSwitchApplication.Properties
{
    [Export(typeof(IApplicationDefinitionLoaderService))]
    public class ApplicationDefinitionLoader : IApplicationDefinitionLoaderService
    {
        private const string AppDefinition = "ApplicationDefinition.lsml";
        public IEnumerable<Stream> LoadModelFragments()
        {
            var definitionStreams = new List<Stream>();

            XDocument xdoc = XDocument.Load(AppDefinition);
            var ms = new MemoryStream();
            xdoc.Save(ms);
            ms.Seek(0, SeekOrigin.Begin);
            definitionStreams.Add(ms);

            return definitionStreams;
        }
    }
}
