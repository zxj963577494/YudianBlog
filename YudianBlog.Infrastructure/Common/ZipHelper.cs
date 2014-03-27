using System;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace YudianBlog.Infrastructure.Common
{
    public class ZipHelper
    {
        public bool UnZip(string sourceFile, string destinationFile)
        {
            bool ret = true;
            try
            {
                ZipEntry theEntry;
                ZipInputStream s = new ZipInputStream(File.OpenRead(sourceFile));
                while ((theEntry = s.GetNextEntry()) != null)
                {
                    bool flag;
                    string directoryName = Path.GetDirectoryName(destinationFile);
                    if (!(Path.GetFileName(theEntry.Name.Replace("updatepacket/", "")) != string.Empty))
                    {
                        goto Label_010A;
                    }
                    if (theEntry.CompressedSize == 0)
                    {
                        break;
                    }
                    Directory.CreateDirectory(Path.GetDirectoryName(destinationFile + theEntry.Name.Replace("updatepacket/", "")));
                    FileStream streamWriter = File.Create(destinationFile + theEntry.Name.Replace("updatepacket/", ""));
                    int size = 0x800;
                    byte[] data = new byte[0x800];
                    goto Label_00FC;
                Label_00C9:
                    size = s.Read(data, 0, data.Length);
                    if (size > 0)
                    {
                        streamWriter.Write(data, 0, size);
                    }
                    else
                    {
                        goto Label_0101;
                    }
                Label_00FC:
                    flag = true;
                    goto Label_00C9;
                Label_0101:
                    streamWriter.Close();
                Label_010A:;
                }
                s.Close();
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        public bool ZipFile(string[] files, string zipFilePath, out string err)
        {
            err = "";
            try
            {
                string[] filenames = files;
                using (ZipOutputStream s = new ZipOutputStream(File.Create(zipFilePath)))
                {
                    s.SetLevel(9);
                    byte[] buffer = new byte[0x1000];
                    foreach (string file in filenames)
                    {
                        ZipEntry entry = new ZipEntry(Path.GetFileName(file)) {
                            DateTime = DateTime.Now
                        };
                        s.PutNextEntry(entry);
                        using (FileStream fs = File.OpenRead(file))
                        {
                            int sourceBytes;
                            do
                            {
                                sourceBytes = fs.Read(buffer, 0, buffer.Length);
                                s.Write(buffer, 0, sourceBytes);
                            }
                            while (sourceBytes > 0);
                        }
                    }
                    s.Finish();
                    s.Close();
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
            return true;
        }
    }
}

