using Grasshopper.Kernel;
using Ironbug.HVAC;
using System;

namespace Ironbug.Grasshopper.Component
{
    public class Ironbug_AirTerminalSingleDuctConstantVolumeNoReheat : Ironbug_HVACComponentBase
    {
        /// <summary>
        /// Initializes a new instance of the Ironbug_AirTerminalSingleDuctVAVReheat class.
        /// </summary>
        public Ironbug_AirTerminalSingleDuctConstantVolumeNoReheat()
          : base("Ironbug_AirTerminalSingleDuctConstantVolumeNoReheat", "Diffuser",
              "Description",
              "Ironbug", "03:AirTerminals",
              typeof(IB_AirTerminalSingleDuctConstantVolumeNoReheat_DataFieldSet))
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("AirTerminalSingleDuctConstantVolumeNoReheat", "Diffuser", "connect to Zone", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            var obj = new IB_AirTerminalSingleDuctConstantVolumeNoReheat();
            obj.PuppetEventHandler += PuppetStateChanged;

            this.SetObjParamsTo(obj);
            DA.SetData(0, obj);
        }
        
        protected override System.Drawing.Bitmap Icon => Properties.Resources.AirTerminalUncontrolled;
        
        public override Guid ComponentGuid => new Guid("623EC8EE-FE37-44B7-BBC7-2BA62C597BC4");
    }
}