namespace PathFinder.Test
{
   using System.Drawing;

   using NUnit.Framework;
   using System;
   using System.Linq;

   [TestFixture]
   public class AStarPathFinderTest
   {
      [Test]
      public void ShouldAvoidPixel()
      {
         var surface = SurfaceFactory.CreateSurface(10, 10);
         var astar = new AStarPathFinder(surface);
         surface.SetPixel(5, 5, Color.Black);
         Path? path = astar.FindPath(new Point(3, 3), new Point(7, 7));
         Assert.That(path?.Count, Is.EqualTo(8));
      }

      [Test]
      public void ShouldFindStraightLine()
      {
         var surface = SurfaceFactory.CreateSurface(10, 10);
         var astar = new AStarPathFinder(surface);
         Path? path = astar.FindPath(new Point(5, 5), new Point(7, 7));
         Assert.That(path?.Count, Is.EqualTo(3));
      }

      [Test]
      public void ShouldGoAround()
      {
         var surface = SurfaceFactory.CreateSurface(10, 10);
         surface.SetPixel(4, 4, Color.Black);
         surface.SetPixel(5, 4, Color.Black);
         surface.SetPixel(6, 4, Color.Black);
         var astar = new AStarPathFinder(surface);
         Path? path = astar.FindPath(new Point(5, 7), new Point(5, 2));
         Assert.That(path?.Count, Is.EqualTo(9));
      }

      [Test]
      public void ShouldGoAroundWithoutTwisting()
      {
         var surface = SurfaceFactory.CreateSurface(400, 400);
         for (int y = 156; y <= 165; y++)
         {
            surface.SetPixel(174, y, Color.Black);
         }

         var astar = new AStarPathFinder(surface);
         Path? path = astar.FindPath(new Point(179, 161), new Point(169, 161));
         Assert.That(path?.Count, Is.EqualTo(15));
      }
   }
}
