using EarClipperLib;

namespace EarClipperTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Example 1
            // specify polygon points in CCW order
            List<Vector3m> points = new List<Vector3m>()
                { new Vector3m(0, 0, 0), new Vector3m(1, 0, 0), new Vector3m(0, 1, 0) };
            EarClipping earClipping = new EarClipping();
            earClipping.SetPoints(points);
            earClipping.Triangulate();
            var res = earClipping.Result;
            PrintTriangles(res);

            //Example 2
            points = new List<Vector3m>()
                { new Vector3m(0, 0, 0), new Vector3m(1, 0, 0), new Vector3m(1, 1, 1), new Vector3m(0, 1, 1) };
            earClipping.SetPoints(points);
            earClipping.Triangulate();
            res = earClipping.Result;
            PrintTriangles(res);

            //Example 3
            points = new List<Vector3m>()
            {
                new Vector3m(0, 0, 0), new Vector3m(1, 0, 0), new Vector3m(2, 0, 0), new Vector3m(3, 0, 0),
                new Vector3m(3, 1, 0), new Vector3m(2, 1, 0), new Vector3m(1, 1, 0), new Vector3m(0, 1, 0)
            };
            earClipping.SetPoints(points);
            earClipping.Triangulate();
            res = earClipping.Result;
            PrintTriangles(res);

            //Example 4
            points = new List<Vector3m>()
            {
                new Vector3m(0, 0, 0), new Vector3m(5, 0, 0), new Vector3m(5, 5, 5), new Vector3m(3, 3, 3),
                new Vector3m(2, 6, 6), new Vector3m(1, 3, 3), new Vector3m(0, 5, 5)
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
            
            
            //Example 5 
            // non coplanar polygon that gets its points mapped to a coplanar space
            points = new List<Vector3m>()
            {
                new Vector3m(7197, -131, -6003),
                new Vector3m(7197, 131, -6003),
                new Vector3m(7103, 131, -6115),
                new Vector3m(7103, 145, -6115),
                new Vector3m(7296, 145, -5884),
                new Vector3m(7296, 131, -5884),
                new Vector3m(7202, 131, -5996),
                new Vector3m(7202, -131, -5996),
                new Vector3m(7296, -131, -5884),
                new Vector3m(7296, -145, -5884),
                new Vector3m(7103, -145, -6115),
                new Vector3m(7103, -131, -6115)
            };
            points = EarClipping.GetCoplanarMapping(points, out var reverseMapping);
            earClipping = new EarClipping();
            earClipping.SetPoints(points);
            earClipping.Triangulate();
            res = earClipping.Result;
            res = EarClipping.RevertCoplanarityMapping(res, reverseMapping);
            PrintTriangles(res);

            //Example 6 
            points = new List<Vector3m>()
            {
                new Vector3m(0, 0, 0),
                new Vector3m(8, 0, 0),
                new Vector3m(8, 4, 0),
                new Vector3m(0, 4, 0)
            };

            // specify holes in CW order
            holes = new List<List<Vector3m>>();
            Vector3m[] hole2 =
            {
                new Vector3m(7, 2, 0),
                new Vector3m(6, 1, 0),
                new Vector3m(4, 2, 0),
                new Vector3m(5, 3, 0),
            };
            holes.Add(hole2.ToList());

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