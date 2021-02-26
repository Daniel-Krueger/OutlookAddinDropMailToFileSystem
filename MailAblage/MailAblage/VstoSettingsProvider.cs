using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Xml;
using System.Collections.Specialized;

namespace MailAblage
{

    /// <summary>
    /// Taken from: http://kikistidbits.blogspot.com/2010/10/save-your-settingssettings-to-known.html
    /// </summary>
    class VstoSettingsProvider : SettingsProvider
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public VstoSettingsProvider()
        {
        }

        /// <summary>
        /// We use the product name (AssemblyProduct from AssemblyInfo.cs)
        /// as the application name
        /// </summary>
        public override string ApplicationName
        {
            get
            {
                string assemblyFileName = System.Reflection.Assembly.GetExecutingAssembly().Location;
                System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assemblyFileName);
                return fvi.ProductName;
            }
            set { }
        }

        /// <summary>
        /// Creates the path to the settings file, which is be design not version dependant
        /// (in contrast to the default provider).
        /// The path is built as user's application data directory, then a subdirectory based
        /// on the application name, and the file name is always user.config similar to the
        /// default provider.
        /// </summary>
        private string GetSavingPath
        {
            get
            {
                string retVal = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Path.DirectorySeparatorChar +
                    ApplicationName + Path.DirectorySeparatorChar + "user.config";
                return retVal;
            }
        }

        /// <summary>
        /// Here we just call the base class initializer
        /// </summary>
        /// <param name="name"></param>
        /// <param name="col"></param>
        public override void Initialize(string name, NameValueCollection col)
        {
            base.Initialize(this.ApplicationName, col);
        }

        /// <summary>
        /// SetPropertyValue is invoked when ApplicationSettingsBase.Save is called
        /// ASB makes sure to pass each provider only the values marked for that provider -
        /// You need to manually set the provider for each setting.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="propvals"></param>
        public override void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection propvals)
        {
            string dir = Path.GetDirectoryName(GetSavingPath);
            if (!Directory.Exists(dir))
            {
                try
                {
                    Directory.CreateDirectory(dir);
                }
                catch (Exception fe)
                {

                    throw new ApplicationException($"Failed to create directory {dir}", fe);
                }
            }
            try
            {
                using (XmlTextWriter tw = new XmlTextWriter(this.GetSavingPath, Encoding.Unicode))
                {
                    tw.WriteStartDocument();
                    tw.WriteStartElement(ApplicationName);

                    foreach (SettingsPropertyValue propertyValue in propvals)
                    {
                        if (IsUserScoped(propertyValue.Property) && propertyValue.SerializedValue != null)
                        {
                            tw.WriteStartElement(propertyValue.Name);
                            tw.WriteValue(propertyValue.SerializedValue);
                            tw.WriteEndElement();
                        }
                    }

                    tw.WriteEndElement();
                    tw.WriteEndDocument();
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException($"Unable to save settings", e);
            }
        }

        /// <summary>
        /// First instantiates all settings with their default values, then tries to
        /// retrieve the values from the settigs file. If the latter fails, the
        /// default values are returned.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="props"></param>
        /// <returns></returns>
        public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context, SettingsPropertyCollection props)
        {
            // Create new collection of values
            SettingsPropertyValueCollection values = new SettingsPropertyValueCollection();

            // Iterate through the settings to be retrieved (use their default values)
            foreach (SettingsProperty setting in props)
            {
                SettingsPropertyValue value = new SettingsPropertyValue(setting);
                value.IsDirty = false;
                /*value.SerializedValue = setting.DefaultValue;
                value.PropertyValue = setting.DefaultValue;*/
                values.Add(value);
            }

            if (!File.Exists(this.GetSavingPath))
            {
                return values;
            }

            try
            {
                using (XmlTextReader tr = new XmlTextReader(this.GetSavingPath))
                {
                    try
                    {
                        tr.ReadStartElement(ApplicationName);
                        foreach (SettingsPropertyValue value in values)
                        {
                            if (IsUserScoped(value.Property))
                            {
                                try
                                {
                                    tr.ReadStartElement(value.Name);
                                    value.SerializedValue = tr.ReadContentAsObject();
                                    value.Deserialized = false;
                                    tr.ReadEndElement();
                                }
                                catch (XmlException xe1)
                                {
                                    throw new ApplicationException("Failed to read value from settings file", xe1);
                                }
                            }
                        }
                        tr.ReadEndElement();
                    }
                    catch (XmlException xe2)
                    {
                        throw new ApplicationException("Failed to read section from settings file", xe2);
                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Failed to read settings file", e);
            }

            return values;
        }

        // Helper method: walks the "attribute bag" for a given property
        // to determine if it is user-scoped or not.
        // Note that this provider does not enforce other rules, such as
        //   - unknown attributes
        //   - improper attribute combinations (e.g. both user and app - this implementation
        //     would say true for user-scoped regardless of existence of app-scoped)
        private bool IsUserScoped(SettingsProperty prop)
        {
            foreach (DictionaryEntry d in prop.Attributes)
            {
                Attribute a = (Attribute)d.Value;
                if (a.GetType() == typeof(UserScopedSettingAttribute))
                    return true;
            }
            return false;
        }

    }
}