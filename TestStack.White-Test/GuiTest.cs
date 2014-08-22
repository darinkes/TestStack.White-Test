using System;
using System.IO;
using System.Reflection;
using Castle.Core.Logging;
using NUnit.Framework;
using TestStack.White.Configuration;
using TestStack.White.Factory;
using TestStack.White.ScreenObjects.Services;
using TestStack.White.ScreenObjects.Sessions;

namespace TestStack.White_Test
{
    class GuiTest : UITestBase
    {
        private static readonly ILogger Logger = CoreAppXmlConfiguration.Instance.LoggerFactory.Create(typeof(GuiTest));

        private WorkConfiguration _workConfiguration;

        [TestFixtureSetUp]
        public void Init()
        {
            Logger.Info("Running Init");
        }

        [SetUp]
        public void BeforeTest()
        {
            Logger.Info("BeforeTest");

            _workConfiguration = new WorkConfiguration
            {
                ArchiveLocation = new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)).LocalPath,
                Name = "TestStack.White-Test.App"
            };
            Assert.IsNotNull(_workConfiguration);

            Logger.Info("Location: " + _workConfiguration.ArchiveLocation);
        }

        [TearDown]
        public void AfterTest()
        {
            Logger.Info("AfterTest");
        }

        [Test]
        public void FullRun()
        {
            using (var workSession = new WorkSession(_workConfiguration, new NullWorkEnvironment()))
            {
                var screenRepository = workSession.Attach(Application);
                var mainWindow = screenRepository.Get<MainWindow>("MainWindow", InitializeOption.NoCache);
                Assert.IsNotNull(mainWindow);
            }
        }


    }
}
