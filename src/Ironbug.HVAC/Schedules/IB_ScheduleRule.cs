﻿using Ironbug.HVAC.BaseClass;
using OpenStudio;
using System;

namespace Ironbug.HVAC.Schedules
{
    public class IB_ScheduleRule : IB_Schedule
    {
        protected override Func<IB_ModelObject> IB_InitSelf
            => () => new IB_ScheduleRule();

        private static ScheduleRule InitMethod(Model model)
            => new ScheduleRule(new ScheduleRuleset(model));


        public IB_ScheduleDay ScheduleDay => this.Children.Get<IB_ScheduleDay>();

        public IB_ScheduleRule() : base(InitMethod(new Model()))
        {
        }

        public IB_ScheduleRule(IB_ScheduleDay SchDay) : base(InitMethod(new Model()))
        {
            AddChild(SchDay);
        }

        public override ModelObject ToOS(Model model)
        {
            throw new ArgumentException(@"Use 'public ScheduleRule ToOS(ScheduleRuleset Ruleset)' instead!");
        }

        public ScheduleRule ToOS(ScheduleRuleset Ruleset)
        {
            var model = Ruleset.model();
            this.CustomAttributes.TryGetValue(IB_Field_Comment.Instance, out object trackingId);
            var name = $"ScheduleRule - {trackingId.ToString().Substring(12)}";

            var sch_o = model.getScheduleRuleByName(name);
            var obj = (ScheduleRule)null;
            if (sch_o.is_initialized())
            {
                obj = sch_o.get();
            }
            else
            {
                //There is a bug in ScheduleRule when it is initialized with ScheduleDay, it recreates a new ScheduleDay
                var day = this.ScheduleDay.ToOS(new Model()) as ScheduleDay;
                obj = new ScheduleRule(Ruleset, day);
                obj.setName(name);
            }

            return obj;
        }

      
        //public ScheduleRule ToOS(ScheduleRule ExistingRule)
        //{
        //    var obj = ExistingRule;
        //    var model = obj.model();
        //    //TODO: copy attributes to existing obj
        //    var day = obj.daySchedule();
        //    this.ScheduleDay.CopyValuesToExisting(day);
       
        //    return obj;
        //}
    }
    public sealed class IB_ScheduleRule_FieldSet
    : IB_FieldSet<IB_ScheduleRule_FieldSet, ScheduleRule>
    {
        private IB_ScheduleRule_FieldSet() { }
        
    }
}