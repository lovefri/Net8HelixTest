using HelixToolkit.SharpDX.Core;
using HelixToolkit.SharpDX.Core.Model.Scene;
using HelixToolkit.Wpf.SharpDX;

using SfärProjekt.Models;

using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

using Camera = HelixToolkit.Wpf.SharpDX.Camera;

namespace SfärProjekt.VieModels
{
    internal class MainViewModel:INotifyPropertyChanged
    {
        /// <summary>
        /// Stuff needed for the view to se anyning and navigate
        /// </summary>
        public EffectsManager? EffectsManager { get; }
        public Camera? Camera { get; }

        /// <summary>
        /// MAterials and geometries
        /// </summary>
        public PhongMaterial Red { get; private set; }
        public MeshGeometryModel3D meshGeometryModel3D;
        public MeshNode SphereMEshModel3D;
        public MeshNode BoxMeshNode;
        public MeshGeometry3D CubeMesh { get; set; }
        public MeshGeometry3D SphereMesh { get; set; }

        /// <summary>
        /// Groups
        /// </summary>
        private SceneNodeGroupModel3D groupmodel;
        public SceneNodeGroupModel3D GroupModel
        {
            get { return groupmodel; }
            set
            {
                groupmodel = value;
                OnPropertyChanged(nameof(GroupModel));
            }
        }
        //get => groupModel; set => groupModel = value; }

        private SceneNodeGroupModel3D _grouModel_2;


        /// <summary>
        /// Transforms
        /// </summary>
        public System.Windows.Media.Media3D.MatrixTransform3D myGenericTransform3D;

        public MainViewModel()
        {
            //Nessecary stuff to se teh geometries
            EffectsManager = new DefaultEffectsManager();
            Camera = new HelixToolkit.Wpf.SharpDX.PerspectiveCamera();


            // Groups
            GroupModel = new SceneNodeGroupModel3D();

            //meshGeometryModel3D = new MeshGeometryModel3D();
            //SphereMEshModel3D = new MeshNode();
            //BoxMeshNode = new MeshNode();

            //var builder1 = new MeshBuilder();
            //builder1.AddBox(new Vector3(0, 0, 0), 2, 2, 2, BoxFaces.All);
            //CubeMesh = builder1.ToMeshGeometry3D();
            //meshGeometryModel3D.Geometry = CubeMesh;
            //BoxMeshNode.Geometry = CubeMesh;
            //BoxMeshNode.Material = PhongMaterials.Silver;
            //GroupModel.AddNode(BoxMeshNode);

            //var builder2 = new MeshBuilder();
            //builder2.AddSphere(new Vector3(0, 0, 4), 2, 7, 30);
            //SphereMesh = builder2.ToMeshGeometry3D();
            //SphereMEshModel3D.Geometry = SphereMesh;
            //SphereMEshModel3D.Material = PhongMaterials.Blue;


            PointHandler pH = new PointHandler();




            // Skapa en PointNode med punktgeometrin


            GroupModel.AddNode(pH.GetPointNode());


            Red = PhongMaterials.Red;
        }

        protected void OnPropertyChanged([CallerMemberName] string info = "") // If it is not in a baseclass This could be replaced with only the invoke
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
