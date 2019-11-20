
namespace MySeleniumProject
{
    public static class TestConfig
    {
        // Enum for holding possible browser type values
        public enum BrowserType { Chrome, Firefox };
        // This is where test configuration starts
        public static BrowserType BrowserForTesting = BrowserType.Chrome;
    }
}
