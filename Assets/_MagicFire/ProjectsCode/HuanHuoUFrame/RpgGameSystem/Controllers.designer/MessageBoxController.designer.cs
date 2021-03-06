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
    
    
    public class MessageBoxControllerBase : uFrame.MVVM.Controller {
        
        private uFrame.MVVM.ViewModels.IViewModelManager<MessageBoxViewModel> _MessageBoxViewModelManager;
        
        private MessageBoxViewModel _MessageBox;
        
        private UserLoginScreenViewModel _UserLoginScreen;
        
        private RpgMainScreenViewModel _RpgMainScreen;
        
        [uFrame.IOC.InjectAttribute("MessageBox")]
        public uFrame.MVVM.ViewModels.IViewModelManager<MessageBoxViewModel> MessageBoxViewModelManager {
            get {
                return _MessageBoxViewModelManager;
            }
            set {
                _MessageBoxViewModelManager = value;
            }
        }
        
        [uFrame.IOC.InjectAttribute("MessageBox")]
        public MessageBoxViewModel MessageBox {
            get {
                return _MessageBox;
            }
            set {
                _MessageBox = value;
            }
        }
        
        [uFrame.IOC.InjectAttribute("UserLoginScreen")]
        public UserLoginScreenViewModel UserLoginScreen {
            get {
                return _UserLoginScreen;
            }
            set {
                _UserLoginScreen = value;
            }
        }
        
        [uFrame.IOC.InjectAttribute("RpgMainScreen")]
        public RpgMainScreenViewModel RpgMainScreen {
            get {
                return _RpgMainScreen;
            }
            set {
                _RpgMainScreen = value;
            }
        }
        
        public IEnumerable<MessageBoxViewModel> MessageBoxViewModels {
            get {
                return MessageBoxViewModelManager.ViewModels;
            }
        }
        
        public override void Setup() {
            base.Setup();
            // This is called when the controller is created
        }
        
        public override void Initialize(uFrame.MVVM.ViewModels.ViewModel viewModel) {
            base.Initialize(viewModel);
            // This is called when a viewmodel is created
            this.InitializeMessageBox(((MessageBoxViewModel)(viewModel)));
        }
        
        public virtual MessageBoxViewModel CreateMessageBox() {
            return ((MessageBoxViewModel)(this.Create(Guid.NewGuid().ToString())));
        }
        
        public override uFrame.MVVM.ViewModels.ViewModel CreateEmpty() {
            return new MessageBoxViewModel(this.EventAggregator);
        }
        
        public virtual void InitializeMessageBox(MessageBoxViewModel viewModel) {
            // This is called when a MessageBoxViewModel is created
            viewModel.ShowMessage.Action = this.ShowMessageHandler;
            viewModel.CloseMessage.Action = this.CloseMessageHandler;
            MessageBoxViewModelManager.Add(viewModel);
        }
        
        public override void DisposingViewModel(uFrame.MVVM.ViewModels.ViewModel viewModel) {
            base.DisposingViewModel(viewModel);
            MessageBoxViewModelManager.Remove(viewModel);
        }
        
        public virtual void ShowMessageHandler(ShowMessageCommand command) {
            this.ShowMessage(command.Sender as MessageBoxViewModel, command);
        }
        
        public virtual void CloseMessageHandler(CloseMessageCommand command) {
            this.CloseMessage(command.Sender as MessageBoxViewModel, command);
        }
        
        public virtual void ShowMessage(MessageBoxViewModel viewModel, ShowMessageCommand arg) {
        }
        
        public virtual void CloseMessage(MessageBoxViewModel viewModel, CloseMessageCommand arg) {
        }
    }
}
