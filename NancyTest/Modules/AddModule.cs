using Nancy;
using Nancy.ModelBinding;
using NancyTest.DBRepository;
using NancyTest.Models;
using System.Collections.Generic;

namespace NancyTest.Modules
{
    public class IndexModule : Nancy.NancyModule
    {
        public IndexModule()
        {
            Get["/"] = parameters =>
            {
                var model = new Location();

                return View["index.html", model];
            };

            Post["/addLocation"] = parameters =>
            {
                //TODO: validation
                var location = this.Bind<Location>();
                new ModelFactory().AddLocation(location);

                return Response.AsRedirect("/");
            };
        }
    }
}