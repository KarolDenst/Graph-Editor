How to use the program:
To create a new polygon select the "Place" checkbox and start clicking on the canvas.
To move a vertex/edge/polygon select the "Move" checkbox, press the left mouse button over an object and move your mouse.
To delete a vertex select the "Delete Vertex" checkbox and click on a vertex.
To add a vertex to a polygon select the "Add Vertex" checkbox and click on an edge. The vertex will be added where you clicked.

If you want the program to draw using a library function select the "Library" checkbox.
If you want the program to draw using Bresenham's algorithm select the "Bresenham" checkbox.

To add a length constraint select the "Add Length Constraint" checkbox and click on an edge. A window will popup prompting you to select the length.
To add a parallel constraint select the "Add Parallel" checkbox and click on an edge. The edge will turn red. Then click on another edge.
parallel constraint is very laggy because I got stack overflow exceptions when I tried to make it smoother.
To remove a constraint select the "Delete Constraint" checkbox and click on an edge. All constraints of that edge will be deleted.

How the constraints work:
Every time an edge is moved [MyPoint.Move() function] the program loops over all constraints. If a constraint is not fulfilled the Move(p) method is used on another vertex where p is such a Point that fulfills that constraint.
The Program does this until all constraints are fulfilled or a limit is reached. Every time Move() is called it is called with an increasing 'retry' variable. Once retry == Constants.RetryTimes the program stops trying to Move a vertex.
If the constraints are impossible to fulfill or require Move() to be called more than Constants.RetryTimes deep the behavior is unspecified (The polygon will move to a random place, probably). 

Bugs:
On my computer the program works quite well. However on other systems it might require changing some constants. The 2 most important ones are RetryTimes and AngleConstraint. 
If the program is lagging or throws stack overflow exceptions try lowering RetryTimes or rising AngleConstraint. They are both located in Constants.cs.
If you want to make Parallel constraint smoother change AngleConstraint to something smaller but be warned that it might cause errors.
