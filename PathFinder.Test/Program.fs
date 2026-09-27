module PathFinder.Test.Program

open PathFinder.Test.AStarSpecs
open PathFinder.Test.IdaSpecs
open Sprout

[<EntryPoint>]
let main _ =
   let reporter = Reporters.TapReporter()
   let results =
      runTestSuiteCustom
         (DefaultRunner(reporter, id))
         (describe "PathFinder tests" {
            aStarTests
            idaTests
         })
      |> Async.RunSynchronously
   results
   |> Array.filter _.Outcome.IsFailed
   |> Array.length