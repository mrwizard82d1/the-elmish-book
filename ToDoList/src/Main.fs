module Main

open Elmish
open Elmish.React
open Feliz
open ToDoList
open Browser.Dom
open Fable.Core.JsInterop

importSideEffects "./styles/global.scss"

ReactDOM.render(
    ToDoList.appTitle,
    document.getElementById "feliz-app"
)

Program.mkSimple ToDoList.init ToDoList.update ToDoList.toAdd
|> Program.withReactSynchronous "feliz-app"
|> Program.run
