using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using CommonLib.Interfaces;
using CommonLib.Models;

namespace Autotests
{
    public class ApplicationSettings : IConfigurationSectionHandler
    {
        public ConfigurationOptions GetConfigurationOptions()
        {
            return new ConfigurationOptions();
        }


        public int Id { get; set; }
        public List<string> CarTypes { get; set; }

        /// <summary>
        /// Creates a configuration section handler.
        /// </summary>
        /// <param name="parent">Parent object.</param>
        /// <param name="configContext">Configuration context object.</param>
        /// <param name="section">Section XML node.</param>
        /// <returns>
        /// The created section handler object.
        /// </returns>
        public object Create(object parent, object configContext, XmlNode section)
        {
            return section;
        }

        /// <summary>
        /// Initialize this object from app config.
        /// </summary>
        public void InitializeFromAppConfig()
        {
            XmlElement settingsXmlElement = GetXmlElementFromAppConfig();
            ApplicationSettings settings = DeserializeFromXmlElement(settingsXmlElement);
            CopyDataToCurrentObject(settings);
        }

        /// <summary>
        /// Gets the XML element from app config.
        /// </summary>
        /// <returns>
        /// The found xml element.
        /// </returns>
        private XmlElement GetXmlElementFromAppConfig()
        {
            string tagName = this.GetType().Name;
            XmlElement sectionElement = ConfigurationManager.GetSection(tagName) as XmlElement;
            if (sectionElement == null)
            {
                throw new ApplicationException($"Could not find section {tagName} in the App.config file.");
            }
            return sectionElement;
        }

        /// <summary>
        /// Convert the given XML element to a ScheduleServiceSettings object.
        /// </summary>
        /// <param name="sectionElement">The XML element containing the information to create a ScheduleServiceSettings object.</param>
        /// <returns>A ScheduleServiceSettings object</returns>
        private ApplicationSettings DeserializeFromXmlElement(XmlElement sectionElement)
        {
            ApplicationSettings settings = null;
            using (StringReader reader = new StringReader(sectionElement.OuterXml))
            {
                XmlSerializer xs = new XmlSerializer(typeof(ApplicationSettings));
                settings = xs.Deserialize(reader) as ApplicationSettings;
            }
            return settings;
        }

        /// <summary>
        /// Copy the data found in the ScheduleServiceSettings object to the current object
        /// </summary>
        /// <param name="settings"></param>
        private void CopyDataToCurrentObject(ApplicationSettings settings)
        {
            Id = settings.Id;
            CarTypes = settings.CarTypes;
        }
    }
}
