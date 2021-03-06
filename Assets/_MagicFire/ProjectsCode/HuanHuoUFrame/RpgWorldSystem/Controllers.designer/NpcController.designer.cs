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
    
    
    public class NpcControllerBase : EntityCommonController {
        
        private uFrame.MVVM.ViewModels.IViewModelManager<NpcViewModel> _NpcViewModelManager;
        
        [uFrame.IOC.InjectAttribute("Npc")]
        public uFrame.MVVM.ViewModels.IViewModelManager<NpcViewModel> NpcViewModelManager {
            get {
                return _NpcViewModelManager;
            }
            set {
                _NpcViewModelManager = value;
            }
        }
        
        public IEnumerable<NpcViewModel> NpcViewModels {
            get {
                return NpcViewModelManager.ViewModels;
            }
        }
        
        public override void Setup() {
            base.Setup();
            // This is called when the controller is created
        }
        
        public override void Initialize(uFrame.MVVM.ViewModels.ViewModel viewModel) {
            base.Initialize(viewModel);
            // This is called when a viewmodel is created
            this.InitializeNpc(((NpcViewModel)(viewModel)));
        }
        
        public virtual NpcViewModel CreateNpc() {
            return ((NpcViewModel)(this.Create(Guid.NewGuid().ToString())));
        }
        
        public override uFrame.MVVM.ViewModels.ViewModel CreateEmpty() {
            return new NpcViewModel(this.EventAggregator);
        }
        
        public virtual void InitializeNpc(NpcViewModel viewModel) {
            // This is called when a NpcViewModel is created
            NpcViewModelManager.Add(viewModel);
        }
        
        public override void DisposingViewModel(uFrame.MVVM.ViewModels.ViewModel viewModel) {
            base.DisposingViewModel(viewModel);
            NpcViewModelManager.Remove(viewModel);
        }
    }
}
