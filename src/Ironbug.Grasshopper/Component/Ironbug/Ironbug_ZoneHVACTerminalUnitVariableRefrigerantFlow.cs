﻿using System;
using Grasshopper.Kernel;

namespace Ironbug.Grasshopper.Component.Ironbug
{
    public class Ironbug_ZoneHVACTerminalUnitVariableRefrigerantFlow : Ironbug_HVACComponent
    {
        
        /// Initializes a new instance of the Ironbug_ZoneHVACTerminalUnitVariableRefrigerantFlow class.
        
        public Ironbug_ZoneHVACTerminalUnitVariableRefrigerantFlow()
          : base("Ironbug_ZoneHVACTerminalUnitVariableRefrigerantFlow", "VRFTerminal",
              "Description",
              "Ironbug", "04:ZoneEquipments",
              typeof(HVAC.IB_ZoneHVACTerminalUnitVariableRefrigerantFlow_FieldSet))
        {
        }

        public override GH_Exposure Exposure => GH_Exposure.tertiary;

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
        }

        
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("ZoneHVACTerminalUnitVariableRefrigerantFlow", "VRFUnit_In", "Connect to Zone's equipment", GH_ParamAccess.item);
            pManager.AddGenericParameter("ZoneHVACTerminalUnitVariableRefrigerantFlow", "VRFUnit_Out", "Connect to VRF system", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            var obj = new HVAC.IB_ZoneHVACTerminalUnitVariableRefrigerantFlow();
            

            this.SetObjParamsTo(obj);
            DA.SetData(0, obj);
            DA.SetData(1, obj);
        }
        protected override System.Drawing.Bitmap Icon => Properties.Resources.VRFUnit;

        public override Guid ComponentGuid => new Guid("1aa85a4b-f306-41ba-9723-5d78ecbec750");
    }
}