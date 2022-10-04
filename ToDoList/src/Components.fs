namespace ToDoList

open Feliz

type ToDo = string

type State = {
    ToDoList: ToDo list
    ToAdd: ToDo
}

type Msg =
    | SetToAdd of ToDo
    | AddItem
    
module ToDoList =

   let init(): State = {
       ToDoList = [ "Learn F#" ];
       ToAdd = ""
   }
   
   let update msg state =
       match msg with
       | SetToAdd toAddText -> {state with ToAdd = toAddText }
       | ToAdd when state.ToAdd = "" -> state  // validation: return `state` unchanged when no `ToAdd`
       | ToAdd -> {
           ToAdd = ""  // Nothing to add when added
           ToDoList = List.append state.ToDoList [state.ToAdd]
       }
       
   let appTitle =
       Html.h1 [
           prop.className "title"
           prop.text "Elmish To Do List"
       ]