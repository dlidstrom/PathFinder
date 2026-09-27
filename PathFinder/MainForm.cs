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
      /// Surface containing paths.
      /// </summary>
      private Surface? Surface;

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
      /// Set drawing surface.
      /// </summary>
      /// <param name="surface">Drawing surface</param>
      public void SetDrawing(Surface surface)
      {
         this.Surface = surface;
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
         if (this.Surface == null)
         {
            return;
         }

         // paint the surface
         using (var graphics = this.CreateGraphics())
         using (var bitmap = this.ToBitmap(this.Surface))
         {
            graphics.DrawImage(bitmap, 0, 0);
         }
      }

      /// <summary>
      /// Converts a surface to a bitmap.
      /// </summary>
      /// <param name="surface">Surface to convert</param>
      /// <returns>Bitmap</returns>
      private Bitmap ToBitmap(Surface surface)
      {
         var bitmap = new Bitmap(surface.Width, surface.Height);
         for (int x = 0; x < surface.Width; x++)
         {
            for (int y = 0; y < surface.Height; y++)
            {
               bitmap.SetPixel(x, y, surface.GetPixel(x, y));
            }
         }

         return bitmap;
      }
   }
}
