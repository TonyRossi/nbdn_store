using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nothinbutdotnetstore.domain;
using nothinbutdotnetstore.domain.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.specs.web
{
    public class ViewDepartmentsInDepartment : ApplicationCommand
    {
        DepartmentRepository department_repository;
        ResponseEngine response_engine;

        public ViewDepartmentsInDepartment()
            : this(new StubDepartmentRepository(),
                new StubResponseEngine())
        {
        }

        public ViewDepartmentsInDepartment(DepartmentRepository department_repository, ResponseEngine response_engine)
        {
            this.department_repository = department_repository;
            this.response_engine = response_engine;
        }

        public void process(Request request)
        {
            response_engine.display(department_repository.get_the_departments_in(request.map<Department>()));
        }
    }
}
