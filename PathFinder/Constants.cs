// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   Defines constants used within the application.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PathFinder
{
   using System.Drawing;

   /// <summary>
   /// Class that contains directional constants.
   /// </summary>
   public static class Constants
   {
      /// <summary>
      /// East direction.
      /// </summary>
      public static readonly Size E = new Size(1, 0);

      /// <summary>
      /// North direction.
      /// </summary>
      public static readonly Size N = new Size(0, -1);

      /// <summary>
      /// Northeast direction.
      /// </summary>
      public static readonly Size NE = new Size(1, -1);

      /// <summary>
      /// Northwest direction.
      /// </summary>
      public static readonly Size NW = new Size(-1, -1);

      /// <summary>
      /// South direction.
      /// </summary>
      public static readonly Size S = new Size(0, 1);

      /// <summary>
      /// Southeast direction.
      /// </summary>
      public static readonly Size SE = new Size(1, 1);

      /// <summary>
      /// Southwest direction.
      /// </summary>
      public static readonly Size SW = new Size(-1, 1);

      /// <summary>
      /// West direction.
      /// </summary>
      public static readonly Size W = new Size(-1, 0);

      /// <summary>
      /// All directions.
      /// </summary>
      public static readonly Size[] Directions = new Size[8] { NW, N, NE, E, SE, S, SW, W };
   }
}