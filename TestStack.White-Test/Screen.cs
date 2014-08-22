using System;
using System.Windows.Automation;
using TestStack.White.ScreenObjects;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.Utility;

namespace TestStack.White_Test
{
    public class Screen : AppScreen
    {
        public Screen(Window window, ScreenRepository screenRepository)
            : base(window, screenRepository)
        {
        }

        public virtual void WaitWhileBusy()
        {
            Retry.For(ShellIsBusy, isBusy => isBusy, TimeSpan.FromSeconds(60));
        }

        bool ShellIsBusy()
        {
            var currentPropertyValue = Window.AutomationElement.GetCurrentPropertyValue(AutomationElement.HelpTextProperty);
            return currentPropertyValue != null && ((string)currentPropertyValue).Contains("Busy");
        }
    }
}