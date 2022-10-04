module Main

open Feliz
open ToDoList
open Browser.Dom
open Fable.Core.JsInterop

importSideEffects "./styles/global.scss"

ReactDOM.render(
    ToDoList.appTitle,
    document.getElementById "feliz-app"
)
