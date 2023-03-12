# CodeSearcher
Search what file includes a certain word in a project, with a simple UI.

### Technique

A silly method to combine C# with python has been applied. The program will call cmd and pass parameters to a python sript `bin\Debug\demo.py` , then read the output of cmd. The python script executes a simple searching.
The treeview is to help you remember which keywords are relative of dependent.
