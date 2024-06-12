using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookReaderApp
{
    public partial class InfoForm : Form
    {
        readonly BookDetails bookDetails;
        readonly string author;
        readonly string title;
        public InfoForm(BookDetails bookDetails, string author, string title)
        {
            InitializeComponent();
            this.bookDetails = bookDetails;
            this.author = author;
            this.title = title;

            descriptionLabel.MaximumSize = new Size(650, 0);
            descriptionLabel.AutoSize = true;
        }

        private void InfoForm_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;

            ControlBox = false;

            StartPosition = FormStartPosition.CenterScreen;

            authorLabel.Text += author;
            titleLabel.Text += title;
            genreLabel.Text += bookDetails.Genre;
            releaseYearLabel.Text += bookDetails.ReleaseYear.ToString();
            descriptionLabel.Text += bookDetails.Description;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Hide();
            this.Close();
        }
    }
}
