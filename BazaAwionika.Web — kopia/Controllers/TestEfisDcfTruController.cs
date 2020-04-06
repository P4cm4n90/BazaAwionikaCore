using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using BazaAwionika.Model;
using BazaAwionika.Web.ViewModel;
using BazaAwionika.Services;

namespace BazaAwionika.Web.Controllers
{
    public class TestEfisDcfTruController : Controller
    {
        private readonly ITestEfisService testEfisService;
        private readonly ITestDcfService testDcfService;
        private readonly ITestTruService testTruService;
        private readonly IAircraftService aircraftService;
        private readonly IUserService userService;
        private readonly ISettingsService settingsService;

        public TestEfisDcfTruController(ITestEfisService testEfisDcfTruService, IUserService userService, ISettingsService settingsService,
            IAircraftService aircraftService, ITestTruService testTruService, ITestDcfService testDcfService)
        {
            this.testEfisService = testEfisDcfTruService;
            this.aircraftService = aircraftService;
            this.settingsService = settingsService;
            this.userService = userService;
            this.testTruService = testTruService;
            this.testDcfService = testDcfService;
        }

        // GET: TestEfisDcfTru
        public IActionResult Index()
        {
            IEnumerable<TestEfisModel> testEfisModels;
            IEnumerable<TestDcfModel> testDcfModels;
            IEnumerable<TestTruModel> testTruModels;
            TestEfisDcfTruViewModel testEfisDcfTruViewModel = new TestEfisDcfTruViewModel();
            testEfisModels = testEfisService.GetTestsEfis();
            testDcfModels = testDcfService.GetTestsDcf();
            testTruModels = testTruService.GetTestsTru();

            testEfisDcfTruViewModel.TestEfisViewModel = AutoMapperConfiguration.Mapper.Map
                <IEnumerable<TestEfisModel>,IEnumerable<TestEfisViewModel>>(testEfisModels);
            testEfisDcfTruViewModel.TestDcfViewModel = AutoMapperConfiguration.Mapper.Map
                <IEnumerable<TestDcfModel>, IEnumerable<TestDcfViewModel>>(testDcfModels);
            testEfisDcfTruViewModel.TestTruViewModel = AutoMapperConfiguration.Mapper.Map
                <IEnumerable<TestTruModel>, IEnumerable<TestTruViewModel>>(testTruModels);
            return View(testEfisDcfTruViewModel);
        }

        // GET: TestEfisDcfTru/Details/5
      

    }
}
