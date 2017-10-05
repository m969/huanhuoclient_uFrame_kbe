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
    using uFrame.ECS.APIs;
    using uFrame.ECS.Components;
    using uFrame.ECS.Systems;
    using uFrame.Kernel;
    using UniRx;
    using UnityEngine;
    
    
    public partial class RpgInputSystemBase : uFrame.ECS.Systems.EcsSystem, uFrame.ECS.APIs.ISystemUpdate {
        
        private IEcsComponentManagerOf<RpgInputModule> _RpgInputModuleManager;
        
        private RpgInputSystemUpdateHandler RpgInputSystemUpdateHandlerInstance = new RpgInputSystemUpdateHandler();
        
        public IEcsComponentManagerOf<RpgInputModule> RpgInputModuleManager {
            get {
                return _RpgInputModuleManager;
            }
            set {
                _RpgInputModuleManager = value;
            }
        }
        
        public override void Setup() {
            base.Setup();
            RpgInputModuleManager = ComponentSystem.RegisterComponent<RpgInputModule>(1);
            RpgInputModuleManager.RemovedObservable.Subscribe(_=>RpgInputModuleComponentDestroyed(_,_)).DisposeWith(this);
            RpgInputModuleManager.CreatedObservable.Subscribe(ComponentCreatedHandlerFilter).DisposeWith(this);
        }
        
        protected virtual void RpgInputSystemUpdateHandler(RpgInputModule group) {
            var handler = RpgInputSystemUpdateHandlerInstance;
            handler.System = this;
            handler.Group = group;
            handler.Execute();
        }
        
        protected void RpgInputSystemUpdateFilter() {
            var RpgInputModuleItems = RpgInputModuleManager.Components;
            for (var RpgInputModuleIndex = 0
            ; RpgInputModuleIndex < RpgInputModuleItems.Count; RpgInputModuleIndex++
            ) {
                if (!RpgInputModuleItems[RpgInputModuleIndex].Enabled) {
                    continue;
                }
                this.RpgInputSystemUpdateHandler(RpgInputModuleItems[RpgInputModuleIndex]);
            }
        }
        
        public virtual void SystemUpdate() {
            RpgInputSystemUpdateFilter();
        }
        
        protected virtual void RpgInputModuleComponentDestroyed(RpgInputModule data, RpgInputModule group) {
        }
        
        protected void RpgInputModuleComponentDestroyedFilter(RpgInputModule data) {
            var GroupRpgInputModule = RpgInputModuleManager[data.EntityId];
            if (GroupRpgInputModule == null) {
                return;
            }
            if (!GroupRpgInputModule.Enabled) {
                return;
            }
            this.RpgInputModuleComponentDestroyed(data, GroupRpgInputModule);
        }
        
        protected virtual void ComponentCreatedHandler(RpgInputModule data, RpgInputModule group) {
        }
        
        protected void ComponentCreatedHandlerFilter(RpgInputModule data) {
            var GroupRpgInputModule = RpgInputModuleManager[data.EntityId];
            if (GroupRpgInputModule == null) {
                return;
            }
            if (!GroupRpgInputModule.Enabled) {
                return;
            }
            this.ComponentCreatedHandler(data, GroupRpgInputModule);
        }
    }
    
    [uFrame.Attributes.uFrameIdentifier("2cd840ab-21c7-4ec9-8561-4f956214683a")]
    public partial class RpgInputSystem : RpgInputSystemBase {
        
        private static RpgInputSystem _Instance;
        
        public RpgInputSystem() {
            Instance = this;
        }
        
        public static RpgInputSystem Instance {
            get {
                return _Instance;
            }
            set {
                _Instance = value;
            }
        }
    }
}