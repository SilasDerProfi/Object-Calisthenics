using System.Windows.Forms;

namespace OC_MS
{
    public partial class Cell : Button
    {
        private readonly int _neighbourMines;
        private bool _isMarked;
        public Cell(int neighbourMines) : base()
        {
            _neighbourMines = neighbourMines;
            MouseUp += OnRightclick;
            Click += OnLeftclick;
        }

        private void OnRightclick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            _isMarked = !_isMarked;
            (Parent as Game)?.UpdateAmount(_isMarked);
            SetApperance();
        }

        private void OnLeftclick(object sender, System.EventArgs e)
        {
            SetApperance(true);
            Enabled = false;
            
            if (_neighbourMines == -1) MessageBox.Show("You lost.");

            if (_neighbourMines == 0) (Parent as Game)?.RevealNeighbours(Name);
        }

        private void SetApperance(bool revealed = false)
        {
            if (_isMarked) BackgroundImage = OC_MS.Properties.Resources.flag;

            if (_neighbourMines == -1 && revealed) BackgroundImage = OC_MS.Properties.Resources.mine;

            if (_neighbourMines >= 0 && revealed)
            {
                BackgroundImage = null;
                Text = GetText();
            }
        }

        private string GetText() => _neighbourMines > 0 ? $"{_neighbourMines}" : "";
    }
}