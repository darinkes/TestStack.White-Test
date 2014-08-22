using TestStack.White.ScreenObjects;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace TestStack.White_Test
{
    class MainWindow : Screen
    {
        public MainWindow(Window window, ScreenRepository screenRepository) : base(window, screenRepository)
        {
        }

        public virtual ListView ListView
        {
            get
            {
                return Window.Get<ListView>(SearchCriteria.ByAutomationId("ParentDataGrid"));
            }
        }
    }
}
