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
        public Form1()
        {
            InitializeComponent();
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
