Swagger.Net
===========

Library to document the ASP.NET Web API using the Swagger specification

Latest version: 0.5

Introduction
------------

Swagger.Net will expose any apis the inherit from the ApiController in the new ASP.NET Web API.

Swagger UI is not included.  Just point your instance of Swagger UI at http://YOUR_URL/api/swagger to expose all of the APIs that you have built.  

Swagger.Net uses a combination of the Web API ApiExplorer class and XML Documentation you write in your /// blocks.

One article that helped me tremendously: [Generating a Web API using ApiExplorer] (http://blogs.msdn.com/b/yaohuang1/archive/2012/05/21/asp-net-web-api-generating-a-web-api-help-page-using-apiexplorer.aspx).

Requirements
------------

+ ASP.NET MVC 4.0
+ .NET 4.0 or 4.5

Setup
-----

1. Clone the branch labled for the version you wish, build and reference.
2. Nuget: I am currently working on this and it is incomplete.  COMING SOON.

Configuration
-------------
1. Enable "XML Documentation File" and specify a value (i.e. App_Data\Docs.XML) in the Web API's properties | Build menu (Alt+Enter). You will use this in step 3. Do not put a ~ in the value path (see step 3).
2. Add the following route to your route config (I added it first):

            routes.MapHttpRoute(
                name: "SwaggerApi",
                routeTemplate: "api/docs/{controller}",
                defaults: new { swagger = true }
            );

3. Add the following method to `Global.asax.cs`:

        private void Configure_Swagger()
        {
            var config = GlobalConfiguration.Configuration;

            config.Filters.Add(new SwaggerActionFilter());
            config.Services.Replace(typeof(IDocumentationProvider),
                new XmlCommentDocumentationProvider(HttpContext.Current.Server.MapPath("~/App_Data/YOUR_XML_FILE_HERE")));
            config.Services.Add(typeof(IAssembliesResolver),
                new SwaggerResolver());
        }

4. Call the `Configure_Swagger()` from `Application_Start()`
5. Optional: If you wish to see the JSON easily from the browser and you don't care about xml Accept headers, then add the following to your `Configure_Swagger()`:

            var xmlFormatter = config.Formatters
              .Where(f =>
              {
                  return f.SupportedMediaTypes.Any(v => v.MediaType == "text/xml");
              })
              .FirstOrDefault();

            if (xmlFormatter != null)
            {
                config.Formatters.Remove(xmlFormatter);
            }

Dependencies
------------
+ Newtonsoft JSON library (Will be shipping with the MVC 4 project templates)

Known Issues
------------

I'm hoping you will help me find these.

+ The version of Swagger UI I have built in the /docs folder DOES NOT WORK in Internet Exlorer.  :-(


Other Thoughts
--------------

I dropped the Swagger UI directly on the root in a folder called docs, then redirected the index action to /docs.  I also edited the index.html file to point it directly at /api/swagger so it can traverse the documentation.  The Swagger UI that I installed I got from the [GitHub Repo Here](https://github.com/wordnik/swagger-ui/tree/master/dist)

I have built this library with the lastest/prerelease versions of everything .NET.  (VS 2012 RC, .NET 4.5 RC, etc.)

Improvements
-----------------

Create a fork of [Swagger.Net](https://github.com/miketrionfo/Swagger.Net)

Did you change it? [Submit a pull request](https://github.com/miketrionfo/Swagger.Net/pull/new/master).

License
-------

Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
