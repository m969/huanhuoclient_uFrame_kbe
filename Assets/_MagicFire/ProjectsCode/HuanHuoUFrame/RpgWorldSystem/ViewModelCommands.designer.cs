// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.42000
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace MagicFire.HuanHuoUFrame {
    using MagicFire.HuanHuoUFrame;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.Kernel;
    using uFrame.Kernel.Serialization;
    using uFrame.MVVM;
    using uFrame.MVVM.Bindings;
    using uFrame.MVVM.ViewModels;
    using UnityEngine;
    
    
    public partial class OnDestroyCommand : uFrame.MVVM.ViewModels.ViewModelCommand {
    }
    
    public partial class OnStopMoveCommand : uFrame.MVVM.ViewModels.ViewModelCommand {
    }
    
    public partial class onMainAvatarEnterSpaceCommand : uFrame.MVVM.ViewModels.ViewModelCommand {
        
        private Int32 _SpaceId;
        
        private String _SpaceName;
        
        public Int32 SpaceId {
            get {
                return _SpaceId;
            }
            set {
                _SpaceId = value;
            }
        }
        
        public String SpaceName {
            get {
                return _SpaceName;
            }
            set {
                _SpaceName = value;
            }
        }
    }
    
    public partial class OnLeaveWorldCommand : uFrame.MVVM.ViewModels.ViewModelCommand {
    }
    
    public partial class onMainAvatarLeaveSpaceCommand : uFrame.MVVM.ViewModels.ViewModelCommand {
    }
    
    public partial class DoMoveCommand : uFrame.MVVM.ViewModels.ViewModelCommand {
        
        private Vector3 _Point;
        
        public Vector3 Point {
            get {
                return _Point;
            }
            set {
                _Point = value;
            }
        }
    }
}
