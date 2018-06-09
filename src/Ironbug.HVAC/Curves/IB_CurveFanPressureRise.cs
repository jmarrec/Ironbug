﻿using Ironbug.HVAC.BaseClass;
using OpenStudio;
using System;

namespace Ironbug.HVAC.Curves
{
    public class IB_CurveFanPressureRise : IB_Curve
    {
        protected override Func<IB_ModelObject> IB_InitSelf => () => new IB_CurveFanPressureRise();
        private static CurveFanPressureRise InitMethod(Model model)
            => new CurveFanPressureRise(model);
        

        public IB_CurveFanPressureRise():base(InitMethod(new Model()))
        {
        }
        protected override ModelObject InitOpsObj(Model model)
        {
            return base.OnInitOpsObj(InitMethod, model).to_CurveFanPressureRise().get();
        }
    }

    public sealed class IB_CurveFanPressureRise_DataFieldSet
        : IB_FieldSet<IB_CurveFanPressureRise_DataFieldSet, CurveFanPressureRise>
    {
        private IB_CurveFanPressureRise_DataFieldSet() { }
        public IB_Field Coefficient1C1 { get; }
            = new IB_TopField("Coefficient1C1", "C1");

        public IB_Field Coefficient2C2 { get; }
            = new IB_TopField("Coefficient2C2", "C2");

        public IB_Field Coefficient3C3 { get; }
            = new IB_TopField("Coefficient3C3", "C3");

        public IB_Field Coefficient4C4 { get; }
            = new IB_TopField("Coefficient4C4", "C4");
    }
}