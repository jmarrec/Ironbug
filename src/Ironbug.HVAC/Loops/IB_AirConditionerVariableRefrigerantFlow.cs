﻿using Ironbug.HVAC.BaseClass;
using OpenStudio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ironbug.HVAC
{
    public class IB_AirConditionerVariableRefrigerantFlow: IB_VRFSystem
    {
        protected override Func<IB_ModelObject> IB_InitSelf => () => new IB_AirConditionerVariableRefrigerantFlow();

        public List<IB_ZoneHVACTerminalUnitVariableRefrigerantFlow> Terminals { get; private set; } 
            = new List<IB_ZoneHVACTerminalUnitVariableRefrigerantFlow>();

        

        private static AirConditionerVariableRefrigerantFlow NewDefaultOpsObj(Model model) 
            => new AirConditionerVariableRefrigerantFlow(model);

        public IB_AirConditionerVariableRefrigerantFlow() : base(NewDefaultOpsObj(new Model()))
        {
        }

        public void AddTerminal(IB_ZoneHVACTerminalUnitVariableRefrigerantFlow Terminal)
        {
            this.Terminals.Add(Terminal);
        }
        

        public override IB_ModelObject Duplicate()
        {
            var newObj = (IB_AirConditionerVariableRefrigerantFlow)base.DuplicateIBObj(IB_InitSelf);
            foreach (var item in this.Terminals)
            {
                newObj.AddTerminal((IB_ZoneHVACTerminalUnitVariableRefrigerantFlow)item.Duplicate());
            }

            return newObj;
        }
        public override HVACComponent ToOS(Model model)
        {
            var newObj = base.OnNewOpsObj(NewDefaultOpsObj, model);

            var allTerms = this.Terminals;
            foreach (var terminal in allTerms)
            {
                
                var item = (IB_ZoneHVACTerminalUnitVariableRefrigerantFlow)terminal;
                //newObj.addTerminal((ZoneHVACTerminalUnitVariableRefrigerantFlow)item.ToOS(model));
                
            }
            
            return newObj;
        }


    }

    public sealed class IB_AirConditionerVariableRefrigerantFlow_FieldSet
        : IB_FieldSet<IB_AirConditionerVariableRefrigerantFlow_FieldSet, AirConditionerVariableRefrigerantFlow>
    {
        private IB_AirConditionerVariableRefrigerantFlow_FieldSet() { }
        
        public IB_Field Name { get; }
            = new IB_BasicField("Name", "Name");
        public IB_Field RatedCoolingCOP { get; }
            = new IB_BasicField("RatedCoolingCOP", "CoCOP");
        public IB_Field RatedHeatingCOP { get; }
            = new IB_BasicField("RatedHeatingCOP", "HeCOP");
    }
}
