using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookReaderApp.Forms
{
    public partial class ReaderForm : Form
    {
        public ReaderForm(string filename)
        {
            InitializeComponent();
            
            pdfViewer1.LoadFromFile(filename);
        }

        private void ReaderForm_Load(object sender, EventArgs e)
        {
        }
    }
}
