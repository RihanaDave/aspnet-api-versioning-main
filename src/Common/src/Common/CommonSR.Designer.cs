﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Asp.Versioning {
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
    internal sealed class CommonSR {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal CommonSR() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Asp.Versioning.CommonSR", typeof(CommonSR).Assembly);
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
        ///   Looks up a localized string similar to &apos;{0}&apos; and &apos;{1}&apos; cannot both be null..
        /// </summary>
        internal static string InvalidPolicyKey
        {
            get
            {
                return ResourceManager.GetString( "InvalidPolicyKey", resourceCulture );
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to The following API versions were requested: {0}. At most, only a single API version may be specified. Please update the intended API version and retry the request..
        /// </summary>
        internal static string MultipleDifferentApiVersionsRequested {
            get {
                return ResourceManager.GetString("MultipleDifferentApiVersionsRequested", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to At least one IApiVersionReader must be specified..
        /// </summary>
        internal static string ZeroApiVersionReaders
        {
            get
            {
                return ResourceManager.GetString( "ZeroApiVersionReaders", resourceCulture );
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to The template '{0}' has more than one parameter and no parameter name was specified..
        /// </summary>
        internal static string InvalidMediaTypeTemplate
        {
            get
            {
                return ResourceManager.GetString( "InvalidMediaTypeTemplate", resourceCulture );
            }
        }
    }
}
