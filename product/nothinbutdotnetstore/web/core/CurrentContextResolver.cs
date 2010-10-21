using System;
using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public delegate HttpContext CurrentContextResolver();
    public delegate object PageFactory(string path,Type page_type);
}