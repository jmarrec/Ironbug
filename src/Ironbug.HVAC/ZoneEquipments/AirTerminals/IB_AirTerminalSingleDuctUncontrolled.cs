using Ironbug.HVAC.BaseClass;
using OpenStudio;
using System;

namespace Ironbug.HVAC
{
    public class IB_AirTerminalSingleDuctConstantVolumeNoReheat: IB_AirTerminal
    {
        protected override Func<IB_ModelObject> IB_InitSelf => () => new IB_AirTerminalSingleDuctConstantVolumeNoReheat();

        private static AirTerminalSingleDuctConstantVolumeNoReheat NewDefaultOpsObj(Model model) => new AirTerminalSingleDuctConstantVolumeNoReheat(model,model.alwaysOnDiscreteSchedule());

        public IB_AirTerminalSingleDuctConstantVolumeNoReheat():base(NewDefaultOpsObj(new Model()))
        {
        }

        public override HVACComponent ToOS(Model model)
        {
            return base.OnNewOpsObj(NewDefaultOpsObj, model);
        }
        
        
    }

    public sealed class IB_AirTerminalSingleDuctUncontrolled_FieldSet
        : IB_FieldSet<IB_AirTerminalSingleDuctUncontrolled_FieldSet, AirTerminalSingleDuctConstantVolumeNoReheat>
    {
        private IB_AirTerminalSingleDuctUncontrolled_FieldSet() { }

    }

}
