# ObjectMerger
This project was created during a research project called AKOMI.

The Object Merger is a Algorithm located in the a Subproject of AKOMI called "Tapako".

Object Merger is used to combine informations, which are stored in properties and fields of different instances with a common class type.
This is needed, because in contrast to Properties and Fields Methods cannot be copied from one object into another.
As a result developers are able to create multiple instances seperately from each other and merge/combine/fusion them later on into a 
object that has appropriate Methods implemented.


Example:
A need in Tapako is to create virtual representations of real devices without having all methods implemented in the firstly instanciated object,
because at this time the containing assembly of a needed class or the class itself is unknown or not accessible.
Therefore the needed class types which contain the fully implemented Methods are gathered from external and unknown Assemblys later on.
This means that at the time of the creation of the needed object information about that object already exist, but are stored in a object 
which looks similar. And here The Object Merger comes to play and does merge the information from the initial object into the needed object.

HOW TO USE:
```
      var initialInstance = new MyObjectBase(); // Initialize first object
      var properInstance = new MyObjectWithAlgorithms(); // Initialize second object
      var result = ObjectMerger.MergeObjects(properInstance, initialInstance); // Merge Objects into type of "properInstance"
```
