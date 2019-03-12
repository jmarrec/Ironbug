﻿using System;
using Grasshopper.Kernel;

namespace Ironbug.Grasshopper.Component
{
    public class Ironbug_GroundHeatExchangerVertical : Ironbug_HVACComponent
    {
        
        public Ironbug_GroundHeatExchangerVertical()
          : base("Ironbug_GroundHeatExchangerVertical", "GroundHXVertical",
              "Description",
              "Ironbug", "02:LoopComponents",
              typeof(HVAC.IB_GroundHeatExchangerVertical_FieldSet))
        {
        }

        protected override System.Drawing.Bitmap Icon => Properties.Resources.GSHPV;
        public override Guid ComponentGuid => new Guid("9FF66F1C-C6C1-4C81-B12F-333230F2FF42");
        public override GH_Exposure Exposure => GH_Exposure.quarternary;
        
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
        }
        
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("GroundHeatExchangerVertical", "GroundHXVert", "GroundHeatExchangerVertical", GH_ParamAccess.item);
        }
        
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            var obj = new HVAC.IB_GroundHeatExchangerVertical();

            this.SetObjParamsTo(obj);
            DA.SetData(0, obj);
        }



    }

   
}