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

                string criteria = Request.Query["temp"].Value;

                DBRepositoryProvider repoProvider = new DBRepositoryProvider(Utilities.GetConnectionStringFromConfiguration());
                DBRepository.DBRepository dbRepo = repoProvider.GetRepository();
                List<Location> result = dbRepo.GetLocationsForAutocomplete(criteria);

                return Response.AsJson(result);
            };
        }
    }
}