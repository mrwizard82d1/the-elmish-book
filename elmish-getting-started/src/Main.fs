module Main

open System.ComponentModel
open Elmish
open Elmish.React
open Feliz

// A simple counter
type State =
    { NumberInput: int }
    
// Messages that cause state to change
type Msg =
    | SetNumberInput of int
    
// Calculate the initial state of the application
let init () =
    { NumberInput = 0 }
    
// Update the state based on messages received
let update (msg: Msg) (state: State): State =
    match msg with
    | SetNumberInput toNumber ->
        { state with NumberInput = toNumber }
        
let tryParseInt (toParse: string): Option<int> =
    try Some (int toParse)
    with | _ -> None
        
// The view function (called `render` to communicate with developers familiar with React)
let render (state: State) (dispatch: Msg -> unit) =
    Html.div [
        Html.input [
            prop.className "has-background-primary"
            prop.valueOrDefault state.NumberInput
            prop.onChange (fun (value: string) ->
                           value
                           |> tryParseInt
                           |> Option.iter (SetNumberInput >> dispatch))
        ]
        Html.span [
            prop.className "has-background-success"
            prop.text (string state.NumberInput)
        ]
    ]
    
Program.mkSimple init update render
|> Program.withReactSynchronous "feliz-app"
|> Program.run