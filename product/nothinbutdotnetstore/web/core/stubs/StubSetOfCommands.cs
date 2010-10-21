using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.web.application;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubSetOfCommands : IEnumerable<WebCommand>
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<WebCommand> GetEnumerator()
        {

            yield return new DefaultWebCommand(x=> x.Url.EndsWith("Departments.Store"),
                                               new ViewMainDeparmentsInTheStore());

            yield return new DefaultWebCommand(x => x.Url.Contains("Departments.Store") && x.QueryString.Any(),
                                               new ViewDepartmentsInDepartment());


            yield return new DefaultWebCommand(x => x.Url.Contains("?"),
                                               new ViewDepartmentsInDepartment());

             //yield return new DefaultWebCommand(x => x.Url.Contains("Departartments/AllDepartments.Store"),
             //                                  new ViewProductsInADepartment());
        
        }
    }
}