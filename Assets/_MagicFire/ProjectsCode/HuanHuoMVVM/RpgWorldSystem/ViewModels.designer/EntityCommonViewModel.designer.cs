// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.42000
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace MagicFire.HuanHuoMVVM {
    using MagicFire.HuanHuoMVVM;
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
    
    
    public partial class EntityCommonViewModelBase : uFrame.MVVM.ViewModels.ViewModel {
        
        private P<String> _modelTypeProperty;
        
        private P<String> _entityNameProperty;
        
        private P<String> _modelNameProperty;
        
        public EntityCommonViewModelBase(uFrame.Kernel.IEventAggregator aggregator) : 
                base(aggregator) {
        }
        
        public virtual P<String> modelTypeProperty {
            get {
                return _modelTypeProperty;
            }
            set {
                _modelTypeProperty = value;
            }
        }
        
        public virtual P<String> entityNameProperty {
            get {
                return _entityNameProperty;
            }
            set {
                _entityNameProperty = value;
            }
        }
        
        public virtual P<String> modelNameProperty {
            get {
                return _modelNameProperty;
            }
            set {
                _modelNameProperty = value;
            }
        }
        
        public virtual String modelType {
            get {
                return modelTypeProperty.Value;
            }
            set {
                modelTypeProperty.Value = value;
            }
        }
        
        public virtual String entityName {
            get {
                return entityNameProperty.Value;
            }
            set {
                entityNameProperty.Value = value;
            }
        }
        
        public virtual String modelName {
            get {
                return modelNameProperty.Value;
            }
            set {
                modelNameProperty.Value = value;
            }
        }
        
        public override void Bind() {
            base.Bind();
            _modelTypeProperty = new P<String>(this, "modelType");
            _entityNameProperty = new P<String>(this, "entityName");
            _modelNameProperty = new P<String>(this, "modelName");
        }
        
        public override void Read(uFrame.Kernel.Serialization.ISerializerStream stream) {
            base.Read(stream);
            this.modelType = stream.DeserializeString("modelType");;
            this.entityName = stream.DeserializeString("entityName");;
            this.modelName = stream.DeserializeString("modelName");;
        }
        
        public override void Write(uFrame.Kernel.Serialization.ISerializerStream stream) {
            base.Write(stream);
            stream.SerializeString("modelType", this.modelType);
            stream.SerializeString("entityName", this.entityName);
            stream.SerializeString("modelName", this.modelName);
        }
        
        protected override void FillCommands(System.Collections.Generic.List<uFrame.MVVM.ViewModels.ViewModelCommandInfo> list) {
            base.FillCommands(list);
        }
        
        protected override void FillProperties(System.Collections.Generic.List<uFrame.MVVM.ViewModels.ViewModelPropertyInfo> list) {
            base.FillProperties(list);
            // PropertiesChildItem
            list.Add(new ViewModelPropertyInfo(_modelTypeProperty, false, false, false, false));
            // PropertiesChildItem
            list.Add(new ViewModelPropertyInfo(_entityNameProperty, false, false, false, false));
            // PropertiesChildItem
            list.Add(new ViewModelPropertyInfo(_modelNameProperty, false, false, false, false));
        }
    }
    
    public partial class EntityCommonViewModel {
        
        public EntityCommonViewModel(uFrame.Kernel.IEventAggregator aggregator) : 
                base(aggregator) {
        }
    }
}