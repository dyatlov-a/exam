using System.Web.Mvc;

namespace Exam.UI.Infrastructure
{
    public static class vEngine
    {
        public static void Init()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}