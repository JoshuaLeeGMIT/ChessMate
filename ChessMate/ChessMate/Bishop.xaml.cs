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
	public partial class Bishop : ContentPage
	{
        private bool _revealed = false;

		public Bishop ()
		{
			InitializeComponent ();
            CreateDescription();
        }

        /* Function to populate the description label when the page loads */
        private void CreateDescription()
        {
            string s = String.Format("\tEach player begins the game with " +
                "two bishops flanking their king and queen. Bishops can " +
                "move as many tiles as the player wants, unless blocked. " +
                "This makes them fearsome opponents who can take one of " +
                "your pieces from across the board.");

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
                Movement.Source = "BishopMove.jpg";
                RevealBtn.Text = "Hide";
                _revealed = true;
            }
        }
    }
}