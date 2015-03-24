﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MazeBot {
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MazeBot.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to Bot movement error: Bot cannot move to undefined tile. This should never happen..
        /// </summary>
        internal static string sErrBotAdjacentCellShouldNotBeUndefined {
            get {
                return ResourceManager.GetString("sErrBotAdjacentCellShouldNotBeUndefined", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Bot movement error: Bot cannot move to wall tile..
        /// </summary>
        internal static string sErrBotCannotMoveToWallTile {
            get {
                return ResourceManager.GetString("sErrBotCannotMoveToWallTile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Bot movement error: Bot cannot move to non-adjacent tiles..
        /// </summary>
        internal static string sErrBotMoveCannotMoveNonAdjacentTiles {
            get {
                return ResourceManager.GetString("sErrBotMoveCannotMoveNonAdjacentTiles", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Game error: Invalid Result.
        /// </summary>
        internal static string sErrGameInvalidResult {
            get {
                return ResourceManager.GetString("sErrGameInvalidResult", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Missing required option -i=XMLFile.
        /// </summary>
        internal static string sErrMissingOptionXmlFile {
            get {
                return ResourceManager.GetString("sErrMissingOptionXmlFile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ERROR: {0}.
        /// </summary>
        internal static string sError {
            get {
                return ResourceManager.GetString("sError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Xml Error: Error in Xml initialization.
        /// </summary>
        internal static string sErrXmlGeneric {
            get {
                return ResourceManager.GetString("sErrXmlGeneric", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Xml Error: Goal point should not be at wall..
        /// </summary>
        internal static string sErrXmlGoalPointShouldNotBeAtWall {
            get {
                return ResourceManager.GetString("sErrXmlGoalPointShouldNotBeAtWall", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Xml Error: No endpoints defined in Xml..
        /// </summary>
        internal static string sErrXmlNoEndpointsFound {
            get {
                return ResourceManager.GetString("sErrXmlNoEndpointsFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Xml Error: No walls defined in Xml..
        /// </summary>
        internal static string sErrXmlNoWallsDefined {
            get {
                return ResourceManager.GetString("sErrXmlNoWallsDefined", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Xml Error: Starting point should not be at wall..
        /// </summary>
        internal static string sErrXmlStartingPointShouldNotBeAtWall {
            get {
                return ResourceManager.GetString("sErrXmlStartingPointShouldNotBeAtWall", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Game in progress.
        /// </summary>
        internal static string sGameInProgress {
            get {
                return ResourceManager.GetString("sGameInProgress", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Game not started.
        /// </summary>
        internal static string sGameNotStarted {
            get {
                return ResourceManager.GetString("sGameNotStarted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Game Result: {0}.
        /// </summary>
        internal static string sGameResult {
            get {
                return ResourceManager.GetString("sGameResult", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Found goal.
        /// </summary>
        internal static string sGoalFound {
            get {
                return ResourceManager.GetString("sGoalFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not find goal.
        /// </summary>
        internal static string sGoalNotFound {
            get {
                return ResourceManager.GetString("sGoalNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Point: ({0},{1}).
        /// </summary>
        internal static string sPoint {
            get {
                return ResourceManager.GetString("sPoint", resourceCulture);
            }
        }
    }
}
