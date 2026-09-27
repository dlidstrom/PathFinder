module PathFinder.Test.IdaSpecs

open System.Drawing
open Sprout

let countOf (path: PathFinder.Path) =
   if isNull path then 0 else path.Count

let idaTests =
   describe "IDA path finder" {

      it "should avoid pixel" {
         let surface = PathFinder.SurfaceFactory.CreateSurface(10, 10)
         let ida = new PathFinder.Ida(surface)
         surface.SetPixel(5, 5, Color.Black)
         let path = ida.FindPath(Point(3, 3), Point(7, 7))
         path |> countOf |> shouldEqual 8
      }

      it "should find straight line" {
         let surface = PathFinder.SurfaceFactory.CreateSurface(10, 10)
         let ida = new PathFinder.Ida(surface)
         let path = ida.FindPath(Point(5, 5), Point(7, 7))
         path |> countOf |> shouldEqual 3
      }

      it "should go around" {
         let surface = PathFinder.SurfaceFactory.CreateSurface(10, 10)
         surface.SetPixel(4, 4, Color.Black)
         surface.SetPixel(5, 4, Color.Black)
         surface.SetPixel(6, 4, Color.Black)
         let ida = new PathFinder.Ida(surface)
         let path = ida.FindPath(Point(5, 7), Point(5, 2))
         path |> countOf |> shouldEqual 9
      }

      pending "should go around without twisting"
   }