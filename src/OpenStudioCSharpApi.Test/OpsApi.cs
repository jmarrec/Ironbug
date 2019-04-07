using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenStudio;

namespace OpenStudioCSharpApi.Test
{
    [TestClass]
    public class OpsApi
    {
        [TestMethod()]
        public void CoilHeatingElecTest()
        {

            var m1 = new Model();

            //1. Add heating coil before the fan
            var lp1 = new AirLoopHVAC(m1);
            var supplyOutletNode1 = lp1.supplyOutletNode();
            ////Add heating coil
            var coil1 = new CoilHeatingElectric(m1);
            coil1.addToNode(supplyOutletNode1);
            ////Add fan
            var fan1 = new FanConstantVolume(m1);
            fan1.addToNode(supplyOutletNode1);
            ////Add SPM
            var spm1 = new SetpointManagerScheduled(m1, new ScheduleRuleset(m1, 20));
            spm1.addToNode(supplyOutletNode1);


            //2. Add fan before heating coil
            var lp2 = new AirLoopHVAC(m1);
            var supplyOutletNode2 = lp2.supplyOutletNode();
            ////Add fan
            var fan2 = new FanConstantVolume(m1);
            fan2.addToNode(supplyOutletNode2);
            ////Add heating coil
            var fanInletNode = fan2.inletModelObject().get().to_Node().get();
            var coil2 = new CoilHeatingElectric(m1);
            coil2.addToNode(fanInletNode);

            ////Add SPM
            var spm2 = new SetpointManagerScheduled(m1, new ScheduleRuleset(m1, 20));
            spm2.addToNode(supplyOutletNode2);



            //check temperatureSetpointNode
            var success = true;
            if (coil1.temperatureSetpointNode().is_initialized())
            {
                var coilTempNodeName = coil1.temperatureSetpointNode().get().nameString();
                var SpmNodeName = supplyOutletNode1.nameString();
                var isCoilTempNodeSetToSPM = coilTempNodeName == SpmNodeName;
                //isCoilTempNodeSetToSPM is True;
                success &= isCoilTempNodeSetToSPM == true;
            }

            if (coil2.temperatureSetpointNode().is_initialized())
            {
                var coilTempNodeName = coil2.temperatureSetpointNode().get().nameString();
                var SpmNodeName = supplyOutletNode2.nameString();
                var isCoilTempNodeSetToSPM = coilTempNodeName == SpmNodeName;
                //isCoilTempNodeSetToSPM is False;
                success &= isCoilTempNodeSetToSPM == false;
            }

            Assert.IsTrue(success);

        }
    }
}
