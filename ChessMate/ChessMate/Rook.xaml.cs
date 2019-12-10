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
	public partial class Rook : ContentPage
	{
        private bool _revealed = false;

		public Rook ()
		{
			InitializeComponent();
            CreateDescription();
		}

        /* Function to populate the description label on page load */
        private void CreateDescription()
        {
            string s = String.Format("\tThe rook starts its life in the corners " +
                "of the board. It moves in straight lines; horizontally or " +
                "vertically. Resembling the tower of a castle, the rook also " +
                "serves a unique function in chess called castling." +
                "\n\n\tCastling is a manuever where one of the two rooks crosses " +
                "over the king on the back line. It's an extremely common " +
                "move in competitive chess as it moves the king into a more " +
                "protected position. Notably, it's the only move in chess " +
                "where two pieces move simultaneously.");

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
                Movement.Source = "RookMove.jpg";
                RevealBtn.Text = "Hide";
                _revealed = true;
            }
        }
    }
}