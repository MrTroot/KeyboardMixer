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
            XmlSerializer serializer = new XmlSerializer(typeof(SerializableSettings));
            TextWriter writer = new StreamWriter(FILE_PATH);
            serializer.Serialize(writer, settings);
            writer.Close();
        }

        public static SerializableSettings ReadConfig()
        {
            Directory.CreateDirectory(DIRECTORY_PATH);
            if (!File.Exists(FILE_PATH))
            {
                return WriteDefaults();
            }

            XmlSerializer serializer = new XmlSerializer(typeof(SerializableSettings));
            FileStream fs = new FileStream(FILE_PATH, FileMode.Open);
            SerializableSettings settings = (SerializableSettings) serializer.Deserialize(fs);
            fs.Close();
            return settings;
        }

        public static SerializableSettings WriteDefaults()
        {
            SerializableSettings settings = SerializableSettings.GetDefaults();
            WriteConfig(settings);
            return settings;
        }
    }
}
