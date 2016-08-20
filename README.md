# earclipper

##Description

Earclipper is a library for triangulating arbitrary convex/non-convex polygons. Earclipper is written in C# and implements the paper [Triangulation By EarClipping] (https://www.geometrictools.com/Documentation/TriangulationByEarClipping.pdf) by David Eberly.

##Features

- Supports arbitrary convex/non-convex polygons
- Usable for 2D and 3D polygons
- Robust: The internal datatype uses a rational arithmetic library. This means that internal computations and thus, the final result is always correct. Floating point problems are simply non-existent.
- Holes: Supports arbitrary complicated and arbitrary many holes.

##Performance
Performance is clearly improvable. The complexity inceases exponentially with the number of holes. Using some kind of binary partitioning (BSP-Tree, Octree) would speed up the algorithm dramatically.

##Notes

Polygons have to be specified in counter clockwise orientation. Each point of the polygon has to lie on the same plane. Holes have to be specified in clockwise orientation. A normal vector is necessary in order to decide which side is front and which is back of the polygon. This normal can either be passed manually or it is calculated automatically, if none was passed. The automatic calculation uses Newell's method in order to calculate the normal. This is an O(n) operation, so it is cheaper to calculate the normal by hand.

##Usage

```
//Example 1
// specify polygon points in CCW order
List<Vector3m> points = new List<Vector3m>(){new Vector3m(0, 0, 0), new Vector3m(1, 0, 0), new Vector3m(0, 1, 0)};
EarClipping earClipping = new EarClipping();
earClipping.SetPoints(points);
earClipping.Triangulate();
var res = earClipping.Result;
PrintTriangles(res);

//Example 2
points = new List<Vector3m>() { new Vector3m(0, 0, 0), new Vector3m(1, 0, 0), new Vector3m(1, 1, 1), new Vector3m(0, 1, 1) };
earClipping.SetPoints(points);
earClipping.Triangulate();
res = earClipping.Result;
PrintTriangles(res);

//Example 3
points = new List<Vector3m>()
{
    new Vector3m(0, 0, 0), new Vector3m(5, 0, 0), new Vector3m(5, 5, 5), new Vector3m(3, 3, 3), new Vector3m(2, 6, 6), new Vector3m(1, 3, 3), new Vector3m(0, 5, 5)
};

// specify holes in CW order
List<List<Vector3m>> holes = new List<List<Vector3m>>();
Vector3m[] hole = { new Vector3m(2, 3.5, 3.5), new Vector3m(1.5, 3.5, 3.5), new Vector3m(2, 4, 4) };
holes.Add(hole.ToList());

earClipping = new EarClipping();
earClipping.SetPoints(points, holes);
earClipping.Triangulate();
res = earClipping.Result;
PrintTriangles(res);

