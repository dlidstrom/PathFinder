// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   Defines the IView interface. This is used in a simple model-view-presenter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PathFinder.Interfaces
{
   using System.Drawing;
   using System.Windows.Forms;

   /// <summary>
   /// Defines the view of the application.
   /// </summary>
   public interface IView
   {
      /// <summary>
      /// Gets or sets the presenter used to control the view.
      /// </summary>
      Presenter Presenter
      {
         get;
         set;
      }

      /// <summary>
      /// Redraw view.
      /// </summary>
      void Redraw();

      /// <summary>
      /// Set drawing surface. This is a bitmap.
      /// </summary>
      /// <param name="bitmap">Drawing surface</param>
      void SetDrawing(Bitmap bitmap);

      /// <summary>
      /// Display an error message.
      /// </summary>
      /// <param name="message">Message to display</param>
      void Error(string message);

      /// <summary>
      /// Set cursor.
      /// </summary>
      /// <param name="cursor">Cursor to show</param>
      void ShowCursor(Cursor cursor);
   }
}