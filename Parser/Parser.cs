using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pluginMarkdown.Parser
{
    public class Parser : codeEditor.CodeEditor.DocumentParser
    {
        public Parser(Data.MarkdownFile file, codeEditor.CodeEditor.DocumentParser.ParseModeEnum parseMode) : base(file, parseMode)
        {
        }

        public override void Parse()
        {
            for(int line = 1; line<document.Lines; line++)
            {
                string lineText = document.CreateString(document.GetLineStartIndex(line), document.GetLineLength(line));
                if (lineText.StartsWith("#"))
                {
                    colorLine(Style.Color.Comment,line);
                }
            }
        }

        private void colorLine(Style.Color color,int line)
        {
            int start = document.GetLineStartIndex(line);
            int end = start + document.GetLineLength(line);
            for (int i = start; i < end; i++)
            {
                document.SetColorAt(i, (byte)color);
            }
        }
    }
}
