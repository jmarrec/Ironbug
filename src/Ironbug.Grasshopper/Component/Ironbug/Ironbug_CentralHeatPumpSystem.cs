﻿using System;
using System.Collections.Generic;
using Grasshopper.Kernel;

namespace Ironbug.Grasshopper.Component
{
    public class Ironbug_CentralHeatPumpSystem : Ironbug_HVACComponent
    {
        
        public Ironbug_CentralHeatPumpSystem()
          : base("Ironbug_CentralHeatPumpSystem", "CentralHeatPumpSystem",
              "Description",
              "Ironbug", "02:LoopComponents",
              typeof(HVAC.IB_CentralHeatPumpSystem_FieldSet))
        {
        }

        public override GH_Exposure Exposure => GH_Exposure.quarternary | GH_Exposure.obscure;

        
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("Chiller-heaters", "chillerHeaters", "use ChillerHeaterPerformanceElectricEIR, typically three chillerheaters are needed", GH_ParamAccess.list);
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("CentralHeatPumpSystem", "ToDW_Demand", "connect to condenser water plantloop's demand side", GH_ParamAccess.item);
            pManager.AddGenericParameter("CentralHeatPumpSystem", "ToCW_Supply", "connect to chilled water plantloop's supply side", GH_ParamAccess.item);
            pManager.AddGenericParameter("CentralHeatPumpSystem", "ToHW_Supply", "connect to hot water plantloop's supply side", GH_ParamAccess.item);
            
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            var chillers = new List<HVAC.IB_ChillerHeaterPerformanceElectricEIR>();
            DA.GetDataList(0, chillers);
            
            var obj = new HVAC.IB_CentralHeatPumpSystem();
            foreach (var item in chillers)
            {
                var module = new HVAC.IB_CentralHeatPumpSystemModule();
                module.SetChillerHeater(item);

                module.SetNumberOfChillerHeaterModules(chillers.Count);
                obj.AddModule(module);
            }

            this.SetObjParamsTo(obj);
            DA.SetData(0, obj);
            DA.SetData(1, obj);
            DA.SetData(2, obj);
        }

        protected override System.Drawing.Bitmap Icon => Properties.Resources.CentralHeatPump;//return null;

        
        public override Guid ComponentGuid => new Guid("32C6C154-746A-4B3E-A705-F6292C40476C");
    }
}