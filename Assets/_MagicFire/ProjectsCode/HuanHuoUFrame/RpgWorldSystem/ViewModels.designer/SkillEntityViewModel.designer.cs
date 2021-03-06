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
    using uFrame.IOC;
    using uFrame.Kernel;
    using uFrame.Kernel.Serialization;
    using uFrame.MVVM;
    using uFrame.MVVM.Bindings;
    using uFrame.MVVM.ViewModels;
    using UniRx;
    using UnityEngine;
    
    
    public partial class SkillEntityViewModelBase : SuperPowerEntityViewModel {
        
        private P<Int32> _isIceFreezingProperty;
        
        public SkillEntityViewModelBase(uFrame.Kernel.IEventAggregator aggregator) : 
                base(aggregator) {
        }
        
        public virtual P<Int32> isIceFreezingProperty {
            get {
                return _isIceFreezingProperty;
            }
            set {
                _isIceFreezingProperty = value;
            }
        }
        
        public virtual Int32 isIceFreezing {
            get {
                return isIceFreezingProperty.Value;
            }
            set {
                isIceFreezingProperty.Value = value;
            }
        }
        
        public override void Bind() {
            base.Bind();
            _isIceFreezingProperty = new P<Int32>(this, "isIceFreezing");
        }
        
        public override void Read(uFrame.Kernel.Serialization.ISerializerStream stream) {
            base.Read(stream);
            this.isIceFreezing = stream.DeserializeInt("isIceFreezing");;
        }
        
        public override void Write(uFrame.Kernel.Serialization.ISerializerStream stream) {
            base.Write(stream);
            stream.SerializeInt("isIceFreezing", this.isIceFreezing);
        }
        
        protected override void FillCommands(System.Collections.Generic.List<uFrame.MVVM.ViewModels.ViewModelCommandInfo> list) {
            base.FillCommands(list);
        }
        
        protected override void FillProperties(System.Collections.Generic.List<uFrame.MVVM.ViewModels.ViewModelPropertyInfo> list) {
            base.FillProperties(list);
            // PropertiesChildItem
            list.Add(new ViewModelPropertyInfo(_isIceFreezingProperty, false, false, false, false));
        }
    }
    
    public partial class SkillEntityViewModel {
        
        public SkillEntityViewModel(uFrame.Kernel.IEventAggregator aggregator) : 
                base(aggregator) {
        }
    }
}
