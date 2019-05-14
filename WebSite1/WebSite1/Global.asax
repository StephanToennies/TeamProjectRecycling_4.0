﻿<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition { 
        Path="~/App_Data/Scripts/jquery-3.3.1.js"
        });

    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code, der beim Herunterfahren der Anwendung ausgeführt wird

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code, der ausgeführt wird, wenn ein nicht behandelter Fehler auftritt

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code, der ausgeführt wird, wenn eine neue Sitzung gestartet wird

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code, der ausgeführt wird, wenn eine Sitzung beendet wird. 
        // Hinweis: Das Ereignis "Session_End" wird nur ausgelöst, wenn der Modus "sessionstate"
        // in der Datei "Web.config" auf "InProc" festgelegt ist. Wenn der Sitzungsmodus auf "StateServer" 
        // oder "SQLServer" festgelegt ist, wird das Ereignis nicht ausgelöst.

    }

</script>
