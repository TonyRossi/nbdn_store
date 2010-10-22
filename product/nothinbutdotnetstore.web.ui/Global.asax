<%@ Application Language="C#" %>
<%@ Import Namespace="nothinbutdotnetstore.tasks.startup" %>
<script runat="server">

        private void Application_Start(object sender, EventArgs e)
        {
          Startup.start_the_application();
        }


</script>
