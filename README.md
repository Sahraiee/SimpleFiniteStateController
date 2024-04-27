# Unity Simple State Machine Controller

A simple yet flexible state machine controller written in C# for Unity.

## Features

- **Define Custom States**: Users can define their own state IDs using an Enum, providing a clear and organized way to manage the state of your game objects.
- **State Node Customization**: Each state node can have its own set of actions that are invoked when the state is entered, exited, or during its stay.
- **State Transitioning**: The controller provides an easy way to change the current state of the object, with an optional flag to allow repetition of the same state.
- **Update Task Management**: The controller provides an UpdateTask() method that can be manually called by the user, allowing you to perform state-specific tasks during the game loop.


## Installation

To use the Unity Simple State Machine Controller in your project, you can install it through the Unity Package Manager.

1. Open your Unity project and navigate to the `Window` > `Package Manager` menu.
2. Click the `+` button in the top-left corner and select `Add package from git URL`.
3. Enter the following URL: `https://github.com/Sahraiee/SimpleFiniteStateController.git`
4. Click `Add` to install the package.

Alternatively, you can manually add the package by following these steps:

1. Create a `manifest.json` file in the `Packages` folder of your Unity project.
2. Add the following content to the `manifest.json` file:

   ```json
   {
     "dependencies": {
       "com.sahracore.simplefinitestatecontroller": "https://github.com/Sahraiee/SimpleFiniteStateController.git"
     }
   }
3. Save the manifest.json file.


# Usage








# Contribution
Contributions to this project are welcome! If you find any issues or have suggestions for improvement, feel free to open a new issue or submit a pull request on the GitHub repository.

# License
This project is licensed under the [MIT License](https://github.com/Sahraiee/SimpleFiniteStateController?tab=MIT-1-ov-file#MIT-1-ov-file).
