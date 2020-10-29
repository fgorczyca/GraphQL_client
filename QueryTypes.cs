using System;
using System.Collections.Generic;

namespace graphqlclient
{
    public class ResponseType
    {
        public PersonType Person { get; set; }
    }

    public class PersonType
    {
        public string Name { get; set; }
        public FilmConnectionType FilmConnection { get; set; }
    }

    public class FilmConnectionType
    {
        public List<FilmContentType> Films { get; set; }
    }

    public class FilmContentType
    {
        public string Title { get; set; }
    }
}