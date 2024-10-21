// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   Defines the MainForm type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PathFinder
{
   using System.Drawing;
   using System.Windows.Forms;
   using Interfaces;

   /// <summary>
   /// The main form class.
   /// </summary>
   public partial class MainForm : Form, IView
   {
      /// <summary>
      /// Bitmap containing paths.
      /// </summary>
      private Bitmap? Bitmap;

      /// <summary>
      /// Initializes a new instance of the Mainform class.
      /// </summary>
      /// <param name="factory">Path finder factory</param>
      public MainForm(IPathFinderFactory factory)
      {
         this.InitializeComponent();
         this.Presenter = new Presenter(this, factory);
      }

      /// <summary>
      /// Gets or sets the presenter.
      /// </summary>
      public Presenter Presenter
      {
         get;
         set;
      }

      /// <summary>
      /// Display an error message.
      /// </summary>
      /// <param name="message">Message to show</param>
      public void Error(string message)
      {
         MessageBox.Show(message);
      }

      /// <summary>
      /// Redraw this form.
      /// </summary>
      public void Redraw()
      {
         this.Invalidate(true);
      }

      /// <summary>
      /// Set bitmap drawing.
      /// </summary>
      /// <param name="bitmap">Bitmap drawing</param>
      public void SetDrawing(Bitmap bitmap)
      {
         this.Bitmap = bitmap;
      }

      /// <summary>
      /// Set the cursor to display.
      /// </summary>
      /// <param name="cursor">Cursor kind</param>
      public void ShowCursor(Cursor cursor)
      {
         this.Cursor = cursor;
      }

      /// <summary>
      /// Called when the user clicks this form.
      /// </summary>
      /// <param name="sender">Sender object</param>
      /// <param name="e">Mouse event arguments</param>
      private void OnClick(object sender, MouseEventArgs e)
      {
         this.Presenter.OnClick(e.Button, e.Location);
      }

      /// <summary>
      /// Called when the form is painted.
      /// </summary>
      /// <param name="sender">Sender object</param>
      /// <param name="e">Paint event arguments</param>
      private void OnPaint(object sender, PaintEventArgs e)
      {
         // paint the bitmap
         using (var graphics = this.CreateGraphics())
         {
            graphics.DrawImage(this.Bitmap, 0, 0);
         }
      }
   }
}
