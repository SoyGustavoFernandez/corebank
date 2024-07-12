using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using form = System.Windows.Forms;
using Word= Microsoft.Office.Interop.Word;

namespace GEN.LibreriaOffice
{
    public class WordHandler
    {
        private Object oMissing = System.Reflection.Missing.Value;
        //OBJECTS OF FALSE AND TRUE
        private Object oTrue = true;
        private Object oFalse = false;
        public void KillApp()
        {
            System.Diagnostics.Process[] p = System.Diagnostics.Process.GetProcessesByName("WINWORD");
            for (int i = 0; i < p.Length; i++)
            {
                try
                {
                    p[i].Kill();
                }
                catch (Exception ex)
                {
                    if (ex.Message.ToLower().Contains("access is denied"))
                        continue;
                }
            }
        }

        public void Print(ref Word.Document oWordDoc)
        {
            object copies = "1";
            object pages = "";
            object range = Word.WdPrintOutRange.wdPrintAllDocument;
            object items = Word.WdPrintOutItem.wdPrintDocumentContent;
            object pageType = Word.WdPrintOutPages.wdPrintAllPages;
            object oTrue = true;
            object oFalse = false;
            Object missing = System.Reflection.Missing.Value;
            oWordDoc.PrintOut(ref oTrue, ref oFalse, ref range, ref missing, ref missing, ref missing,
                         ref items, ref copies, ref pages, ref pageType, ref oFalse, ref oTrue,
                         ref missing, ref oFalse, ref missing, ref missing, ref missing, ref missing);
        }

        public void CreateWord(String filename, out Word.Application oWord, out Word.Document oWordDoc)
        {
            KillApp();
            //CREATING OBJECTS OF WORD AND DOCUMENT
            oWord = new Word.Application();
            oWord.Visible = true;
            oWordDoc = new Word.Document();
            oWord.Visible = true;
            //MAKING THE APPLICATION VISIBLE
            // oWord.Visible = true;
            //ADDING A NEW DOCUMENT TO THE APPLICATION
            // oworddoc = oword.documents.add(ref omissing, ref omissing, ref omissing, ref omissing);
            object isVisible = true;
            Object oSaveAsFile = (Object)filename;
            oWordDoc = oWord.Documents.Open(ref oSaveAsFile, ref oMissing, ref oMissing, ref oMissing,
                   ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                   ref oMissing, ref oMissing, ref isVisible, ref oMissing, ref oMissing
                  , ref oMissing, ref oMissing);
        }

        public void SaveFile(String fileName, ref Word.Application oWord,
                                              ref Word.Document oWordDoc, Boolean delete)
        {
            Object oSaveAsFile = (Object)fileName;
            if (delete)
            {
                if (System.IO.File.Exists(fileName))
                    System.IO.File.Delete(fileName);
            }
            else
                oSaveAsFile = (Object)(fileName + DateTime.Now.Second.ToString());
            oWordDoc.SaveAs(ref oSaveAsFile, ref oMissing, ref oMissing, ref oMissing,
                            ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                            ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                             ref oMissing, ref oMissing);
        }

        public void CreateWordBasedOnTemplate(String filename, String basedOn,
                                       out Word.Application oWord, out Word.Document oWordDoc)
        {
            //CREATING OBJECTS OF WORD AND DOCUMENT
            oWord = new Word.Application();
            oWordDoc = new Word.Document();
            //MAKING THE APPLICATION VISIBLE
            // oWord.Visible = true;
            //ADDING A NEW DOCUMENT TO THE APPLICATION
            //oWordDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            Object oFilePath = basedOn;
            oWordDoc = oWord.Documents.Add(ref oFilePath, ref oMissing, ref oMissing, ref oTrue);
            //oWordDoc.Bookmarks.get_Item(ref oBookMark).Range.InsertFile(
            //       oFilePath, ref oMissing, ref oFalse, ref oFalse, ref oFalse);
            Object oSaveAsFile = (Object)filename;
            oWordDoc.SaveAs(ref oSaveAsFile, ref oMissing, ref oMissing, ref oMissing,
                     ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                     ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                     ref oMissing, ref oMissing);
        }

        public void FindAndReplace(Word.Application oWord, object findText, object replaceText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundsLine = false;
            object nmatchAllWordForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiacritics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;
            oWord.Selection.Find.Execute(ref findText, ref matchCase, ref matchWholeWord,
                       ref matchWildCards, ref matchSoundsLine,
                       ref nmatchAllWordForms, ref forward, ref wrap, ref format, ref replaceText, ref replace,
                       ref matchKashida, ref matchDiacritics, ref matchAlefHamza, ref matchControl);
        }
    }

}
