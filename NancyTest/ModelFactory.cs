using NancyTest.DBRepository;
using NancyTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NancyTest
{
    public class ModelFactory
    {
        private DBRepository.DBRepository dbRepo;

        public ModelFactory()
        {
            DBRepositoryProvider repoProvider = new DBRepositoryProvider(Utilities.GetConnectionStringFromConfiguration());
            dbRepo = repoProvider.GetRepository();
        }

        public void AddLocation(Location location)
        {
            dbRepo.InsertLocation(location);
        }

        public List<Location> SearchLocation(string criteria)
        {
            return dbRepo.GetLocationsForAutocomplete(criteria);
        }
    }
}