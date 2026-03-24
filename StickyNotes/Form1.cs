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
                rtb.Tag = stickyNote;
                rtb.Text = stickyNote.NoteText;

                rtb.TextChanged += Rtb_TextChanged;
                rtb.MouseDown += Rtb_MouseDown;
                flowLayoutPanelList.Controls.Add(rtb);
            }
        }

        private void Rtb_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (sender is RichTextBox)
                {
                    RichTextBox rtb = sender as RichTextBox;
                    if (rtb.Tag is StickyNote)
                    {
                        StickyNote myStickyNote = rtb.Tag as StickyNote;
                        if (MessageBox.Show($"Are you sure you want to delete the sticyNote '{myStickyNote.NoteText}'?",
                                            "Confirm Deletion",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            db.StickyNotes.DeleteOnSubmit(myStickyNote);
                            db.SubmitChanges();
                            showStickyNotes();
                        }
                    }
                }
            }
        }

        private void Rtb_TextChanged(object sender, EventArgs e)
        {
            if(sender is RichTextBox)
            {
                RichTextBox rtb = sender as RichTextBox;
                if(rtb.Tag is StickyNote)
                {
                    StickyNote myStickyNote = rtb.Tag as StickyNote;
                    myStickyNote.NoteText = rtb.Text;
                    db.SubmitChanges();
                    //showStickyNotes();
                }
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
