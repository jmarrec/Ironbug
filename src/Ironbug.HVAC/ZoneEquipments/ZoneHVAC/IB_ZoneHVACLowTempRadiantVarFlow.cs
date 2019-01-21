﻿using System;
using Ironbug.HVAC.BaseClass;
using OpenStudio;

namespace Ironbug.HVAC
{
    public class IB_ZoneHVACLowTempRadiantVarFlow : BaseClass.IB_ZoneEquipment
    {
        private IB_CoilHeatingLowTempRadiantVarFlow HeatingCoil => this.Children.Get<IB_CoilHeatingLowTempRadiantVarFlow>();
        private IB_CoilCoolingLowTempRadiantVarFlow CoolingCoil => this.Children.Get<IB_CoilCoolingLowTempRadiantVarFlow>();
        
        protected override Func<IB_ModelObject> IB_InitSelf 
            => () => new IB_ZoneHVACLowTempRadiantVarFlow(HeatingCoil, CoolingCoil);

        private static ZoneHVACLowTempRadiantVarFlow NewDefaultOpsObj(Model model, IB_CoilHeatingLowTempRadiantVarFlow HeatingCoil, IB_CoilCoolingLowTempRadiantVarFlow CoolingCoil) 
            => new ZoneHVACLowTempRadiantVarFlow(model,model.alwaysOnDiscreteSchedule(), HeatingCoil.ToOS(model), CoolingCoil.ToOS(model));

        
        public IB_ZoneHVACLowTempRadiantVarFlow(IB_CoilHeatingLowTempRadiantVarFlow HeatingCoil, IB_CoilCoolingLowTempRadiantVarFlow CoolingCoil) 
            : base(NewDefaultOpsObj(new Model(), HeatingCoil, CoolingCoil))
        {
            this.AddChild(HeatingCoil);
            this.AddChild(CoolingCoil);
            
        }
        
        protected override ModelObject NewOpsObj(Model model)
        {
            var opsObj =  base.OnNewOpsObj(LocalInitMethod, model).to_ZoneHVACLowTempRadiantVarFlow().get();
            return opsObj;

            ZoneHVACLowTempRadiantVarFlow LocalInitMethod(Model m)
            => new ZoneHVACLowTempRadiantVarFlow(
                m, 
                m.alwaysOnDiscreteSchedule(), 
                HeatingCoil.ToOS(m), 
                CoolingCoil.ToOS(m)
                );
        }
    }

    public sealed class IB_ZoneHVACLowTempRadiantVarFlow_DataFieldSet
        : IB_FieldSet<IB_ZoneHVACLowTempRadiantVarFlow_DataFieldSet, ZoneHVACLowTempRadiantVarFlow>
    {
        private IB_ZoneHVACLowTempRadiantVarFlow_DataFieldSet() { }

    }
}