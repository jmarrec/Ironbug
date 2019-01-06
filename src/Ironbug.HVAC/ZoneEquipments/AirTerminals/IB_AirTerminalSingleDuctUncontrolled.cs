using Ironbug.HVAC.BaseClass;
using OpenStudio;
using System;

namespace Ironbug.HVAC
{
    public class IB_AirTerminalSingleDuctConstantVolumeNoReheat : IB_AirTerminal
    {
        protected override Func<IB_ModelObject> IB_InitSelf => () => new IB_AirTerminalSingleDuctConstantVolumeNoReheat();

        private static AirTerminalSingleDuctConstantVolumeNoReheat InitMethod(Model model) => new AirTerminalSingleDuctConstantVolumeNoReheat(model, model.alwaysOnDiscreteSchedule());

        public IB_AirTerminalSingleDuctConstantVolumeNoReheat() : base(InitMethod(new Model()))
        {
        }

        protected override ModelObject InitOpsObj(Model model)
        {
            return base.OnInitOpsObj(InitMethod, model).to_AirTerminalSingleDuctConstantVolumeNoReheat().get();
        }
    }

    public sealed class IB_AirTerminalSingleDuctConstantVolumeNoReheat_DataFieldSet
        : IB_FieldSet<IB_AirTerminalSingleDuctConstantVolumeNoReheat_DataFieldSet, AirTerminalSingleDuctConstantVolumeNoReheat>
    {
        private IB_AirTerminalSingleDuctConstantVolumeNoReheat_DataFieldSet()
        {
        }
    }
}