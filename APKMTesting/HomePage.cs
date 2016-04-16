using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APKMFrame
{
    public class HomePage : Pages
    {
        public override string Address { get; } = "http://ams.authoritypartners.com:44303/";

        public override string Title { get; } = "API Management System";
    }
}
