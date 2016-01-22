using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NancyTest.Models
{
    public class Location
    {
        int _id;
        float _latitude;
        float _longitude;
        string _title;
        List<string> _keywords;

        #region Constructors

        /// <summary>
        /// Creates an instance of Location.
        /// </summary>
        /// <param name="latitude">Location latitude</param>
        /// <param name="longitude">Location longitude</param>
        /// <param name="title">Location title</param>
        /// <param name="keywords">Keywords for location</param>
        public Location(float latitude, float longitude, string title, List<string> keywords)
        {
            _latitude = latitude;
            _longitude = longitude;
            _title = title;
            _keywords = keywords;
        }

        /// <summary>
        /// Creates an empty instance of Location.
        /// </summary>
        public Location()
        {

        }

        #endregion

        #region Properties

		public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public float Latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }

        public float Longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public List<string> Keywords
        {
            get { return _keywords; }
            set { _keywords = value; }
        }
 
	    #endregion    
    }
}