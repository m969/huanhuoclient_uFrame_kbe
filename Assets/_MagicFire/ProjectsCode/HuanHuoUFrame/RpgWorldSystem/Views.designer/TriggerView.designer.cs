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
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.Kernel;
    using uFrame.Kernel.Serialization;
    using uFrame.MVVM;
    using uFrame.MVVM.Bindings;
    using uFrame.MVVM.Services;
    using uFrame.MVVM.ViewModels;
    using UniRx;
    using UnityEngine;
    
    
    public class TriggerViewBase : ModelView {
        
        [UnityEngine.SerializeField()]
        [uFrame.MVVM.Attributes.UFGroup("View Model Properties")]
        [UnityEngine.HideInInspector()]
        public Int32 _triggerSize;
        
        [UnityEngine.SerializeField()]
        [uFrame.MVVM.Attributes.UFGroup("View Model Properties")]
        [UnityEngine.HideInInspector()]
        public String _triggerType;
        
        [UnityEngine.SerializeField()]
        [uFrame.MVVM.Attributes.UFGroup("View Model Properties")]
        [UnityEngine.HideInInspector()]
        public Int32 _circleTrigger;
        
        [UnityEngine.SerializeField()]
        [uFrame.MVVM.Attributes.UFGroup("View Model Properties")]
        [UnityEngine.HideInInspector()]
        public String _campName;
        
        [UnityEngine.SerializeField()]
        [uFrame.MVVM.Attributes.UFGroup("View Model Properties")]
        [UnityEngine.HideInInspector()]
        public Int32 _triggerID;
        
        [UnityEngine.SerializeField()]
        [uFrame.MVVM.Attributes.UFGroup("View Model Properties")]
        [UnityEngine.HideInInspector()]
        public Single _lifeSpans;
        
        [uFrame.MVVM.Attributes.UFToggleGroup("triggerSize")]
        [UnityEngine.HideInInspector()]
        public bool _BindtriggerSize = true;
        
        [uFrame.MVVM.Attributes.UFGroup("triggerSize")]
        [UnityEngine.SerializeField()]
        [UnityEngine.HideInInspector()]
        [UnityEngine.Serialization.FormerlySerializedAsAttribute("_triggerSizeonlyWhenChanged")]
        protected bool _triggerSizeOnlyWhenChanged;
        
        [uFrame.MVVM.Attributes.UFToggleGroup("campName")]
        [UnityEngine.HideInInspector()]
        public bool _BindcampName = true;
        
        [uFrame.MVVM.Attributes.UFGroup("campName")]
        [UnityEngine.SerializeField()]
        [UnityEngine.HideInInspector()]
        [UnityEngine.Serialization.FormerlySerializedAsAttribute("_campNameonlyWhenChanged")]
        protected bool _campNameOnlyWhenChanged;
        
        public override string DefaultIdentifier {
            get {
                return base.DefaultIdentifier;
            }
        }
        
        public override System.Type ViewModelType {
            get {
                return typeof(TriggerViewModel);
            }
        }
        
        public TriggerViewModel Trigger {
            get {
                return (TriggerViewModel)ViewModelObject;
            }
        }
        
        protected override void InitializeViewModel(uFrame.MVVM.ViewModels.ViewModel model) {
            base.InitializeViewModel(model);
            // NOTE: this method is only invoked if the 'Initialize ViewModel' is checked in the inspector.
            // var vm = model as TriggerViewModel;
            // This method is invoked when applying the data from the inspector to the viewmodel.  Add any view-specific customizations here.
            var triggerview = ((TriggerViewModel)model);
            triggerview.triggerSize = this._triggerSize;
            triggerview.triggerType = this._triggerType;
            triggerview.circleTrigger = this._circleTrigger;
            triggerview.campName = this._campName;
            triggerview.triggerID = this._triggerID;
            triggerview.lifeSpans = this._lifeSpans;
        }
        
        public override void Bind() {
            base.Bind();
            // Use this.Trigger to access the viewmodel.
            // Use this method to subscribe to the view-model.
            // Any designer bindings are created in the base implementation.
            if (_BindtriggerSize) {
                this.BindProperty(this.Trigger.triggerSizeProperty, this.triggerSizeChanged, _triggerSizeOnlyWhenChanged);
            }
            if (_BindcampName) {
                this.BindProperty(this.Trigger.campNameProperty, this.campNameChanged, _campNameOnlyWhenChanged);
            }
        }
        
        public virtual void triggerSizeChanged(Int32 arg1) {
        }
        
        public virtual void campNameChanged(String arg1) {
        }
    }
}