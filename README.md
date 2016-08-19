# earclipper

##Description

Earclipper is a library for triangulating arbitrary convex/non-convex polygons. EarClipper is written in C# and implements the paper https://www.geometrictools.com/Documentation/TriangulationByEarClipping.pdf by David Eberly.

##Features

- Supports arbitrary convex/non-convex polygon
- Usable for 2D and 3D polygons
- Robust: The internal datatype uses a rational arithmetic library. This means that internal computations and thus, the final result is always correct. Floating point problems are simply non-existent.
- Holes: Supports arbitrary complicated and arbitrary many holes.

##Performance
Performance is, at the moment, not very good. The complexity inceases exponentially with the number of holes.

