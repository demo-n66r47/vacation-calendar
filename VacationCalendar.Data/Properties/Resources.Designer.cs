﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VacationCalendar.Data.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("VacationCalendar.Data.Properties.Resources", typeof(Resources).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Date from.
        /// </summary>
        public static string DateFrom {
            get {
                return ResourceManager.GetString("DateFrom", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Date to.
        /// </summary>
        public static string DateTo {
            get {
                return ResourceManager.GetString("DateTo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to First name.
        /// </summary>
        public static string FirstName {
            get {
                return ResourceManager.GetString("FirstName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Last name.
        /// </summary>
        public static string LastName {
            get {
                return ResourceManager.GetString("LastName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Vacation type.
        /// </summary>
        public static string VacationType {
            get {
                return ResourceManager.GetString("VacationType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Holiday.
        /// </summary>
        public static string VacationTypeKind_Holiday {
            get {
                return ResourceManager.GetString("VacationTypeKind_Holiday", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Sick leave.
        /// </summary>
        public static string VacationTypeKind_SickLeave {
            get {
                return ResourceManager.GetString("VacationTypeKind_SickLeave", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Vacation leave.
        /// </summary>
        public static string VacationTypeKind_VacationLeave {
            get {
                return ResourceManager.GetString("VacationTypeKind_VacationLeave", resourceCulture);
            }
        }
    }
}
