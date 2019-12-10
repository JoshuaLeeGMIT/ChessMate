using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChessMate
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Queen : ContentPage
	{
        private bool _revealed = false;

		public Queen ()
		{
			InitializeComponent ();
            CreateDescription();
        }

        /* Function to populate the description label when page loads */
        private void CreateDescription()
        {
            string s = String.Format("\tThe queen is the real mover on a " +
                "chess board. Want to move her diagonally like a bishop? " +
                "Sure. Want to move her straight like a rook? Okay. In " +
                "fact, the queen can move in any direction she likes for " +
                "as many tiles as she wants.");

            Description.Text = s;
        }

        /* Function to reveal or hide the movement map on button click */
        private void ButtonClicked(object sender, EventArgs e)
        {
            /* If map is already revealed, change to ability to hide it */
            if (_revealed)
            {
                Movement.Source = "";
                RevealBtn.Text = "Reveal more...";
                _revealed = false;
            }
            else
            {
                Movement.Source = "QueenMove.jpg";
                RevealBtn.Text = "Hide";
                _revealed = true;
            }
        }
    }
}