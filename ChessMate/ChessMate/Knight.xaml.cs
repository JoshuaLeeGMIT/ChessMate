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
    public partial class Knight : ContentPage
    {
        private bool _revealed = false;

        public Knight()
        {
            InitializeComponent();
            CreateDescription();
        }

        /* Function to populate the label description when the page loads */
        private void CreateDescription()
        {
            string s = String.Format("\tThe knight gallops about the board" +
                "in an 'L' shape, e.g. three squares forward and one " +
                "square to the left. It can also hop over pieces that " +
                "are in its way. This makes it an adept early game " +
                "threat: it can bypass the mass of pawns in the mid " +
                "board and threaten your opponent's valuable pieces " +
                "on her backline.");

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
                Movement.Source = "KnightMove.jpg";
                RevealBtn.Text = "Hide";
                _revealed = true;
            }
        }
    }
}