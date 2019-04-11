﻿using System;
using Grasshopper.Kernel;

namespace Ironbug.Grasshopper.Component
{
    public class Ironbug_CoilHeatingLowTempRadiantVarFlow : Ironbug_HVACComponent
    {
        public Ironbug_CoilHeatingLowTempRadiantVarFlow()
          : base("Ironbug_CoilHeatingLowTempRadiantVarFlow", "CoilHtn_LowTRadV",
              "Description",
              "Ironbug", "04:ZoneEquipments",
              typeof(HVAC.IB_CoilHeatingLowTempRadiantVarFlow_FieldSet))
        {
        }

        protected override System.Drawing.Bitmap Icon => Properties.Resources.CoilHWRV;

        public override Guid ComponentGuid => new Guid("933B91D4-014C-4466-9EDF-293002B0154B");

        public override GH_Exposure Exposure => GH_Exposure.quinary | GH_Exposure.obscure;
        
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddNumberParameter("Low Air Temperature", "airLoT", "Low control air temperature, above which the heating will be turned on", GH_ParamAccess.item, 15);
        }
        
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("CoilHeatingLowTempRadiantVarFlow", "Coil", "Add to ZoneHVACLowTempRadiantVarFlow", GH_ParamAccess.item);
            pManager.AddGenericParameter("WaterSide_CoilHeatingLowTempRadiantVarFlow", "ToWaterLoop", "Connect to hot water loop's demand side via plantBranches", GH_ParamAccess.item);
        }
        
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            double airLoT = 15;
            
            DA.GetData(0, ref airLoT);

            var obj = new HVAC.IB_CoilHeatingLowTempRadiantVarFlow(airLoT);
            
            DA.SetData(0, obj);
            DA.SetData(1, obj);
        }
        

    }
    
}