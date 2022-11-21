The goal of this system is to utilize methods from a variety of scripts and organized
them in a sequence of individual tasks, i.e. played on after the other.

The Task class contains a reference from the script from which we want to extract methods.

For instance, an intro sequence could be:

	Task 1 - Play a vfx for 5 seconds
	Task 2 - Switch camera
	Task 3 - Show "Start" message on UI
	Task 4 - Enable player input
 
The sequence system acts as an additional layer and doesn't disrupt nor is it tacked on to existing systems — instead, the task script act as a wrapper around the target script.
