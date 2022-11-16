# Processing 3D lidar data, tracking objects and calculating the passageway of the robot

<img src="/imgs/img4.png" alt="img1" width="700"/>

*Developer*

1. [Andrey Nedov](https://github.com/Andrey-Nedov)

# The objective of the project

_Develop an algorithm for reading and visualizing streaming data in the form of a dynamically updated point cloud of a multibeam 3D lidar._

- Prepare an application for reading data from a 3D lidar saved in a streaming file and calculating a point cloud; 
- Develop a function to dynamically update data in a given structure (object) for storing point cloud data; 
- Develop a function for frame-by-frame visualization of a point cloud in isometric projection and in the "top view" mode with a given (adjustable) frame rate (frequency); 
- Develop a data filtering function using clipping planes (cube of interest);
- Develop a function for detecting objects by cluster analysis;
- Develop a method for tracking the "patency corridor" for the rectilinear movement of the robot.

**Only the standard C# libraries and the SharpGL graphics library (OpenGL specification) were used in the work.** 

# Lidar

I used raw data recorded from a Velodyne HDL-32E 32-beam 3D lidar.

[Specification](https://github.com/Andrey-Nedov/3D-Lidar-Data-Processing/tree/main/materials/Velodyne_techinfo.pdf)

<img src="/imgs/lidar.jpg" width="500"/>

# Result

[Video report](https://drive.google.com/file/d/1d_tY8FgbC7GMUCyQpd-twABTlqXyMKZ8/view?usp=sharing)

In 3D space, the robot is represented by a green horizontal plane on the surface of the clipping cube. The transparent parallelepiped shows the passable corridor available for the unobstructed rectilinear movement of the robot.

<img src="/imgs/img1.png" width="700"/>

## The sequence of the program:

- Reading raw data recorded from the lidar from the package file
- Convert data to pointcloud
- Clipping points outside the clipping cube
- Filtration
- Clustering by k-means method
- Calculation of the passage corridor for the robot based on the translation matrix from the general basis to the basis of the robot

<br/><img src="/imgs/img2.png" width="700"/>

Top view in isometric:

<img src="/imgs/img3.png" width="700"/>
