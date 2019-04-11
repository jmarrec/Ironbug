﻿using System;
using Grasshopper.Kernel;

namespace Ironbug.Grasshopper.Component
{
    public class Ironbug_CoilHeatingDesuperheater : Ironbug_HVACComponent
    {
        
        public Ironbug_CoilHeatingDesuperheater()
          : base("Ironbug_CoilHeatingDesuperheater", "Desuperheater",
              "Description",
              "Ironbug", "02:LoopComponents",
              typeof(HVAC.IB_CoilHeatingDesuperheater_FieldSet))
        {
        }

        public override GH_Exposure Exposure => GH_Exposure.secondary | GH_Exposure.obscure;
        
        
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("HeatingSource", "HeatingSource", "Heating source, can be CoilCoolingDXSingleSpeed or CoilCoolingDXTwoSpeed", GH_ParamAccess.item);
        }

        
        
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("CoilHeatingDesuperheater", "Desuperheater", "A desuperheater with a heating source (CoilCoolingDXSingleSpeed or CoilCoolingDXTwoSpeed).", GH_ParamAccess.item);
        }

        
        protected override void SolveInstance(IGH_DataAccess DA)
        {

            var obj = (HVAC.IB_CoilHeatingDesuperheater)null;
            var heatingSource = (HVAC.BaseClass.IB_CoilDX)null;
            if (DA.GetData(0, ref heatingSource))
            {
                obj = new HVAC.IB_CoilHeatingDesuperheater(heatingSource);
                this.AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, "This desuperheater is not supported in OpenStudio App interface, which means you will not be able to edit the loop this desuperhater belongs to in OpenStudio App.\n\rMeanwhile, there is a bug in OpenStudio API:https://unmethours.com/question/23669/coilwaterheatingdesuperheater-methods-not-executing-correctly/. You will need an EnergyPlus measure to make this work!");
            }
            
            this.SetObjParamsTo(obj);
            DA.SetData(0, obj);
        }

        protected override System.Drawing.Bitmap Icon => null;




        public override Guid ComponentGuid => new Guid("44EA1323-99CE-4D03-A7EC-8A58A7652906");
    }
}