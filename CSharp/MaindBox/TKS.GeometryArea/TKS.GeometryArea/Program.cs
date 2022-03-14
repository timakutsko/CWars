using System;
using System.Collections.Generic;
using TKS.GeomArea.Data;

namespace TKS.GeometryArea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GeomVector edgeA = new GeomVector(2, 0);
            GeomVector edgeAa = new GeomVector(2, 90);
            GeomVector edgeB = new GeomVector(2, 90);
            GeomVector edgeC = new GeomVector(1, 45);
            GeomVector edgeD = new GeomVector(5, 90);
            GeomVector edgeE = new GeomVector(5, 45);
            GeomVector edgeF = new GeomVector(1, 135);
            GeomVector edgeG = new GeomVector(5, 360);

            GeometryBuilder treangle = new GeometryBuilder(new List<GeomVector> { edgeA, edgeB });
            GeometryBuilder square = new GeometryBuilder(new List<GeomVector> { edgeA, edgeB, edgeB });
            GeometryBuilder rectangle = new GeometryBuilder(new List<GeomVector> { edgeA, edgeD, edgeAa });
            GeometryBuilder parallelogram = new GeometryBuilder(new List<GeomVector> { edgeA, edgeE, edgeAa });
            GeometryBuilder trapezoid = new GeometryBuilder(new List<GeomVector> { edgeA, edgeF, edgeC });
            GeometryBuilder circle = new GeometryBuilder(new List<GeomVector> { edgeG });

            treangle.GetArea();
            square.GetArea();
            rectangle.GetArea();
            parallelogram.GetArea();
            trapezoid.GetArea();
            circle.GetArea();

            
        }
    }
}
