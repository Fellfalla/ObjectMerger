# ObjectMerger

<img src="https://github.com/Fellfalla/ObjectMerger/blob/master/Icon_64x64.png" style="width:50px;height:50px;">


<a href="https://www.myget.org/"><img src="https://www.myget.org/BuildSource/Badge/fellfeed?identifier=17573ff1-a05b-422c-a723-a12e4f092444" alt="fellfeed MyGet Build Status" /></a>

NuGet-Packages:
<a href="https://www.nuget.org/packages/Tapako.ObjectMerger/0.5.0.3">
      ObjectMerger
</a>

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
