﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ironbug.Ladybug
{
    // this is a default static class for holding Valuables and Functions
    public static class WeaStatic
    {


    }//end of default static class

    // this is a class
    public class Wea : IronbugBase
    {
        // this is a class Property
        public object IsWea
        {
            get { return this.RawObj.isWea; }
            set { this.RawObj.isWea = value; }
        }

        // this is a class Property
        public object Header
        {
            get { return this.RawObj.header; }
            set { this.RawObj.header = value; }
        }

        public Wea()
        {
            PythonEngine engine = new PythonEngine();
            dynamic pyModule = engine.ImportFrom(From: "ladybug.wea", Import: "Wea");

            if (pyModule != null)
            {
                this.RawObj = pyModule;
            }
        }

        public Wea(dynamic Instance)
        {
            if (Instance is null) return;
            if (Instance is Wea) return;
            

            Type t = Instance.GetType();
            dynamic obj = null;
            
            bool objFromIronPython = t.GetProperty("Value") != null;

            if (objFromIronPython)
            {
                obj = Instance.Value;
            }
            else
            {
                obj = Instance;
            }
            string pyClsType = obj.__module__;

            if (pyClsType == "ladybug.wea")
            {
                this.RawObj = obj;
            }
            else
            {
                return;
            }
            
            
        }

        // this is a class constructor
        public Wea(object location, object directNormalRadiation, object diffuseHorizontalRadiation, int timestep= 1)
        {
            this.RawObj =  this.RawObj(location, directNormalRadiation, diffuseHorizontalRadiation, timestep);
        }

        // this is a class method
        public Wea From_EpwFile(object Epwfile)
        {
            this.RawObj = this.RawObj.from_epw_file(Epwfile);
            return this;
        }
        
        // this is a class method
        public override string ToString()
        {
            return this.RawObj.ToString();
        }

        

    }
}

