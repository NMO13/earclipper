using EarClipperLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarClipper
{
    class Program
    {
        static void Main(string[] args)
        {
            //Example 1
            // specify polygon points in CCW order
            List<Vector3m> points = new List<Vector3m>() { new Vector3m(0, 0, 0), new Vector3m(1, 0, 0), new Vector3m(0, 1, 0) };
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
            points = new List<Vector3m>() { new Vector3m(0, 0, 0), new Vector3m(1, 0, 0), new Vector3m(2, 0, 0), new Vector3m(3, 0, 0),
                new Vector3m(3, 1, 0), new Vector3m(2, 1, 0), new Vector3m(1, 1, 0), new Vector3m(0, 1, 0) };
            earClipping.SetPoints(points);
            earClipping.Triangulate();
            res = earClipping.Result;
            PrintTriangles(res);

            //Example 4
            points = new List<Vector3m>() {new Vector3m(10, -1, 0), new Vector3m(11, 3.5, 0), new Vector3m(9, 3, 0), new Vector3m(6, 5, 0), new Vector3m(5, 0.5, 0), 
                new Vector3m(2, 1, 0), new Vector3m(0.5, 4, 0),
            new Vector3m(0, 0, 0), new Vector3m(3, -2, 0), new Vector3m(6, 1, 0)};
            earClipping.SetPoints(points);
            earClipping.Triangulate();
            res = earClipping.Result;
            PrintTriangles(res);

            //Example 5
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
            Console.ReadKey();
        }

        private static void PrintTriangles(List<Vector3m> points)
        {
            Console.WriteLine("Polygon:");
            for (int i = 0; i < points.Count; i += 3)
            {
                Console.WriteLine("Face{0}: {1} {2} {3}", i / 3, points[i], points[i + 1], points[i + 2]);
            }
            Console.WriteLine();
        }
    }
}
