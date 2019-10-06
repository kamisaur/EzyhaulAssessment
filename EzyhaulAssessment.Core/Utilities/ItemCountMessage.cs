using MvvmCross.Plugin.Messenger;
using System;
using System.Collections.Generic;
using System.Text;

namespace EzyhaulAssessment.Core.Utilities
{
    class ItemCountMessage : MvxMessage
    {
        public ItemCountMessage(object sender, int count) : base(sender)
        {
            Count = count;
        }

        public int Count { get; private set; }

    }
}
