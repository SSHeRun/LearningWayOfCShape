using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Collections.ObjectModel;

namespace ReadShpStepByStep
{
    class ReadAndWriteXml
    {
        public static void CreateXmlFile(string xmlName, int folderCount, int filesCount)
        {
            XmlDocument filesXml = new XmlDocument();
            if (!File.Exists(xmlName))
            {
                //添加XML文件的申明
                XmlDeclaration xmlDec = filesXml.CreateXmlDeclaration("1.0", "gb2312", null);
                filesXml.AppendChild(xmlDec);
                //添加根节点
                XmlElement xmlElement = filesXml.CreateElement("Infomation");
                filesXml.AppendChild(xmlElement);
                //选中当前节点
                XmlNode node = filesXml.SelectSingleNode("Infomation");

                xmlElement = filesXml.CreateElement("Folder");
                XmlElement xmlElement1 = filesXml.CreateElement("FolderCount");
                xmlElement1.InnerText = folderCount.ToString();
                xmlElement.AppendChild(xmlElement1);
                node.AppendChild(xmlElement);

                xmlElement = filesXml.CreateElement("Files");
                xmlElement1 = filesXml.CreateElement("FilesCount");
                xmlElement1.InnerText = filesCount.ToString();
                xmlElement.AppendChild(xmlElement1);
                node.AppendChild(xmlElement);
                filesXml.Save(xmlName);
            }
        }
        public static void WriteFolderOrFileToXml(string xmlName, string folderOrFileName, int typeFolderOrFile)
        {

            XmlDocument filesXml = new XmlDocument();
            filesXml.Load(xmlName);

            XmlNode root = filesXml.SelectSingleNode("Infomation");
            XmlNode folderRoot = root.SelectSingleNode("Folder");
            int folderCount = Convert.ToInt32(folderRoot.SelectSingleNode("FolderCount").InnerText);
            XmlNode fileRoot = root.SelectSingleNode("Files");
            int filesCount = Convert.ToInt32(fileRoot.SelectSingleNode("FilesCount").InnerText);
            int count = 0;
            XmlNode folderOrFileRoot = fileRoot;//赋不用值
            root = filesXml.SelectSingleNode("Infomation");
            //保存文件夹路径
            
            if (typeFolderOrFile == 1)
            {
                folderOrFileRoot = root.SelectSingleNode("Folder");
                count = folderCount;
            }
            //保存文件路径
            if (typeFolderOrFile == 2)
            {
                folderOrFileRoot = root.SelectSingleNode("Files");
                count = filesCount;
            }
            XmlNodeList nodeList = folderOrFileRoot.SelectNodes("List");
            foreach (XmlNode node in nodeList)
            {//保证最近使用过的文件在后后面
                if (node.InnerText == folderOrFileName)
                {
                    folderOrFileRoot.RemoveChild(node);
                    folderOrFileRoot.AppendChild(node);
                    filesXml.Save(xmlName);
                    return;
                }
            }
            if (nodeList.Count < count)
            {
                XmlElement xmlElement2 = filesXml.CreateElement("List");
                xmlElement2.InnerText = folderOrFileName;
                fileRoot.AppendChild(xmlElement2);
            }
            else
            {//保证节点先后次序
                fileRoot.RemoveAll();
                for (int i = 1; i <= nodeList.Count - 1; i++)
                {
                    fileRoot.AppendChild(nodeList[i]);
                }
                XmlElement xmlElement2 = filesXml.CreateElement("List");
                xmlElement2.InnerText = folderOrFileName;
                fileRoot.AppendChild(xmlElement2);
            }
            filesXml.Save(xmlName);
        }
        public static Collection<string> LoadFileOrFolderName(string xmlName, int typeFolderOrFile)
        {
            Collection<string> names = new Collection<string>();
            XmlDocument filesXml = new XmlDocument();
            filesXml.Load(xmlName);
            XmlNode root = filesXml.SelectSingleNode("Infomation");
            XmlNode folderRoot = root;
            if (typeFolderOrFile == 1)
            {
                 folderRoot = root.SelectSingleNode("Folder");              
            }
            else
            {
                 folderRoot = root.SelectSingleNode("Files");               
            }
            XmlNodeList nodeList = folderRoot.SelectNodes("List");
            foreach (XmlNode node in nodeList)
            {
                names.Add(node.InnerText);
            }
            return names;
        }
    }
}
