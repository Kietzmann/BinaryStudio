﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApplication3 {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Messages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Messages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ConsoleApplication3.Messages", typeof(Messages).Assembly);
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
        ///   Looks up a localized string similar to All zoo is dead..
        /// </summary>
        internal static string AllZooDeadOutput {
            get {
                return ResourceManager.GetString("AllZooDeadOutput", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Available animal types:.
        /// </summary>
        internal static string AvailableAnimalTypesOutput {
            get {
                return ResourceManager.GetString("AvailableAnimalTypesOutput", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Bye..
        /// </summary>
        internal static string ByeOutput {
            get {
                return ResourceManager.GetString("ByeOutput", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enter animal name:.
        /// </summary>
        internal static string EnterAnimalNameOutput {
            get {
                return ResourceManager.GetString("EnterAnimalNameOutput", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enter animal type:.
        /// </summary>
        internal static string EnterAnimalTypeOutput {
            get {
                return ResourceManager.GetString("EnterAnimalTypeOutput", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Press 1 to add animal, 2 to feed animal, 3 to treat animal, 4 to kill animal. Press q to quit..
        /// </summary>
        internal static string GreetingOutput {
            get {
                return ResourceManager.GetString("GreetingOutput", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You have entered incorrect type of animal.
        /// </summary>
        internal static string IncorrectAnimalTypeValueWarningOutput {
            get {
                return ResourceManager.GetString("IncorrectAnimalTypeValueWarningOutput", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You have entered incorrect value. Please try again..
        /// </summary>
        internal static string IncorrectValueWarningOutput {
            get {
                return ResourceManager.GetString("IncorrectValueWarningOutput", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You have entered whitespace name value..
        /// </summary>
        internal static string WhitespaceNameValueWarningOutput {
            get {
                return ResourceManager.GetString("WhitespaceNameValueWarningOutput", resourceCulture);
            }
        }
    }
}