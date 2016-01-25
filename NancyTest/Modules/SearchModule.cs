using Nancy;
using Nancy.ModelBinding;
using NancyTest.DBRepository;
using NancyTest.Models;
using System.Collections.Generic;

namespace NancyTest.Modules
{
    public class SearchModule : Nancy.NancyModule
    {
        public SearchModule()
            : base("/search")
        {
            Get["/"] = parameters =>
            {
                var model = new Location();

                return View["index.html", model];
            };

            Get["/searchLocation"] = parameters =>
            {
                //TODO: validation
                string criteria = Request.Query["term"].Value;
                List<Location> result = new ModelFactory().SearchLocation(criteria);

                return Response.AsJson(result);
            };
        }
    }
}