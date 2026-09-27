module PathFinder.Test.AStarSpecs

open System.Drawing
open Sprout

let countOf (path: PathFinder.Path) =
   if isNull path then 0 else path.Count

let aStarTests =
   describe "AStar path finder" {

      it "should avoid pixel" {
         let surface = PathFinder.SurfaceFactory.CreateSurface(10, 10)
         let astar = new PathFinder.AStarPathFinder(surface)
         surface.SetPixel(5, 5, Color.Black)
         let path = astar.FindPath(Point(3, 3), Point(7, 7))
         path |> countOf |> shouldEqual 8
      }

      it "should find straight line" {
         let surface = PathFinder.SurfaceFactory.CreateSurface(10, 10)
         let astar = new PathFinder.AStarPathFinder(surface)
         let path = astar.FindPath(Point(5, 5), Point(7, 7))
         path |> countOf |> shouldEqual 3
      }

      it "should go around" {
         let surface = PathFinder.SurfaceFactory.CreateSurface(10, 10)
         surface.SetPixel(4, 4, Color.Black)
         surface.SetPixel(5, 4, Color.Black)
         surface.SetPixel(6, 4, Color.Black)
         let astar = new PathFinder.AStarPathFinder(surface)
         let path = astar.FindPath(Point(5, 7), Point(5, 2))
         path |> countOf |> shouldEqual 9
      }

      it "should go around without twisting" {
         let surface = PathFinder.SurfaceFactory.CreateSurface(400, 400)
         [156..165] |> List.iter (fun y -> surface.SetPixel(174, y, Color.Black))
         let astar = new PathFinder.AStarPathFinder(surface)
         let path = astar.FindPath(Point(179, 161), Point(169, 161))
         path |> countOf |> shouldEqual 15
      }
   }