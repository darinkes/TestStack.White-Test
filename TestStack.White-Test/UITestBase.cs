using System;
using TestStack.White;

namespace TestStack.White_Test
{
    public abstract class UITestBase : IDisposable
    {
        public Application Application { get; private set; }

        protected UITestBase()
        {
            Application = Application.Launch(@"TestStack.White-Test.App.exe");
        }

        public void Dispose()
        {
            Application.Dispose();
        }
    }
}
