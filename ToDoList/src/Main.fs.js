import { ProgramModule_mkSimple, ProgramModule_run } from "./fable_modules/Fable.Elmish.3.1.0/program.fs.js";
import { Program_withReactSynchronous } from "./fable_modules/Fable.Elmish.React.3.0.1/react.fs.js";
import { ToDoList_render, ToDoList_update, ToDoList_init } from "./Components.fs.js";

ProgramModule_run(Program_withReactSynchronous("feliz-app", ProgramModule_mkSimple(ToDoList_init, ToDoList_update, ToDoList_render)));

//# sourceMappingURL=Main.fs.js.map
