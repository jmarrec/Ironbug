﻿using Ironbug.HVAC.BaseClass;
using OpenStudio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ironbug.HVAC
{
    public class IB_SizingSystem: IB_ModelObject
    {
        protected override Func<IB_ModelObject> IB_InitSelf => () => new IB_SizingSystem();

        private static SizingSystem InitMethod(Model model) => new SizingSystem(model, new AirLoopHVAC(model));
        

        public IB_SizingSystem() : base(InitMethod(new Model()))
        {
        }
        public override IB_ModelObject Duplicate()
        {
            return base.DuplicateIBObj(IB_InitSelf);
        }

        public ModelObject ToOS(AirLoopHVAC loop)
        {
            //create a new sizingPlant to target plant loop
            var targetModel = loop.model();
            return base.OnInitOpsObj((Model model) => new SizingSystem(model, loop), targetModel);
        }
        //this is replaced by above method
        protected override ModelObject InitOpsObj(Model model)
        {
            throw new NotImplementedException();
        }

    }

    public sealed class IB_SizingSystem_FieldSet
        : IB_FieldSet<IB_SizingSystem_FieldSet, SizingSystem>
    {

        private IB_SizingSystem_FieldSet() { }
        
        public IB_Field TypeofLoadtoSizeOn { get; }
            = new IB_BasicField("TypeofLoadtoSizeOn", "typeOfLoad");

        public IB_Field DesignOutdoorAirFlowRate { get; }
            = new IB_BasicField("DesignOutdoorAirFlowRate", "OAFlowRate");

        public IB_Field MinimumSystemAirFlowRatio { get; }
            = new IB_BasicField("MinimumSystemAirFlowRatio", "MinFlowRatio");


    }

}
