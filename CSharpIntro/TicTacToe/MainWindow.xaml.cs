using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor
        public MainWindow()
        {
            InitializeComponent();

            NewGame();
        }

        #endregion

        #region Private Members

        /// <summary>
        /// Holds current result of the active game
        /// </summary>
        private MarkType[] _results;

        /// <summary>
        /// True if its player 1's turn
        /// </summary>
        private bool _player1Turn;

        /// <summary>
        /// True if the game is stale, won, or lost
        /// </summary>
        private bool _gameOver;

        #endregion

        /// <summary>
        /// Sets the stage for a new game
        /// </summary>
        private void NewGame()
        {
            // create a new array for game cell
            _results = new MarkType[9];

            // set cell value to Free
            for (var i = 0; i < _results.Length; i++)
                _results[i] = MarkType.Free;

            // set player 1 turn
            _player1Turn = true;

            // iterate every button on the grid
            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                // set defaults for new game
                button.Content = String.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Blue;
            });

            // reset game status
            _gameOver = false;
        }

        /// <summary>
        /// Handles button clicks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button0_0_Click(object sender, RoutedEventArgs e)
        {
            // start a new game if button is clicked when game is over
            if (_gameOver)
            {
                NewGame();
                return;
            }

            // cast sender to button
            var button = (Button)sender;

            // find button position in array
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row * 3);

            // dont do anything if the cell has a value in it already
            if (_results[index] != MarkType.Free)
                return;

            // set the cell value based on the player
            if (_player1Turn)
                _results[index] = MarkType.Cross;
            else
                _results[index] = MarkType.Nought;

            // set button text content
            button.Content = _player1Turn ? "X" : "O";

            // toggle player turn
            _player1Turn ^= true;

        }
    }
}
