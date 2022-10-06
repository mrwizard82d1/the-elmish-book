namespace ToDoList

open Feliz

type ToDo = string

type State = {
    ToDoList: ToDo list
    ToAdd: ToDo
}

type Msg =
    | SetToAdd of ToDo
    | ToAdd
    
module ToDoList =

   let init(): State = {
       ToDoList = [ "Learn F#"; "Read Shakespeare" ];
       ToAdd = ""
   }
   
   let update msg state =
       match msg with
       | SetToAdd toAddText -> {state with ToAdd = toAddText }
       | ToAdd when state.ToAdd = "" -> state  // validation: return `state` unchanged when no `ToAdd`
       | ToAdd -> {
           ToAdd = ""  // Nothing to add when added
           ToDoList = List.append state.ToDoList [ state.ToAdd ]
       }
       
   let renderAppTitle =
       Html.h1 [
           prop.className "title"
           prop.text "Elmish To Do List"
       ]
       
   let renderToAdd (state: State) (dispatch: Msg -> unit) = 
        Html.div [
            prop.classes [ "field"; "has-addons" ]
            prop.children [
                Html.div [
                    prop.classes [ "control"; "is-expanded" ]
                    prop.children [
                        Html.input [
                            prop.classes [ "input"; "is-medium" ]
                            prop.valueOrDefault state.ToAdd
                            prop.onChange (SetToAdd >> dispatch)
                        ]
                    ]
                ]
                Html.div [
                    prop.className "control"
                    prop.children [
                        Html.button [
                            prop.classes [ "button"; "is-primary"; "is-medium" ]
                            prop.onClick (fun _ -> dispatch ToAdd)
                            prop.children [
                                Html.i [prop.classes [ "fa"; "fa-plus" ]]
                            ]
                        ]
                    ]
                ]
            ]
        ]
        
   let renderToDoItems (state: State) (dispatch: Msg -> unit) =
        Html.div [
            prop.classes [ "content"; "is-medium" ]
            prop.children [
                Html.ul [
                    prop.children (state.ToDoList
                                   |> (List.map (fun t ->
                                       Html.listItem [
                                           prop.classes [ "is-primary" ]
                                           prop.text t
                                       ])))
                ]
            ]
        ]
       
   let render (state: State) (dispatch: Msg -> unit) =
       Html.div [
        prop.children [
            renderAppTitle
            renderToAdd state dispatch
            renderToDoItems state dispatch
        ]
       ]