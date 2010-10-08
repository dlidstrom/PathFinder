// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   Defines the Presenter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PathFinder
{
   using System.Drawing;
   using System.Windows.Forms;
   using Interfaces;

   /// <summary>
   /// Mouse state enumerator.
   /// </summary>
   public enum MouseState
   {
      /// <summary>
      /// Default state is when no clicks have been made
      /// </summary>
      Default,

      /// <summary>
      /// Point state is when there has been a point selected
      /// </summary>
      Point
   }

   /// <summary>
   /// Presenter class handles logic within the main form.
   /// </summary>
   public class Presenter
   {
      /// <summary>
      /// Height of the bitmap surface.
      /// </summary>
      private const int Height = 400;

      /// <summary>
      /// Width of the bitmap surface.
      /// </summary>
      private const int Width = 400;

      /// <summary>
      /// Path finder factory service.
      /// </summary>
      private readonly IPathFinderFactory Factory;

      /// <summary>
      /// Bitmap surface.
      /// </summary>
      private readonly Bitmap Surface = SurfaceFactory.CreateSurface(Width, Height);

      /// <summary>
      /// View that the user interacts with.
      /// </summary>
      private readonly IView View;

      /// <summary>
      /// The current mouse state.
      /// </summary>
      private MouseState CurrentMouseState;

      /// <summary>
      /// Initializes a new instance of the Presenter class.
      /// </summary>
      /// <param name="view">View interface</param>
      /// <param name="factory">Path finder factory service</param>
      public Presenter(IView view, IPathFinderFactory factory)
      {
         this.View = view;
         this.View.Presenter = this;
         this.View.SetDrawing(this.Surface);
         this.CurrentMouseState = MouseState.Default;
         this.Factory = factory;
      }

      /// <summary>
      /// Gets or sets the start point.
      /// </summary>
      private Point StartPoint
      {
         get;
         set;
      }

      /// <summary>
      /// Gets or sets the endpoint.
      /// </summary>
      private Point EndPoint
      {
         get;
         set;
      }

      /// <summary>
      /// Called when the user has clicked in the view.
      /// </summary>
      /// <param name="button">Mouse button used to click</param>
      /// <param name="point">Point location of click</param>
      public void OnClick(MouseButtons button, Point point)
      {
         if (button == MouseButtons.Left)
         {
            switch (this.CurrentMouseState)
            {
               case MouseState.Default:
               {
                  this.StartPoint = point;
                  this.CurrentMouseState = MouseState.Point;
                  break;
               }
               case MouseState.Point:
               {
                  // time to construct a path
                  this.EndPoint = point;

                  // create a new path finder
                  var pathFinder = this.Factory.CreatePathFinder(this.Surface);

                  // set cursor mode to the wait cursor while we find a path
                  this.View.ShowCursor(Cursors.WaitCursor);

                  // now find the path from start point to end point
                  var path = pathFinder.FindPath(this.StartPoint, this.EndPoint);

                  // set cursor back to default cursor
                  this.View.ShowCursor(Cursors.Default);

                  if (path == null)
                  {
                     // no path was found, show an error message
                     this.View.Error(
                           string.Format("Could not create path between {0} and {1}", this.StartPoint, this.EndPoint));
                  }
                  else
                  {
                     // path was found, turn on every pixel in path
                     foreach (var pt in path)
                     {
                        this.Surface.SetPixel(pt.X, pt.Y, Color.Black);
                     }
                  }

                  // set state back to default
                  this.CurrentMouseState = MouseState.Default;

                  // redraw view
                  this.View.Redraw();
                  break;
               }
            }
         }
         else if (button == MouseButtons.Right)
         {
            // right mouse button cancels first point
            this.CurrentMouseState = MouseState.Default;
         }
      }
   }
}