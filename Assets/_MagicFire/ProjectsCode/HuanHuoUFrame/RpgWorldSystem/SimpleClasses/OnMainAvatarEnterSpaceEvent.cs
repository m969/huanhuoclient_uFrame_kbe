﻿namespace MagicFire.HuanHuoUFrame {
    using HuanHuoUFrame;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.Json;
    using uFrame.Kernel;
    using uFrame.Kernel.Serialization;
    using uFrame.MVVM;
    using uFrame.MVVM.Bindings;
    
    
    public partial class OnMainAvatarEnterSpaceEvent : OnMainAvatarEnterSpaceEventBase {
        public OnMainAvatarEnterSpaceEvent(int SpaceId, string SpaceName)
        {
            this.SpaceId = SpaceId;
            this.SpaceName = SpaceName;
        }
    }
}
