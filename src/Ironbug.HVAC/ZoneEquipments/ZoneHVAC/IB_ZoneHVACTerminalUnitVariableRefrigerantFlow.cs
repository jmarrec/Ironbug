﻿using System;
using Ironbug.HVAC.BaseClass;
using OpenStudio;

namespace Ironbug.HVAC
{
    public class IB_ZoneHVACTerminalUnitVariableRefrigerantFlow 
        : IB_ZoneEquipment, IIB_DualLoopObj
        
    {
        protected override Func<IB_ModelObject> IB_InitSelf => () => new IB_ZoneHVACTerminalUnitVariableRefrigerantFlow();

        private static ZoneHVACTerminalUnitVariableRefrigerantFlow NewDefaultOpsObj(Model model) 
            => new ZoneHVACTerminalUnitVariableRefrigerantFlow(model);
        
        public IB_ZoneHVACTerminalUnitVariableRefrigerantFlow() : base(NewDefaultOpsObj(new Model()))
        { 
        }
        
        //public override ZoneHVACTerminalUnitVariableRefrigerantFlow ToOS(Model model)
        //{
        //    return base.OnNewOpsObj(NewDefaultOpsObj, model);
        //}

        public override HVACComponent ToOS(Model model)
        {
            return base.OnNewOpsObj(NewDefaultOpsObj, model);
        }



    }

    public sealed class IB_ZoneHVACTerminalUnitVariableRefrigerantFlow_FieldSet
        : IB_FieldSet<IB_ZoneHVACTerminalUnitVariableRefrigerantFlow_FieldSet, ZoneHVACTerminalUnitVariableRefrigerantFlow>
    {
        private IB_ZoneHVACTerminalUnitVariableRefrigerantFlow_FieldSet() { }
        
        //public IB_DataField Name { get; }
        //    = new IB_BasicDataField("Name", "Name");
        //public IB_DataField RatedCoolingCOP { get; }
        //    = new IB_BasicDataField("RatedCoolingCOP", "CoCOP");
        //public IB_DataField RatedHeatingCOP { get; }
        //    = new IB_BasicDataField("RatedHeatingCOP", "HeCOP");
    }
}
