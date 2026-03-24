using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StickyNotes
{
    public partial class Form1 : Form
    {
        private DBStickyNotesDataContext db = new DBStickyNotesDataContext();
        public Form1()
        {
            InitializeComponent();
            showStickyNotes();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            StickyNote myNewStickyNote = new StickyNote();
            myNewStickyNote.NoteText = "";

            db.StickyNotes.InsertOnSubmit(myNewStickyNote);

            db.SubmitChanges();

            showStickyNotes();
        }

        private void showStickyNotes()
        {
            flowLayoutPanelList.Controls.Clear();

            foreach (StickyNote stickyNote in db.StickyNotes)
            {
                RichTextBox rtb = new RichTextBox();
                flowLayoutPanelList.Controls.Add(rtb);
            }
        }
    }
}
/*
CREATE TABLE [dbo].[StickyNote]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [NoteText] NVARCHAR(MAX) NOT NULL
)
*/
