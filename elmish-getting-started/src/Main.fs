module Main

open System.ComponentModel
open Elmish
open Elmish.React
open Feliz

// A simple counter
type State =
    { NumberInput: int
      ErrorMessage: string }
    
// Messages that cause state to change
type Msg =
    | SetNumberInput of int
    | SetErrorMessage of string
    
// Calculate the initial state of the application
let init () =
    { NumberInput = 0
      ErrorMessage = "" }
    
// Update the state based on messages received
let update (msg: Msg) (state: State): State =
    match msg with
    | SetNumberInput toNumber ->
        { state with NumberInput = toNumber; ErrorMessage = "" }
    | SetErrorMessage toMessage ->
        { state with ErrorMessage = toMessage }
        
let tryParseInt (toParse: string): Result<int, string> =
    try Ok (int toParse)
    with
    | ex -> Error(ex.Message)
        
// The view function (called `render` to communicate with developers familiar with React)
let render (state: State) (dispatch: Msg -> unit) =
    Html.div [
        Html.div [
            Html.input [
                prop.className "has-background-primary"
                prop.valueOrDefault state.NumberInput
                prop.onChange (fun (value: string) ->
                    match (tryParseInt value) with
                    | Ok toNumber ->
                        toNumber
                        |> SetNumberInput
                        |> dispatch
                    | Error withMessage ->
                        withMessage
                        |> SetErrorMessage
                        |> dispatch)
            ]
            Html.span [
                prop.className "has-background-success"
                prop.text (string state.NumberInput)
            ]
        ]
        Html.text state.ErrorMessage
    ]
    
    
Program.mkSimple init update render
|> Program.withReactSynchronous "feliz-app"
|> Program.run