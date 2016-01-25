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
                var location = this.Bind<Location>();

                DBRepositoryProvider repoProvider = new DBRepositoryProvider(Utilities.GetConnectionStringFromConfiguration());
                DBRepository.DBRepository dbRepo = repoProvider.GetRepository();
                dbRepo.InsertLocation(location);

                return Response.AsRedirect("/");
            };
        }
    }
}