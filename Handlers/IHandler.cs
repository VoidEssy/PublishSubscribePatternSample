using System;
using System.Collections.Generic;
using System.Text;

namespace PublishSubscribePatternSample.Handlers
{
    public interface IHandler
    {
        bool CanHandle(EventArgs e);
        void Handle(EventArgs e);
    }
}
