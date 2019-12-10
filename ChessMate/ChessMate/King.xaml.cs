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
	public partial class King : ContentPage
	{
        private bool _revealed = false;

		public King ()
		{
			InitializeComponent ();
            CreateDescription();
        }

        /* Function to populate the label description when the page loads */
        private void CreateDescription()
        {
            string s = String.Format("\tThe king is the most important " +
                "piece on the board. If your king is taken by your " +
                "oppenent, you lose. If your king is under attack by an " +
                "opposing piece, you must alleviate that pressure. This is " +
                "called a check. Competitive chess players are adept at " +
                "keeping their king safe.\n\n\tWhile important, the king " +
                "has a very limited movement range. It can move in any " +
                "direction it wishes, but only one tile at a time.");

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
                Movement.Source = "KingMove.jpg";
                RevealBtn.Text = "Hide";
                _revealed = true;
            }
        }
    }
}