using System;

namespace PublishSubscribePatternSample.Handlers
{
    public interface IHandler
    {
        /// <summary>
        /// Method integral to the Strategy Pattern, it checks if a particular handler can handle the supplied data
        /// </summary>
        /// <param name="e"> Since we use polymorphism we supply the base EventArgs type and in the Handle Method we can see if it's one of the specific types</param>
        /// <returns></returns>
        bool CanHandle(EventArgs e);

        /// <summary>
        /// Executes the desired logic within the selected handler
        /// </summary>
        /// <param name="e">Event content that fit the handler</param>
        void Handle(EventArgs e);
    }
}