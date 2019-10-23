using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

namespace KeyboardMixer
{
    class ConfigManager
    {
        private static readonly string DIRECTORY_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "KeyboardMixer");
        private static readonly string FILE_PATH = Path.Combine(DIRECTORY_PATH, "settings.xml");
        public static void WriteConfig(SerializableSettings settings)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(SerializableSettings));
                TextWriter writer = new StreamWriter(FILE_PATH);
                serializer.Serialize(writer, settings);
                writer.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static SerializableSettings ReadConfig()
        {
            try
            {
                Directory.CreateDirectory(DIRECTORY_PATH);
                if (!File.Exists(FILE_PATH))
                {
                    return WriteDefaults();
                }

                XmlSerializer serializer = new XmlSerializer(typeof(SerializableSettings));
                FileStream fs = new FileStream(FILE_PATH, FileMode.Open);
                SerializableSettings settings = (SerializableSettings)serializer.Deserialize(fs);
                fs.Close();
                return settings;
            }
            catch (Exception e)
            {
                //on read error (e.g. blank or invalid config) write defaults instead
                Console.WriteLine(e.ToString());
                return WriteDefaults();
            }
        }

        public static SerializableSettings WriteDefaults()
        {
            SerializableSettings defaultSettings = SerializableSettings.GetDefaults();
            WriteConfig(defaultSettings);
            return defaultSettings;
        }
    }
}
