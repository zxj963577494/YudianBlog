using System;
using System.IO;
using System.Text;

namespace YudianBlog.Infrastructure.Common
{
    public class FileHelper
    {
        private Encoding defaultEncoding = Encoding.UTF8;
        private int directoryIndex = 0;
        public StringBuilder fileTree = new StringBuilder();
        private int listIndex = 0;
        public string rootUrl = "";

        /// <summary>
        /// 拷贝文件
        /// </summary>
        /// <param name="FileOldPath">原始文件</param>
        /// <param name="FileNewPath">新文件路径</param>
        /// <param name="IsReplaceFile">是否替换文件</param>
        public bool CopyFile(string FileOldPath, string FileNewPath, bool IsReplaceFile)
        {
            try
            {
                if (File.Exists(FileOldPath))
                {
                    if (!File.Exists(FileNewPath))
                    {
                        if (!File.Exists(FileNewPath.Substring(0, FileNewPath.LastIndexOf(@"\"))))
                        {
                            this.CreateDirectory(FileNewPath.Substring(0, FileNewPath.LastIndexOf(@"\")));
                        }
                        File.Copy(FileOldPath, FileNewPath);
                        return true;
                    }
                    if (IsReplaceFile)
                    {
                        File.Delete(FileNewPath);
                        File.Copy(FileOldPath, FileNewPath);
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public bool CreateDirectory(string filePath)
        {
            try
            {
                // 判断目标目录是否存在如果不存在则新建之
                if (!Directory.Exists(filePath))
                {
                    DirectoryInfo di = Directory.CreateDirectory(filePath);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="fileContent">文件内容</param>
        /// <returns></returns>
        public bool CreateFile(string filePath, string fileContent)
        {
            try
            {
                if (this.CreateDirectory(Path.GetDirectoryName(filePath)))
                {
                    Encoding code = this.defaultEncoding;
                    StreamWriter mySream = new StreamWriter(filePath, false, code);
                    mySream.WriteLine(fileContent);
                    mySream.Flush();
                    mySream.Close();
                    mySream = null;
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 删除文件夹
        /// </summary>
        /// <param name="directoryPath">文件路径</param>
        /// <returns></returns>
        public bool DeleteDirectory(string directoryPath)
        {
            try
            {
                if (Directory.Exists(directoryPath))
                {
                    Directory.Delete(directoryPath);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        public bool DeleteFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 批量删除文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        public bool DeleteFile(string[] filePath)
        {
            bool isAllDelete = true;
            for (int i = 0; i < filePath.Length; i++)
            {
                if (!this.DeleteFile(filePath[i]))
                {
                    isAllDelete = false;
                }
            }
            return isAllDelete;
        }

        /// <summary>
        /// 获取指定文件夹下所有子目录
        /// </summary>
        /// <param name="dir">指定目录</param>
        /// <param name="level">默认起始值,调用时,一般为0</param>
        public void ListFileName(string dir, int level)
        {
            try
            {
                string[] dirs = Directory.GetDirectories(dir);
                foreach (string d in dirs)
                {
                    this.directoryIndex++;
                    if (d.LastIndexOf(@"\") == -1)
                    {
                        this.fileTree.AppendLine(string.Concat(new object[] { "d.add(", this.directoryIndex, ",", level, ",'", d.Substring(d.LastIndexOf("/") + 1), "','javascript: GetFileUrl(filelist[", this.listIndex, "]);');" }));
                    }
                    else
                    {
                        this.fileTree.AppendLine(string.Concat(new object[] { "filelist[", this.listIndex, "]='", d.Replace(this.rootUrl + @"\", "").Replace(@"\", "/"), "';" }));
                        this.fileTree.AppendLine(string.Concat(new object[] { "d.add(", this.directoryIndex, ",", level, ",'", d.Substring(d.LastIndexOf(@"\") + 1), "','javascript: GetFileUrl(filelist[", this.listIndex, "]);');" }));
                    }
                    this.listIndex++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 获取指定文件夹下所有子目录
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="level"></param>
        public void ListFiles(string dir, int level)
        {
            try
            {
                string[] dirs = Directory.GetDirectories(dir);
                foreach (string d in dirs)
                {
                    this.directoryIndex++;
                    if (d.LastIndexOf(@"\") == -1)
                    {
                        this.fileTree.AppendLine(string.Concat(new object[] { "d.add(", this.directoryIndex, ",", level, ",'", d.Substring(d.LastIndexOf("/") + 1), "');" }));
                    }
                    else
                    {
                        this.fileTree.AppendLine(string.Concat(new object[] { "d.add(", this.directoryIndex, ",", level, ",'", d.Substring(d.LastIndexOf(@"\") + 1), "');" }));
                    }
                    if (Directory.Exists(d))
                    {
                        this.ListFiles(d, this.directoryIndex);
                    }
                }
                string[] files = Directory.GetFiles(dir, "*.*htm*");
                foreach (string f in files)
                {
                    this.directoryIndex++;
                    if (f.LastIndexOf(@"\") == -1)
                    {
                        this.fileTree.AppendLine(string.Concat(new object[] { "filelist[", this.listIndex, "]='", f.Replace(this.rootUrl + @"\", "").Replace(@"\", "/"), "';" }));
                        this.fileTree.AppendLine(string.Concat(new object[] { "d.add(", this.directoryIndex, ",", level, ",''", f.Substring(f.LastIndexOf("/") + 1), "','javascript: GetFileUrl(filelist[", this.listIndex, "]);');" }));
                    }
                    else
                    {
                        this.fileTree.AppendLine(string.Concat(new object[] { "filelist[", this.listIndex, "]='", f.Replace(this.rootUrl + @"\", "").Replace(@"\", "/"), "';" }));
                        this.fileTree.AppendLine(string.Concat(new object[] { "d.add(", this.directoryIndex, ",", level, ",'", f.Substring(f.LastIndexOf(@"\") + 1), "','javascript: GetFileUrl(filelist[", this.listIndex, "]);');" }));
                    }
                    this.listIndex++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 读文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public string ReadFileContent(string filePath)
        {
            return this.ReadFileContent(filePath, this.defaultEncoding);
        }

        /// <summary>
        /// 读文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public string ReadFileContent(string filePath, Encoding encoding)
        {
            try
            {
                using (StreamReader sr = new StreamReader(filePath, encoding))
                {
                    return sr.ReadToEnd();
                }
            }
            catch
            {
                return "读取文件时产生不可预知的错误。";
            }
        }

        /// <summary>
        /// 读HTML
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public static string ReadHtml(string Path)
        {
            string result = string.Empty;
            if (File.Exists(Path))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(Path, Encoding.GetEncoding("UTF-8")))
                    {
                        result = sr.ReadToEnd();
                    }
                }
                catch
                {
                }
                return result;
            }
            return "模板不存在!";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="oldName"></param>
        /// <param name="newName"></param>
        /// <param name="fileType"></param>
        /// <returns></returns>
        public bool ReNameFile(string filePath, string oldName, string newName, int fileType)
        {
            try
            {
                if (fileType.Equals(0))
                {
                    if (Directory.Exists(filePath + @"\" + oldName))
                    {
                        Directory.Move(filePath + @"\" + oldName, filePath + @"\" + newName.Replace(".", ""));
                        return true;
                    }
                    return false;
                }
                if (File.Exists(filePath + @"\" + oldName))
                {
                    File.Move(filePath + @"\" + oldName, filePath + @"\" + newName);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public static string StringToHtml(string strText)
        {
            return strText.Replace(" ", "&nbsp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\r\n", "<br />").Replace("\"", "&quot;").Replace("'", "&#39;");
        }

        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="fileContent">文件内容</param>
        /// <param name="isAppend">是否追加文件内容</param>
        /// <returns></returns>
        public bool WriteFileContent(string filePath, string fileContent, bool isAppend)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    this.CreateFile(filePath, "");
                }
                StreamWriter Fso = new StreamWriter(filePath);
                Fso.WriteLine(fileContent);
                Fso.Close();
                Fso.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

