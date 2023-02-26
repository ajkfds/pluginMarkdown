using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using codeEditor.CodeEditor;

namespace pluginMarkdown.Data
{
    public class MarkdownFile : codeEditor.Data.TextFile
    {
        public static new MarkdownFile Create(string relativePath, codeEditor.Data.Project project)
        {
            //string id = GetID(relativePath, project);

            MarkdownFile fileItem = new MarkdownFile();
            fileItem.Project = project;
            fileItem.RelativePath = relativePath;
            if (relativePath.Contains('\\'))
            {
                fileItem.Name = relativePath.Substring(relativePath.LastIndexOf('\\') + 1);
            }
            else
            {
                fileItem.Name = relativePath;
            }

            return fileItem;
        }



        protected override codeEditor.NavigatePanel.NavigatePanelNode createNode()
        {
            return new codeEditor.NavigatePanel.TextFileNode(this);
        }

        public override codeEditor.CodeEditor.DocumentParser CreateDocumentParser(DocumentParser.ParseModeEnum parseMode)
        {
            return new Parser.Parser(this, parseMode);
        }


    }
}
