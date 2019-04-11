﻿using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Ironbug.Grasshopper.Properties;
using Ironbug.HVAC.BaseClass;

namespace Ironbug.Grasshopper.Component
{
    public class Ironbug_AirLoopHVAC : Ironbug_HVACComponent
    {
        public Ironbug_AirLoopHVAC()
          : base("Ironbug_AirLoopHVAC", "AirLoop",
              "Description",
              "Ironbug", "01:Loops",
              typeof(HVAC.IB_AirLoopHVAC_FieldSet))
        {
        }
        public override GH_Exposure Exposure => GH_Exposure.primary;

        
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("supply", "supply", "heating or cooling supply source", GH_ParamAccess.list);
            pManager.AddGenericParameter("demand", "demand", "zoneBranches or other HVAC components", GH_ParamAccess.list);
            pManager.AddGenericParameter("sizingSystem", "sizing", "HVAC components", GH_ParamAccess.item);
            
            pManager[0].Optional = true;
            pManager[1].Optional = true;
            pManager[2].Optional = true;
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("AirLoopHVAC", "AirLoop", "To HVACsystem", GH_ParamAccess.item);
        }

        
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            var supplyComs = new List<IB_HVACObject>();
            DA.GetDataList(0, supplyComs);

            var demandComs = new List<IB_HVACObject>();
            DA.GetDataList(1, demandComs);

            HVAC.IB_SizingSystem sizing = null;
           
            
            var airLoop = new HVAC.IB_AirLoopHVAC();
            if (DA.GetData(2, ref sizing))
            {
                airLoop.SetSizingSystem(sizing);
            }
            

            //TODO: need to check nulls
            foreach (var item in supplyComs)
            {
                airLoop.AddToSupplySide(item);
            }

            foreach (var item in demandComs)
            {
                airLoop.AddToDemandSide(item);
            }


            this.SetObjParamsTo(airLoop);
            DA.SetData(0, airLoop);

        }


        protected override System.Drawing.Bitmap Icon => Resources.AirLoop;

        public override Guid ComponentGuid => new Guid("a416631f-bdda-4e11-8a2c-658c38681201");

        public override void CreateAttributes()
        {
            var newAttri = new IB_LoopComponentAttributes(this);
            m_attributes = newAttri;
        }
    }
}