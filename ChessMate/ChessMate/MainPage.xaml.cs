using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChessMate
{
    public partial class MainPage : ContentPage
    {
        /* Entry will always be in the last row */
        private const int ENTRY_ROW = 6;

        /* A 2D array of the piece titles and a short blurb for each */
        private static string[,] _pieces =
        {
            { "Pawn", "the foot soldier" },
            { "Bishop", "the diagonal mover" },
            { "Knight", "the galloping threat" },
            { "Rook", "the straightfoward powerhouse" },
            { "Queen", "the black widow" },
            { "King", "the head honcho"},
        };

        public MainPage()
        {
            InitializeComponent();
            CreateOverview();
            CreateEntry();
        }

        private void ListTapped(object sender, EventArgs e)
        {
            /* Get the row that the user clicked on */
            int row = (int)((StackLayout)sender).GetValue(Grid.RowProperty);

            /* Switch based on the string in index[row, 0] that the user clicked on */
            switch (_pieces[row, 0])
            {
                case "Bishop":
                    /* Navigate to the correct page */
                    Navigation.PushAsync(new Bishop());
                    break;
                case "King":
                    Navigation.PushAsync(new King());
                    break;
                case "Knight":
                    Navigation.PushAsync(new Knight());
                    break;
                case "Pawn":
                    Navigation.PushAsync(new Pawn());
                    break;
                case "Queen":
                    Navigation.PushAsync(new Queen());
                    break;
                case "Rook":
                    Navigation.PushAsync(new Rook());
                    break;
            }
        }

        private void CreateOverview()
        {
            /* Loop to create a StackLayout for each chess piece */
            for (int i = 0; i < _pieces.GetLength(0); ++i)
            {
                StackLayout listBox = new StackLayout();
                Image img = new Image();
                Label descr = new Label();
                TapGestureRecognizer t = new TapGestureRecognizer();

                /* Set up a StackLayout */
                listBox.HeightRequest = 90;
                listBox.WidthRequest = 640;
                listBox.Orientation = StackOrientation.Horizontal;
                listBox.HorizontalOptions = LayoutOptions.Center;
                listBox.VerticalOptions = LayoutOptions.Center;
                listBox.Margin = 4;
                listBox.SetValue(Grid.RowProperty, i);
                listBox.SetValue(Grid.ColumnProperty, 0);

                /* Set up the image to be included in each StackLayout */
                img.HeightRequest = 90;
                img.WidthRequest = 90;
                img.HorizontalOptions = LayoutOptions.Start;
                img.Source =  _pieces[i, 0] + ".png";
                img.Margin = 4;

                /* Set up the description text for each StackLayout */
                descr.Text = _pieces[i, 0] + ": " + _pieces[i, 1];
                descr.TextColor = Color.Black;
                descr.FontSize = 32;
                descr.HorizontalOptions = LayoutOptions.StartAndExpand;
                descr.VerticalOptions = LayoutOptions.Center;
                descr.Margin = 4;

                /* Add the image and the description into the StackLayout */
                listBox.Children.Add(img);
                listBox.Children.Add(descr);
                /* Add the StackLayout into the grid "List" */
                List.Children.Add(listBox);

                /* Add a clicked event to each StackLayout */
                t.Tapped += ListTapped;
                listBox.GestureRecognizers.Add(t);
            }
        }

        private void CreateEntry()
        {
            Entry e = new Entry();

            /* If the user has already saved their favourite piece, load it in */
            if (File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "favourite.txt")))
            {
                String path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "favourite.txt");
                StreamReader f = new StreamReader(path, true);
                string favourite = f.ReadLine();

                CurFave.Text = "Your favourite chess piece is the " + favourite;
            }

            /* Set up the entry box for entering favourite piece */
            e.Placeholder = "Enter your favourite chess piece...";
            e.Completed += GetEntry;
            e.SetValue(Grid.RowProperty, ENTRY_ROW);
            e.SetValue(Grid.ColumnProperty, 0);
            e.HorizontalOptions = LayoutOptions.Center;
            e.VerticalOptions = LayoutOptions.Center;

            Overview.Children.Add(e);
        }

        /* Short function to determine if the entered string is a valid chess piece */
        private bool IsPiece(string s)
        {
            for (int i = 0; i < _pieces.GetLength(0); ++i)
            {
                /* Ignore case to be more user friendly */
                if (s.Equals(_pieces[i, 0], StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }

            return false;
        }

        /* Function to get the entered text from entry and save it as the user's favourite piece */
        private void GetEntry(object sender, EventArgs e)
        {
            string s = ((Entry)sender).Text;
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "favourite.txt");
            StreamWriter file = new StreamWriter(path, true);

            /* Check if string entered is a valid chess piece */
            if (!IsPiece(s))
            {
                /* If not, display alert and exit function */
                DisplayAlert("Alert", s + " is not a valid chess piece", "OK");
                file.Close();
                return;
            }

            /* Otherwise, display the favourite piece */
            CurFave.Text = "Your favourite chess piece is the " + s;
            /* Display alert confirming that the piece will be saved to file */
            DisplayAlert("Alert", "Your favourite piece has been saved to " + path, "OK");
            
            /* Write favourite piece to file */
            file.WriteLine(s);
            file.Close();
        }
    }
}
