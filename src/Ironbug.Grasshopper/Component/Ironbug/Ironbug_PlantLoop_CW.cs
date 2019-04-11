﻿using System;
using System.Collections.Generic;
using System.Linq;
using Grasshopper.Kernel;
using Ironbug.Grasshopper.Properties;
using Ironbug.HVAC.BaseClass;

namespace Ironbug.Grasshopper.Component
{
    public class Ironbug_PlantLoop_CW : Ironbug_HVACComponent
    {
        
        public Ironbug_PlantLoop_CW()
          : base("Ironbug_ChilledWaterPlantLoop", "ChilledWaterLoop",
              "Same as PlantLoop, except the FluidType and LoopType cannot be overridden.",
              "Ironbug", "01:Loops",
              typeof(HVAC.IB_PlantLoop_FieldSet))
        {
        }

        public override GH_Exposure Exposure => GH_Exposure.primary;

        
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("supply", "supply", "HVAC components", GH_ParamAccess.list);
            pManager[0].Optional = true;
            pManager.AddGenericParameter("demand", "demand", "HVAC components", GH_ParamAccess.list);
            pManager[1].Optional = true;
            pManager.AddGenericParameter("sizingLoop", "sizing", "HVAC components", GH_ParamAccess.item);
            pManager[2].Optional = true;
        }

        
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("ChilledWaterPlantLoop", "CWLoop", "ChilledWaterPlantLoop", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            List<IB_HVACObject> supplyComs = new List<IB_HVACObject>();
            List<IB_HVACObject> demandComs = new List<IB_HVACObject>();
            HVAC.IB_SizingPlant sizing = new HVAC.IB_SizingPlant();

            DA.GetDataList(0, supplyComs);
            DA.GetDataList(1, demandComs);
            DA.GetData(2, ref sizing);


            var plant = new HVAC.IB_PlantLoop();
            var plantFields = HVAC.IB_PlantLoop_FieldSet.Value;
            plant.SetFieldValues(
                new Dictionary<IB_Field, object>() {
                    { plantFields.Name, "Chilled Water Loop" },
                    { plantFields.FluidType, "Water" }
                });
     

            foreach (var item in supplyComs)
            {
                var newItem = item.Duplicate();
                plant.AddToSupply(newItem);
            }
            foreach (var item in demandComs)
            {
                var newItem = item.Duplicate();
                plant.AddToDemand(newItem);
            }
            
            var sizingChecked = this.setSizingDefault(sizing);
            plant.SetSizingPlant(sizingChecked);
            
            base.SetObjParamsTo(plant);
            
            DA.SetData(0, plant);
        }

        
        protected override System.Drawing.Bitmap Icon => Resources.PlantLoopCW;

        public override Guid ComponentGuid => new Guid("1A540675-358F-45EB-A73C-FB7C4BFC9541");


        private HVAC.IB_SizingPlant setSizingDefault(HVAC.IB_SizingPlant sizingPlant)
        {
            var szFields = HVAC.IB_SizingPlant_FieldSet.Value;
            var sizing = sizingPlant.Duplicate() as HVAC.IB_SizingPlant;

            var custAtt = sizing.CustomAttributes.Select(_=>_.Key.FULLNAME);

            sizing.SetFieldValue(szFields.LoopType, "Cooling");
            
            if (!custAtt.Any(_=>_ == szFields.DesignLoopExitTemperature.FULLNAME))
            {
                sizing.SetFieldValue(szFields.DesignLoopExitTemperature, 7.22);
            }

            if (!custAtt.Any(_ => _ == szFields.LoopDesignTemperatureDifference.FULLNAME))
            {
                sizing.SetFieldValue(szFields.LoopDesignTemperatureDifference, 6.67);
            }
            

            return sizing;
        }
        public override void CreateAttributes()
        {
            var newAttri = new IB_LoopComponentAttributes(this);
            m_attributes = newAttri;
        }
    }
}