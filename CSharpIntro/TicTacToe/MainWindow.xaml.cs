using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
// Tutorial - https://www.youtube.com/watch?v=mnTyiUAHuVk&list=PLrW43fNmjaQXhWOKalftye87ObZA-xNIJ&index=9

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

            // change noughts to green
            if (!_player1Turn)
                button.Foreground = Brushes.Red;

            // toggle player turn
            _player1Turn ^= true;

            CheckForStale();
            CheckForWinner();

        }

        /// <summary>
        /// Check for stale-mate / no more turns possible / tie-game
        /// </summary>
        private void CheckForStale()
        {
            #region Check zero sum game
            // check for zero move left
            if (!_results.Any(single_result => single_result == MarkType.Free))
            {
                // set game state to gameover
                _gameOver = true;

                // set cells to inidicate stale game
                Container.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    // set defaults for new game
                    button.Background = Brushes.Orange;
                });

            }
            #endregion
        }

        /// <summary>
        /// Check for possible win pattern
        /// </summary>
        private void CheckForWinner()
        {
            var winnerBrush = Brushes.GreenYellow;

            #region Check Row
            // Row 1 for winner
            if (_results[0] != MarkType.Free && (_results[0] & _results[1] & _results[2]) == _results[0])
            {
                // set gameover
                _gameOver = true;

                // highlight winning cells in green
                Button0_0.Background = Button1_0.Background = Button2_0.Background = winnerBrush;
            }
            // Row 2 for winner
            if (_results[3] != MarkType.Free && (_results[3] & _results[4] & _results[5]) == _results[3])
            {
                // set gameover
                _gameOver = true;

                // highlight winning cells in green
                Button0_1.Background = Button1_1.Background = Button2_1.Background = winnerBrush;
            }
            // Row 3 for winner
            if (_results[6] != MarkType.Free && (_results[6] & _results[7] & _results[8]) == _results[6])
            {
                // set gameover
                _gameOver = true;

                // highlight winning cells in green
                Button0_2.Background = Button1_2.Background = Button2_2.Background = winnerBrush;
            }
            #endregion

            #region Check Column
            // Column 1 for winner
            if (_results[0] != MarkType.Free && (_results[0] & _results[3] & _results[6]) == _results[0])
            {
                // set gameover
                _gameOver = true;

                // highlight winning cells in green
                Button0_0.Background = Button0_1.Background = Button0_2.Background = winnerBrush;
            }
            // Column 2 for winner
            if (_results[1] != MarkType.Free && (_results[1] & _results[4] & _results[7]) == _results[1])
            {
                // set gameover
                _gameOver = true;

                // highlight winning cells in green
                Button1_0.Background = Button1_1.Background = Button1_2.Background = winnerBrush;
            }
            // Column 3 for winner
            if (_results[2] != MarkType.Free && (_results[2] & _results[5] & _results[8]) == _results[2])
            {
                // set gameover
                _gameOver = true;

                // highlight winning cells in green
                Button2_0.Background = Button2_1.Background = Button2_2.Background = winnerBrush;
            }
            #endregion

            #region Check Diagonal
            // TODO:

            // Top left - bottom right
            if (_results[0] != MarkType.Free && (_results[0] & _results[4] & _results[8]) == _results[0])
            {
                // set gameover
                _gameOver = true;

                // highlight winning cells in green
                Button0_0.Background = Button1_1.Background = Button2_2.Background = winnerBrush;
            }

            // Top right - bottom left
            if (_results[2] != MarkType.Free && (_results[2] & _results[4] & _results[6]) == _results[2])
            {
                // set gameover
                _gameOver = true;

                // highlight winning cells in green
                Button0_2.Background = Button1_1.Background = Button2_0.Background = winnerBrush;
            }
            #endregion

        }
    }
}
