# ObjectMerger

<img src="https://github.com/Fellfalla/ObjectMerger/blob/master/Icon_64x64.png" style="width:50px;height:50px;">


<a href="https://www.myget.org/"><img src="https://www.myget.org/BuildSource/Badge/fellfeed?identifier=17573ff1-a05b-422c-a723-a12e4f092444" alt="fellfeed MyGet Build Status" /></a>

NuGet-Packages:
<a href="https://www.nuget.org/packages/Tapako.ObjectMerger/">
      ObjectMerger
</a>

This project was created during a research project called AKOMI.

The Object Merger is the subproject of a research project called AKOMI.

The Object Merger is used to merge values, which are stored in properties and fields of different instances with a common class type.
As a result, one can create multiple instances seperately from each other and merge/combine/fusion them later into a single object. Behind the scenes, reflection is used for that.


Example:
One requirement within the research project is to be able to create virtual representations of real devices without having all methods implemented in the firstly instanciated object, because at this time the containing assembly of a needed class or the class itself is unknown or not accessible.
The final class type, which contains the full implementation, can be gathered from external and unknown assemblies later on. Here, the Object Merger comes into play and merges the information from the initial instance into the final class instance.

HOW TO USE:
```
      var initialInstance = new MyObjectBase(); // Initialize first object
      var properInstance = new MyObjectWithAlgorithms(); // Initialize second object
      var result = ObjectMerger.MergeObjects(properInstance, initialInstance); // Merge Objects into type of "properInstance"
```
