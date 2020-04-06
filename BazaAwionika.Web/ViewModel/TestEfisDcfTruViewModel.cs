using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BazaAwionika.Web.ViewModel
{
    public class TestEfisDcfTruViewModel
    {
        public IEnumerable<TestEfisViewModel> TestEfisViewModel { get; set; }
        public IEnumerable<TestDcfViewModel> TestDcfViewModel { get; set; }

        public IEnumerable<TestTruViewModel> TestTruViewModel { get; set; }
    }
}