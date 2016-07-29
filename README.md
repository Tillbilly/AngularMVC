# AngularMVC
==========

This is a newb skill up project demonstrating ASP.Net MVC, Web API 2, Angular js

## Current endpoints
=================  
/Angular/TestApp  -  The Angular hello world

/api/Sfia         - Baseline SFIA data

------------------------------------------


Web Publish failing - complaining about chunked encoding - turn it on for IIS 8

cd %windir%\system32\inetsrv

appcmd set config /section:asp /enableChunkedEncoding:True


