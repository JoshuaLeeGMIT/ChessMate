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
	public partial class Pawn : ContentPage
	{
        private bool _revealed = false;

		public Pawn ()
		{
			InitializeComponent ();
            CreateDescription();
        }

        /* Function to populate the description label when page loads */
        private void CreateDescription()
        {
            string s = String.Format("\tThe pawn is the foot soldier of " +
                "your army. It is typically the first piece to move, and " +
                "the least important to protect.\n\n\tHowever, the " +
                "formation you arrange your pawns in can prove decisive " +
                "in taking your opponent down. Pawns that protect each " +
                "other are strong. Furthermore, pawns posess a unique " +
                "property: if they manage to make it to the opposite " +
                "end of the board, they can be transformed into a queen. " +
                "Then, they can pose a real threat.");

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
                Movement.Source = "PawnMove.jpg";
                RevealBtn.Text = "Hide";
                _revealed = true;
            }
        }
    }
}