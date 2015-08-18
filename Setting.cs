using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace SQUI
{
    public class Setting
    {
        const string FileName = "Settings.dat";

        public static List<ManagedDirectory> Orders { get; private set; }

        public static void Load()
        {
            if (File.Exists(FileName))
            {
                using (System.IO.Stream ReadStream = new FileStream(FileName, FileMode.Open))
                {
                    BinaryFormatter binFormatter = new BinaryFormatter();
                    Orders = binFormatter.Deserialize(ReadStream) as List<ManagedDirectory>;
                }
                foreach (var item in Orders)
                {
                    if (item.Enabled && item.Option.RealtimeWatch)
                    {
                        item.WatcherIndex = Watcher.Create(item);
                    }
                }
            }
            else
            {
                Orders = new List<ManagedDirectory>();
            }
        }

        public static void Save()
        {
            using (var WriteStream = new FileStream(FileName, FileMode.Create))
            {
                var binFormatter = new BinaryFormatter();
                binFormatter.Serialize(WriteStream, Orders);
            }
        }
    }
}
