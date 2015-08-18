using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SQUI
{
    class Watcher
    {
        static List<Watcher> __watchers = new List<Watcher>();

        FileSystemWatcher _watcher;
        ManagedDirectory info;

        public int Index { get; private set; }

        public static int Create(ManagedDirectory info)
        {
            var gen = new Watcher(info);
            gen.Index = __watchers.Count;
            __watchers.Add(gen);
            return gen.Index;
        }

        public static void Start(int index)
        {
            foreach (var item in __watchers)
            {
                if (item.Index == index)
                {
                    item.StartWatch();
                }
            }
        }

        public static void Stop(int index)
        {
            foreach (var item in __watchers)
            {
                if (item.Index == index)
                {
                    item.StopWatch();
                }
            }
        }

        public static void Remove(int index)
        {
            __watchers.RemoveAt(index);
        }

        private Watcher(ManagedDirectory info)
        {
            this.info = info;
            StartWatch();
        }

        public void StartWatch()
        {
            if (!Directory.Exists(info.DepartureFolder) && !Directory.Exists(info.DestinationFolder)) return;
            _watcher = new FileSystemWatcher(info.DepartureFolder);
            _watcher.EnableRaisingEvents = true;
            _watcher.IncludeSubdirectories = info.Option.RootSerach;
            _watcher.Changed += new FileSystemEventHandler(changed);
            _watcher.Renamed += new RenamedEventHandler(renamed);
            _watcher.Created += new FileSystemEventHandler(created);
            _watcher.Deleted += new FileSystemEventHandler(deleted);
        }

        public void StopWatch()
        {
            if (_watcher != null)
                _watcher.Dispose();
        }

        private void changed(object sender, FileSystemEventArgs e)
        {
            if (e.Name.Contains("Thumbs.db")) return;
            copytweak(e);
        }

        private void deleted(object sender, FileSystemEventArgs e)
        {
            if (e.Name.Contains("Thumbs.db")) return;

            var newPath = e.FullPath.Replace(info.DepartureFolder, info.DestinationFolder);
            if (File.Exists(newPath) && info.Option.isCopy == true)
            {
                File.Delete(newPath);
            }
        }

        private void renamed(object sender, RenamedEventArgs e)
        {
            if (e.Name.Contains("Thumbs.db")) return;

            var OutsideOldPath = e.OldFullPath.Replace(info.DepartureFolder, info.DestinationFolder);
            var OutsideNewPath = e.FullPath.Replace(info.DepartureFolder, info.DestinationFolder);

            if ((File.GetAttributes(e.FullPath) & FileAttributes.Directory) == FileAttributes.Directory)
            {
                if (!Directory.Exists(OutsideOldPath))
                {
                    CopyDirectory(e.FullPath);
                }
                else
                {
                    Directory.Move(OutsideOldPath, OutsideNewPath);
                }
            }
            else
            {
                if (Framework.isManagedFile(e.OldName, info))
                {
                    if (!File.Exists(OutsideOldPath))
                    {
                        var dir = Path.GetDirectoryName(OutsideOldPath);
                        if (!Directory.Exists(dir))
                        {
                            Directory.CreateDirectory(dir);
                        }
                        if (!IsLocked(e.FullPath))
                        {
                            File.Copy(e.FullPath, OutsideNewPath);
                        }
                    }
                    else
                    {
                        if (!IsLocked(OutsideOldPath))
                        {
                            File.Move(OutsideOldPath, OutsideNewPath);
                            File.Delete(OutsideOldPath);
                        }
                    }
                }
            }
        }

        private void created(object sender, FileSystemEventArgs e)
        {
            if (e.Name.Contains("Thumbs.db")) return;
            copytweak(e);
        }

        private void copytweak(FileSystemEventArgs e)
        {
            if (File.Exists(e.FullPath))
            {
                if ((File.GetAttributes(e.FullPath) & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    CopyDirectory(e.FullPath);
                }
                else
                {
                    if(Framework.isManagedFile(e.Name, info))
                    {
                        var newPath = e.FullPath.Replace(info.DepartureFolder, info.DestinationFolder);
                        var dir = Path.GetDirectoryName(newPath);
                        if (!Directory.Exists(dir))
                        {
                            Directory.CreateDirectory(dir);
                        }
                        if (!IsLocked(e.FullPath))
                        {
                            if (info.Option.isCopy)
                            {
                                File.Copy(e.FullPath, newPath, true);
                            }
                            else
                            {
                                File.Move(e.FullPath, newPath);
                            }
                        }
                    }
                }
            }
        }

        private void CopyDirectory(string watchsideCurrentDir)
        {
            var sdirs = Directory.GetDirectories(watchsideCurrentDir);
            foreach (var dir in sdirs)
            {
                CopyDirectory(dir);
            }

            var outsideCurrentDir = watchsideCurrentDir.Replace(info.DepartureFolder, info.DestinationFolder);
            if (!Directory.Exists(outsideCurrentDir))
            {
                Directory.CreateDirectory(outsideCurrentDir);
            }

            var files = Directory.GetFiles(watchsideCurrentDir);
            foreach (var file in files)
            {
                var destfile = file.Replace(watchsideCurrentDir, outsideCurrentDir);
                if (!File.Exists(destfile))
                {
                    if (!IsLocked(file))
                    {
                        if (info.Option.isCopy)
                        {
                            File.Copy(file, destfile);
                        }
                        else
                        {
                            File.Move(file, destfile);
                        }
                    }
                }
            }
        }

        private static bool IsLocked(string path)
        {
            try
            {
                using (File.Open(path, FileMode.Open)) { }
                return false;
            }
            catch
            {
                return true;
            }
        }
    }
}
