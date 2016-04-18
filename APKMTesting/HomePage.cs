using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APKMFrame
{
    public class HomePage : Pages
    {
        protected override string Address { get; } = "http://ams.authoritypartners.com:44303/";

        protected override string Title { get; } = "API Management System";
    }
}
