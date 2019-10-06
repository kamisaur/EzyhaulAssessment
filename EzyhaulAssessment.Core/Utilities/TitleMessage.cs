using MvvmCross.Plugin.Messenger;
using System;
using System.Collections.Generic;
using System.Text;

namespace EzyhaulAssessment.Core.Utilities
{
    class TitleMessage : MvxMessage
    {
        public TitleMessage(object sender, string title) 
            : base(sender)
        {
            Title = title;
        }

        public string Title { get; private set; }

    }
}
