using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace WilliamsBestAF.Model
{
    public class LocationInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public override string ToString()
        {
            return this.Name + " " + Latitude + " " + Longitude;
        }

        //
        // System.Reflection GetType().GetMethod("Split", new Type[] { typeof(char[]) }).Invoke(this, new object[] { new char[] { ' ' } });
        MethodInfo SplitMethod1 = typeof(string).GetMethod("Split", bindingAttr: BindingFlags.Public | BindingFlags.Instance, binder: null, types: new Type[] { typeof(char[]) }, modifiers: null);
        // typeof(string).GetMethod("Split")
        MethodInfo SplitMethod2 = typeof(string).GetMethod("Split");
        // typeof(string).GetMethod("Split", new Type[] { typeof(char[]) })
        MethodInfo SplitMethod3 = typeof(string).GetMethod("Split", new Type[] { typeof(char[]) });
        // typeof(string).GetMethod("Split", new Type[] { typeof(char[]) })
        MethodInfo SplitMethod4 = typeof(string).GetMethod("Split", new Type[] { typeof(char[]) });
        // typeof(string).GetMethod("Split", new Type[] { typeof(char[]) })
        


    }
}
