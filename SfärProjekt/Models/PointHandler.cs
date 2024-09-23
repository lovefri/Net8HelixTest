using HelixToolkit.Wpf.SharpDX;
using HelixToolkit.SharpDX.Core.Model.Scene;
using SharpDX;

using HelixToolkit.SharpDX.Core;

namespace SfärProjekt.Models
{
    internal class PointHandler
    {

        private Vector3Collection getRandSpere(int numberOfPoints, float radius)
        {

            var points = new Vector3Collection();
            Random random = new Random();

            // Går igenom och genererar punkterna
            for (int i = 0; i < numberOfPoints; i++)
            {
                // Generera slumpmässiga vinklar i rätt intervall
                double theta = random.NextDouble() * 2 * Math.PI; // Azimutalvinkel [0, 2π]
                double phi = random.NextDouble() * Math.PI;        // Polvinkel [0, π]

                // Konvertera sfäriska koordinater till kartesiska
                float x = radius * (float)(Math.Sin(phi) * Math.Cos(theta));
                float y = radius * (float)(Math.Sin(phi) * Math.Sin(theta));
                float z = radius * (float)(Math.Cos(phi));

                // Lägg till den nya punkten
                points.Add(new Vector3(x, y, z));
            }

            return points;

        }



        private PointGeometry3D GetPoints()
        {



            var points = new PointGeometry3D();
            points.Positions = getRandSpere(1000, 3);
            //{

            //    //Positions = new Vector3Collection
            //    //{
            //    //    new Vector3(2, 1, 0),
            //    //    new Vector3(-2, 1, 0),
            //    //    new Vector3(-2, -1, 0),
            //    //    new Vector3(2, -1, 0)
            //    //}
            //};

            return points;

        }

        private PointGeometryModel3D GetPointGeometryModel()
        {
            //var color = System.Drawing.Color.Red;
            //var color1 = System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
            var color1 = GetRandomColor();

            var pointGeometryModel = new PointGeometryModel3D
            {
                Geometry = GetPoints(),
                Color = color1,
                Size = new System.Windows.Size(5, 5) // Punktstorlek
            };

            

            return pointGeometryModel;
        }

        private System.Windows.Media.Color GetRandomColor()
        {
            Random random = new Random();

            // Slumpa värden för RGB (0-255)
            byte r = (byte)random.Next(0, 256);
            byte g = (byte)random.Next(0, 256);
            byte b = (byte)random.Next(0, 256);
            byte a = 255; // Sätt alfa till full genomskinlighet (valfritt)

            // Skapa och returnera färgen
            return System.Windows.Media.Color.FromArgb(a, r, g, b);
        }


        internal PointNode GetPointNode()
        {
            PointGeometryModel3D pointGeometryModel3D = GetPointGeometryModel();
            //pointGeometryModel3D.Geometry.Positions.AddRange(GetPointGeometryModel().Geometry.Positions);
            //pointGeometryModel3D.Geometry.Positions.AddRange(GetPointGeometryModel().Geometry.Positions);

            PointNode pointNode = (PointNode)pointGeometryModel3D.SceneNode;
            return pointNode;
        }




        // Lägg till PointNode i GroupModel

        

    }
}
