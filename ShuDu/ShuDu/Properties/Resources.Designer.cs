﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShuDu.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ShuDu.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Sample {
            get {
                object obj = ResourceManager.GetObject("Sample", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {&quot;Blocks&quot;:[{&quot;Lines&quot;:[{&quot;Text&quot;:&quot;5&quot;,&quot;BoundingPolygon&quot;:[{&quot;X&quot;:87,&quot;Y&quot;:130},{&quot;X&quot;:130,&quot;Y&quot;:130},{&quot;X&quot;:128,&quot;Y&quot;:185},{&quot;X&quot;:86,&quot;Y&quot;:184}],&quot;Words&quot;:[{&quot;Text&quot;:&quot;5&quot;,&quot;BoundingPolygon&quot;:[{&quot;X&quot;:86,&quot;Y&quot;:130},{&quot;X&quot;:114,&quot;Y&quot;:130},{&quot;X&quot;:114,&quot;Y&quot;:185},{&quot;X&quot;:86,&quot;Y&quot;:184}],&quot;Confidence&quot;:0.96}]},{&quot;Text&quot;:&quot;8&quot;,&quot;BoundingPolygon&quot;:[{&quot;X&quot;:200,&quot;Y&quot;:128},{&quot;X&quot;:245,&quot;Y&quot;:127},{&quot;X&quot;:244,&quot;Y&quot;:182},{&quot;X&quot;:199,&quot;Y&quot;:183}],&quot;Words&quot;:[{&quot;Text&quot;:&quot;8&quot;,&quot;BoundingPolygon&quot;:[{&quot;X&quot;:205,&quot;Y&quot;:128},{&quot;X&quot;:233,&quot;Y&quot;:127},{&quot;X&quot;:234,&quot;Y&quot;:181},{&quot;X&quot;:206,&quot;Y&quot;:182}],&quot;Confidence&quot;:0.994}]},{&quot;Text&quot;:&quot;6&q....
        /// </summary>
        internal static string SampleJson {
            get {
                return ResourceManager.GetString("SampleJson", resourceCulture);
            }
        }
    }
}