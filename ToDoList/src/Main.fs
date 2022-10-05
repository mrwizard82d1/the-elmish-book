module Main

open Elmish
open Elmish.React
open ToDoList

Program.mkSimple ToDoList.init ToDoList.update ToDoList.render
|> Program.withReactSynchronous "feliz-app"
|> Program.run
