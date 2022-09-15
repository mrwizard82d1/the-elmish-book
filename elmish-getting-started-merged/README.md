# Elmish Getting Started (Merged)

This is a simple Fable application including an [Elmish](https://elmish.github.io/) counter. The repository is made for learning purposes and the generated Javascript output is not optimized. That said, the template shows you how easy it is to get started with Fable and Elmish using minimal configuration.

I created this project by executing `dotnew feliz -n elmish-getting-started`. (I eventually renamed the repository to `elmish-getting-started-merged` to better reflect its "intent." After creating that skeleton project, I merged (some) of the code from the cloned project mentioned in "The Elmish Book."

This project is "broke." That is, I see the "Increment" and "Decrement" buttons and the Count on the web page; however, pressing the "Increment" button has no effect on the web page. Further, I was unable to diagnose the issue. First, I was unable to locate the source for the original file in the browser source maps. Second, I could not seem to debug in Rider (but I did not try very hard). Finally, adding a print statement to the `update` function for the `Increment` message **did not** appear in the debug console.

## Feliz Template

This template gets you up and running with a simple web app using [Fable](http://fable.io/), [Elmish](https://fable-elmish.github.io/) and [Feliz](https://github.com/Zaid-Ajaj/Feliz).

## Requirements

* [dotnet SDK](https://www.microsoft.com/net/download/core) 2.0.0 or higher
* [node.js](https://nodejs.org) 10.0.0 or higher


## Editor

To write and edit your code, you can use either VS Code + [Ionide](http://ionide.io/), Emacs with [fsharp-mode](https://github.com/fsharp/emacs-fsharp-mode), [Rider](https://www.jetbrains.com/rider/) or Visual Studio.


## Development

Before doing anything, start with installing npm dependencies using `npm install`.

Then to start development mode with hot module reloading, run:
```bash
npm start
```
This will start the development server after compiling the project, once it is finished, navigate to http://localhost:8080 to view the application .

To build the application and make ready for production:
```
npm run build
```
This command builds the application and puts the generated files into the `deploy` directory (can be overwritten in webpack.config.js).

### Tests

The template includes a test project that ready to go which you can either run in the browser in watch mode or run in the console using node.js and mocha. To run the tests in watch mode:
```
npm run test:live
```
This command starts a development server for the test application and makes it available at http://localhost:8085.

To run the tests using the command line and of course in your CI server, you have to use the mocha test runner which doesn't use the browser but instead runs the code using node.js:
```
npm test
```
